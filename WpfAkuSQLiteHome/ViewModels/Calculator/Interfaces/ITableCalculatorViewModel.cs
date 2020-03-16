using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAkuSQLiteHome.Models;

namespace WpfAkuSQLiteHome.ViewModels
{
    public interface ITableCalculatorViewModel
    {
        void FillTableFromCalculatorOutput(CalculatorOutput calculatorOutput);
    }
}
