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
        private string myVar;

        public string MyPropertyDS
        {
            get { return myVar; }
            set { myVar = value; NotifyOfPropertyChange(() => MyPropertyDS); }
        }



        public ICalculatorViewModel SBCalculatorViewModel { get; }
    
        public ICalendarViewModel CalendarViewModel { get; }
    

        public ShellViewModel(ICalculatorViewModel sBCalculatorViewModel, ICalendarViewModel calendarViewModel)
        {
            SBCalculatorViewModel = sBCalculatorViewModel;
            CalendarViewModel = calendarViewModel;
        }

        public void LoadPageOne() => ActivateItem(SBCalculatorViewModel);
        public void LoadPageTwo() => ActivateItem(CalendarViewModel);
    }
}
