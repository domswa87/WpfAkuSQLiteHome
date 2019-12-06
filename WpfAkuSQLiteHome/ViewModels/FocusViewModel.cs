﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAkuSQLiteHome.ViewModels
{
    public class FocusViewModel : Screen, IFocusViewModel
    {
        private bool isTxt1Focused = false;
        private bool isTxt1Focused1;

        public string Txt1 { get; set; } = "aaa";
        public string Txt2 { get; set; } = "bbb";
        public string Txt3 { get; set; } = "ccc";


        public bool IsTxt1Focused
        {
            get
            {
                return isTxt1Focused1;
            }

            set
            {
                isTxt1Focused1 = value;
                NotifyOfPropertyChange(() => IsTxt1Focused);
            }
        }

        public bool IsTxt2Focused { get; set; }
        public bool IsTxt3Focused { get; set; }

        public void But1()
        {
            IsTxt1Focused = true;
        }

        public void But2()
        {
            IsTxt2Focused = true;
        }

        public void But3()
        {
            IsTxt3Focused = true;
        }





    }
}
