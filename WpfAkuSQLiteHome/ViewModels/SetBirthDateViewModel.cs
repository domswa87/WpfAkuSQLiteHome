using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAkuSQLiteHome.ViewModels
{
    public class SetBirthDateViewModel : Screen, ISetBirthDateViewModel
    {
        public SetBirthDateViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
        }

        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string Hour { get; set; }
        public IEventAggregator EventAggregator { get; }

        public void Calculate()
        {
            EventAggregator.BeginPublishOnUIThread("calculate");
        }
    }
}
