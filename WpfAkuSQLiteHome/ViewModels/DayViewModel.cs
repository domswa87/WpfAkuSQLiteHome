using Caliburn.Micro;
using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfAkuSQLiteHome.Models;

namespace WpfAkuSQLiteHome.ViewModels
{
    public class DayViewModel : Screen, IDayViewModel
    {
        public DayViewModel()
        {
            LoadHours();
            LoadEvents();
        }

        public string MarginTextBox { get; set; }

        // Config Properties
        public int StartHour { get; set; } = 8;
        public int QuantityOfHours { get; set; } = 14;
        public int HourHeight { get; set; } = 48;
        public int HourWidth { get; set; } = 190;
        public int DistanceFromTopToFirstHour { get; set; } = 45;
        public int OffsetForOverlappingEvents { get; set; } = 30;
        public int LeftEventMargin { get; set; } = 20;

        // Properies
        public ObservableCollection<EventButton> EventsCollection { get; set; } = new ObservableCollection<EventButton>();
        public ObservableCollection<Hour> HoursCollection { get; set; } = new ObservableCollection<Hour>();
        public List<Event> eventsList = new List<Event>();
        public GoogleCalendarAPI googleCalendarAPI = new GoogleCalendarAPI();
        public double HourCounter { get; set; }
        public string DayString { get; set; }
        public Hour ActiveHour { get; set; }
        public EventButton ActiceEventButton { get; set; }

