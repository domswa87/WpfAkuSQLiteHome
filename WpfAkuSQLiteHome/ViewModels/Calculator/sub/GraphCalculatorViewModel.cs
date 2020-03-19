using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAkuSQLiteHome.ViewModels
{
    public class GraphCalculatorViewModel : Screen, IGraphCalculatorViewModel
    {
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
    }
}
