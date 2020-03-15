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



        public A_01_X_ICalculatorViewModel SBCalculatorViewModel { get; }
        public IWebPageViewModel WebPageViewModel { get; }
        public ICalendarViewModel CalendarViewModel { get; }
        public IFocusViewModel FocusViewModel { get; }

        public ShellViewModel(A_01_X_ICalculatorViewModel sBCalculatorViewModel, IWebPageViewModel webPageViewModel, ICalendarViewModel calendarViewModel, IFocusViewModel focusViewModel)
        {
            SBCalculatorViewModel = sBCalculatorViewModel;
            WebPageViewModel = webPageViewModel;
            CalendarViewModel = calendarViewModel;
            FocusViewModel = focusViewModel;
        }

        public void LoadPageOne() => ActivateItem(SBCalculatorViewModel);

        public void LoadPageTwo() => ActivateItem(WebPageViewModel);

        public void LoadPageThree() => ActivateItem(CalendarViewModel);

        public void LoadPageFour() => ActivateItem(FocusViewModel);
    }
}
