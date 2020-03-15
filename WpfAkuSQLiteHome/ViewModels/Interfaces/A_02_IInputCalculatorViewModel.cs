using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAkuSQLiteHome.ViewModels
{
    public interface A_02_IInputCalculatorViewModel
    {
        string Year { get; set; }
        string Month { get; set; }
        string Day { get; set; }
        string Hour { get; set; }
        DateTime InputDate { get; set; }
    }
}
