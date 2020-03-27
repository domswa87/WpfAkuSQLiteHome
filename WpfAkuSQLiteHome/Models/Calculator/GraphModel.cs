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

        public string HeadSignB { get; set; }
        public string ArmRSignB { get; set; }
        public string ArmLSignB { get; set; }
        public string LegRSignB { get; set; }
        public string LegLSignB { get; set; }

        public string HeadSignS { get; set; }
        public string ArmRSignS { get; set; }
        public string ArmLSignS { get; set; }
        public string LegRSignS { get; set; }
        public string LegLSignS { get; set; }


        // STEMS
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

        // UNDERLINE

        public string HeadURUnderline { get; set; }
        public string ArmRURUnderline { get; set; }
        public string ArmLURUnderline { get; set; }
        public string LegLURUnderline { get; set; }

        public string HeadULUnderline { get; set; }
        public string ArmRULUnderline { get; set; }
        public string ArmLULUnderline { get; set; }
        public string LegRULUnderline { get; set; }

        public string HeadDRUnderline { get; set; }
        public string LegRDRUnderline { get; set; }

        public string HeadDLUnderline { get; set; }
        public string LegLDLUnderline { get; set; }

        // DIVISIONS
        public Visibility Div1 { get; set; } = Visibility.Hidden;
        public Visibility Div2 { get; set; } = Visibility.Hidden;
        public Visibility Div3 { get; set; } = Visibility.Hidden;
        public Visibility Div4 { get; set; } = Visibility.Hidden;
        public Visibility Div5 { get; set; } = Visibility.Hidden;
        public Visibility Div6 { get; set; } = Visibility.Hidden;

        //DOTS
        public string HeadDot1 { get; set; }
        public string ArmRDot1 { get; set; }
        public string ArmLDot1 { get; set; }
        public string LegRDot1 { get; set; }
        public string LegLDot1 { get; set; }

        public string HeadDot2 { get; set; }
        public string ArmRDot2 { get; set; }
        public string ArmLDot2 { get; set; }
        public string LegRDot2 { get; set; }
        public string LegLDot2 { get; set; }

        public string HeadDot3 { get; set; }
        public string ArmRDot3 { get; set; }
        public string ArmLDot3 { get; set; }
        public string LegRDot3 { get; set; }
        public string LegLDot3 { get; set; }
    }
}
