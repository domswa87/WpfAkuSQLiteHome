﻿using Caliburn.Micro;
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
        public IEventAggregator EventAggregator { get; }
        public IInputCalculatorViewModel InputCalculatorViewModel { get; }
        public ITableCalculatorViewModel TableCalculatorViewModel { get; }
        public IGraphCalculatorViewModel GraphCalculatorViewModel { get; }
        public DatabaseTablesCollection DatabaseTablesCollection { get; set; }
        public Calculator Calculator { get; set; }
        public CalculatorOutput CalculatorOutput { get; set; }
        public DateTime InputDate { get; set; }


        public CalculatorViewModel(IEventAggregator eventAggregator, IInputCalculatorViewModel inputCalculatorViewModel, ITableCalculatorViewModel tableCalculatorViewModel, IGraphCalculatorViewModel graphCalculatorViewModel)
        {
            EventAggregator = eventAggregator;
            InputCalculatorViewModel = inputCalculatorViewModel;
            TableCalculatorViewModel = tableCalculatorViewModel;
            GraphCalculatorViewModel = graphCalculatorViewModel;
            EventAggregator.Subscribe(this);
            InitializeData();
        }

        private void InitializeData()
        {
            DatabaseTablesCollection = new DatabaseTablesCollection();
            Calculator = new Calculator();

        }

        public void Handle(string message)
        {
            if (message == "calculate")
            {
                InputDate = new DateTime(int.Parse(InputCalculatorViewModel.Year), int.Parse(InputCalculatorViewModel.Month), int.Parse(InputCalculatorViewModel.Day), int.Parse(InputCalculatorViewModel.Hour), 0, 0);
                // validation
               
                
                CalculatorOutput = Calculator.CalculateOutput(InputDate, DatabaseTablesCollection);
                UpdateTableViewModel(CalculatorOutput);
            }
        }

        public void UpdateTableViewModel(CalculatorOutput calculatorOutput)
        {
            this.CalculatorOutput = calculatorOutput;
            TableCalculatorViewModel.H1 = "";
            TableCalculatorViewModel.H2 = CalculatorOutput.Hour.Steam.ChineseSign;
            TableCalculatorViewModel.H3 = CalculatorOutput.Hour.Steam.ChineseString;
            TableCalculatorViewModel.H4 = CalculatorOutput.Hour.Steam.EnglishString;
            TableCalculatorViewModel.H5 = CalculatorOutput.Hour.Branch.ChineseSign;
            TableCalculatorViewModel.H6 = CalculatorOutput.Hour.Branch.ChineseString;
            TableCalculatorViewModel.H7 = CalculatorOutput.Hour.Branch.EnglishString;
            TableCalculatorViewModel.H8 = CalculatorOutput.Hour.BelowRowTable;
            TableCalculatorViewModel.HourGMColor = CalculatorOutput.Hour.GMColour;
            TableCalculatorViewModel.HourSteamColor = CalculatorOutput.Hour.Steam.Colour;
            TableCalculatorViewModel.HourBranchColor = CalculatorOutput.Hour.Branch.Colour;

            TableCalculatorViewModel.D1 = "";
            TableCalculatorViewModel.D2 = CalculatorOutput.Day.Steam.ChineseSign;
            TableCalculatorViewModel.D3 = CalculatorOutput.Day.Steam.ChineseString;
            TableCalculatorViewModel.D4 = CalculatorOutput.Day.Steam.EnglishString;
            TableCalculatorViewModel.D5 = CalculatorOutput.Day.Branch.ChineseSign;
            TableCalculatorViewModel.D6 = CalculatorOutput.Day.Branch.ChineseString;
            TableCalculatorViewModel.D7 = CalculatorOutput.Day.Branch.EnglishString;
            TableCalculatorViewModel.D8 = CalculatorOutput.Day.BelowRowTable;
            TableCalculatorViewModel.DayGMColor = CalculatorOutput.Day.GMColour;
            TableCalculatorViewModel.DaySteamColor = CalculatorOutput.Day.Steam.Colour;
            TableCalculatorViewModel.DayBranchColor = CalculatorOutput.Day.Branch.Colour;

            TableCalculatorViewModel.Y1 = "";
            TableCalculatorViewModel.Y2 = CalculatorOutput.Year.Steam.ChineseSign;
            TableCalculatorViewModel.Y3 = CalculatorOutput.Year.Steam.ChineseString;
            TableCalculatorViewModel.Y4 = CalculatorOutput.Year.Steam.EnglishString;
            TableCalculatorViewModel.Y5 = CalculatorOutput.Year.Branch.ChineseSign;
            TableCalculatorViewModel.Y6 = CalculatorOutput.Year.Branch.ChineseString;
            TableCalculatorViewModel.Y7 = CalculatorOutput.Year.Branch.EnglishString;
            TableCalculatorViewModel.Y8 = CalculatorOutput.Year.BelowRowTable;
            TableCalculatorViewModel.YearGMColor = CalculatorOutput.Year.GMColour;
            TableCalculatorViewModel.YearSteamColor = CalculatorOutput.Year.Steam.Colour;
            TableCalculatorViewModel.YearBranchColor = CalculatorOutput.Year.Branch.Colour;

            TableCalculatorViewModel.M1 = "";
            TableCalculatorViewModel.M2 = CalculatorOutput.Month.Steam.ChineseSign;
            TableCalculatorViewModel.M3 = CalculatorOutput.Month.Steam.ChineseString;
            TableCalculatorViewModel.M4 = CalculatorOutput.Month.Steam.EnglishString;
            TableCalculatorViewModel.M5 = CalculatorOutput.Month.Branch.ChineseSign;
            TableCalculatorViewModel.M6 = CalculatorOutput.Month.Branch.ChineseString;
            TableCalculatorViewModel.M7 = CalculatorOutput.Month.Branch.EnglishString;
            TableCalculatorViewModel.M8 = CalculatorOutput.Month.BelowRowTable;
            TableCalculatorViewModel.MonthGMColor = CalculatorOutput.Month.GMColour;
            TableCalculatorViewModel.MonthSteamColor = CalculatorOutput.Month.Steam.Colour;
            TableCalculatorViewModel.MonthBranchColor = CalculatorOutput.Month.Branch.Colour;
        }
    }
}