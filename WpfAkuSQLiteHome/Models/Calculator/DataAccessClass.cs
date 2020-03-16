using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfAkuSQLiteHome.Models;

namespace WpfAkuSQLite.Models
{
    public class DataAccessClass
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

    }


   

  
}
