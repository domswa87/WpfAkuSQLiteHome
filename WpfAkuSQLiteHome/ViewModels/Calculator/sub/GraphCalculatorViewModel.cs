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





        private string headUR;
        public string HeadUR { get => headUR; set { headUR = value; NotifyOfPropertyChange(() => HeadUR); } }

        private string armRUR;
        public string ArmRUR { get => armRUR; set { armRUR = value; NotifyOfPropertyChange(() => ArmRUR); } }

        private string armLUR;
        public string ArmLUR { get => armLUR; set { armLUR = value; NotifyOfPropertyChange(() => ArmLUR); } }

        private string legRUR;
        public string LegRUR { get => legRUR; set { legRUR = value; NotifyOfPropertyChange(() => LegRUR); } }

        private string legLUR;
        public string LegLUR { get => legLUR; set { legLUR = value; NotifyOfPropertyChange(() => LegLUR); } }




        private string headUL;
        public string HeadUL { get => headUL; set { headUL = value; NotifyOfPropertyChange(() => HeadUL); } }

        private string armRUL;
        public string ArmRUL { get => armRUL; set { armRUL = value; NotifyOfPropertyChange(() => ArmRUL); } }

        private string armLUL;
        public string ArmLUL { get => armLUL; set { armLUL = value; NotifyOfPropertyChange(() => ArmLUL); } }

        private string legRUL;
        public string LegRUL { get => legRUL; set { legRUL = value; NotifyOfPropertyChange(() => LegRUL); } }

        private string legLUL;
        public string LegLUL { get => legLUL; set { legLUL = value; NotifyOfPropertyChange(() => LegLUL); } }




        private string headDR;
        public string HeadDR { get => headDR; set { headDR = value; NotifyOfPropertyChange(() => HeadDR); } }

        private string armRDR;
        public string ArmRDR { get => armRDR; set { armRDR = value; NotifyOfPropertyChange(() => ArmRDR); } }

        private string armLDR;
        public string ArmLDR { get => armLDR; set { armLDR = value; NotifyOfPropertyChange(() => ArmLDR); } }

        private string legRDR;
        public string LegRDR { get => legRDR; set { legRDR = value; NotifyOfPropertyChange(() => LegRDR); } }

        private string legLDR;
        public string LegLDR { get => legLDR; set { legLDR = value; NotifyOfPropertyChange(() => LegLDR); } }



        private string headDL;
        public string HeadDL { get => headDL; set { headDL = value; NotifyOfPropertyChange(() => HeadDL); } }

        private string armRDL;
        public string ArmRDL { get => armRDL; set { armRDL = value; NotifyOfPropertyChange(() => ArmRDL); } }

        private string armLDL;
        public string ArmLDL { get => armLDL; set { armLDL = value; NotifyOfPropertyChange(() => ArmLDL); } }

        private string legRDL;
        public string LegRDL { get => legRDL; set { legRDL = value; NotifyOfPropertyChange(() => LegRDL); } }

        private string legLDL;
        public string LegLDL { get => legLDL; set { legLDL = value; NotifyOfPropertyChange(() => LegLDL); } }
    }
}
