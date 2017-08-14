using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWTTransport.Common
{
    public class DWTComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    public static class Utilities
    {
        public static string ConvertTo12HourFormat(TimeSpan time)
        {
            var hours = time.Hours;
            var minutes = time.Minutes;
            var amPmDesignator = "AM";
            if (hours == 0)
                hours = 12;
            else if (hours == 12)
                amPmDesignator = "PM";

            else if (hours > 12)
            {
                hours -= 12;
                amPmDesignator = "PM";
            }

            var hourstring = hours.ToString();
            if(hours < 10)
            {
                hourstring = "0" + hourstring;
            }

            var formattedTime =
              String.Format("{0}:{1:00} {2}", hourstring, minutes, amPmDesignator);

            return formattedTime;
        } 
    }
}
