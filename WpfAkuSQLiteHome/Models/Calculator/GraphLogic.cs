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
            Thickness smallFontMargin = new Thickness(0, 15, 0, 0);
            Thickness bigFontMargin = new Thickness(0, 0, 0, 0);
            String yearSteamToLower = new String(yearSteam.Select((ch, index) => (index == 0) ? ch : Char.ToLower(ch)).ToArray());

            Colors color1 = Colors.white;
            Colors color2 = Colors.white;
            Colors color3 = Colors.white;
            Colors color4 = Colors.white;


            switch (yearSteamToLower)
            {

                case "Gb":
                    graphModel.ArmR = yearSteamToLower;
                    graphModel.ArmRSignS = "+";
                    graphModel.ArmLSignB = "-";
                    color1 = Colors.blue;
                    break;
                case "Liv":
                    graphModel.LegR = yearSteamToLower;
                    graphModel.LegRSignS = "-";
                    graphModel.HeadSignB = "+";
                    color1 = Colors.yellow;
                    break;
                case "Si":
                    graphModel.LegL = yearSteamToLower;
                    graphModel.LegLSignS = "+";
                    graphModel.HeadSignB = "-";
                    color1 = Colors.yellow;
                    break;
                case "Ht":
                    graphModel.ArmL = yearSteamToLower;
                    graphModel.ArmLSignS = "-";
                    graphModel.LegRSignB = "+";
                    color1 = Colors.red;
                    break;
                case "St":
                    graphModel.Head = yearSteamToLower;
                    graphModel.HeadSignS = "+";
                    graphModel.LegRSignB = "-";
                    color1 = Colors.yellow;
                    break;
                case "Sp":
                    graphModel.ArmR = yearSteamToLower;
                    graphModel.ArmRSignS = "-";
                    graphModel.ArmLSignB = "+";
                    color1 = Colors.red;
                    break;
                case "Co":
                    graphModel.LegR = yearSteamToLower;
                    graphModel.LegRSignS = "+";
                    graphModel.ArmLSignB = "-";
                    color1 = Colors.green;
                    break;
                case "Lu":
                    graphModel.LegL = yearSteamToLower;
                    graphModel.LegLSignS = "-";
                    graphModel.ArmRSignB = "+";
                    color1 = Colors.green;
                    break;
                case "Bl":
                    graphModel.ArmL = yearSteamToLower;
                    graphModel.ArmLSignS = "+";
                    graphModel.ArmRSignB = "-";
                    color1 = Colors.white;
                    break;
                case "Ki":
                    graphModel.Head = yearSteamToLower;
                    graphModel.HeadSignS = "-";
                    graphModel.LegLSignB = "+";
                    color1 = Colors.white;
                    break;
            }

            string yearBranch = CalculatorOutput.Year.Branch.EnglishString;
            String yearBranchToLower = new String(yearBranch.Select((ch, index) => (index == 0) ? ch : Char.ToLower(ch)).ToArray());
            switch (yearBranchToLower)
            {
                case "Gb":
                    graphModel.ArmLUL = yearBranchToLower;
                    graphModel.ArmLULUnderline = "=";
                    color2 = Colors.blue;
                    break;
                case "Liv":
                    graphModel.ArmLUR = yearBranchToLower;
                    graphModel.ArmLURUnderline = "=";
                    color2 = Colors.yellow;
                    break;
                case "Lu":
                    graphModel.LegRUL = yearBranchToLower;
                    graphModel.LegRULUnderline = "=";
                    color2 = Colors.green;
                    break;
                case "Co":
                    graphModel.LegRDR = yearBranchToLower;
                    graphModel.LegRDRUnderline = "=";
                    color2 = Colors.green;
                    break;
                case "St":
                    graphModel.ArmRUR = yearBranchToLower;
                    graphModel.ArmRURUnderline = "=";
                    color2 = Colors.yellow;
                    break;
                case "Sp":
                    graphModel.ArmRUL = yearBranchToLower;
                    graphModel.ArmRULUnderline = "=";
                    color2 = Colors.red;
                    break;
                case "Ht":
                    graphModel.HeadDL = yearBranchToLower;
                    graphModel.HeadDLUnderline = "=";
                    color2 = Colors.red;
                    break;
                case "Si":
                    graphModel.HeadUL = yearBranchToLower;
                    graphModel.HeadULUnderline = "=";
                    color2 = Colors.yellow;
                    break;
                case "Bl":
                    graphModel.LegLDL = yearBranchToLower;
                    graphModel.LegLDLUnderline = "=";
                    color2 = Colors.white;
                    break;
                case "Ki":
                    graphModel.LegLUR = yearBranchToLower;
                    graphModel.LegLURUnderline = "=";
                    color2 = Colors.white;
                    break;
                case "Pc":
                    graphModel.HeadDR = yearBranchToLower;
                    graphModel.HeadDRUnderline = "=";
                    color2 = Colors.yellow;
                    break;
                case "Th":
                    graphModel.HeadUR = "Sj";
                    graphModel.HeadURUnderline = "=";
                    color2 = Colors.blue;
                    break;
            }


            string division = CalculatorOutput.AdditionalInfo.Division;
            switch (division)
            {
                case "Yang Ming":
                    graphModel.Div1 = Visibility.Visible;
                    color3 = Colors.yellow;
                    color4 = Colors.green;
                    break;
                case "Tai Yin":
                    graphModel.Div2 = Visibility.Visible;
                    color3 = Colors.red;
                    color4 = Colors.green;
                    break;
                case "Shao Yang":
                    graphModel.Div3 = Visibility.Visible;
                    color3 = Colors.yellow;
                    color4 = Colors.blue;
                    break;
                case "Jue Yin":
                    graphModel.Div4 = Visibility.Visible;
                    color3 = Colors.yellow;
                    color4 = Colors.yellow;
                    break;
                case "Shao Yin":
                    graphModel.Div5 = Visibility.Visible;
                    color3 = Colors.red;
                    color4 = Colors.white;
                    break;
                case "Tai Yang":
                    graphModel.Div6 = Visibility.Visible;
                    color3 = Colors.yellow;
                    color4 = Colors.white;
                    break;
            }

            CalulateDots(color1, color2, color3, color4);







            return graphModel;
        }

        private void CalulateDots(Colors color1, Colors color2, Colors color3, Colors color4)
        {
            var dicColorElemental = new Dictionary<Colors, string>
                {
                {Colors.red,"HeadDot"},
                {Colors.yellow,"ArmRDot" },
                {Colors.white,"LegRDot" },
                {Colors.blue,"LegLDot" },
                {Colors.green,"ArmLDot" },
                };

            List<Colors> colorsList = new List<Colors>() { color1, color2, color3, color4 };

            Type type = typeof(GraphModel);

            for (int i = 0; i < 4; i++)
            {
                Colors activeColor = colorsList[i];
                string basePropertyName = dicColorElemental[activeColor];

                bool isFirstPropertyEmpty = type.GetProperty(basePropertyName + "1").GetValue(graphModel) is null;
                bool isSecondPropertyEmpty = type.GetProperty(basePropertyName + "2").GetValue(graphModel) is null;

                if (isFirstPropertyEmpty)
                    type.GetProperty(basePropertyName + "1").SetValue(graphModel, ".");
                else
                {
                    if (isSecondPropertyEmpty)
                        type.GetProperty(basePropertyName + "2").SetValue(graphModel, ".");
                    else
                        type.GetProperty(basePropertyName + "3").SetValue(graphModel, ".");
                }
            }
        }
    }
}
