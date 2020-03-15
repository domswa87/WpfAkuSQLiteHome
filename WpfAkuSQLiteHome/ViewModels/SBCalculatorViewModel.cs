using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAkuSQLiteHome.ViewModels
{
    public class SBCalculatorViewModel : Conductor<object>.Collection.AllActive, ISBCalculatorViewModel, IHandle<string>
    {
        public IEventAggregator EventAggregator { get; }
        public ISetBirthDateViewModel SetBirthDateViewModel { get; }
        public ISBTableVIewModel SBTableVIewModel { get; }

        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string Hour { get; set; }

        public SBCalculatorViewModel(IEventAggregator eventAggregator, ISetBirthDateViewModel setBirthDateViewModel, ISBTableVIewModel sBTableVIewModel)
        {
            EventAggregator = eventAggregator;
            SetBirthDateViewModel = setBirthDateViewModel;
            SBTableVIewModel = sBTableVIewModel;
            EventAggregator.Subscribe(this);
        }

        public void Handle(string message)
        {
            if (message == "calculate")
            {
                Year = SetBirthDateViewModel.Year;
                Month = SetBirthDateViewModel.Month;
                Day = SetBirthDateViewModel.Day;
                Hour = SetBirthDateViewModel.Hour;
                SBTableVIewModel.LoadData(Year, Month, Day, Hour);
            }
        }
    }
}
