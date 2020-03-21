using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAkuSQLiteHome.ViewModels
{
    public class TableRestCalculatorViewModel : Screen, ITableRestCalculatorViewModel
    {

        public string H1 { get => h1; set { h1 = value; NotifyOfPropertyChange(() => H1); } }
        public string H2 { get => h2; set { h2 = value; NotifyOfPropertyChange(() => H2); } }
        public string H3 { get => h3; set { h3 = value; NotifyOfPropertyChange(() => H3); } }
        public string H4 { get => h4; set { h4 = value; NotifyOfPropertyChange(() => H4); } }
        public string H5 { get => h5; set { h5 = value; NotifyOfPropertyChange(() => H5); } }
        public string H6 { get => h6; set { h6 = value; NotifyOfPropertyChange(() => H6); } }
        public string H7 { get => h7; set { h7 = value; NotifyOfPropertyChange(() => H7); } }
        public string H8 { get => h8; set { h8 = value; NotifyOfPropertyChange(() => H8); } }
        public string H9 { get => h9; set { h9 = value; NotifyOfPropertyChange(() => H9); } }
        public string H10 { get => h10; set { h10 = value; NotifyOfPropertyChange(() => H10); } }
        public string H11 { get => h11; set { h11 = value; NotifyOfPropertyChange(() => H11); } }
        public string H12 { get => h12; set { h12 = value; NotifyOfPropertyChange(() => H12); } }
        public string H13 { get => h13; set { h13 = value; NotifyOfPropertyChange(() => H13); } }

        private string h1;
        private string h2;
        private string h3;
        private string h4;
        private string h5;
        private string h6;
        private string h7;
        private string h8;
        private string h9;
        private string h10;
        private string h11;
        private string h12;
        private string h13;

    }
}
