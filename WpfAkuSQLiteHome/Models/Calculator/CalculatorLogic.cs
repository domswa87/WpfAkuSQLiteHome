using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfAkuSQLite.Models;

namespace WpfAkuSQLiteHome.Models.Calculator
{
    public class CalculatorLogic
    {
        public FinalOutput finalOutput { get; set; }
        public DateTime GivenDate { get; set; }



        private int YearSteamKey = 0;
        private int YearBranchKey = 0;
        private int monthNumber = 0;
        private int DaySteamKey = 0;
        DateTime givenDate;
        public List<BranchTable> branchTables { get; set; } = new List<BranchTable>();
        public List<DayTable> dayTables { get; set; } = new List<DayTable>();
        public List<DivisionTable> divisionTable { get; set; } = new List<DivisionTable>();
        public List<HsiuTable> hsiuTable { get; set; } = new List<HsiuTable>();
        public List<SeasonTable> seasonTable { get; set; } = new List<SeasonTable>();
        public List<StemsTable> stemsTable { get; set; } = new List<StemsTable>();
        public List<YearTable> yearTable { get; set; } = new List<YearTable>();

        public CalculatorLogic(FinalOutput finalOutput, DateTime givenDate)
        {
            this.finalOutput = finalOutput;
            this.GivenDate = givenDate;
        }

        public void LoadData(DateTime givenDate)
        {
            branchTables = DataAccessClass.LoadBranchTable();
            dayTables = DataAccessClass.LoadDayTable();
            divisionTable = DataAccessClass.LoadDivisionTable();
            hsiuTable = DataAccessClass.LoadHsiuTable();
            seasonTable = DataAccessClass.LoadSeasonTable();
            stemsTable = DataAccessClass.LoadStemsTable();
            yearTable = DataAccessClass.LoadYearTable();
            this.givenDate = givenDate;
           

            YearCalculation();
            MonthCalculation();
            DayCalculation();
            HourCalculation();
        }

        private void YearCalculation()
        {
            int year = int.Parse(GivenDate.Year.ToString());
            int YearkeyNo = year - 1923;
            YearSteamKey = YearkeyNo % 10 == 0 ? 10 : YearkeyNo % 10;
            YearBranchKey = YearkeyNo % 12 == 0 ? 12 : YearkeyNo % 12;

            AssignYearFinalOutput(YearBranchKey);
        }

        private void MonthCalculation()
        {
            monthNumber = GetMonthNumber();
            int MonthSteamKey = ((2 * (YearSteamKey % 5)) + monthNumber) % 10 == 0 ? 10 : ((2 * (YearSteamKey % 5)) + monthNumber) % 10;
            int MontBranchKey = (monthNumber + 14) % 12 == 0 ? 12 : (monthNumber + 14) % 12;

            AssignMonthFinalOutput(MonthSteamKey, MontBranchKey);
        }

        private void DayCalculation()
        {

            var betweenDatesDays = (givenDate - Convert.ToDateTime("01/01/1904")).TotalDays;
            int days = Convert.ToInt32(betweenDatesDays);
            int keyNumber = (days - 29) % 60 == 0 ? 60 : (days - 29) % 60;
            int adjustedNumber = keyNumber == 13 ? keyNumber + 1 : keyNumber;
            int steamKey = adjustedNumber % 10 == 0 ? 10 : adjustedNumber % 10;
            int branchKey = adjustedNumber % 12 == 0 ? 12 : adjustedNumber % 12;
            DaySteamKey = steamKey;

            AssignDayFinalOutput(steamKey, branchKey);

        }

        private void HourCalculation()
        {
            int hourNumber = GetHourNumber();
            hourNumber = hourNumber == 13 ? 1 : hourNumber;
            int steamKey = (((DaySteamKey % 5) * 2) + (hourNumber - 2)) % 10;
            steamKey = steamKey == 0 ? 10 : steamKey;
            int branchKey = hourNumber;

            AssignHourFinalOutput(steamKey, branchKey);

        }


        private int GetHourNumber()
        {
            int hourNumber = 0;
            int hour = int.Parse(finalOutput.GivenDate.Hour.ToString());
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
            int index = int.Parse(finalOutput.GivenDate.Year.ToString()) - 1925;
            Regex ex = new Regex(@"(?<day>\d{2})\.(?<month>\d{2})");
            List<DateTime> DateList = new List<DateTime>();
            var tab = yearTable[index];
            string[] dates = { tab.P1, tab.P2, tab.P3, tab.P4, tab.P5, tab.P6, tab.P7, tab.P8, tab.P9, tab.P10, tab.P11, tab.P12 };
            foreach (var item in dates)
            {
                Match m = ex.Match(item);
                if (m.Success)
                {
                    int month = int.Parse(m.Groups["month"].Value);
                    int day = int.Parse(m.Groups["day"].Value);
                    DateTime dt = new DateTime(int.Parse(finalOutput.GivenDate.Year.ToString()), month, day);
                    DateList.Add(dt);
                }
            }

            givenDate = new DateTime(int.Parse(finalOutput.GivenDate.Year.ToString()), int.Parse(finalOutput.GivenDate.Month.ToString()), int.Parse(finalOutput.GivenDate.Day.ToString()));
            int counter = 0;
            int monthNumber = 0;
            foreach (var item in DateList)
            {
                if (givenDate < item)
                {
                    monthNumber = counter;
                    continue;
                }
                counter++;
            }
            return monthNumber;
        }

