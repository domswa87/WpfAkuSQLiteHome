using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAkuSQLiteHome.ViewModels
{
    public class A_01_CalculatorViewModel : Conductor<object>.Collection.AllActive, A_01_ICalculatorViewModel, IHandle<string>
    {
        public IEventAggregator EventAggregator { get; }
        public A_02_IInputCalculatorViewModel SetBirthDateViewModel { get; }
        public ISBTableVIewModel SBTableVIewModel { get; }

        public A_01_CalculatorViewModel(IEventAggregator eventAggregator, A_02_IInputCalculatorViewModel setBirthDateViewModel, ISBTableVIewModel sBTableVIewModel)
        {
            EventAggregator = eventAggregator;
            SetBirthDateViewModel = setBirthDateViewModel;
            SBTableVIewModel = sBTableVIewModel;
            EventAggregator.Subscribe(this);
        }

        public void Handle(string message)
        {
            if (message == "calculate")
                SBTableVIewModel.LoadData(SetBirthDateViewModel.InputDate);
        }
    }
}
