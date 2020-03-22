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
            Thickness smallFontMargin = new Thickness(0,15,0,0);
            Thickness bigFontMargin = new Thickness(0, 0, 0, 0);
            String yearSteamToLower = new String(yearSteam.Select((ch, index) => (index == 0) ? ch : Char.ToLower(ch)).ToArray());

            switch (yearSteamToLower)
            {
              
                case "Gb":
                    graphModel.ArmR = yearSteamToLower;
                    graphModel.ArmRSignS = "+";
                    graphModel.ArmLSignB = "-";
                    break;
                case "Liv":
                    graphModel.LegR = yearSteamToLower;
                    graphModel.LegRSignS = "-";
                    graphModel.HeadSignB = "+";
                    break;
                case "Si":
                    graphModel.LegL = yearSteamToLower;
                    graphModel.LegLSignS = "+";
                    graphModel.HeadSignB = "-";
                    break;
                case "Ht":
                    graphModel.ArmL = yearSteamToLower;
                    graphModel.ArmLSignS = "-";
                    graphModel.LegRSignB = "+";
                    break;
                case "St":
                    graphModel.Head = yearSteamToLower;
                    graphModel.HeadSignS = "+";
                    graphModel.LegRSignB = "-";
                    break;
                case "Sp":
                    graphModel.ArmR = yearSteamToLower;
                    graphModel.ArmRSignS = "-";
                    graphModel.ArmLSignB = "+";
                    break;
                case "Co":
                    graphModel.LegR = yearSteamToLower;
                    graphModel.LegRSignS = "+";
                    graphModel.ArmLSignB = "-";
                    break;
                case "Lu":
                    graphModel.LegL = yearSteamToLower;
                    graphModel.LegLSignS = "-";
                    graphModel.ArmRSignB = "+";
                    break;
                case "Bl":
                    graphModel.ArmL = yearSteamToLower;
                    graphModel.ArmLSignS = "+";
                    graphModel.ArmRSignB = "-";
                    break;
                case "Ki":
                    graphModel.Head = yearSteamToLower;
                    graphModel.HeadSignS = "-";
                    graphModel.LegLSignB = "+";
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
