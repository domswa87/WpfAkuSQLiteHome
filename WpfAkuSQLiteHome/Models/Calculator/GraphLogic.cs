using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAkuSQLiteHome.Models.Calculator
{
    public class GraphLogic
    {
        public GraphModel graphModel { get; set; }

        public GraphModel FillGraphModel(CalculatorOutput CalculatorOutput)
        {
            graphModel = new GraphModel();
            string yearSteam = CalculatorOutput.Year.Steam.EnglishString;
            int bigFont = 80;
            int smallFont = 30;
            Thickness smallFontMargin = new Thickness(0,15,0,0);
            Thickness bigFontMargin = new Thickness(0, 0, 0, 0);
            switch (yearSteam)
            {
              
                case "GB":
                    graphModel.ArmR = yearSteam + " +";
                    graphModel.ArmRFontSize = smallFont;
                    graphModel.ArmRMargin = smallFontMargin;

                    graphModel.ArmL = "-";
                    graphModel.ArmLFontSize = bigFont;
                    graphModel.ArmLMargin = bigFontMargin;
                    break;
                case "LIV":
                    graphModel.LegR = yearSteam + " -";
                    graphModel.LegRFontSize = smallFont;
                    graphModel.LegRMargin = smallFontMargin;

                    graphModel.Head = "+";
                    graphModel.HeadFontSize = bigFont;
                    graphModel.HeadMargin = bigFontMargin;
                    break;
                case "SI":
                    graphModel.LegL = yearSteam + " +";
                    graphModel.LegLFontSize = smallFont;
                    graphModel.LegLMargin = smallFontMargin;

                    graphModel.Head = "-";
                    graphModel.HeadFontSize = bigFont;
                    graphModel.HeadMargin = bigFontMargin;
                    break;
                case "HT":
                    graphModel.ArmL = yearSteam + " -";
                    graphModel.ArmLFontSize = smallFont;
                    graphModel.ArmLMargin = smallFontMargin;

                    graphModel.LegR = "+";
                    graphModel.LegRFontSize = bigFont;
                    graphModel.LegRMargin = bigFontMargin;
                    break;
                case "ST":
                    graphModel.Head = yearSteam + " +";
                    graphModel.HeadFontSize = smallFont;
                    graphModel.HeadMargin = smallFontMargin;

                    graphModel.LegR = "-";
                    graphModel.LegRFontSize = bigFont;
                    graphModel.LegRMargin = bigFontMargin;
                    break;
                case "SP":
                    graphModel.ArmR = yearSteam + " -";
                    graphModel.ArmRFontSize = smallFont;
                    graphModel.ArmRMargin = smallFontMargin;

                    graphModel.ArmL = "+";
                    graphModel.ArmLFontSize = bigFont;
                    graphModel.ArmLMargin = bigFontMargin;
                    break;
                case "CO":
                    graphModel.LegR = yearSteam + " +";
                    graphModel.LegRFontSize = smallFont;
                    graphModel.LegRMargin = smallFontMargin;

                    graphModel.ArmL = "-";
                    graphModel.ArmLFontSize = bigFont;
                    graphModel.ArmLMargin = bigFontMargin;
                    break;
                case "LU":
                    graphModel.LegL = yearSteam + " -";
                    graphModel.LegLFontSize = smallFont;
                    graphModel.LegLMargin = smallFontMargin;

                    graphModel.ArmR = "+";
                    graphModel.ArmRFontSize = bigFont;
                    graphModel.ArmRMargin = bigFontMargin;
                    break;
                case "BL":
                    graphModel.ArmL = yearSteam + " +";
                    graphModel.ArmLFontSize = smallFont;
                    graphModel.ArmLMargin = smallFontMargin;

                    graphModel.ArmR = "-";
                    graphModel.ArmRFontSize = bigFont;
                    graphModel.ArmRMargin = bigFontMargin;
                    break;
                case "KI":
                    graphModel.Head = yearSteam + " -";
                    graphModel.HeadFontSize = smallFont;
                    graphModel.HeadMargin = smallFontMargin;

                    graphModel.LegL = "+";
                    graphModel.LegLFontSize = bigFont;
                    graphModel.LegLMargin = bigFontMargin;
                    break;
            }

            string yearBranch = CalculatorOutput.Year.Branch.EnglishString;
            switch (yearBranch)
            {
                case "GB":
                    graphModel.ArmLUL = yearBranch;
                    break;
                case "LIV":
                    graphModel.ArmLUR = yearBranch;
                    break;
                case "LU":
                    graphModel.LegRUL = yearBranch;
                    break;
                case "CO":
                    graphModel.LegRDR = yearBranch;
                    break;
                case "ST":
                    graphModel.ArmRUR = yearBranch;
                    break;
                case "SP":
                    graphModel.ArmRUL = yearBranch;
                    break;
                case "HT":
                    graphModel.HeadDL = yearBranch;
                    break;
                case "SI":
                    graphModel.HeadUL = yearBranch;
                    break;
                case "BL":
                    graphModel.LegLDL = yearBranch;
                    break;
                case "KI":
                    graphModel.LegLUR = yearBranch;
                    break;
                case "PC":
                    graphModel.HeadDR = yearBranch;
                    break;
                case "TH":
                    graphModel.HeadUR = "SJ";
                    break;

            }

            return graphModel;
        }
    }
}
