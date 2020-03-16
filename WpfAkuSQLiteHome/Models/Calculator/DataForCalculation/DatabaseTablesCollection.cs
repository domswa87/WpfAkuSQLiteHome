using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAkuSQLite.Models;

namespace WpfAkuSQLiteHome.Models.Calculator
{
    public class DatabaseTablesCollection
    {
        public List<BranchTable> branchTables { get; set; } = new List<BranchTable>();
        public List<DayTable> dayTables { get; set; } = new List<DayTable>();
        public List<DivisionTable> divisionTable { get; set; } = new List<DivisionTable>();
        public List<HsiuTable> hsiuTable { get; set; } = new List<HsiuTable>();
        public List<SeasonTable> seasonTable { get; set; } = new List<SeasonTable>();
        public List<StemsTable> stemsTable { get; set; } = new List<StemsTable>();
        public List<YearTable> yearTable { get; set; } = new List<YearTable>();

        public DatabaseTablesCollection()
        {
            branchTables = DataAccessClass.LoadBranchTable();
            dayTables = DataAccessClass.LoadDayTable();
            divisionTable = DataAccessClass.LoadDivisionTable();
            hsiuTable = DataAccessClass.LoadHsiuTable();
            seasonTable = DataAccessClass.LoadSeasonTable();
            stemsTable = DataAccessClass.LoadStemsTable();
            yearTable = DataAccessClass.LoadYearTable();
        }
    }
}
