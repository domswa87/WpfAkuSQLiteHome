using Caliburn.Micro;
using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfAkuSQLiteHome.Models;

namespace WpfAkuSQLiteHome.ViewModels
{
    public class DayViewModel : Screen, IDayViewModel
    {
        public DayViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            LoadHours();
            LoadEvents();
        }

        public string MarginTextBox { get; set; }

        // Config Properties
        public int StartHour { get; set; } = 8;
        public int QuantityOfHours { get; set; } = 14;
        public int HourHeight { get; set; } = 60;
        public int HourWidth { get; set; } = 260;
        public int DistanceFromTopToFirstHour { get; set; } = 45;

        // Properies
        public ObservableCollection<EventButton> EventsCollection { get; set; } = new ObservableCollection<EventButton>();
        public ObservableCollection<Hour> HoursCollection { get; set; } = new ObservableCollection<Hour>();
        public List<Event> eventsList = new List<Event>();
        public int BelowLineMarginPosion { get; set; }
        public GoogleCalendarAPI googleCalendarAPI = new GoogleCalendarAPI();
        public double HourCounter { get; set; }
        public IEventAggregator EventAggregator { get; }
        public bool IsWindowBox { get; set; } = false;
        public string DayString { get; set; }
        public Hour ActiveHour { get; set; }
        public EventButton ActiceEventButton { get; set; }
       
        private DateTime actualDay;
        private Thickness marginConfirmationWindow = new Thickness(0, 0, 0, 0);
        private Visibility visibilityProp = Visibility.Hidden;
        private Visibility visibilityDeleteButton = Visibility.Hidden;
        private string hourString;
        private string dayString;
        private string startHourCreateEvent;
        private string summaryCreateEvent;
        private string _propButtonContentCreateModify = "Utwórz";

        public DateTime ActualDay
        {
            get => actualDay; set
            {
                actualDay = value;
                NotifyOfPropertyChange(() => ActualDay);
            }
        }

        public string StartHourCreateEvent
        {
            get { return startHourCreateEvent; }
            set
            {
                startHourCreateEvent = value;
                NotifyOfPropertyChange(() => StartHourCreateEvent);
            }
        }

        private string endHourCreateEvent;
        public string EndHourCreateEvent
        {
            get { return endHourCreateEvent; }
            set
            {
                endHourCreateEvent = value;
                NotifyOfPropertyChange(() => EndHourCreateEvent);
            }
        }


       

        public string SummaryCreateEvent
        {
            get { return summaryCreateEvent; }
            set
            {
                summaryCreateEvent = value;
                NotifyOfPropertyChange(() => SummaryCreateEvent);
            }
        }

        public string DateString
        {
            get => dayString;
            set
            {
                dayString = value;
                NotifyOfPropertyChange(() => DateString);
            }
        }

        public Thickness MarginConfirmationWindow
        {
            get => marginConfirmationWindow; set
            {
                marginConfirmationWindow = value;
                NotifyOfPropertyChange(() => MarginConfirmationWindow);
            }
        }

