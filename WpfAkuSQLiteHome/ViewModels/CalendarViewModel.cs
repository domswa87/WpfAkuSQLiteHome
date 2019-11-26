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
        public CalendarViewModel(IDayViewModel dayViewModel1, IDayViewModel dayViewModel2, IDayViewModel dayViewModel3, IDayViewModel dayViewModel4, IDayViewModel dayViewModel5, IDayViewModel dayViewModel6, IDayViewModel dayViewModel7, IEventAggregator eventAggregator)
        {
            DayViewModel1 = dayViewModel1;
            DayViewModel2 = dayViewModel2;
            DayViewModel3 = dayViewModel3;
            DayViewModel4 = dayViewModel4;
            DayViewModel5 = dayViewModel5;
            DayViewModel6 = dayViewModel6;
            DayViewModel7 = dayViewModel7;
            EventAggregator = eventAggregator;
            EventAggregator.Subscribe(this);
           
            DateUpdate();
        }


        public IDayViewModel DayViewModel1 { get; }
        public IDayViewModel DayViewModel2 { get; }
        public IDayViewModel DayViewModel3 { get; }
        public IDayViewModel DayViewModel4 { get; }
        public IDayViewModel DayViewModel5 { get; }
        public IDayViewModel DayViewModel6 { get; }
        public IDayViewModel DayViewModel7 { get; }

        public IEventAggregator EventAggregator { get; }
        public DateTime NewEndDate { get; set; } = DateTime.Today;
        public DateTime NewStartDate { get; set; } = DateTime.Today;
        public string NewSummary { get; set; }
        public BindableCollection<string> GoogleEvents { get; set; } = new BindableCollection<string>();
        public List<Event> eventsList = new List<Event>();
        public GoogleCalendarAPI googleCalendarAPI = new GoogleCalendarAPI();

        private string hourStart;
        private DateTime startDate = DateTime.Now.StartOfWeek(DayOfWeek.Monday);


        public string HourStart
        {
            get => hourStart;
            set
            {
                hourStart = value;
                NotifyOfPropertyChange(() => HourStart);
            }
        }

        public DateTime StartDate
        {
            get => startDate;
            set
            {
                startDate = value;
                NotifyOfPropertyChange(() => StartDate);
                DateUpdate();
            }
        }

        private void DateUpdate()
        {
            DateTime FirstMonday = StartDate.StartOfWeek(DayOfWeek.Monday);
            DayViewModel1.ActualDay = FirstMonday;
            DayViewModel2.ActualDay = FirstMonday.AddDays(1);
            DayViewModel3.ActualDay = FirstMonday.AddDays(2);
            DayViewModel4.ActualDay = FirstMonday.AddDays(3);
            DayViewModel5.ActualDay = FirstMonday.AddDays(4);
            DayViewModel6.ActualDay = FirstMonday.AddDays(5);
            DayViewModel7.ActualDay = FirstMonday.AddDays(6);

            DayViewModel1.DateString = DayViewModel1.ActualDay.ToShortDateString(); 
            DayViewModel2.DateString = DayViewModel2.ActualDay.ToShortDateString();
            DayViewModel3.DateString = DayViewModel3.ActualDay.ToShortDateString();
            DayViewModel4.DateString = DayViewModel4.ActualDay.ToShortDateString();
            DayViewModel5.DateString = DayViewModel5.ActualDay.ToShortDateString();
            DayViewModel6.DateString = DayViewModel6.ActualDay.ToShortDateString();
            DayViewModel7.DateString = DayViewModel7.ActualDay.ToShortDateString();

            DayViewModel1.DayString = "Poniedziałek";
            DayViewModel2.DayString = "Wtorek";
            DayViewModel3.DayString = "Środa";
            DayViewModel4.DayString = "Czwartek";
            DayViewModel5.DayString = "Piątek";
            DayViewModel6.DayString = "Sobota";
            DayViewModel7.DayString = "Niedziela";

            DayViewModel1.LoadEvents();
            DayViewModel2.LoadEvents();
            DayViewModel3.LoadEvents();
            DayViewModel4.LoadEvents();
            DayViewModel5.LoadEvents();
            DayViewModel6.LoadEvents();
            DayViewModel7.LoadEvents();

        }

        public void LoadEvents()
        {
            //GoogleEvents.Clear();
            //googleCalendarAPI.RunRequst(new DateTime?(StartDate), new DateTime?(EndDate));
            //eventsList = googleCalendarAPI.LoadEventsToList();
            //foreach (var item in eventsList)
            //    GoogleEvents.Add(item.Start.DateTime.ToString() + " " + item.Summary);
        }

        public void CreateEvent()
        {
            googleCalendarAPI.CreateEvent(NewStartDate, NewEndDate, NewSummary);
        }

        public void Handle(string message)
        {
            HourStart = message;
        }

        public void Add7Days()
        {
            StartDate = StartDate.AddDays(7);
        }

        public void Sub7Days()
        {
            StartDate = StartDate.AddDays(-7);
        }
    }
}
