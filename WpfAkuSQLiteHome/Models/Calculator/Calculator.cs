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
    public class Calculator
    {
        public DateTime GivenDate { get; set; }
        public DatabaseTablesCollection DatabaseTablesCollection { get; set; }
        public CalculatorLogic CalculatorLogic { get; set; }


        public Calculator(DateTime givenDate)
        {
            this.GivenDate = givenDate;
            DatabaseTablesCollection = new DatabaseTablesCollection();
            CalculatorLogic = new CalculatorLogic(GivenDate, DatabaseTablesCollection);
        }

        public CalculatorOutput CalculateOutput()
        {
            return CalculatorLogic.CalculateOutput();
        }

    }
}
