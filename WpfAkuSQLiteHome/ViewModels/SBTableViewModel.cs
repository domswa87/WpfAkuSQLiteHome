using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfAkuSQLite.Models;
using WpfAkuSQLiteHome.Models;

namespace WpfAkuSQLiteHome.ViewModels
{
    public class SBTableViewModel : Screen, ISBTableVIewModel
    {
        // HOUR

        private string h1;
        private string h2;
        private string h3;
        private string h4;
        private string h5;
        private string h6;
        private string h7;
        private string h8;
        private Brush hourGMColor = new SolidColorBrush(Colors.LightGray);
        private Brush hourSteamColor = new SolidColorBrush(Colors.LightGray);
        private Brush hourBranchColor = new SolidColorBrush(Colors.LightGray);

        public string H1 { get => h1; set { h1 = value; NotifyOfPropertyChange(() => H1); } }
        public string H2 { get => h2; set { h2 = value; NotifyOfPropertyChange(() => H2); } }
        public string H3 { get => h3; set { h3 = value;NotifyOfPropertyChange(() => H3);  } }
        public string H4 { get => h4; set { h4 = value; NotifyOfPropertyChange(() => H4); } }
        public string H5 { get => h5; set { h5 = value; NotifyOfPropertyChange(() => H5); } }
        public string H6 { get => h6; set { h6 = value; NotifyOfPropertyChange(() => H6); } }
        public string H7 { get => h7; set { h7 = value; NotifyOfPropertyChange(() => H7); } }
        public string H8 { get => h8; set { h8 = value; NotifyOfPropertyChange(() => H8); } }
        public Brush HourGMColor {get => hourGMColor;set{hourGMColor = value;NotifyOfPropertyChange(() => HourGMColor);}}
        public Brush HourSteamColor { get => hourSteamColor; set { hourSteamColor = value; NotifyOfPropertyChange(() => HourSteamColor); } }
        public Brush HourBranchColor { get => hourBranchColor; set { hourBranchColor = value; NotifyOfPropertyChange(() => HourBranchColor); } }

        // DAY

        private string d1;
        private string d2;
        private string d3;
        private string d4;
        private string d5;
        private string d6;
        private string d7;
        private string d8;
        private Brush dayGMColor = new SolidColorBrush(Colors.LightGray);
        private Brush daySteamColor = new SolidColorBrush(Colors.LightGray);
        private Brush dayBranchColor = new SolidColorBrush(Colors.LightGray);

        public string D1 { get => d1; set { d1 = value; NotifyOfPropertyChange(() => D1); } }
        public string D2 { get => d2; set { d2 = value; NotifyOfPropertyChange(() => D2); } }
        public string D3 { get => d3; set { d3 = value; NotifyOfPropertyChange(() => D3); } }
        public string D4 { get => d4; set { d4 = value; NotifyOfPropertyChange(() => D4); } }
        public string D5 { get => d5; set { d5 = value; NotifyOfPropertyChange(() => D5); } }
        public string D6 { get => d6; set { d6 = value; NotifyOfPropertyChange(() => D6); } }
        public string D7 { get => d7; set { d7 = value; NotifyOfPropertyChange(() => D7); } }
        public string D8 { get => d8; set { d8 = value; NotifyOfPropertyChange(() => D8); } }
        public Brush DayGMColor { get => dayGMColor; set { dayGMColor = value; NotifyOfPropertyChange(() => DayGMColor); } }
        public Brush DaySteamColor { get => daySteamColor; set { daySteamColor = value; NotifyOfPropertyChange(() => DaySteamColor); } }
        public Brush DayBranchColor { get => dayBranchColor; set { dayBranchColor = value; NotifyOfPropertyChange(() => DayBranchColor); } }

        // MONTH

        private string m1;
        private string m2;
        private string m3;
        private string m4;
        private string m5;
        private string m6;
        private string m7;
        private string m8;
        private Brush monthGMColor = new SolidColorBrush(Colors.LightGray);
        private Brush monthSteamColor = new SolidColorBrush(Colors.LightGray);
        private Brush monthBranchColor = new SolidColorBrush(Colors.LightGray);

