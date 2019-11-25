﻿using Caliburn.Micro;
using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
            LoadEventsToList();
            DisplayEventOnScreen();
        }

        private void LoadEventsToList()
        {
            EventsCollection.Clear();
            DateTime? startTime = new DateTime?(DatePickerDS);
            DateTime? endTime = new DateTime?(DatePickerDS.AddHours(23));

            GoogleEvents.Clear();
            googleCalendarAPI.RunRequst(startTime, endTime, "primary", 20);
            eventsList = googleCalendarAPI.LoadEventsToList();
        }

        private void DisplayEventOnScreen()
        {
            int height;
            int maxPosition = 0;
            int left = 0;
            int offset = 0;

            // displayEvents
            foreach (var singleEvent in eventsList)
            {
                int startHour = singleEvent.Start.DateTime.Value.Hour - 8;
                int startMin = singleEvent.Start.DateTime.Value.Minute;
                int startPosition = startHour * 60 + startMin + 85;

                int hoursDuration = singleEvent.End.DateTime.Value.Hour - singleEvent.Start.DateTime.Value.Hour;
                int minutesDuration = singleEvent.End.DateTime.Value.Minute - singleEvent.Start.DateTime.Value.Minute;
                height = hoursDuration * 60 + minutesDuration;

                int endPosition = startPosition + height;


                if (endPosition > maxPosition)
                    offset = startPosition - maxPosition;
                else
                    offset = startPosition - maxPosition - (maxPosition - endPosition);

                if (endPosition > maxPosition)
                    maxPosition = endPosition;

                if (offset < 0)
                    left += 50;
                else
                    left = 0;

                string text = singleEvent.Summary + "\r\n" + singleEvent.Start.DateTime.Value.ToString("HH:mm");
                EventButton eventButton = new EventButton { MarginDS = new Thickness(left + 10, offset, 0, 0), TextDS = text, Height = height, Width = 180 };
                EventsCollection.Add(eventButton);
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

        public void OnEventClickDS(EventButton eve)
        {
            MessageBox.Show(eve.TextDS);
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
