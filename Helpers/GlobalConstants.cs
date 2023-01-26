using System.Globalization;

namespace DiplomenProekt.Helpers
{
    public static class GlobalConstants
    {
        public static string Currency = "lv.";
        public static string SiteName = "BulBroker";
        public static string ApplicationName = "DiplomenProekt";
        
        private static string dateFormat = "dd-MM-yyyy г."; 

        public static string FormatDate(DateTime date)
        {
            return date.ToString(dateFormat);
        }


    }
}