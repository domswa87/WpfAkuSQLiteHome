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
    public class CalendarViewModel : Screen, ICalendarViewModel, INotifyPropertyChangedEx
    {
        public List<Event> eventsList = new List<Event>();

        private string one;
        private string two;
        private string three;
 

        public string One { get => one; set { one = value; NotifyOfPropertyChange(() => One); } }
        public string Two { get => two; set { two = value; NotifyOfPropertyChange(() => Two); } }
        public string Three { get => three; set { three = value; NotifyOfPropertyChange(() => Three); } }




        public void LoadEvents()
        {
            GoogleCalendarAPI googleCalendarAPI = new GoogleCalendarAPI();

            DateTime? min = new DateTime?(new DateTime(2019, 10, 01));
            DateTime? max = new DateTime?(new DateTime(2019, 12, 01));

            googleCalendarAPI.RunRequst(min, max);
            eventsList = googleCalendarAPI.LoadEventsToList();
            One = eventsList[0].Start.DateTime.Value.Hour.ToString() + " " + eventsList[0].Summary;
            Two = eventsList[1].Start.DateTime.Value.Hour.ToString() + " " + eventsList[1].Summary;
            Three = eventsList[2].Start.DateTime.Value.Hour.ToString() + " " + eventsList[2].Summary;
        }
    }
}
