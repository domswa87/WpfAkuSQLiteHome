using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAkuSQLiteHome.Models.Calculator
{
    public class GraphLogic
    {
        public GraphModel graphModel { get; set; }

        public GraphModel FillGraphModel(CalculatorOutput CalculatorOutput)
        {
            graphModel = new GraphModel();
            string yearSteam = CalculatorOutput.Year.Steam.EnglishString;
            int bigFont = 35;
            int smallFont = 25;
            switch (yearSteam)
            {
              
                case "GB":
                    graphModel.ArmR = yearSteam + " +";
                    graphModel.ArmRFontSize = smallFont;
                    graphModel.ArmL = "-";
                    graphModel.ArmLFontSize = bigFont;
                    break;
                case "LIV":
                    graphModel.LegR = yearSteam + " -";
                    graphModel.LegRFontSize = smallFont;
                    graphModel.Head = "+";
                    graphModel.HeadFontSize = bigFont;
                    break;
                case "SI":
                    graphModel.LegL = yearSteam + " +";
                    graphModel.LegLFontSize = smallFont;
                    graphModel.Head = "-";
                    graphModel.HeadFontSize = bigFont;
                    break;
                case "HT":
                    graphModel.ArmL = yearSteam + " -";
                    graphModel.ArmLFontSize = smallFont;
                    graphModel.LegR = "+";
                    graphModel.LegRFontSize = bigFont;
                    break;
                case "ST":
                    graphModel.Head = yearSteam + " +";
                    graphModel.HeadFontSize = smallFont;
                    graphModel.LegR = "-";
                    graphModel.LegRFontSize = bigFont;
                    break;
                case "SP":
                    graphModel.ArmR = yearSteam + " -";
                    graphModel.ArmRFontSize = smallFont;
                    graphModel.ArmL = "+";
                    graphModel.ArmLFontSize = bigFont;
                    break;
                case "CO":
                    graphModel.LegR = yearSteam + " +";
                    graphModel.LegRFontSize = smallFont;
                    graphModel.ArmL = "-";
                    graphModel.ArmLFontSize = bigFont;
                    break;
                case "LU":
                    graphModel.LegL = yearSteam + " -";
                    graphModel.LegLFontSize = smallFont;
                    graphModel.ArmR = "+";
                    graphModel.ArmRFontSize = bigFont;
                    break;
                case "BL":
                    graphModel.ArmL = yearSteam + " +";
                    graphModel.ArmLFontSize = smallFont;
                    graphModel.ArmR = "-";
                    graphModel.ArmRFontSize = bigFont;
                    break;
                case "KI":
                    graphModel.Head = yearSteam + " -";
                    graphModel.HeadFontSize = smallFont;
                    graphModel.LegL = "+";
                    graphModel.LegLFontSize = bigFont;
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
