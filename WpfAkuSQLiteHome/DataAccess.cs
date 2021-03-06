﻿using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfAkuSQLite
{
    public class DataAccess
    {
        public static List<BranchTable> LoadBranchTable()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return cnn.Query<BranchTable>("select * from BranchTable", new DynamicParameters()).ToList();
            }
        }

        public static List<DayTable> LoadDayTable()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return cnn.Query<DayTable>("select * from DayTable", new DynamicParameters()).ToList();
            }
        }

        public static List<DivisionTable> LoadDivisionTable()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return cnn.Query<DivisionTable>("select * from DivisionTable", new DynamicParameters()).ToList();
            }
        }

        public static List<HsiuTable> LoadHsiuTable()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return cnn.Query<HsiuTable>("select * from HsiuTable", new DynamicParameters()).ToList();
            }
        }

        public static List<SeasonTable> LoadSeasonTable()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return cnn.Query<SeasonTable>("select * from SeasonTable", new DynamicParameters()).ToList();
            }
        }

        public static List<StemsTable> LoadStemsTable()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return cnn.Query<StemsTable>("select * from StemsTable", new DynamicParameters()).ToList();
            }
        }


        public static List<YearTable> LoadYearTable()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return cnn.Query<YearTable>("select * from YearTable", new DynamicParameters()).ToList();
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return "Data Source=.\\DemoDB.db;Version=3;";
            // return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }


        public class BranchTable
        {
            public Int64? Branches { get; set; }

            public String Symbol1 { get; set; }

            public String Symbol2 { get; set; }

            public String Symbol3 { get; set; }

            public String Colour { get; set; }

            public String BelowTableRow { get; set; }
               

        }

        public class DayTable
        {
            public Int64? Day { get; set; }

            public String Symbol1 { get; set; }

            public String Symbol2 { get; set; }

            public String Rest { get; set; }

        }

        public class DivisionTable
        {
            public Int64? Divisions { get; set; }

            public String Symbol1 { get; set; }

            public String Symbol2 { get; set; }

        }

        public class HsiuTable
        {
            public Int64? Hsiu { get; set; }

            public String Animal { get; set; }

            public String Direction { get; set; }

            public String Element { get; set; }

            public String Planet { get; set; }

            public String Elts { get; set; }

            public String Rest { get; set; }

        }

        public class SeasonTable
        {
            public Int64? Id { get; set; }

            public String Seasons { get; set; }

            public Int64? day { get; set; }

            public Int64? month { get; set; }

            public String Forbidden { get; set; }

        }

        public class StemsTable
        {
            public Int64? StemsID { get; set; }

            public String StemsSymbol1 { get; set; }

            public String StemsSymbol2 { get; set; }

            public String StemsSymbol3 { get; set; }

            public String StemColour { get; set; }

            public String GMColour { get; set; }

        }

        public class YearTable
        {
            public Int64? Id { get; set; }

            public String P1 { get; set; }

            public String P2 { get; set; }

            public String P3 { get; set; }

            public String P4 { get; set; }

            public String P5 { get; set; }

            public String P6 { get; set; }

            public String P7 { get; set; }

            public String P8 { get; set; }

            public String P9 { get; set; }

            public String P10 { get; set; }

            public String P11 { get; set; }

            public String P12 { get; set; }

            public String NextYear { get; set; }

        }

        public class FinalOutput : INotifyPropertyChanged
        {
            private ColumnCLass _hour;
            public ColumnCLass Hour
            { get { return _hour; } set { _hour = value; OnPropertyRaised("Hour"); } }

            private ColumnCLass _day;
            public ColumnCLass Day
            { get { return _day; } set { _day = value; OnPropertyRaised("Day"); } }

            private ColumnCLass _month;
            public ColumnCLass Month
            { get { return _month; } set { _month = value; OnPropertyRaised("Month"); } }

            private ColumnCLass _year;
            public ColumnCLass Year
            { get { return _year; } set { _year = value; OnPropertyRaised("Year"); } }

            private GivenDate _givenDate;
            public GivenDate GivenDate
            { get { return _givenDate; } set { _givenDate = value; OnPropertyRaised("GivenDate"); } }


            public FinalOutput()
            {
                this.Year = new ColumnCLass();
                this.Month = new ColumnCLass();
                this.Day = new ColumnCLass();
                this.Hour = new ColumnCLass();
                this.GivenDate = new GivenDate();
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyRaised(string propertname)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertname));
                }
            }
        }

        public class ColumnCLass : INotifyPropertyChanged
        {

            private SolidColorBrush _gmcolour;
            public SolidColorBrush GMColour
            { get { return _gmcolour; } set { _gmcolour = value; OnPropertyRaised("GMColour"); } }


            private SymbolClass _steam;
            public SymbolClass Steam
            { get { return _steam; } set { _steam = value; OnPropertyRaised("Steam"); } }


            private SymbolClass _branch;
            public SymbolClass Branch
            { get { return _branch; } set { _branch = value; OnPropertyRaised("Branch"); } }


            private string _belowRowTable;
            public string BelowRowTable
            { get { return _belowRowTable; } set { _belowRowTable = value; OnPropertyRaised("BelowRowTable"); } }


            public ColumnCLass()
            {
                this.Steam = new SymbolClass();
                this.Branch = new SymbolClass();
                this.GMColour = null;
                this.BelowRowTable = null;

            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyRaised(string propertname)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertname));
                }
            }
        }

        public class SymbolClass : INotifyPropertyChanged
        {
            public SymbolClass()
            {
                this.ChineseSign = null;
                this.ChineseString = null;
                this.EnglishString = null;
                this.Colour = null;
            }


            private string _chineseSign;
            public string ChineseSign
            { get { return _chineseSign; } set { _chineseSign = value; OnPropertyRaised("ChineseSign"); } }


            private string _chineseString;
            public string ChineseString
            { get { return _chineseString; } set { _chineseString = value; OnPropertyRaised("ChineseString"); } }


            private string _englishString;
            public string EnglishString
            { get { return _englishString; } set { _englishString = value; OnPropertyRaised("EnglishString"); } }


            private SolidColorBrush _colour;
            public SolidColorBrush Colour
            { get { return _colour; } set { _colour = value; OnPropertyRaised("Colour"); } }


            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyRaised(string propertname)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertname));
                }
            }
        }

        public class GivenDate : INotifyPropertyChanged
        {

            private string _year;
            public string Year
            { get { return _year; } set { _year = value; OnPropertyRaised("Year"); } }

            private string _month;
            public string Month
            { get { return _month; } set { _month = value; OnPropertyRaised("Month"); } }

            private string _day;
            public string Day
            { get { return _day; } set { _day = value; OnPropertyRaised("Day"); } }

            private string _hour;
            public string Hour
            { get { return _hour; } set { _hour = value; OnPropertyRaised("Hour"); } }

            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyRaised(string propertname)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertname));
                }
            }
        }



    }
}
