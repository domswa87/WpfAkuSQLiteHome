using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using WpfAkuSQLiteHome.Models.Calculator;

namespace WpfAkuSQLiteHome.Models
{
    public class MissingElementsLogic
    {
        MissingElementModel missingElements; 
        public MissingElementModel FillMissingElementsModel(GraphModel graphModel, CalculatorOutput calculatorOutput)
        {
            missingElements = new MissingElementModel();
            List<string> listEL = CalculateListEL(graphModel);
            List<string> listEM = CalculateListEM(graphModel, calculatorOutput);
            Decorate(listEL, listEM);
            return missingElements;
        }

        private void Decorate(List<string> listEL, List<string> listEM)
        {
            List<string> doubletsList = CheckForDoublets(ref listEL, ref listEM);
            ProcessDuplicates(ref listEL, ref listEM, doubletsList);

        }

        private static List<string> CheckForDoublets(ref List<string> listEL, ref List<string> listEM)
        {
            listEL = listEL.Where(x => x != "").ToList();
            listEM = listEM.Where(x => x != "").ToList();

            List<string> doubletsList = listEL.Intersect(listEM).ToList();
            return doubletsList;
        }

        private void ProcessDuplicates(ref List<string> listEL, ref List<string> listEM, List<string> doubletsList)
        {
            listEL = listEL.Except(doubletsList).ToList();
            listEM = listEM.Except(doubletsList).ToList();

            if (doubletsList.Count > 0)
            {
                var AllProperties = missingElements.GetType().GetProperties();
                Regex exNumber = new Regex(@"\d");

                foreach (var property in AllProperties)
                {
                    Match m = exNumber.Match(property.Name);
                    if (m.Success)
                    {
                        int propNumber = int.Parse(m.Value);
                        if (property.Name.Contains("Underline") && propNumber <= doubletsList.Count)
                        {
                            property.SetValue(missingElements, TextDecorations.Underline);
                        }
                    }
                }
            }

            List<string> FinalListEL = doubletsList.Union(listEL).ToList();
            List<string> FinalListEM = doubletsList.Union(listEM).ToList();

            int counter = 1;
            foreach (string item in FinalListEL)
            {
                missingElements.GetType().GetProperty("EL" + counter).SetValue(missingElements, item);
                counter++;
            }
            counter = 1;
            foreach (string item in FinalListEM)
            {
                missingElements.GetType().GetProperty("EM" + counter).SetValue(missingElements, item);
                counter++;
            }
        }

        private List<string> CalculateListEL(GraphModel graphModel)
        {
            List<string> list = new List<string>() { "", "", "", "", "" };

            if (graphModel.ArmLDot1 != ".")
                list.Add("Wo");
            if (graphModel.LegLDot1 != ".")
                list.Add("Wt");
            if (graphModel.LegRDot1 != ".")
                list.Add("M");
            if (graphModel.ArmRDot1 != ".")
                list.Add("E");
            if (graphModel.HeadDot1 != ".")
                list.Add("F");

            list.Reverse();
            return list;

        }

        private List<string> CalculateListEM(GraphModel graphModel, CalculatorOutput calculatorOutput)
        {
            List<string> list = new List<string>() { "", "", "", "", "" };

            Dictionary<int, string> d = new Dictionary<int, string>()
            {
                {1,"Yang Ming" },
                {2,"Tai Yin" },
                {3,"Shao Yang" },
                {4,"Jue Yin" },
                {5,"Shao Yin" },
                {6,"Tai Yang" }
            };

            bool missingHead = graphModel.Head == null && graphModel.HeadUR == null && graphModel.HeadUL == null && graphModel.HeadDR == null && graphModel.HeadDL == null;
            bool missingArmR = graphModel.ArmR == null && graphModel.ArmRUR == null && graphModel.ArmRUL == null;
            bool missingLegR = graphModel.LegR == null && graphModel.LegRDR == null && graphModel.LegRUL == null;
            bool missingLegL = graphModel.LegL == null && graphModel.LegLUR == null && graphModel.LegLDL == null;
            bool missingArmL = graphModel.ArmL == null && graphModel.ArmLUR == null && graphModel.ArmLUL == null;

            missingHead = missingHead
                          && calculatorOutput.AdditionalInfo.Division != d[3]
                          && calculatorOutput.AdditionalInfo.Division != d[4]
                          && calculatorOutput.AdditionalInfo.Division != d[5]
                          && calculatorOutput.AdditionalInfo.Division != d[6];

            missingArmR = missingArmR
                          && calculatorOutput.AdditionalInfo.Division != d[1]
                          && calculatorOutput.AdditionalInfo.Division != d[2];

            missingLegR = missingLegR
                          && calculatorOutput.AdditionalInfo.Division != d[1]
                          && calculatorOutput.AdditionalInfo.Division != d[2];

            missingLegL = missingLegL
                          && calculatorOutput.AdditionalInfo.Division != d[5]
                          && calculatorOutput.AdditionalInfo.Division != d[6];

            missingArmL = missingArmL
                          && calculatorOutput.AdditionalInfo.Division != d[3]
                          && calculatorOutput.AdditionalInfo.Division != d[4];

            if (missingArmL)
                list.Add("Wo");
            if (missingLegL)
                list.Add("Wt");
            if (missingLegR)
                list.Add("M");
            if (missingArmR)
                list.Add("E");
            if (missingHead)
                list.Add("F");

            list.Reverse();

            return list;
        }
    }
}
