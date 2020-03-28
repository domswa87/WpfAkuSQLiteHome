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
    public class TableCalculatorViewModel : Screen, ITableCalculatorViewModel
    {
        // HOUR
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



        private string h1;
        private string h2;
        private string h3;
        private string h4;
        private string h5;
        private string h6;
        private string h7;
        private string h8;
        private Brush hourGMColor = new SolidColorBrush(System.Windows.Media.Colors.LightGray);
        private Brush hourSteamColor = new SolidColorBrush(System.Windows.Media.Colors.LightGray);
        private Brush hourBranchColor = new SolidColorBrush(System.Windows.Media.Colors.LightGray);

        private string d1;
        private string d2;
        private string d3;
        private string d4;
        private string d5;
        private string d6;
        private string d7;
        private string d8;
        private Brush dayGMColor = new SolidColorBrush(System.Windows.Media.Colors.LightGray);
        private Brush daySteamColor = new SolidColorBrush(System.Windows.Media.Colors.LightGray);
        private Brush dayBranchColor = new SolidColorBrush(System.Windows.Media.Colors.LightGray);


        private string m1;
        private string m2;
        private string m3;
        private string m4;
        private string m5;
        private string m6;
        private string m7;
        private string m8;
        private Brush monthGMColor = new SolidColorBrush(System.Windows.Media.Colors.LightGray);
        private Brush monthSteamColor = new SolidColorBrush(System.Windows.Media.Colors.LightGray);
        private Brush monthBranchColor = new SolidColorBrush(System.Windows.Media.Colors.LightGray);

        private string y1;
        private string y2;
        private string y3;
        private string y4;
        private string y5;
        private string y6;
        private string y7;
        private string y8;
        private Brush yearGMColor = new SolidColorBrush(System.Windows.Media.Colors.LightGray);
        private Brush yearSteamColor = new SolidColorBrush(System.Windows.Media.Colors.LightGray);
        private Brush yearBranchColor = new SolidColorBrush(System.Windows.Media.Colors.LightGray);


        public TableCalculatorViewModel()
        {

        }

    }

}