        public Visibility VisibilityDeleteButton
        {
            get => visibilityDeleteButton;
            set
            {
                visibilityDeleteButton = value;
                NotifyOfPropertyChange(() => VisibilityDeleteButton);
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

        public string PropButtonContentCreateModify
        {
            get => _propButtonContentCreateModify;
            set
            {
                _propButtonContentCreateModify = value;
                NotifyOfPropertyChange(() => PropButtonContentCreateModify);
            }
        }

        // Methods

        public void LoadHours()
        {
            for (int i = 0; i < QuantityOfHours; i++)
            {
                string hourString = new DateTime(1, 1, 1, StartHour, 0, 0).AddHours(HourCounter).ToString("HH:mm");
                Hour hour = new Hour { HourTime = new DateTime(1, 1, 1, StartHour + i, 0, 0), HourString = hourString, Height = HourHeight, Width = HourWidth };
                HoursCollection.Add(hour);
                HourCounter++;
            }
        }


        public void OnHoursClick(Hour hour)
        {
            ActiveHour = hour;
            int offset = ((ActiveHour.HourTime.Hour - 8) * 60) + DistanceFromTopToFirstHour;

            MarginConfirmationWindow = new Thickness(0, offset, 0, 0);

            PropButtonContentCreateModify = "Utwórz";
            SummaryCreateEvent = null;
            VisibilityProp = Visibility.Visible;

            StartHourCreateEvent = ActiveHour.HourTime.ToString("HH:mm");
            EndHourCreateEvent = hour.HourTime.AddHours(1).ToString("HH:mm");
            VisibilityDeleteButton = Visibility.Hidden;


            // MessageBox.Show(hour.HourString);


            //int startPosition = ((hour.HourInt - 8) * 60) + 85;
            //int offset = startPosition - BelowLineMarginPosion;
            //EventButton eventButton = new EventButton { MarginDS = new Thickness(10, offset, 0, 0), TextDS = "", Height = 60, Width = 180 };
            //EventsCollection.Add(eventButton);

            ////EventAggregator.PublishOnUIThread(HourString);

            ////MessageBoxResult result = MessageBox.Show($"Do you want to create new event ? \r\n Day:{DayString} \r\n Hour {HourString}",
            ////                             "Confirmation",
            //                             MessageBoxButton.YesNo,
            //                             MessageBoxImage.Question);
            //if (result == MessageBoxResult.Yes)
            //{
            //    VisibilityProp = Visibility.Visible;
            //}
            //else
            //{
            //    VisibilityProp = Visibility.Hidden;
            //}
        }

        public void OnEventClickDS(EventButton eve)
        {
            VisibilityDeleteButton = Visibility.Visible;
            ActiceEventButton = eve;
            int offset = ((eve.startTime.Hour - 8) * 60) + DistanceFromTopToFirstHour;
            MarginConfirmationWindow = new Thickness(0, offset, 0, 0);
            VisibilityProp = Visibility.Visible;

            StartHourCreateEvent = eve.startTime.ToString("HH:mm");
            EndHourCreateEvent = eve.endTime.ToString("HH:mm");
            SummaryCreateEvent = eve.TextDS.Split(new[] { '\r', '\n' }).FirstOrDefault();

            PropButtonContentCreateModify = "Zamień";

        }

        public void DeleteEvent()
        {
            googleCalendarAPI.DeleteEventByID(ActiceEventButton.GoogleEvent.Id);
            VisibilityProp = Visibility.Hidden;
            MessageBox.Show("Event is deleted");
            LoadEvents();
        }



        public void CancelDS()
        {
            VisibilityProp = Visibility.Hidden;
        }

        public void ConfirmEditButtonClick()
        {
            if (PropButtonContentCreateModify == "Utwórz")
            {
                int hour = ActiveHour.HourTime.Hour;
                DateTime startTime = new DateTime(actualDay.Year, actualDay.Month, actualDay.Day, hour, 0, 0);
                DateTime endTime = new DateTime(actualDay.Year, actualDay.Month, actualDay.Day, hour + 1, 0, 0);


                googleCalendarAPI.CreateEvent(startTime, endTime, SummaryCreateEvent);

                VisibilityProp = Visibility.Hidden;
                LoadEvents();
                MessageBox.Show("Task is created");
            }
            else if(PropButtonContentCreateModify == "Zamień")
            {
                googleCalendarAPI.DeleteEventByID(ActiceEventButton.GoogleEvent.Id);
                MessageBox.Show("Task will be modify");

            }
         
        }


        public void LoadEvents()
        {
            LoadEventsToList();
            DisplayEventOnScreen();
        }

        private void LoadEventsToList()
        {
            EventsCollection.Clear();
            DateTime? startTime = new DateTime?(ActualDay);
            DateTime? endTime = new DateTime?(ActualDay.AddHours(23));

            googleCalendarAPI.RunRequst(startTime, endTime, "primary", 20);
            eventsList = googleCalendarAPI.LoadEventsToList();
        }

        private void DisplayEventOnScreen()
        {
            int height;
            int maxPosition = 0;
            int left = 0;
            int offset = 0;

            foreach (var singleEvent in eventsList)
            {
                int startHour = singleEvent.Start.DateTime.Value.Hour - 8;
                int startMin = singleEvent.Start.DateTime.Value.Minute;
                int startPosition = startHour * 60 + startMin + DistanceFromTopToFirstHour;

                int hoursDuration = singleEvent.End.DateTime.Value.Hour - singleEvent.Start.DateTime.Value.Hour;
                int minutesDuration = singleEvent.End.DateTime.Value.Minute - singleEvent.Start.DateTime.Value.Minute;
                height = hoursDuration * 60 + minutesDuration;

                int endPosition = startPosition + height;


                if (endPosition > maxPosition)
                    offset = startPosition - maxPosition;
                else
                    offset = startPosition - maxPosition - (maxPosition - endPosition);

                if (endPosition > maxPosition)
                {
                    maxPosition = endPosition;
                    BelowLineMarginPosion = maxPosition;
                }

                if (offset < 0)
                    left += 50;
                else
                    left = 0;

                string text = singleEvent.Summary + "\r\n" + singleEvent.Start.DateTime.Value.ToString("HH:mm");
                EventButton eventButton = new EventButton { MarginButtonEvent = new Thickness(left + 10, offset, 0, 0), TextDS = text, Height = height, Width = 180,
                                                            startTime = new DateTime(1,1,1,singleEvent.Start.DateTime.Value.Hour, singleEvent.Start.DateTime.Value.Minute,0),
                                                            endTime = new DateTime(1,1,1,singleEvent.End.DateTime.Value.Hour, singleEvent.End.DateTime.Value.Minute,0),
                                                            GoogleEvent = singleEvent};
                EventsCollection.Add(eventButton);
            }
        }

    

    }

    public class EventButton
    {
        public Event GoogleEvent { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public Thickness MarginButtonEvent { get; set; }
        public string TextDS { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }

    public class Hour
    {
        public DateTime HourTime { get; set; }
        public string HourString { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
