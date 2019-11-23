using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            EventsCollection = new ObservableCollection<EventButton>();
        }

        // Properies

        public ObservableCollection<EventButton> EventsCollection { get; set; }

        public IEventAggregator EventAggregator { get; }
        public bool IsWindowBox { get; set; } = false;
        public int ItemIndex { get; set; }
        public string DayString { get; set; }

        private Thickness marginDS = new Thickness(50, 20, 0, 0);
        private Visibility visibilityProp = Visibility.Hidden;
        private string hourString;
        private DateTime dataPickerDS;
        private string dayString;

        public string DateString
        {
            get => dayString;
            set
            {
                dayString = value;
                NotifyOfPropertyChange(() => DateString);
            }
        }

        public Thickness MarginDS
        {
            get => marginDS; set
            {
                marginDS = value;
                NotifyOfPropertyChange(() => MarginDS);
            }
        }

        public DateTime DatePickerDS
        {
            get => dataPickerDS; set
            {
                dataPickerDS = value;
                NotifyOfPropertyChange(() => DatePickerDS);
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
            else if (ItemIndex == 5)
                HourString = "13:00";
            else if (ItemIndex == 6)
                HourString = "14:00";
            else if (ItemIndex == 7)
                HourString = "15:00";
            else if (ItemIndex == 8)
                HourString = "16:00";
            else if (ItemIndex == 9)
                HourString = "17:00";
            else if (ItemIndex == 10)
                HourString = "18:00";
            else if (ItemIndex == 11)
                HourString = "19:00";
            else if (ItemIndex == 12)
                HourString = "20:00";
            else if (ItemIndex == 13)
                HourString = "21:00";

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


        public void LoadDayEvents()
        {
            EventButton eventButton = new EventButton { MarginDS = new Thickness(10, 10, 10, 10), TextDS = "JEEEEEAH", Height=50, Width=50 };
            EventsCollection.Add(eventButton);
        }
    }

    public class EventButton
    {
        public Thickness MarginDS { get; set; }
        public string TextDS { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }





    }
}