        private void AssignYearFinalOutput(int YearBranchKey)
        {
            finalOutput.Year.GMColour = GetColor(stemsTable[YearSteamKey - 1].GMColour);

            finalOutput.Year.Steam.ChineseSign = stemsTable[YearSteamKey - 1].StemsSymbol1;
            finalOutput.Year.Steam.ChineseString = stemsTable[YearSteamKey - 1].StemsSymbol2;
            finalOutput.Year.Steam.EnglishString = stemsTable[YearSteamKey - 1].StemsSymbol3;
            finalOutput.Year.Steam.Colour = GetColor(stemsTable[YearSteamKey - 1].StemColour);

            finalOutput.Year.Branch.ChineseSign = branchTables[YearBranchKey - 1].Symbol1;
            finalOutput.Year.Branch.ChineseString = branchTables[YearBranchKey - 1].Symbol2;
            finalOutput.Year.Branch.EnglishString = branchTables[YearBranchKey - 1].Symbol3;
            finalOutput.Year.Branch.Colour = GetColor(branchTables[YearBranchKey - 1].Colour);

            finalOutput.Year.BelowRowTable = branchTables[YearBranchKey - 1].BelowTableRow;
        }


        private void AssignMonthFinalOutput(int MonthSteamKey, int MontBranchKey)
        {
            finalOutput.Month.GMColour = GetColor(stemsTable[MonthSteamKey - 1].GMColour);

            finalOutput.Month.Steam.ChineseSign = stemsTable[MonthSteamKey - 1].StemsSymbol1;
            finalOutput.Month.Steam.ChineseString = stemsTable[MonthSteamKey - 1].StemsSymbol2;
            finalOutput.Month.Steam.EnglishString = stemsTable[MonthSteamKey - 1].StemsSymbol3;
            finalOutput.Month.Steam.Colour = GetColor(stemsTable[MonthSteamKey - 1].StemColour);

            finalOutput.Month.Branch.ChineseSign = branchTables[MontBranchKey - 1].Symbol1;
            finalOutput.Month.Branch.ChineseString = branchTables[MontBranchKey - 1].Symbol2;
            finalOutput.Month.Branch.EnglishString = branchTables[MontBranchKey - 1].Symbol3;
            finalOutput.Month.Branch.Colour = GetColor(branchTables[MontBranchKey - 1].Colour);

            finalOutput.Month.BelowRowTable = branchTables[MontBranchKey - 1].BelowTableRow;
        }

        private void AssignDayFinalOutput(int steamKey, int branchKey)
        {
            finalOutput.Day.GMColour = GetColor(stemsTable[steamKey - 1].GMColour);

            finalOutput.Day.Steam.ChineseSign = stemsTable[steamKey - 1].StemsSymbol1;
            finalOutput.Day.Steam.ChineseString = stemsTable[steamKey - 1].StemsSymbol2;
            finalOutput.Day.Steam.EnglishString = stemsTable[steamKey - 1].StemsSymbol3;
            finalOutput.Day.Steam.Colour = GetColor(stemsTable[steamKey - 1].StemColour);

            finalOutput.Day.Branch.ChineseSign = branchTables[branchKey - 1].Symbol1;
            finalOutput.Day.Branch.ChineseString = branchTables[branchKey - 1].Symbol2;
            finalOutput.Day.Branch.EnglishString = branchTables[branchKey - 1].Symbol3;
            finalOutput.Day.Branch.Colour = GetColor(branchTables[branchKey - 1].Colour);

            finalOutput.Day.BelowRowTable = branchTables[branchKey - 1].BelowTableRow;
        }

        private void AssignHourFinalOutput(int steamKey, int branchKey)
        {
            finalOutput.Hour.GMColour = GetColor(stemsTable[steamKey - 1].GMColour);
            finalOutput.Hour.Steam.ChineseSign = stemsTable[steamKey - 1].StemsSymbol1;
            finalOutput.Hour.Steam.ChineseString = stemsTable[steamKey - 1].StemsSymbol2;
            finalOutput.Hour.Steam.EnglishString = stemsTable[steamKey - 1].StemsSymbol3;
            finalOutput.Hour.Steam.Colour = GetColor(stemsTable[steamKey - 1].StemColour);
            finalOutput.Hour.Branch.ChineseSign = branchTables[branchKey - 1].Symbol1;
            finalOutput.Hour.Branch.ChineseString = branchTables[branchKey - 1].Symbol2;
            finalOutput.Hour.Branch.EnglishString = branchTables[branchKey - 1].Symbol3;
            finalOutput.Hour.Branch.Colour = GetColor(branchTables[branchKey - 1].Colour);
            finalOutput.Hour.BelowRowTable = branchTables[branchKey - 1].BelowTableRow;
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
