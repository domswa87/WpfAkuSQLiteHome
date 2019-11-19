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
        public IWebPageViewModel WebPageViewModel { get; }
        public ICalendarViewModel CalendarViewModel { get; }

        public ShellViewModel(ISBCalculatorViewModel sBCalculatorViewModel, IWebPageViewModel webPageViewModel, ICalendarViewModel calendarViewModel)
        {
            SBCalculatorViewModel = sBCalculatorViewModel;
            WebPageViewModel = webPageViewModel;
            CalendarViewModel = calendarViewModel;
        }

        public void LoadPageOne() => ActivateItem(SBCalculatorViewModel);

        public void LoadPageTwo() => ActivateItem(WebPageViewModel);

        public void LoadPageThree() => ActivateItem(CalendarViewModel);
    }
}
