using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAkuSQLiteHome.ViewModels
{
    public interface ISetBirthDateViewModel
    {
        string Year { get; set; }
        string Month { get; set; }
        string Day { get; set; }
        string Hour { get; set; }
    }
}
