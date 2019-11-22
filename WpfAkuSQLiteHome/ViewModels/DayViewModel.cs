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
        public DayViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
        }

        // Properies

        public IEventAggregator EventAggregator { get; }
        public bool IsWindowBox { get; set; } = false;
        public string DayString { get; set; }
        public int ItemIndex { get; set; }

        private Thickness marginDS = new Thickness(50, 20, 0, 0);
        private Visibility visibilityProp = Visibility.Hidden;
        private string hourString;
    

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

        public string HourString
        {
            get { return hourString; }
            set
            {
                hourString = value;
                NotifyOfPropertyChange(() => HourString);
            }
        }




        // Methods

        public void MethodDS()
        {
            if (ItemIndex == 0)
                HourString = "8:00";
            else if (ItemIndex == 1)
                HourString = "9:00";
            else if (ItemIndex == 2)
                HourString = "10:00";
            else if (ItemIndex == 3)
                HourString = "11:00";
            else if (ItemIndex == 4)
                HourString = "12:00";

            EventAggregator.PublishOnUIThread(HourString);

            MessageBoxResult result = MessageBox.Show($"Do you want to create new event ? \r\n Day:{DayString} \r\n Hour {HourString}",
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
