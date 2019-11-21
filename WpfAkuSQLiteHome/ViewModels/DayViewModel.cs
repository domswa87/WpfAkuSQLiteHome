using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAkuSQLiteHome.ViewModels
{
    public class DayViewModel : Screen, IDayViewModel
    {
        public IEventAggregator EventAggregator { get; }

        public DayViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
        }

        private string itemValue;

        public int ItemIndex { get; set; }
        public string ItemValue
        {
            get { return itemValue; }
            set
            {
                itemValue = value;
                NotifyOfPropertyChange(() => ItemValue);
            }
        }


        public void MethodDS()
        {
            if (ItemIndex == 0)
                ItemValue = "8:00";
            else if (ItemIndex == 1)
                ItemValue = "9:00";
            else if (ItemIndex == 2)
                ItemValue = "10:00";
            else if (ItemIndex == 3)
                ItemValue = "11:00";
            else if (ItemIndex == 4)
                ItemValue = "12:00";

            EventAggregator.PublishOnUIThread(ItemValue);
        }

    }
}
