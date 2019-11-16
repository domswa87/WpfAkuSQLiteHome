using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAkuSQLiteHome.ViewModels
{
    public class ShellViewModel : Conductor<object>.Collection.OneActive
    {
        public ISBCalculatorViewModel SBCalculatorViewModel { get; }

        public ShellViewModel(ISBCalculatorViewModel sBCalculatorViewModel)
        {
            SBCalculatorViewModel = sBCalculatorViewModel;
        }

        public void LoadPageOne() => ActivateItem(SBCalculatorViewModel);
    }
}
