using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public class FinalOutput
        {
            public ColumnCLass Hour { get; set; } = new ColumnCLass();
            public ColumnCLass Day { get; set; } = new ColumnCLass();
            public ColumnCLass Month { get; set; } = new ColumnCLass();
            public ColumnCLass Year { get; set; } = new ColumnCLass();
        }

        public class ColumnCLass
        {
            public string GMColour { get; set; } = null;
            public SymbolClass Steam { get; set; } = new SymbolClass();
            public SymbolClass Branch { get; set; } = new SymbolClass();
            public string BelowRowTable { get; set; } = null;
        }

        public class SymbolClass
        {
            public String ChineseSign { get; set; }
            public String ChineseString { get; set; }
            public String EnglishString { get; set; }
            public string Colour { get; set; } = null;
        }
    }
}
