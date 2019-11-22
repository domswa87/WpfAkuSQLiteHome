using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using System.Windows;
using WpfAkuSQLiteHome.Models;

namespace WpfAkuSQLiteHome.ViewModels
{
    public class CalendarViewModel : Conductor<object>.Collection.AllActive, ICalendarViewModel, INotifyPropertyChangedEx, IHandle<string>
    {
        public IDayViewModel DayViewModel1 { get; }
        public IDayViewModel DayViewModel2 { get; }
        public IEventAggregator EventAggregator { get; }

        public string HourStart
        {
            get => hourStart;
            set
            {
                hourStart = value;
                NotifyOfPropertyChange(() => HourStart);
            }
        }



        public DateTime StartDate { get; set; } = new DateTime(2019, 10, 1);
        public DateTime EndDate { get; set; } = new DateTime(2019, 10, 3);
        public DateTime NewEndDate { get; set; } = DateTime.Today;
        public DateTime NewStartDate { get; set; } = DateTime.Today;
        public string NewSummary { get; set; }
        public BindableCollection<string> GoogleEvents { get; set; } = new BindableCollection<string>();
        public List<Event> eventsList = new List<Event>();
        GoogleCalendarAPI googleCalendarAPI = new GoogleCalendarAPI();
        private string hourStart;

        public CalendarViewModel(IDayViewModel dayViewModel1, IDayViewModel dayViewModel2, IEventAggregator eventAggregator)
        {
            DayViewModel1 = dayViewModel1;
            DayViewModel2 = dayViewModel2;
            EventAggregator = eventAggregator;
            EventAggregator.Subscribe(this);

            DayViewModel1.DayString = "Monday";
            DayViewModel2.DayString = "Tuesday";
        }


        public void LoadEvents()
        {
            GoogleEvents.Clear();
            googleCalendarAPI.RunRequst(new DateTime?(StartDate), new DateTime?(EndDate));
            eventsList = googleCalendarAPI.LoadEventsToList();
            foreach (var item in eventsList)
                GoogleEvents.Add(item.Start.DateTime.ToString() + " " + item.Summary);
        }

        public void CreateEvent()
        {
            googleCalendarAPI.CreateEvent(NewStartDate, NewEndDate, NewSummary);
        }

        public void Handle(string message)
        {
            HourStart = message;
        }
    }
}
