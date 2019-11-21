using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAkuSQLiteHome.ViewModels
{
    public class DayViewModel : Screen, IDayViewModel
    {
        private string itemValue;
        private Visibility visibilityProp = Visibility.Hidden;
        private Thickness marginDS = new Thickness(50, 20, 0, 0);

        public Thickness MarginDS
        {
            get => marginDS; set
            {
                marginDS = value;
                NotifyOfPropertyChange(() => MarginDS);
            }
        }
        public Visibility VisibilityProp
        {
            get => visibilityProp;
            set
            {
                visibilityProp = value;
                NotifyOfPropertyChange(() => VisibilityProp);
            }
        }
        public IEventAggregator EventAggregator { get; }
        public bool IsWindowBox { get; set; } = false;

        public DayViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
        }



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

            MessageBoxResult result = MessageBox.Show("Do you want to create new event ? \r\n aaa \r\n ddd",
                                         "Confirmation",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                VisibilityProp = Visibility.Visible;
            }
            else
            {
                VisibilityProp = Visibility.Hidden;
            }
        }


        public void CancelDS()
        {
            VisibilityProp = Visibility.Hidden;
            MessageBox.Show("CancelDS");
        }

        public void OKDS()
        {
            VisibilityProp = Visibility.Hidden;
            MessageBox.Show("Task is created");
        }


        public void marginUP()
        {
            double n = MarginDS.Top;
            n += 10;
            MarginDS = new Thickness(50, n, 0, 0);

        }
    }
}
