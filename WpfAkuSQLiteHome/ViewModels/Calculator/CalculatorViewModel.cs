using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAkuSQLiteHome.ViewModels
{
    public class CalculatorViewModel : Conductor<object>.Collection.AllActive, ICalculatorViewModel, IHandle<string>
    {
        public IEventAggregator EventAggregator { get; }
        public IInputCalculatorViewModel SetBirthDateViewModel { get; }
        public ISBTableVIewModel SBTableVIewModel { get; }


        public CalculatorViewModel(IEventAggregator eventAggregator, IInputCalculatorViewModel setBirthDateViewModel, ISBTableVIewModel sBTableVIewModel)
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
                SBTableVIewModel.LoadData(SetBirthDateViewModel.InputDate);
            }
                
        }
    }
}
