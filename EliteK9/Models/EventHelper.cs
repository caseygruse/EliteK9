using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EliteK9.Models
{
    public static class EventHelper
    {
        public static List<CalendarEvents> OrderEvents()
        {
            List<CalendarEvents> calendarEvents = new List<CalendarEvents>();

            Events events = Calendar.GetCalendarEvents();
            foreach(var i in events.Items)
            {
                CalendarEvents e = new CalendarEvents();
                e.Title = i.Summary;
                e.When = i.Start.Date;
                calendarEvents.Add(e);
            }
            return calendarEvents;
        }
    }
}