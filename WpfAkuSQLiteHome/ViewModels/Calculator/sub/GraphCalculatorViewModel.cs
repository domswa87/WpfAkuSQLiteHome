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


    }
}
