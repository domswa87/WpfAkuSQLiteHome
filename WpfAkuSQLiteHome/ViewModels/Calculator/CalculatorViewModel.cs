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
        public IInputCalculatorViewModel InputCalculatorViewModel { get; }
        public ITableCalculatorViewModel TableCalculatorViewModel { get; }


        public CalculatorViewModel(IEventAggregator eventAggregator, IInputCalculatorViewModel inputCalculatorViewModel, ITableCalculatorViewModel tableCalculatorViewModel)
        {
            EventAggregator = eventAggregator;
            InputCalculatorViewModel = inputCalculatorViewModel;
            TableCalculatorViewModel = tableCalculatorViewModel;
            EventAggregator.Subscribe(this);
        }

        public void Handle(string message)
        {
            if (message == "calculate")
            {
                TableCalculatorViewModel.LoadData(InputCalculatorViewModel.InputDate);
            }
                
        }
    }
}
