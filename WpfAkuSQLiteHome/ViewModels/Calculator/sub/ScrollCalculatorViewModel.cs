using AutoMapper;
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
    class ScrollCalculatorViewModel : Conductor<object>.Collection.AllActive, IScrollCalculatorViewModel
    {
        public ITableCalculatorViewModel TableCalculatorViewModel { get; }
        public ITableRestCalculatorViewModel TableRestCalculatorViewModel { get; }
        public IGraphCalculatorViewModel GraphCalculatorViewModel { get; }
        public IMissingElementsViewModel MissingElementsViewModel { get; }

        public ScrollCalculatorViewModel(ITableCalculatorViewModel tableCalculatorViewModel, ITableRestCalculatorViewModel tableRestCalculatorViewModel,
                                         IGraphCalculatorViewModel graphCalculatorViewModel, IMissingElementsViewModel missingElementsViewModel)
        {
            TableCalculatorViewModel = tableCalculatorViewModel;
            TableRestCalculatorViewModel = tableRestCalculatorViewModel;
            GraphCalculatorViewModel = graphCalculatorViewModel;
            MissingElementsViewModel = missingElementsViewModel;
        }
      

        public void UpdateTableRestViewModel(CalculatorOutput CalculatorOutput)
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

        public void UpdateTableViewModel(CalculatorOutput CalculatorOutput)
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

        public void UpdateGraphViewModel(GraphModel GraphModel)
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
            GraphCalculatorViewModel.Div1 = GraphModel.Div1;
            GraphCalculatorViewModel.Div2 = GraphModel.Div2;
            GraphCalculatorViewModel.Div3 = GraphModel.Div3;
            GraphCalculatorViewModel.Div4 = GraphModel.Div4;
            GraphCalculatorViewModel.Div5 = GraphModel.Div5;
            GraphCalculatorViewModel.Div6 = GraphModel.Div6;

            //DOTS
            GraphCalculatorViewModel.HeadDot1 = GraphModel.HeadDot1;
            GraphCalculatorViewModel.ArmRDot1 = GraphModel.ArmRDot1;
            GraphCalculatorViewModel.LegRDot1 = GraphModel.LegRDot1;
            GraphCalculatorViewModel.LegLDot1 = GraphModel.LegLDot1;
            GraphCalculatorViewModel.ArmLDot1 = GraphModel.ArmLDot1;

            GraphCalculatorViewModel.HeadDot2 = GraphModel.HeadDot2;
            GraphCalculatorViewModel.ArmRDot2 = GraphModel.ArmRDot2;
            GraphCalculatorViewModel.LegRDot2 = GraphModel.LegRDot2;
            GraphCalculatorViewModel.LegLDot2 = GraphModel.LegLDot2;
            GraphCalculatorViewModel.ArmLDot2 = GraphModel.ArmLDot2;

            GraphCalculatorViewModel.HeadDot3 = GraphModel.HeadDot3;
            GraphCalculatorViewModel.ArmRDot3 = GraphModel.ArmRDot3;
            GraphCalculatorViewModel.LegRDot3 = GraphModel.LegRDot3;
            GraphCalculatorViewModel.LegLDot3 = GraphModel.LegLDot3;
            GraphCalculatorViewModel.ArmLDot3 = GraphModel.ArmLDot3;
        }

        public void UpdateMissingElementsViewModel(MissingElementModel missingElementModel)
        {
            MissingElementsViewModel.EL1 = missingElementModel.EL1;
            MissingElementsViewModel.EL2 = missingElementModel.EL2;
            MissingElementsViewModel.EL3 = missingElementModel.EL3;
            MissingElementsViewModel.EL4 = missingElementModel.EL4;
            MissingElementsViewModel.EL5 = missingElementModel.EL5;

            MissingElementsViewModel.EM1 = missingElementModel.EM1;
            MissingElementsViewModel.EM2 = missingElementModel.EM2;
            MissingElementsViewModel.EM3 = missingElementModel.EM3;
            MissingElementsViewModel.EM4 = missingElementModel.EM4;
            MissingElementsViewModel.EM5 = missingElementModel.EM5;

        }
    }
}