        private DateTime actualDay;
        private Thickness marginConfirmationWindow = new Thickness(0, 0, 0, 0);
        private Visibility visibilityConfirmationWindow = Visibility.Hidden;
        private Visibility visibilityDeleteAndEditButtons = Visibility.Hidden;
        private Visibility visibilityokButton = Visibility.Hidden;
        private string hourString;
        private string dayString;
        private string startHourCreateEvent;
        private string endHourCreateEvent;
        private string summaryCreateEvent;
        private bool isModifyButtonEnabled;

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
                IsModifyButtonEnabled = true;
            }
        }

        public string EndHourCreateEvent
        {
            get { return endHourCreateEvent; }
            set
            {
                endHourCreateEvent = value;
                NotifyOfPropertyChange(() => EndHourCreateEvent);
                IsModifyButtonEnabled = true;
            }
        }

        public string SummaryCreateEvent
        {
            get { return summaryCreateEvent; }
            set
            {
                summaryCreateEvent = value;
                NotifyOfPropertyChange(() => SummaryCreateEvent);
                IsModifyButtonEnabled = true;
            }
        }

        public string DateString{get => dayString;set{dayString = value;NotifyOfPropertyChange(() => DateString);}}
        public Thickness MarginConfirmationWindow{get => marginConfirmationWindow; set{ marginConfirmationWindow = value;NotifyOfPropertyChange(() => MarginConfirmationWindow);}}
        public Visibility VisibilityDeleteAndEditButtons{get => visibilityDeleteAndEditButtons;set{visibilityDeleteAndEditButtons = value;NotifyOfPropertyChange(() => VisibilityDeleteAndEditButtons);}}
        public Visibility VisibilityOkButton { get => visibilityokButton; set { visibilityokButton = value; NotifyOfPropertyChange(() => VisibilityOkButton); } }

        public Visibility VisibilityConfirmationWindow
        {
            get => visibilityConfirmationWindow;
            set
            {
                visibilityConfirmationWindow = value;
                NotifyOfPropertyChange(() => VisibilityConfirmationWindow);
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

        public bool IsModifyButtonEnabled
        {
            get => isModifyButtonEnabled;
            set
            {
                isModifyButtonEnabled = value;
                NotifyOfPropertyChange(() => IsModifyButtonEnabled);
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
        public void LoadEvents()
        {
            LoadEventsToList();
            DisplayEventOnScreen();
        }


        public void OnHoursClick(Hour hour)
        {
            ActiveHour = hour;
            int offset = ((ActiveHour.HourTime.Hour - 8) * HourHeight) + DistanceFromTopToFirstHour;

            MarginConfirmationWindow = new Thickness(0, offset, 0, 0);

            SummaryCreateEvent = null;
            VisibilityConfirmationWindow = Visibility.Visible;

            StartHourCreateEvent = ActiveHour.HourTime.ToString("HH:mm");
            EndHourCreateEvent = hour.HourTime.AddHours(1).ToString("HH:mm");
            VisibilityDeleteAndEditButtons = Visibility.Hidden;
            VisibilityOkButton = Visibility.Visible;
        }

        public void OnEventClickDS(EventButton eve)
        {
            VisibilityDeleteAndEditButtons = Visibility.Visible;
            ActiceEventButton = eve;
            int offset = ((eve.startTime.Hour - 8) * HourHeight) + DistanceFromTopToFirstHour;
            MarginConfirmationWindow = new Thickness(0, offset, 0, 0);
            VisibilityConfirmationWindow = Visibility.Visible;
            VisibilityOkButton = Visibility.Hidden;

            StartHourCreateEvent = eve.startTime.ToString("HH:mm");
            EndHourCreateEvent = eve.endTime.ToString("HH:mm");
            SummaryCreateEvent = eve.TextDS.Split(new[] { '\r', '\n' }).FirstOrDefault();
            IsModifyButtonEnabled = false;
        }


        public void CancelButtonClick()
        {
            VisibilityConfirmationWindow = Visibility.Hidden;
        }

        public void CreateButtonClick()
        {
            int startHour, startMinute, endHour, endMinute;
            bool isCorrectFormat;
            GetTime(out startHour, out startMinute, out endHour, out endMinute, out isCorrectFormat);

            if (isCorrectFormat)
            {
                DateTime startTime = new DateTime(actualDay.Year, actualDay.Month, actualDay.Day, startHour, startMinute, 0);
                DateTime endTime = new DateTime(actualDay.Year, actualDay.Month, actualDay.Day, endHour, endMinute, 0);

                googleCalendarAPI.CreateEvent(startTime, endTime, SummaryCreateEvent);

                VisibilityConfirmationWindow = Visibility.Hidden;
                LoadEvents();
                MessageBox.Show("Task is created");
            }
            else
                MessageBox.Show("Wrong date format");
        }

        public void DeleteEventButtonClick()
        {
            googleCalendarAPI.DeleteEventByID(ActiceEventButton.GoogleEvent.Id);
            VisibilityConfirmationWindow = Visibility.Hidden;
            MessageBox.Show("Event is deleted");
            LoadEvents();
        }

        public void EditButtonClick()
        {
            int startHour, startMinute, endHour, endMinute;
            bool isCorrectFormat;
            GetTime(out startHour, out startMinute, out endHour, out endMinute, out isCorrectFormat);

            if (isCorrectFormat)
            {
                ActiceEventButton.GoogleEvent.Summary = SummaryCreateEvent;
                ActiceEventButton.GoogleEvent.Start.DateTime = new DateTime(ActualDay.Year, ActualDay.Month, actualDay.Day, startHour, startMinute, 0);
                ActiceEventButton.GoogleEvent.End.DateTime = new DateTime(ActualDay.Year, ActualDay.Month, actualDay.Day, endHour, endMinute, 0);

                googleCalendarAPI.UpdateEvent(ActiceEventButton.GoogleEvent, ActiceEventButton.GoogleEvent.Id);

                VisibilityConfirmationWindow = Visibility.Hidden;
                LoadEvents();
                MessageBox.Show("Task was modify");
            }
            else
                MessageBox.Show("Wrong date format");
        }

        private void GetTime(out int startHour, out int startMinute, out int endHour, out int endMinute, out bool isCorrectFormat)
        {
            isCorrectFormat = false;
            Regex exTime = new Regex(@"(?<hour>\d{2}):?(?<min>\d{2})");
            Match matchStart = exTime.Match(StartHourCreateEvent);
            Match matchEnd = exTime.Match(EndHourCreateEvent);

            if (matchStart.Success && matchEnd.Success)
            {
                isCorrectFormat = true;
                startHour = int.Parse(matchStart.Groups["hour"].Value);
                startMinute = int.Parse(matchStart.Groups["min"].Value);
                endHour = int.Parse(matchEnd.Groups["hour"].Value);
                endMinute = int.Parse(matchEnd.Groups["min"].Value);

            }
            else
            {
                startHour = 1;
                startMinute = 1;
                endHour = 1;
                endMinute = 1;
            }
            
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
                int minuteCalculation = (startMin / 5) * 4;
                int startPosition = startHour * HourHeight + minuteCalculation + DistanceFromTopToFirstHour;

                int hoursDuration = singleEvent.End.DateTime.Value.Hour - singleEvent.Start.DateTime.Value.Hour;
                int minutesDuration = singleEvent.End.DateTime.Value.Minute - singleEvent.Start.DateTime.Value.Minute;
                int minutesDuationCalculation = (minutesDuration / 5) * 4;
                height = hoursDuration * HourHeight + minutesDuationCalculation;

                int endPosition = startPosition + height;

                if (endPosition > maxPosition)
                    offset = startPosition - maxPosition;
                else
                    offset = startPosition - maxPosition - (maxPosition - endPosition);

                if (endPosition > maxPosition)
                    maxPosition = endPosition;

                if (offset < 0)
                    left += OffsetForOverlappingEvents;
                else
                    left = 0;

                string text = singleEvent.Summary + "\r\n" + singleEvent.Start.DateTime.Value.ToString("HH:mm");


                EventButton eventButton;
                if (left>0)
                {
                    eventButton = new EventButton
                    {
                        MarginButtonEvent = new Thickness(left, offset, 0, 0),
                        TextDS = text,
                        Height = height,
                        Width = 180,
                        startTime = new DateTime(1, 1, 1, singleEvent.Start.DateTime.Value.Hour, singleEvent.Start.DateTime.Value.Minute, 0),
                        endTime = new DateTime(1, 1, 1, singleEvent.End.DateTime.Value.Hour, singleEvent.End.DateTime.Value.Minute, 0),
                        GoogleEvent = singleEvent
                    };
                }
                else
                {
                    eventButton = new EventButton
                    {
                        MarginButtonEvent = new Thickness(LeftEventMargin, offset, 0, 0),
                        TextDS = text,
                        Height = height,
                        Width = 180,
                        startTime = new DateTime(1, 1, 1, singleEvent.Start.DateTime.Value.Hour, singleEvent.Start.DateTime.Value.Minute, 0),
                        endTime = new DateTime(1, 1, 1, singleEvent.End.DateTime.Value.Hour, singleEvent.End.DateTime.Value.Minute, 0),
                        GoogleEvent = singleEvent
                    };
                }
        
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