        public string M1 { get => m1; set { m1 = value; NotifyOfPropertyChange(() => M1); } }
        public string M2 { get => m2; set { m2 = value; NotifyOfPropertyChange(() => M2); } }
        public string M3 { get => m3; set { m3 = value; NotifyOfPropertyChange(() => M3); } }
        public string M4 { get => m4; set { m4 = value; NotifyOfPropertyChange(() => M4); } }
        public string M5 { get => m5; set { m5 = value; NotifyOfPropertyChange(() => M5); } }
        public string M6 { get => m6; set { m6 = value; NotifyOfPropertyChange(() => M6); } }
        public string M7 { get => m7; set { m7 = value; NotifyOfPropertyChange(() => M7); } }
        public string M8 { get => m8; set { m8 = value; NotifyOfPropertyChange(() => M8); } }
        public Brush MonthGMColor { get => monthGMColor; set { monthGMColor = value; NotifyOfPropertyChange(() => MonthGMColor); } }
        public Brush MonthSteamColor { get => monthSteamColor; set { monthSteamColor = value; NotifyOfPropertyChange(() => MonthSteamColor); } }
        public Brush MonthBranchColor { get => monthBranchColor; set { monthBranchColor = value; NotifyOfPropertyChange(() => MonthBranchColor); } }

        // YEAR

        private string y1;
        private string y2;
        private string y3;
        private string y4;
        private string y5;
        private string y6;
        private string y7;
        private string y8;
        private Brush yearGMColor = new SolidColorBrush(Colors.LightGray);
        private Brush yearSteamColor = new SolidColorBrush(Colors.LightGray);
        private Brush yearBranchColor = new SolidColorBrush(Colors.LightGray);

        public string Y1 { get => y1; set { y1 = value; NotifyOfPropertyChange(() => Y1); } }
        public string Y2 { get => y2; set { y2 = value; NotifyOfPropertyChange(() => Y2); } }
        public string Y3 { get => y3; set { y3 = value; NotifyOfPropertyChange(() => Y3); } }
        public string Y4 { get => y4; set { y4 = value; NotifyOfPropertyChange(() => Y4); } }
        public string Y5 { get => y5; set { y5 = value; NotifyOfPropertyChange(() => Y5); } }
        public string Y6 { get => y6; set { y6 = value; NotifyOfPropertyChange(() => Y6); } }
        public string Y7 { get => y7; set { y7 = value; NotifyOfPropertyChange(() => Y7); } }
        public string Y8 { get => y8; set { y8 = value; NotifyOfPropertyChange(() => Y8); } }
        public Brush YearGMColor { get => yearGMColor; set { yearGMColor = value; NotifyOfPropertyChange(() => YearGMColor); } }
        public Brush YearSteamColor { get => yearSteamColor; set { yearSteamColor = value; NotifyOfPropertyChange(() => YearSteamColor); } }
        public Brush YearBranchColor { get => yearBranchColor; set { yearBranchColor = value; NotifyOfPropertyChange(() => YearBranchColor); } }

