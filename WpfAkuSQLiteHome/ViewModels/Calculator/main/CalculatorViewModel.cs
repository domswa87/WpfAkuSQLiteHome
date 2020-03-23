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
        public ITableCalculatorViewModel TableCalculatorViewModel { get; }
        public IGraphCalculatorViewModel GraphCalculatorViewModel { get; }
        public ITableRestCalculatorViewModel TableRestCalculatorViewModel { get; }
        public IScrollCalculatorViewModel ScrollCalculatorViewModel { get; }
        public IEventAggregator EventAggregator { get; }



        public DatabaseTablesCollection DatabaseTablesCollection { get; set; }
        public Calculator Calculator { get; set; }
        public CalculatorOutput CalculatorOutput { get; set; }
        public GraphLogic GraphLogic { get; set; }
        public GraphModel GraphModel { get; set; }
        public DateTime InputDate { get; set; }


        public CalculatorViewModel(IEventAggregator eventAggregator, IInputCalculatorViewModel inputCalculatorViewModel, ITableCalculatorViewModel tableCalculatorViewModel,
                                    IGraphCalculatorViewModel graphCalculatorViewModel, ITableRestCalculatorViewModel tableRestCalculatorViewModel, IScrollCalculatorViewModel scrollCalculatorViewModel)
        {
            EventAggregator = eventAggregator;
            InputCalculatorViewModel = inputCalculatorViewModel;
            TableCalculatorViewModel = tableCalculatorViewModel;
            GraphCalculatorViewModel = graphCalculatorViewModel;
            TableRestCalculatorViewModel = tableRestCalculatorViewModel;
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
                UpdateTableViewModel();

                GraphModel = GraphLogic.FillGraphModel(CalculatorOutput);
                UpdateGraphViewModel();

                UpdateTableRestViewModel();
            }
        }

        private void UpdateTableRestViewModel()
        {
            TableRestCalculatorViewModel.H1 = CalculatorOutput.AdditionalInfo.Division;
            TableRestCalculatorViewModel.H2 = CalculatorOutput.AdditionalInfo.CorrectiveEnergy;
            TableRestCalculatorViewModel.H3 = CalculatorOutput.AdditionalInfo.Season;
            TableRestCalculatorViewModel.H4 = CalculatorOutput.AdditionalInfo.Forbidden;
            TableRestCalculatorViewModel.H5 = CalculatorOutput.AdditionalInfo.ForbiddenMeridians1;
            TableRestCalculatorViewModel.H6 = CalculatorOutput.AdditionalInfo.ForbiddenMeridians2;
            TableRestCalculatorViewModel.H7 = CalculatorOutput.AdditionalInfo.ForbiddenRegion;
            TableRestCalculatorViewModel.H8 = CalculatorOutput.AdditionalInfo.Hsiu.Animal;
            TableRestCalculatorViewModel.H9 = CalculatorOutput.AdditionalInfo.Hsiu.Direction;
            TableRestCalculatorViewModel.H10 = CalculatorOutput.AdditionalInfo.Hsiu.Element;
            TableRestCalculatorViewModel.H11 = CalculatorOutput.AdditionalInfo.Hsiu.Planet;
            TableRestCalculatorViewModel.H12 = CalculatorOutput.AdditionalInfo.Hsiu.Elts;
            TableRestCalculatorViewModel.H13 = CalculatorOutput.AdditionalInfo.Hsiu.Points;
        }

        public void UpdateTableViewModel()
        {
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

        public void UpdateGraphViewModel()
        {
      
            GraphCalculatorViewModel.Head = GraphModel.Head;
            GraphCalculatorViewModel.ArmR = GraphModel.ArmR;
            GraphCalculatorViewModel.ArmL = GraphModel.ArmL;
            GraphCalculatorViewModel.LegR = GraphModel.LegR;
            GraphCalculatorViewModel.LegL = GraphModel.LegL;


            // branches
            GraphCalculatorViewModel.HeadUR = GraphModel.HeadUR;
            GraphCalculatorViewModel.ArmRUR = GraphModel.ArmRUR;
            GraphCalculatorViewModel.ArmLUR = GraphModel.ArmLUR;
            GraphCalculatorViewModel.LegLUR = GraphModel.LegLUR;

            GraphCalculatorViewModel.HeadUL = GraphModel.HeadUL;
            GraphCalculatorViewModel.ArmRUL = GraphModel.ArmRUL;
            GraphCalculatorViewModel.ArmLUL = GraphModel.ArmLUL;
            GraphCalculatorViewModel.LegRUL = GraphModel.LegRUL;

            GraphCalculatorViewModel.HeadDR = GraphModel.HeadDR;
            GraphCalculatorViewModel.LegRDR = GraphModel.LegRDR;

            GraphCalculatorViewModel.HeadDL = GraphModel.HeadDL;
            GraphCalculatorViewModel.LegLDL = GraphModel.LegLDL;

            // underlines
            GraphCalculatorViewModel.HeadURUnderline = GraphModel.HeadURUnderline;
            GraphCalculatorViewModel.ArmRURUnderline = GraphModel.ArmRURUnderline;
            GraphCalculatorViewModel.ArmLURUnderline = GraphModel.ArmLURUnderline;
            GraphCalculatorViewModel.LegLURUnderline = GraphModel.LegLURUnderline;

            GraphCalculatorViewModel.HeadULUnderline = GraphModel.HeadULUnderline;
            GraphCalculatorViewModel.ArmRULUnderline = GraphModel.ArmRULUnderline;
            GraphCalculatorViewModel.ArmLULUnderline = GraphModel.ArmLULUnderline;
            GraphCalculatorViewModel.LegRULUnderline = GraphModel.LegRULUnderline;

            GraphCalculatorViewModel.HeadDRUnderline = GraphModel.HeadDRUnderline;
            GraphCalculatorViewModel.LegRDRUnderline = GraphModel.LegRDRUnderline;

            GraphCalculatorViewModel.HeadDLUnderline = GraphModel.HeadDLUnderline;
            GraphCalculatorViewModel.LegLDLUnderline = GraphModel.LegLDLUnderline;

            // BIG SIGNS
            GraphCalculatorViewModel.HeadSignB = GraphModel.HeadSignB;
            GraphCalculatorViewModel.ArmRSignB = GraphModel.ArmRSignB;
            GraphCalculatorViewModel.ArmLSignB = GraphModel.ArmLSignB;
            GraphCalculatorViewModel.LegRSignB = GraphModel.LegRSignB;
            GraphCalculatorViewModel.LegLSignB = GraphModel.LegLSignB;

            // SMALL SIGNS
            GraphCalculatorViewModel.HeadSignS = GraphModel.HeadSignS;
            GraphCalculatorViewModel.ArmRSignS = GraphModel.ArmRSignS;
            GraphCalculatorViewModel.ArmLSignS = GraphModel.ArmLSignS;
            GraphCalculatorViewModel.LegRSignS = GraphModel.LegRSignS;
            GraphCalculatorViewModel.LegLSignS = GraphModel.LegLSignS;

            //DIVISIONS
            GraphCalculatorViewModel.Division = CalculatorOutput.AdditionalInfo.Division;
            GraphCalculatorViewModel.Div1 = GraphModel.Div1;
            GraphCalculatorViewModel.Div2 = GraphModel.Div2;
            GraphCalculatorViewModel.Div3 = GraphModel.Div3;
            GraphCalculatorViewModel.Div4 = GraphModel.Div4;
            GraphCalculatorViewModel.Div5 = GraphModel.Div5;
            GraphCalculatorViewModel.Div6 = GraphModel.Div6;
        }
    }
}
