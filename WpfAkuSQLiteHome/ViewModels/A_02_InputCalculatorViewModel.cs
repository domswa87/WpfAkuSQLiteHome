using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAkuSQLiteHome.ViewModels
{
    public class A_02_InputCalculatorViewModel : Screen, A_02_X_IInputCalculatorViewModel
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string Hour { get; set; }

        public A_02_InputCalculatorViewModel(IEventAggregator eventAggregator) => EventAggregator = eventAggregator;
        public DateTime InputDate { get; set; }
        public IEventAggregator EventAggregator { get; }

        public void Calculate()
        {
            InputDate = new DateTime(int.Parse(Year), int.Parse(Month), int.Parse(Day), int.Parse(Hour), 0, 0);
            EventAggregator.BeginPublishOnUIThread("calculate");
        }
    }
}
