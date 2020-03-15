using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAkuSQLiteHome.ViewModels
{
    public interface ISBTableVIewModel
    {
        void LoadData(string year, string month, string day, string hour);
    }
}
