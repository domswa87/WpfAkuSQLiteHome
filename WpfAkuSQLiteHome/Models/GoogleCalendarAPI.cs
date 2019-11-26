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

namespace WpfAkuSQLiteHome.Models
{
    public class GoogleCalendarAPI
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/calendar-dotnet-quickstart.json
        static string[] Scopes = { CalendarService.Scope.Calendar };
        static string ApplicationName = "Google Calendar API .NET Quickstart";

        public Events events;
        CalendarService service = CreateService();

        public void RunRequst(DateTime? timeMin, DateTime? timeMax, string calendarName = "primary", int maxResults = 20)
        {
            EventsResource.ListRequest request = service.Events.List(calendarName);
            request.TimeMin = timeMin;
            request.TimeMax = timeMax;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = maxResults;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            events = request.Execute();
        }

        private static CalendarService CreateService()
        {
            UserCredential credential;

            using (var stream =
               new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            return service;
        }

        public List<Event> LoadEventsToList()
        {
            List<Event> list = new List<Event>();

            if (events.Items != null && events.Items.Count > 0)
            {
                string[] table = new string[10];
                foreach (var eventItem in events.Items)
                {
                    string when = eventItem.Start.DateTime.ToString();
                    if (String.IsNullOrEmpty(when))
                    {
                        when = eventItem.Start.Date;
                    }
                    list.Add(eventItem);
                }
            }
            return list;
        }

        public void CreateEvent(DateTime startDate, DateTime endDate, string summary)
        {
            var ev = new Event();

            EventDateTime start = new EventDateTime();
            start.DateTime = startDate;
            EventDateTime end = new EventDateTime();
            end.DateTime = endDate;

            ev.Start = start;
            ev.End = end;
            ev.Summary = summary;

            var calendarId = "primary";
            Event recurringEvent = service.Events.Insert(ev, calendarId).Execute();
        }

        public void DeleteEventByID(string EventID)
        {
            var calendarId = "primary";
            service.Events.Delete(calendarId, EventID).Execute();
        }
    }
}
