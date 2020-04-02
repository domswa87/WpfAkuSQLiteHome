using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAkuSQLiteHome.ViewModels
{
    class UnlikeQiViewModel : Screen, IUnlikeQiViewModel
    {

        //BIG LETTERS

        private string bigLetterInput;
        public string BigLetterInput { get => bigLetterInput; set { bigLetterInput = value; NotifyOfPropertyChange(() => BigLetterInput); } }

        private string bigLetterUp;
        public string BigLetterUp { get => bigLetterUp; set { bigLetterUp = value; NotifyOfPropertyChange(() => BigLetterUp); } }

        private string bigLetterDown;
        public string BigLetterDown { get => bigLetterDown; set { bigLetterDown = value; NotifyOfPropertyChange(() => BigLetterDown); } }

        //SMALL LETTERS

        private string smallLetterInput;
        public string SmallLetterInput { get => smallLetterInput; set { smallLetterInput = value; NotifyOfPropertyChange(() => SmallLetterInput); } }

        private string smallLetterUp;
        public string SmallLetterUp { get => smallLetterUp; set { smallLetterUp = value; NotifyOfPropertyChange(() => SmallLetterUp); } }

        private string smallLetterDown;
        public string SmallLetterDown { get => smallLetterDown; set { smallLetterDown = value; NotifyOfPropertyChange(() => SmallLetterDown); } }

        private string smallLetterDownR;
        public string SmallLetterDownR { get => smallLetterDownR; set { smallLetterDownR = value; NotifyOfPropertyChange(() => SmallLetterDownR); } }

        private string smallLetterDownL;
        public string SmallLetterDownL { get => smallLetterDownL; set { smallLetterDownL = value; NotifyOfPropertyChange(() => SmallLetterDownL); } }


    }
}
