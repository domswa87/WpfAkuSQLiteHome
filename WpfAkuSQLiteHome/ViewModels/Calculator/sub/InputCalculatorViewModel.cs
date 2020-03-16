using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAkuSQLiteHome.ViewModels
{
    public class InputCalculatorViewModel : Screen, IInputCalculatorViewModel
    {
        public string Year { get; set; } = "2000";
        public string Month { get; set; } = "3";
        public string Day { get; set; } = "3";
        public string Hour { get; set; } = "3";

        public InputCalculatorViewModel(IEventAggregator eventAggregator) => EventAggregator = eventAggregator;
        public DateTime InputDate { get; set; }
        public IEventAggregator EventAggregator { get; }

        public void Calculate()
        {
            InputDate = new DateTime(int.Parse(Year), int.Parse(Month), int.Parse(Day), int.Parse(Hour), 0, 0);
            EventAggregator.BeginPublishOnUIThread("calculate");
        }
    }
}
