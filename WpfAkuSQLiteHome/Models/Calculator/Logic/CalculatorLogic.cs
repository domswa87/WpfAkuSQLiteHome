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

        public CalculatorOutput CalculateOutput(DateTime givenDate, DatabaseTablesCollection databaseTablesCollection)
        {
            this.GivenDate = givenDate;
            this.DatabaseTablesCollection = databaseTablesCollection;
            this.CalculatorOutput = new CalculatorOutput();
            YearCalculation();
            MonthCalculation();
            DayCalculation();
            HourCalculation();
            return CalculatorOutput;
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
            int keyNumber = (days - 29) % 60 == 0 ? 60 : (days - 29) % 60;
            int adjustedNumber = keyNumber == 13 ? keyNumber + 1 : keyNumber;
            int steamKey = adjustedNumber % 10 == 0 ? 10 : adjustedNumber % 10;
            int branchKey = adjustedNumber % 12 == 0 ? 12 : adjustedNumber % 12;
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
