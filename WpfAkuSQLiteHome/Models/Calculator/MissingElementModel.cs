using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAkuSQLiteHome.Models
{
    public class MissingElementModel
    {
        public string EL1 { get; set; }
        public string EL2 { get; set; }
        public string EL3 { get; set; }
        public string EL4 { get; set; }
        public string EL5 { get; set; }

        public string EM1 { get; set; }
        public string EM2 { get; set; }
        public string EM3 { get; set; }
        public string EM4 { get; set; }
        public string EM5 { get; set; }

        public string MissingOrgans { get; set; }

        public TextDecorationCollection EL1Underline { get; set; }
        public TextDecorationCollection EL2Underline { get; set; }
        public TextDecorationCollection EL3Underline { get; set; }
        public TextDecorationCollection EL4Underline { get; set; }
        public TextDecorationCollection EL5Underline { get; set; }


        public TextDecorationCollection EM1Underline { get; set; }
        public TextDecorationCollection EM2Underline { get; set; }
        public TextDecorationCollection EM3Underline { get; set; }
        public TextDecorationCollection EM4Underline { get; set; }
        public TextDecorationCollection EM5Underline { get; set; }

    }

}
