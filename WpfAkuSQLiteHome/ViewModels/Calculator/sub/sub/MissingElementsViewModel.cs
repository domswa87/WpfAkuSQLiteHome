using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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


        // EL UnderLine
        private TextDecorationCollection eL1Underline;
        public TextDecorationCollection EL1Underline { get => eL1Underline; set { eL1Underline = value; NotifyOfPropertyChange(() => EL1Underline); } }

        private TextDecorationCollection eL2Underline;
        public TextDecorationCollection EL2Underline { get => eL2Underline; set { eL2Underline = value; NotifyOfPropertyChange(() => EL2Underline); } }

        private TextDecorationCollection eL3Underline;
        public TextDecorationCollection EL3Underline { get => eL3Underline; set { eL3Underline = value; NotifyOfPropertyChange(() => EL3Underline); } }

        private TextDecorationCollection eL4Underline;
        public TextDecorationCollection EL4Underline { get => eL4Underline; set { eL4Underline = value; NotifyOfPropertyChange(() => EL4Underline); } }

        private TextDecorationCollection eL5Underline;
        public TextDecorationCollection EL5Underline { get => eL5Underline; set { eL5Underline = value; NotifyOfPropertyChange(() => EL5Underline); } }


        // EM UnderLine
        private TextDecorationCollection em1Underline;
        public TextDecorationCollection EM1Underline { get => em1Underline; set { em1Underline = value; NotifyOfPropertyChange(() => EM1Underline); } }

        private TextDecorationCollection em2Underline;
        public TextDecorationCollection EM2Underline { get => em2Underline; set { em2Underline = value; NotifyOfPropertyChange(() => EM2Underline); } }

        private TextDecorationCollection em3Underline;
        public TextDecorationCollection EM3Underline { get => em3Underline; set { em3Underline = value; NotifyOfPropertyChange(() => EM3Underline); } }

        private TextDecorationCollection em4Underline;
        public TextDecorationCollection EM4Underline { get => em4Underline; set { em4Underline = value; NotifyOfPropertyChange(() => EM4Underline); } }

        private TextDecorationCollection em5Underline;
        public TextDecorationCollection EM5Underline { get => em5Underline; set { em5Underline = value; NotifyOfPropertyChange(() => EM5Underline); } }

        //MissingOrgans
        private string missingOrgans;
        public string MissingOrgans { get => missingOrgans; set { missingOrgans = value; NotifyOfPropertyChange(() => MissingOrgans); } }
    }
}
