using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfAkuSQLiteHome.Models.Calculator
{
    public class CalculatorLogic
    {
        private DateTime GivenDate { get; set; }
        private DatabaseTablesCollection DatabaseTablesCollection { get; set; }
        private CalculatorOutput CalculatorOutput { get; set; }

        public CalculatorLogic()
        {
           
        }

        private int YearSteamKey = 0;
        private int YearBranchKey = 0;
        private int monthNumber = 0;
        private int DaySteamKey = 0;
        private string Division;
        private int DayAdjustemntNumber =0;
        private int DaysBetweenGivenDateAnd1904 = 0;

        public CalculatorOutput CalculateOutput(DateTime givenDate, DatabaseTablesCollection databaseTablesCollection)
        {
            this.GivenDate = givenDate;
            this.DatabaseTablesCollection = databaseTablesCollection;
            this.CalculatorOutput = new CalculatorOutput();
            YearCalculation();
            MonthCalculation();
            DayCalculation();
            HourCalculation();
            DivisionCalculation();
            CorrectiveEnergyCalculation();
            SeasonCalculation(givenDate);
            ForbiddenCalculation();
            HsiuCalculation();

            return CalculatorOutput;
        }

        private void HsiuCalculation()
        {
            int hsiuKey;
            int daysMinus19 = DaysBetweenGivenDateAnd1904 - 19;
            int restFromDivision = daysMinus19 % 28;
            if (restFromDivision ==0)
            {
                hsiuKey = 28;
            }
            else
            {
                hsiuKey = restFromDivision;
            }
            CalculatorOutput.AdditionalInfo.Hsiu.Animal = DatabaseTablesCollection.hsiuTable[hsiuKey - 1].Animal;
            CalculatorOutput.AdditionalInfo.Hsiu.Direction = DatabaseTablesCollection.hsiuTable[hsiuKey - 1].Direction;
            CalculatorOutput.AdditionalInfo.Hsiu.Element = DatabaseTablesCollection.hsiuTable[hsiuKey - 1].Element;
            CalculatorOutput.AdditionalInfo.Hsiu.Planet = DatabaseTablesCollection.hsiuTable[hsiuKey - 1].Planet;
            CalculatorOutput.AdditionalInfo.Hsiu.Elts = DatabaseTablesCollection.hsiuTable[hsiuKey - 1].Elts;
            CalculatorOutput.AdditionalInfo.Hsiu.Points = DatabaseTablesCollection.hsiuTable[hsiuKey - 1].Rest;
        }


        private void ForbiddenCalculation()
        {
            int forbiddenKey = DayAdjustemntNumber;
            CalculatorOutput.AdditionalInfo.ForbiddenMeridians1 = DatabaseTablesCollection.dayTables[forbiddenKey - 1].Symbol1;
            CalculatorOutput.AdditionalInfo.ForbiddenMeridians2 = DatabaseTablesCollection.dayTables[forbiddenKey - 1].Symbol2;
            CalculatorOutput.AdditionalInfo.ForbiddenRegion = DatabaseTablesCollection.dayTables[forbiddenKey - 1].Rest;
        }

        private void SeasonCalculation(DateTime givenDate)
        {
            int day = givenDate.Day;
            int month = givenDate.Month;
            List<int> MontTable = new List<int> { 0,1,2,4,5,7,8,10,11 };

            var query = MontTable.Where(n => n < 3);
            var LastElement = query.Last();
            int seasonKey = MontTable.IndexOf(LastElement) + 1;
            int[] DayArray = { 0,18,5,18,6,21,8,21,8 };
            int relevantDay = DayArray[seasonKey - 1];
            int relevantMonth = MontTable[seasonKey - 1];
            int adjustedKey;
            if (month > relevantMonth)
            {
                adjustedKey = seasonKey;
            }
            else
            {
                if (day<relevantDay)
                {
                    adjustedKey = seasonKey - 1;
                }
                else
                {
                    adjustedKey = seasonKey;
                }
            }
            string[] SeasonArray = { "Winter", "Winter (Earth)", "Spring", "Spring (Earth)", "Summer", "Summer (Earth)", "Autumn", "Autumn (Earth)","Winter" };
            string[] ForbiddenArray = { "3 leg yin left", "3 leg yin left", "3 leg yang left", "3 leg yang left","3 leg yang right","3 leg yang right","3 leg yin right","3 leg yin right","3 leg yin left" };
            CalculatorOutput.AdditionalInfo.Season = SeasonArray[adjustedKey - 1];
            CalculatorOutput.AdditionalInfo.Forbidden = ForbiddenArray[adjustedKey - 1];
        }

        private void CorrectiveEnergyCalculation()
        {
            int correctionKey = YearBranchKey%6;
            if (correctionKey == 0)
                correctionKey = 6;
            string[] CorrectionKeyArray = { "Fire M.", "Earth", "Fire P.", "Metal", "Water", "Wood" };
            CalculatorOutput.AdditionalInfo.CorrectiveEnergy = CorrectionKeyArray[correctionKey - 1];
        }

        private void DivisionCalculation()
        {
            int _monthNumber = monthNumber;
            int _branchKey = YearBranchKey;
            if (_monthNumber > 6)
            {
                _branchKey = _branchKey + 3;
            }
            int divisionKey = _branchKey % 6;
            if (divisionKey==0)
            {
                divisionKey = 6;
            }
            string[] divisionsArray = { "Shao Yin", "Tai Yin", "Shao Yang", "Yang Ming", "Tai Yang", "Jue Yin" };
            Division = divisionsArray[divisionKey - 1];
            AssignDivisionCalculatorOutput();
        }

        private void YearCalculation()
        {
            int year = int.Parse(GivenDate.Year.ToString());
            int YearkeyNo = year - 1923;
            YearSteamKey = YearkeyNo % 10 == 0 ? 10 : YearkeyNo % 10;
            YearBranchKey = YearkeyNo % 12 == 0 ? 12 : YearkeyNo % 12;
            AssignYearCalculatorOutput(YearBranchKey);
        }

        private void MonthCalculation()
        {
            monthNumber = GetMonthNumber();
            int MonthSteamKey = ((2 * (YearSteamKey % 5)) + monthNumber) % 10 == 0 ? 10 : ((2 * (YearSteamKey % 5)) + monthNumber) % 10;
            int MontBranchKey = (monthNumber + 14) % 12 == 0 ? 12 : (monthNumber + 14) % 12;
            AssignMonthCalculatorOutput(MonthSteamKey, MontBranchKey);
        }

        private void DayCalculation()
        {
            var betweenDatesDays = (GivenDate - Convert.ToDateTime("01/01/1904")).TotalDays;
            int days = Convert.ToInt32(betweenDatesDays);
            DaysBetweenGivenDateAnd1904 = days;
            int keyNumber = (days - 29) % 60 == 0 ? 60 : (days - 29) % 60;
            DayAdjustemntNumber = keyNumber == 13 ? keyNumber + 1 : keyNumber;
            int steamKey = DayAdjustemntNumber % 10 == 0 ? 10 : DayAdjustemntNumber % 10;
            int branchKey = DayAdjustemntNumber % 12 == 0 ? 12 : DayAdjustemntNumber % 12;
            DaySteamKey = steamKey;
            AssignDayCalculatorOutput(steamKey, branchKey);
        }

        private void HourCalculation()
        {
            int hourNumber = GetHourNumber();
            hourNumber = hourNumber == 13 ? 1 : hourNumber;
            int steamKey = (((DaySteamKey % 5) * 2) + (hourNumber - 2)) % 10;
            steamKey = steamKey == 0 ? 10 : steamKey;
            int branchKey = hourNumber;
            AssignHourCalculatorOutput(steamKey, branchKey);
        }


        private int GetHourNumber()
        {
            int hourNumber = 0;
            int hour = int.Parse(GivenDate.Hour.ToString());
            int[] hours = { 0, 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 24 };
            foreach (var item in hours)
            {
                if (hour < item)
                {
                    hourNumber = Array.FindIndex(hours, x => x == item);
                    break;
                }
                else
                {

                }
            }
            return hourNumber;
        }

        private int GetMonthNumber()
        {
            int index = int.Parse(GivenDate.Year.ToString()) - 1925;
            Regex ex = new Regex(@"(?<day>\d{2})\.(?<month>\d{2})");
            List<DateTime> DateList = new List<DateTime>();
            var tab = DatabaseTablesCollection.yearTable[index];
            string[] dates = { tab.P1, tab.P2, tab.P3, tab.P4, tab.P5, tab.P6, tab.P7, tab.P8, tab.P9, tab.P10, tab.P11, tab.P12 };
            foreach (var item in dates)
            {
                Match m = ex.Match(item);
                if (m.Success)
                {
                    int month = int.Parse(m.Groups["month"].Value);
                    int day = int.Parse(m.Groups["day"].Value);
                    DateTime dt = new DateTime(int.Parse(GivenDate.Year.ToString()), month, day);
                    DateList.Add(dt);
                }
            }

            int counter = 0;
            int monthNumber = 0;
            foreach (var item in DateList)
            {
                if (GivenDate < item)
                {
                    monthNumber = counter;
                    continue;
                }
                counter++;
            }
            return monthNumber;
        }

        private void AssignYearCalculatorOutput(int YearBranchKey)
        {
            CalculatorOutput.Year.GMColour = GetColor(DatabaseTablesCollection.stemsTable[YearSteamKey - 1].GMColour);
            CalculatorOutput.Year.Steam.ChineseSign = DatabaseTablesCollection.stemsTable[YearSteamKey - 1].StemsSymbol1;
            CalculatorOutput.Year.Steam.ChineseString = DatabaseTablesCollection.stemsTable[YearSteamKey - 1].StemsSymbol2;
            CalculatorOutput.Year.Steam.EnglishString = DatabaseTablesCollection.stemsTable[YearSteamKey - 1].StemsSymbol3;
            CalculatorOutput.Year.Steam.Colour = GetColor(DatabaseTablesCollection.stemsTable[YearSteamKey - 1].StemColour);
            CalculatorOutput.Year.Branch.ChineseSign = DatabaseTablesCollection.branchTables[YearBranchKey - 1].Symbol1;
            CalculatorOutput.Year.Branch.ChineseString = DatabaseTablesCollection.branchTables[YearBranchKey - 1].Symbol2;
            CalculatorOutput.Year.Branch.EnglishString = DatabaseTablesCollection.branchTables[YearBranchKey - 1].Symbol3;
            CalculatorOutput.Year.Branch.Colour = GetColor(DatabaseTablesCollection.branchTables[YearBranchKey - 1].Colour);
            CalculatorOutput.Year.BelowRowTable = DatabaseTablesCollection.branchTables[YearBranchKey - 1].BelowTableRow;
        }


        private void AssignMonthCalculatorOutput(int MonthSteamKey, int MontBranchKey)
        {
            CalculatorOutput.Month.GMColour = GetColor(DatabaseTablesCollection.stemsTable[MonthSteamKey - 1].GMColour);
            CalculatorOutput.Month.Steam.ChineseSign = DatabaseTablesCollection.stemsTable[MonthSteamKey - 1].StemsSymbol1;
            CalculatorOutput.Month.Steam.ChineseString = DatabaseTablesCollection.stemsTable[MonthSteamKey - 1].StemsSymbol2;
            CalculatorOutput.Month.Steam.EnglishString = DatabaseTablesCollection.stemsTable[MonthSteamKey - 1].StemsSymbol3;
            CalculatorOutput.Month.Steam.Colour = GetColor(DatabaseTablesCollection.stemsTable[MonthSteamKey - 1].StemColour);
            CalculatorOutput.Month.Branch.ChineseSign = DatabaseTablesCollection.branchTables[MontBranchKey - 1].Symbol1;
            CalculatorOutput.Month.Branch.ChineseString = DatabaseTablesCollection.branchTables[MontBranchKey - 1].Symbol2;
            CalculatorOutput.Month.Branch.EnglishString = DatabaseTablesCollection.branchTables[MontBranchKey - 1].Symbol3;
            CalculatorOutput.Month.Branch.Colour = GetColor(DatabaseTablesCollection.branchTables[MontBranchKey - 1].Colour);
            CalculatorOutput.Month.BelowRowTable = DatabaseTablesCollection.branchTables[MontBranchKey - 1].BelowTableRow;
        }

        private void AssignDayCalculatorOutput(int steamKey, int branchKey)
        {
            CalculatorOutput.Day.GMColour = GetColor(DatabaseTablesCollection.stemsTable[steamKey - 1].GMColour);
            CalculatorOutput.Day.Steam.ChineseSign = DatabaseTablesCollection.stemsTable[steamKey - 1].StemsSymbol1;
            CalculatorOutput.Day.Steam.ChineseString = DatabaseTablesCollection.stemsTable[steamKey - 1].StemsSymbol2;
            CalculatorOutput.Day.Steam.EnglishString = DatabaseTablesCollection.stemsTable[steamKey - 1].StemsSymbol3;
            CalculatorOutput.Day.Steam.Colour = GetColor(DatabaseTablesCollection.stemsTable[steamKey - 1].StemColour);
            CalculatorOutput.Day.Branch.ChineseSign = DatabaseTablesCollection.branchTables[branchKey - 1].Symbol1;
            CalculatorOutput.Day.Branch.ChineseString = DatabaseTablesCollection.branchTables[branchKey - 1].Symbol2;
            CalculatorOutput.Day.Branch.EnglishString = DatabaseTablesCollection.branchTables[branchKey - 1].Symbol3;
            CalculatorOutput.Day.Branch.Colour = GetColor(DatabaseTablesCollection.branchTables[branchKey - 1].Colour);
            CalculatorOutput.Day.BelowRowTable = DatabaseTablesCollection.branchTables[branchKey - 1].BelowTableRow;
        }

        private void AssignHourCalculatorOutput(int steamKey, int branchKey)
        {
            CalculatorOutput.Hour.GMColour = GetColor(DatabaseTablesCollection.stemsTable[steamKey - 1].GMColour);
            CalculatorOutput.Hour.Steam.ChineseSign = DatabaseTablesCollection.stemsTable[steamKey - 1].StemsSymbol1;
            CalculatorOutput.Hour.Steam.ChineseString = DatabaseTablesCollection.stemsTable[steamKey - 1].StemsSymbol2;
            CalculatorOutput.Hour.Steam.EnglishString = DatabaseTablesCollection.stemsTable[steamKey - 1].StemsSymbol3;
            CalculatorOutput.Hour.Steam.Colour = GetColor(DatabaseTablesCollection.stemsTable[steamKey - 1].StemColour);
            CalculatorOutput.Hour.Branch.ChineseSign = DatabaseTablesCollection.branchTables[branchKey - 1].Symbol1;
            CalculatorOutput.Hour.Branch.ChineseString = DatabaseTablesCollection.branchTables[branchKey - 1].Symbol2;
            CalculatorOutput.Hour.Branch.EnglishString = DatabaseTablesCollection.branchTables[branchKey - 1].Symbol3;
            CalculatorOutput.Hour.Branch.Colour = GetColor(DatabaseTablesCollection.branchTables[branchKey - 1].Colour);
            CalculatorOutput.Hour.BelowRowTable = DatabaseTablesCollection.branchTables[branchKey - 1].BelowTableRow;
        }

        private void AssignDivisionCalculatorOutput()
        {
            CalculatorOutput.AdditionalInfo.Division = Division;
        }




        private SolidColorBrush GetColor(string color)
        {
            switch (color)
            {
                case "green":
                    return Brushes.LightGreen;
                case "red":
                    return Brushes.Red;
                case "yellow":
                    return Brushes.Yellow;
                case "blue":
                    return Brushes.Blue;
                case "white":
                    return Brushes.White;
                default:
                    return Brushes.LightGreen;
            }
        }
    }
}
