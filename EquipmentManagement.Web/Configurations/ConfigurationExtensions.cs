using System;
using System.Collections.Specialized;
using System.Linq;

namespace EquipmentManagement.Web.Configurations
{
    public static class ConfigurationExtensions
    {
        public static string GetStringOrDefault(this NameValueCollection settings, string key, string defaultValue = "")
        {
            if (settings.AllKeys.Contains(key))
            {
                return settings[key];
            }
            return defaultValue;
        }

        public static bool GetBoolOrDefault(this NameValueCollection settings, string key, bool defaultValue = false)
        {
            if (settings.AllKeys.Contains(key))
            {
                if (bool.TryParse(settings[key], out bool value))
                {
                    return value;
                }
            }
            return defaultValue;
        }

        public static int GetIntOrDefault(this NameValueCollection settings, string key, int defaultValue = 0)
        {
            if (settings.AllKeys.Contains(key))
            {
                if (int.TryParse(settings[key], out int value))
                {
                    return value;
                }
            }
            return defaultValue;
        }

        public static double GetDoubleOrDefault(this NameValueCollection settings, string key, double defaultValue = 0)
        {
            if (settings.AllKeys.Contains(key))
            {
                if (double.TryParse(settings[key], out double value))
                {
                    return value;
                }
            }
            return defaultValue;
        }

        public static DateTime? GetDateTimeOrDefault(this NameValueCollection settings, string key, DateTime? defaultValue = null)
        {
            if (settings.AllKeys.Contains(key))
            {
                if (DateTime.TryParse(settings[key], out DateTime value))
                {
                    return value;
                }
            }
            return defaultValue;
        }
    }
}
