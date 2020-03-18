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
        public CalculatorLogic CalculatorLogic { get; set; }

        public Calculator()
        {
            CalculatorLogic = new CalculatorLogic();
        }

        public CalculatorOutput CalculateOutput(DateTime GivenDate, DatabaseTablesCollection DatabaseTablesCollection)
        {
            return CalculatorLogic.CalculateOutput(GivenDate, DatabaseTablesCollection);
        }

    }
}
