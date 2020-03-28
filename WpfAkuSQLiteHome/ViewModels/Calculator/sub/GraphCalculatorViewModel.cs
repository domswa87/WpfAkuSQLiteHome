using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAkuSQLiteHome.ViewModels
{
    public class GraphCalculatorViewModel : Screen, IGraphCalculatorViewModel
    {
        // Division
        private string division;
        public string Division { get => division; set { division = value; NotifyOfPropertyChange(() => Division); } }


        //BIG SIGNS

        private string headSignB;
        public string HeadSignB { get => headSignB; set { headSignB = value; NotifyOfPropertyChange(() => HeadSignB); } }

        private string armRSignB;
        public string ArmRSignB { get => armRSignB; set { armRSignB = value; NotifyOfPropertyChange(() => ArmRSignB); } }

        private string armLSignB;
        public string ArmLSignB { get => armLSignB; set { armLSignB = value; NotifyOfPropertyChange(() => ArmLSignB); } }

        private string legRSignB;
        public string LegRSignB { get => legRSignB; set { legRSignB = value; NotifyOfPropertyChange(() => LegRSignB); } }

        private string legLSignB;
        public string LegLSignB { get => legLSignB; set { legLSignB = value; NotifyOfPropertyChange(() => LegLSignB); } }


        // LETTERS
        private string head;
        public string Head { get => head; set { head = value; NotifyOfPropertyChange(() => Head); } }

        private string armR;
        public string ArmR { get => armR; set { armR = value; NotifyOfPropertyChange(() => ArmR); } }

        private string armL;
        public string ArmL { get => armL; set { armL = value; NotifyOfPropertyChange(() => ArmL); } }

        private string legR;
        public string LegR { get => legR; set { legR = value; NotifyOfPropertyChange(() => LegR); } }

        private string legL;
        public string LegL { get => legL; set { legL = value; NotifyOfPropertyChange(() => LegL); } }


        // SMALL SIGNS
        private string headSignS;
        public string HeadSignS { get => headSignS; set { headSignS = value; NotifyOfPropertyChange(() => HeadSignS); } }

        private string armRSignS;
        public string ArmRSignS { get => armRSignS; set { armRSignS = value; NotifyOfPropertyChange(() => ArmRSignS); } }

        private string armLSignS;
        public string ArmLSignS { get => armLSignS; set { armLSignS = value; NotifyOfPropertyChange(() => ArmLSignS); } }

        private string legRSignS;
        public string LegRSignS { get => legRSignS; set { legRSignS = value; NotifyOfPropertyChange(() => LegRSignS); } }

        private string legLSignS;
        public string LegLSignS { get => legLSignS; set { legLSignS = value; NotifyOfPropertyChange(() => LegLSignS); } }




        // HEAD STEMS
        private string headUR;
        public string HeadUR { get => headUR; set { headUR = value; NotifyOfPropertyChange(() => HeadUR); } }

        private string headUL;
        public string HeadUL { get => headUL; set { headUL = value; NotifyOfPropertyChange(() => HeadUL); } }

        private string headDR;
        public string HeadDR { get => headDR; set { headDR = value; NotifyOfPropertyChange(() => HeadDR); } }

        private string headDL;
        public string HeadDL { get => headDL; set { headDL = value; NotifyOfPropertyChange(() => HeadDL); } }



        // ARM R STEMS
        private string armRUR;
        public string ArmRUR { get => armRUR; set { armRUR = value; NotifyOfPropertyChange(() => ArmRUR); } }

        private string armRUL;
        public string ArmRUL { get => armRUL; set { armRUL = value; NotifyOfPropertyChange(() => ArmRUL); } }


        // ARM L STEMS
        private string armLUR;
        public string ArmLUR { get => armLUR; set { armLUR = value; NotifyOfPropertyChange(() => ArmLUR); } }

        private string armLUL;
        public string ArmLUL { get => armLUL; set { armLUL = value; NotifyOfPropertyChange(() => ArmLUL); } }


        // LEG R STEMS
        private string legRDR;
        public string LegRDR { get => legRDR; set { legRDR = value; NotifyOfPropertyChange(() => LegRDR); } }

        private string legRUL;
        public string LegRUL { get => legRUL; set { legRUL = value; NotifyOfPropertyChange(() => LegRUL); } }


        // LEG L STEMS
        private string legLUR;
        public string LegLUR { get => legLUR; set { legLUR = value; NotifyOfPropertyChange(() => LegLUR); } }

        private string legLDL;
        public string LegLDL { get => legLDL; set { legLDL = value; NotifyOfPropertyChange(() => LegLDL); } }




        // UNDERLINE

        // HEAD 
        private string headURUnderline;
        public string HeadURUnderline { get => headURUnderline; set { headURUnderline = value; NotifyOfPropertyChange(() => HeadURUnderline); } }

        private string headULUnderline;
        public string HeadULUnderline { get => headULUnderline; set { headULUnderline = value; NotifyOfPropertyChange(() => HeadULUnderline); } }

        private string headDRUnderline;
        public string HeadDRUnderline { get => headDRUnderline; set { headDRUnderline = value; NotifyOfPropertyChange(() => HeadDRUnderline); } }

        private string headDLUnderline;
        public string HeadDLUnderline { get => headDLUnderline; set { headDLUnderline = value; NotifyOfPropertyChange(() => HeadDLUnderline); } }

        // ARM R 
        private string armRURUnderline;
        public string ArmRURUnderline { get => armRURUnderline; set { armRURUnderline = value; NotifyOfPropertyChange(() => ArmRURUnderline); } }

        private string armRULUnderline;
        public string ArmRULUnderline { get => armRULUnderline; set { armRULUnderline = value; NotifyOfPropertyChange(() => ArmRULUnderline); } }

        // ARM L 
        private string armLURUnderline;
        public string ArmLURUnderline { get => armLURUnderline; set { armLURUnderline = value; NotifyOfPropertyChange(() => ArmLURUnderline); } }

        private string armLULUnderline;
        public string ArmLULUnderline { get => armLULUnderline; set { armLULUnderline = value; NotifyOfPropertyChange(() => ArmLULUnderline); } }

        // LEG R 
        private string legRDRUnderline;
        public string LegRDRUnderline { get => legRDRUnderline; set { legRDRUnderline = value; NotifyOfPropertyChange(() => LegRDRUnderline); } }

        private string legRULUnderline;
        public string LegRULUnderline { get => legRULUnderline; set { legRULUnderline = value; NotifyOfPropertyChange(() => LegRULUnderline); } }

        // LEG L 
        private string legLURUnderline;
        public string LegLURUnderline { get => legLURUnderline; set { legLURUnderline = value; NotifyOfPropertyChange(() => LegLURUnderline); } }

        private string legLDLUnderline;
        public string LegLDLUnderline { get => legLDLUnderline; set { legLDLUnderline = value; NotifyOfPropertyChange(() => LegLDLUnderline); } }

        // Divisions

        private Visibility div1 = Visibility.Hidden;
        public Visibility Div1 { get => div1; set { div1 = value; NotifyOfPropertyChange(() => Div1); } }

        private Visibility div2 = Visibility.Hidden;
        public Visibility Div2 { get => div2; set { div2 = value; NotifyOfPropertyChange(() => Div2); } }

        private Visibility div3 = Visibility.Hidden;
        public Visibility Div3 { get => div3; set { div3 = value; NotifyOfPropertyChange(() => Div3); } }

        private Visibility div4 = Visibility.Hidden;
        public Visibility Div4 { get => div4; set { div4 = value; NotifyOfPropertyChange(() => Div4); } }

        private Visibility div5 = Visibility.Hidden;
        public Visibility Div5 { get => div5; set { div5 = value; NotifyOfPropertyChange(() => Div5); } }

        private Visibility div6 = Visibility.Hidden;
        public Visibility Div6 { get => div6; set { div6 = value; NotifyOfPropertyChange(() => Div6); } }


        // Dots
        //1
        private string headDot1;
        public string HeadDot1 { get => headDot1; set { headDot1 = value; NotifyOfPropertyChange(() => HeadDot1); } }

        private string armRDot1;
        public string ArmRDot1 { get => armRDot1; set { armRDot1 = value; NotifyOfPropertyChange(() => ArmRDot1); } }

        private string armLDot1;
        public string ArmLDot1 { get => armLDot1; set { armLDot1 = value; NotifyOfPropertyChange(() => ArmLDot1); } }

        private string legRDot1;
        public string LegRDot1 { get => legRDot1; set { legRDot1 = value; NotifyOfPropertyChange(() => LegRDot1); } }

        private string legLDot1;
        public string LegLDot1 { get => legLDot1; set { legLDot1 = value; NotifyOfPropertyChange(() => LegLDot1); } }


        //2
        private string headDot2;
        public string HeadDot2 { get => headDot2; set { headDot2 = value; NotifyOfPropertyChange(() => HeadDot2); } }

        private string armRDot2;
        public string ArmRDot2 { get => armRDot2; set { armRDot2 = value; NotifyOfPropertyChange(() => ArmRDot2); } }

        private string armLDot2;
        public string ArmLDot2 { get => armLDot2; set { armLDot2 = value; NotifyOfPropertyChange(() => ArmLDot2); } }

        private string legRDot2;
        public string LegRDot2 { get => legRDot2; set { legRDot2 = value; NotifyOfPropertyChange(() => LegRDot2); } }

        private string legLDot2;
        public string LegLDot2 { get => legLDot2; set { legLDot2 = value; NotifyOfPropertyChange(() => LegLDot2); } }


        //3
        private string headDot3;
        public string HeadDot3 { get => headDot3; set { headDot3 = value; NotifyOfPropertyChange(() => HeadDot3); } }

        private string armRDot3;
        public string ArmRDot3 { get => armRDot3; set { armRDot3 = value; NotifyOfPropertyChange(() => ArmRDot3); } }

        private string armLDot3;
        public string ArmLDot3 { get => armLDot3; set { armLDot3 = value; NotifyOfPropertyChange(() => ArmLDot3); } }

        private string legRDot3;
        public string LegRDot3 { get => legRDot3; set { legRDot3 = value; NotifyOfPropertyChange(() => LegRDot3); } }

        private string legLDot3;
        public string LegLDot3 { get => legLDot3; set { legLDot3 = value; NotifyOfPropertyChange(() => LegLDot3); } }
    }
}
