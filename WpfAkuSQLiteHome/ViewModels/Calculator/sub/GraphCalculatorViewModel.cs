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


        // HEAD
        private string head;
        public string Head { get => head; set { head = value; NotifyOfPropertyChange(() => Head); } }

        // HEAD STEMS
        private string headUR;
        public string HeadUR { get => headUR; set { headUR = value; NotifyOfPropertyChange(() => HeadUR); } }

        private string headUL;
        public string HeadUL { get => headUL; set { headUL = value; NotifyOfPropertyChange(() => HeadUL); } }

        private string headDR;
        public string HeadDR { get => headDR; set { headDR = value; NotifyOfPropertyChange(() => HeadDR); } }

        private string headDL;
        public string HeadDL { get => headDL; set { headDL = value; NotifyOfPropertyChange(() => HeadDL); } }


        // ARM R
        private string armR;
        public string ArmR { get => armR; set { armR = value; NotifyOfPropertyChange(() => ArmR); } }

        // ARM R STEMS
        private string armRUR;
        public string ArmRUR { get => armRUR; set { armRUR = value; NotifyOfPropertyChange(() => ArmRUR); } }

        private string armRUL;
        public string ArmRUL { get => armRUL; set { armRUL = value; NotifyOfPropertyChange(() => ArmRUL); } }


        // ARM L
        private string armL;
        public string ArmL { get => armL; set { armL = value; NotifyOfPropertyChange(() => ArmL); } }

        // ARM L STEMS
        private string armLUR;
        public string ArmLUR { get => armLUR; set { armLUR = value; NotifyOfPropertyChange(() => ArmLUR); } }

        private string armLUL;
        public string ArmLUL { get => armLUL; set { armLUL = value; NotifyOfPropertyChange(() => ArmLUL); } }


        // LEG R
        private string legR;
        public string LegR { get => legR; set { legR = value; NotifyOfPropertyChange(() => LegR); } }

        // LEG R STEMS
        private string legRDR;
        public string LegRDR { get => legRDR; set { legRDR = value; NotifyOfPropertyChange(() => LegRDR); } }

        private string legRUL;
        public string LegRUL { get => legRUL; set { legRUL = value; NotifyOfPropertyChange(() => LegRUL); } }

        // LEG L
        private string legL;
        public string LegL { get => legL; set { legL = value; NotifyOfPropertyChange(() => LegL); } }

        // LEG L STEMS
        private string legLUR;
        public string LegLUR { get => legLUR; set { legLUR = value; NotifyOfPropertyChange(() => LegLUR); } }

        private string legLDL;
        public string LegLDL { get => legLDL; set { legLDL = value; NotifyOfPropertyChange(() => LegLDL); } }


        // SMALL SYMBOLS

        private int headFontSize;
        public int HeadFontSize { get => headFontSize; set { headFontSize = value; NotifyOfPropertyChange(() => HeadFontSize); } }


        private int armRFontSize;
        public int ArmRFontSize { get => armRFontSize; set { armRFontSize = value; NotifyOfPropertyChange(() => ArmRFontSize); } }


        private int armLFontSize;
        public int ArmLFontSize { get => armLFontSize; set { armLFontSize = value; NotifyOfPropertyChange(() => ArmLFontSize); } }


        private int legLFontSize;
        public int LegLFontSize { get => legLFontSize; set { legLFontSize = value; NotifyOfPropertyChange(() => LegLFontSize); } }


        private int legRFontSize;
        public int LegRFontSize { get => legRFontSize; set { legRFontSize = value; NotifyOfPropertyChange(() => LegRFontSize); } }

        // BIG SYMBOLS

        private int headMargin;
        public int HeadMargin { get => headMargin; set { headMargin = value; NotifyOfPropertyChange(() => HeadMargin); } }

        private int armRMargin;
        public int ArmRMargin { get => armRMargin; set { armRMargin = value; NotifyOfPropertyChange(() => ArmRMargin); } }

        private int armLMargin;
        public int ArmLMargin { get => armLMargin; set { armLMargin = value; NotifyOfPropertyChange(() => ArmLMargin); } }

        private int legRMargin;
        public int LegRMargin { get => legRMargin; set { legRMargin = value; NotifyOfPropertyChange(() => LegRMargin); } }

        private int legLMargin;
        public int LegLMargin { get => legLMargin; set { legLMargin = value; NotifyOfPropertyChange(() => LegLMargin); } }

    }
}
