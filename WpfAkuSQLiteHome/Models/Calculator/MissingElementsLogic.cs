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
        public MissingElementModel FillMissingElementsModel(GraphModel graphModel)
        {
            MissingElementModel missingElements = new MissingElementModel();


            missingElements.EL1 = "dupa";



            return missingElements;
        }
    }
}
