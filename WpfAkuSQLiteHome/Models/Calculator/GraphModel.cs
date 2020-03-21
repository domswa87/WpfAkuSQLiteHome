using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAkuSQLiteHome.Models.Calculator
{
    public class GraphModel
    {
        public string Head { get; set; }
        public string ArmR { get; set; }
        public string ArmL { get; set; }
        public string LegR { get; set; }
        public string LegL { get; set; }


        public string HeadUR { get; set; }
        public string ArmRUR { get; set; }
        public string ArmLUR { get; set; }
        public string LegLUR { get; set; }


        public string HeadUL { get; set; }
        public string ArmRUL { get; set; }
        public string ArmLUL { get; set; }
        public string LegRUL { get; set; }


        public string HeadDR { get; set; }
        public string LegRDR { get; set; }


        public string HeadDL { get; set; }
        public string LegLDL { get; set; }

        public int HeadFontSize { get; set; }
        public int ArmRFontSize { get; set; }
        public int ArmLFontSize { get; set; }
        public int LegRFontSize { get; set; }
        public int LegLFontSize { get; set; }

        public Thickness HeadMargin { get; set; }
        public Thickness ArmRMargin { get; set; }
        public Thickness ArmLMargin { get; set; }
        public Thickness LegRMargin { get; set; }
        public Thickness LegLMargin { get; set; }

    }
}
