using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAkuSQLiteHome.ViewModels
{
    class MissingElementsViewModel : Screen, IMissingElementsViewModel
    {
        // EL
        private string eL1;
        public string EL1 { get => eL1; set { eL1 = value; NotifyOfPropertyChange(() => EL1); } }

        private string eL2;
        public string EL2 { get => eL2; set { eL2 = value; NotifyOfPropertyChange(() => EL2); } }

        private string eL3;
        public string EL3 { get => eL3; set { eL3 = value; NotifyOfPropertyChange(() => EL3); } }

        private string eL4;
        public string EL4 { get => eL4; set { eL4 = value; NotifyOfPropertyChange(() => EL4); } }

        private string eL5;
        public string EL5 { get => eL5; set { eL5 = value; NotifyOfPropertyChange(() => EL5); } }


        // EM
        private string em1;
        public string EM1 { get => em1; set { em1 = value; NotifyOfPropertyChange(() => EM1); } }

        private string em2;
        public string EM2 { get => em2; set { em2 = value; NotifyOfPropertyChange(() => EM2); } }

        private string em3;
        public string EM3 { get => em3; set { em3 = value; NotifyOfPropertyChange(() => EM3); } }

        private string em4;
        public string EM4 { get => em4; set { em4 = value; NotifyOfPropertyChange(() => EM4); } }

        private string em5;
        public string EM5 { get => em5; set { em5 = value; NotifyOfPropertyChange(() => EM5); } }
    }
}
