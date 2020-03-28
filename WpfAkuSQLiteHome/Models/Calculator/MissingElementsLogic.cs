using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAkuSQLiteHome.Models.Calculator;

namespace WpfAkuSQLiteHome.Models
{
    public class MissingElementsLogic
    {
        MissingElementModel missingElements = new MissingElementModel();

        public MissingElementModel FillMissingElementsModel(GraphModel graphModel, CalculatorOutput calculatorOutput)
        {
            CalculateEL(graphModel);
            CalculateEM(graphModel, calculatorOutput);
            return missingElements;
        }

        private void CalculateEL(GraphModel graphModel)
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

            missingElements.EL1 = list[0];
            missingElements.EL2 = list[1];
            missingElements.EL3 = list[2];
            missingElements.EL4 = list[3];
            missingElements.EL5 = list[4];
        }

        private void CalculateEM(GraphModel graphModel, CalculatorOutput calculatorOutput)
        {
            List<string> list = new List<string>() { "", "", "", "", "" };

            Dictionary<int, string> d = new Dictionary<int, string>()
            {
                {1,"Yang Ming" },
                {2,"Tai Yin" },
                {3,"Shao Yang" },
                {4,"Yue Yin" },
                {5,"Shao Yin" },
                {6,"Tai Yang" }
            };

            bool missingHead = graphModel.Head == null && graphModel.HeadUR == null && graphModel.HeadUL == null && graphModel.HeadDR == null && graphModel.HeadDL == null;
            bool missingArmR = graphModel.ArmR == null && graphModel.ArmRUR == null && graphModel.ArmRUL == null;
            bool missingLegR = graphModel.LegR == null && graphModel.LegRDR == null && graphModel.LegRUL == null;
            bool missingLegL = graphModel.LegL == null && graphModel.LegLUR == null && graphModel.LegLDL == null;
            bool missingArmL = graphModel.ArmL == null && graphModel.ArmLUR == null && graphModel.ArmRUR == null;

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

            missingElements.EM1 = list[0];
            missingElements.EM2 = list[1];
            missingElements.EM3 = list[2];
            missingElements.EM4 = list[3];
            missingElements.EM5 = list[4];
        }
    }
}
