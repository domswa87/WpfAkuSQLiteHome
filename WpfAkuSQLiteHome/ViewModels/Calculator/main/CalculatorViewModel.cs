using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAkuSQLiteHome.Models;
using WpfAkuSQLiteHome.Models.Calculator;

namespace WpfAkuSQLiteHome.ViewModels
{
    public class CalculatorViewModel : Conductor<object>.Collection.AllActive, ICalculatorViewModel, IHandle<string>
    {

        public IInputCalculatorViewModel InputCalculatorViewModel { get; }
        public IScrollCalculatorViewModel ScrollCalculatorViewModel { get; }
        public IEventAggregator EventAggregator { get; }



        public DatabaseTablesCollection DatabaseTablesCollection { get; set; }
        public Calculator Calculator { get; set; }
        public CalculatorOutput CalculatorOutput { get; set; }
        public GraphLogic GraphLogic { get; set; }
        public GraphModel GraphModel { get; set; }
        public DateTime InputDate { get; set; }


        public CalculatorViewModel(IEventAggregator eventAggregator, IInputCalculatorViewModel inputCalculatorViewModel, IScrollCalculatorViewModel scrollCalculatorViewModel)
        {
            EventAggregator = eventAggregator;
            InputCalculatorViewModel = inputCalculatorViewModel;
            ScrollCalculatorViewModel = scrollCalculatorViewModel;
            EventAggregator.Subscribe(this);
            InitializeData();
        }

        private void InitializeData()
        {
            DatabaseTablesCollection = new DatabaseTablesCollection();
            Calculator = new Calculator();
            GraphLogic = new GraphLogic();
            GraphModel = new GraphModel();
        }

        public void Handle(string message)
        {
            if (message == "calculate")
            {
                InputDate = new DateTime(int.Parse(InputCalculatorViewModel.Year), int.Parse(InputCalculatorViewModel.Month), int.Parse(InputCalculatorViewModel.Day), int.Parse(InputCalculatorViewModel.Hour), 0, 0);
                // validation

                CalculatorOutput = Calculator.CalculateOutput(InputDate, DatabaseTablesCollection);
                ScrollCalculatorViewModel.UpdateTableViewModel(CalculatorOutput);

                GraphModel = GraphLogic.FillGraphModel(CalculatorOutput);
                ScrollCalculatorViewModel.UpdateGraphViewModel(GraphModel);

                ScrollCalculatorViewModel.UpdateTableRestViewModel(CalculatorOutput);
            }
        }
       
    }
}