        private void AssignProperties()
        {
            H1 = "";
            H2 = finalOutput.Hour.Steam.ChineseSign;
            H3 = finalOutput.Hour.Steam.ChineseString;
            H4 = finalOutput.Hour.Steam.EnglishString;
            H5 = finalOutput.Hour.Branch.ChineseSign;
            H6 = finalOutput.Hour.Branch.ChineseString;
            H7 = finalOutput.Hour.Branch.EnglishString;
            H8 = finalOutput.Hour.BelowRowTable;
            HourGMColor = finalOutput.Hour.GMColour;
            HourSteamColor = finalOutput.Hour.Steam.Colour;
            HourBranchColor = finalOutput.Hour.Branch.Colour;

            D1 = "";
            D2 = finalOutput.Day.Steam.ChineseSign;
            D3 = finalOutput.Day.Steam.ChineseString;
            D4 = finalOutput.Day.Steam.EnglishString;
            D5 = finalOutput.Day.Branch.ChineseSign;
            D6 = finalOutput.Day.Branch.ChineseString;
            D7 = finalOutput.Day.Branch.EnglishString;
            D8 = finalOutput.Day.BelowRowTable;
            DayGMColor = finalOutput.Day.GMColour;
            DaySteamColor = finalOutput.Day.Steam.Colour;
            DayBranchColor = finalOutput.Day.Branch.Colour;

            Y1 = "";
            Y2 = finalOutput.Year.Steam.ChineseSign;
            Y3 = finalOutput.Year.Steam.ChineseString;
            Y4 = finalOutput.Year.Steam.EnglishString;
            Y5 = finalOutput.Year.Branch.ChineseSign;
            Y6 = finalOutput.Year.Branch.ChineseString;
            Y7 = finalOutput.Year.Branch.EnglishString;
            Y8 = finalOutput.Year.BelowRowTable;
            YearGMColor = finalOutput.Year.GMColour;
            YearSteamColor = finalOutput.Year.Steam.Colour;
            YearBranchColor = finalOutput.Year.Branch.Colour;

            M1 = "";
            M2 = finalOutput.Month.Steam.ChineseSign;
            M3 = finalOutput.Month.Steam.ChineseString;
            M4 = finalOutput.Month.Steam.EnglishString;
            M5 = finalOutput.Month.Branch.ChineseSign;
            M6 = finalOutput.Month.Branch.ChineseString;
            M7 = finalOutput.Month.Branch.EnglishString;
            M8 = finalOutput.Month.BelowRowTable;
            MonthGMColor = finalOutput.Month.GMColour;
            MonthSteamColor = finalOutput.Month.Steam.Colour;
            MonthBranchColor = finalOutput.Month.Branch.Colour;
        }

        public SBTableViewModel()
        {
            finalOutput = new FinalOutput();
        }

        int YearSteamKey = 0;
        int DaySteamKey = 0;
        DateTime givenDate;
        public List<BranchTable> branchTables { get; set; } = new List<BranchTable>();
        public List<DayTable> dayTables { get; set; } = new List<DayTable>();
        public List<DivisionTable> divisionTable { get; set; } = new List<DivisionTable>();
        public List<HsiuTable> hsiuTable { get; set; } = new List<HsiuTable>();
        public List<SeasonTable> seasonTable { get; set; } = new List<SeasonTable>();
        public List<StemsTable> stemsTable { get; set; } = new List<StemsTable>();
        public List<YearTable> yearTable { get; set; } = new List<YearTable>();
        FinalOutput finalOutput;

        public void LoadData(string year, string month, string day, string hour)
        {
            branchTables = DataAccessClass.LoadBranchTable();
            dayTables = DataAccessClass.LoadDayTable();
            divisionTable = DataAccessClass.LoadDivisionTable();
            hsiuTable = DataAccessClass.LoadHsiuTable();
            seasonTable = DataAccessClass.LoadSeasonTable();
            stemsTable = DataAccessClass.LoadStemsTable();
            yearTable = DataAccessClass.LoadYearTable();
            finalOutput.GivenDate.Year = year;
            finalOutput.GivenDate.Month = month;
            finalOutput.GivenDate.Day = day;
            finalOutput.GivenDate.Hour = hour;

            YearCalculation();
            MonthCalculation();
            DayCalculation();
            HourCalculation();
            AssignProperties();
        }

   

        private void YearCalculation()
        {
            int year = int.Parse(finalOutput.GivenDate.Year);
            int YearkeyNo = year - 1923;
            YearSteamKey = YearkeyNo % 10 == 0 ? 10 : YearkeyNo % 10;
            int YearBranchKey = YearkeyNo % 12 == 0 ? 12 : YearkeyNo % 12;

            AssignYearFinalOutput(YearBranchKey);
        }

        private void MonthCalculation()
        {
            int monthNumber = GetMonthNumber();
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
            int hour = int.Parse(finalOutput.GivenDate.Hour);
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
            int index = int.Parse(finalOutput.GivenDate.Year) - 1925;
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
                    DateTime dt = new DateTime(int.Parse(finalOutput.GivenDate.Year), month, day);
                    DateList.Add(dt);
                }
            }

            givenDate = new DateTime(int.Parse(finalOutput.GivenDate.Year), int.Parse(finalOutput.GivenDate.Month), int.Parse(finalOutput.GivenDate.Day));
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

