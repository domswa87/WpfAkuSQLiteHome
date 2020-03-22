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
            String yearBranchToLower = new String(yearBranch.Select((ch, index) => (index == 0) ? ch : Char.ToLower(ch)).ToArray());
            switch (yearBranchToLower)
            {
                case "Gb":
                    graphModel.ArmLUL = yearBranchToLower;
                    graphModel.ArmLULUnderline = "=";
                    break;
                case "Liv":
                    graphModel.ArmLUR = yearBranchToLower;
                    graphModel.ArmLURUnderline = "=";
                    break;
                case "Lu":
                    graphModel.LegRUL = yearBranchToLower;
                    graphModel.LegRULUnderline = "=";
                    break;
                case "Co":
                    graphModel.LegRDR = yearBranchToLower;
                    graphModel.LegRDRUnderline = "=";
                    break;
                case "St":
                    graphModel.ArmRUR = yearBranchToLower;
                    graphModel.ArmRURUnderline = "=";
                    break;
                case "Sp":
                    graphModel.ArmRUL = yearBranchToLower;
                    graphModel.ArmRULUnderline = "=";
                    break;
                case "Ht":
                    graphModel.HeadDL = yearBranchToLower;
                    graphModel.HeadDLUnderline = "=";
                    break;
                case "Si":
                    graphModel.HeadUL = yearBranchToLower;
                    graphModel.HeadULUnderline = "=";
                    break;
                case "Bl":
                    graphModel.LegLDL = yearBranchToLower;
                    graphModel.LegLDLUnderline = "=";
                    break;
                case "Ki":
                    graphModel.LegLUR = yearBranchToLower;
                    graphModel.LegLURUnderline = "=";
                    break;
                case "Pc":
                    graphModel.HeadDR = yearBranchToLower;
                    graphModel.HeadDRUnderline = "=";
                    break;
                case "Th":
                    graphModel.HeadUR = "Sj";
                    graphModel.HeadURUnderline = "=";
                    break;
            }

            return graphModel;
        }
    }
}
