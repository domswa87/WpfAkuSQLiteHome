using Caliburn.Micro;
using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAkuSQLiteHome.Models;

namespace WpfAkuSQLiteHome.ViewModels
{
    public class DayViewModel : Screen, IDayViewModel
    {
        public DayViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
        }

        public string MarginTextBox { get; set; }

        // Config Properties
        public int StartHour { get; set; } = 8;
        public int QuantityOfHours { get; set; } = 14;

        // Properies
        public BindableCollection<string> GoogleEvents { get; set; } = new BindableCollection<string>();
        public List<Event> eventsList = new List<Event>();
        public GoogleCalendarAPI googleCalendarAPI = new GoogleCalendarAPI();

        public ObservableCollection<EventButton> EventsCollection { get; set; } = new ObservableCollection<EventButton>();
        public ObservableCollection<Hour> HoursCollection { get; set; } = new ObservableCollection<Hour>();
        public double HourCounter { get; set; }
        public IEventAggregator EventAggregator { get; }
        public bool IsWindowBox { get; set; } = false;
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

        public void OnHoursClick(Hour hour)
        {
            HourString = hour.Content;
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

        public void ConfirmDS()
        {
            VisibilityProp = Visibility.Hidden;
            MessageBox.Show("Task is created");
        }


        public void LoadEvents()
        {
            EventsCollection.Clear();
            DateTime? startTime = new DateTime?(DatePickerDS);
            DateTime? endTime = new DateTime?(DatePickerDS.AddHours(23));

            GoogleEvents.Clear();
            googleCalendarAPI.RunRequst(startTime, endTime, "primary", 20);
            eventsList = googleCalendarAPI.LoadEventsToList();

            int height;
            int counter =0;
            int endPositionOfPreviousEvent = 0;

            // displayEvents
            foreach (var item in eventsList)
            {
                int hoursDuration = item.End.DateTime.Value.Hour - item.Start.DateTime.Value.Hour;
                int minutesDuration = item.End.DateTime.Value.Minute - item.Start.DateTime.Value.Minute;
                height = hoursDuration * 60 + minutesDuration;

                int startHour = item.Start.DateTime.Value.Hour - 8;
                int startMin = item.Start.DateTime.Value.Minute;
                int startPosition = startHour * 60 + startMin + 85;

          
                int differenceBetweenEvents = startPosition - endPositionOfPreviousEvent;

                int endPosition = startPosition + height;


                endPositionOfPreviousEvent = endPosition;



                EventButton eventButton = new EventButton { MarginDS = new Thickness(0, differenceBetweenEvents, 0, 0), TextDS = item.Summary, Height = height, Width = 180 };
                EventsCollection.Add(eventButton);
                counter++;
            }
           
        }

        public void LoadHours()
        {
            for (int i = 0; i < QuantityOfHours; i++)
            {
                string hourString = new DateTime(1, 1, 1, StartHour, 0, 0).AddHours(HourCounter).ToString("HH:mm");
                Hour hour = new Hour { Content = hourString, Height = 60, Width = 260 };
                HoursCollection.Add(hour);
                HourCounter++;
            }
        }
    }

    public class EventButton
    {
        public Thickness MarginDS { get; set; }
        public string TextDS { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }

    public class Hour
    {
        public string Content { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
