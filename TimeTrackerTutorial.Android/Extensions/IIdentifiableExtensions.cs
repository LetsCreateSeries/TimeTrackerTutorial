using System;
using System.Collections.Generic;
using TimeTrackerTutorial.Services;

namespace TimeTrackerTutorial.Droid.Extensions
{
    public static class IIdentifiableExtensions
    {
        public static Dictionary<string, Java.Lang.Object> Convert(this IIdentifiable item)
        {
            var dict = new Dictionary<string, Java.Lang.Object>();

            var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(item);
            var propertyDict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonStr);

            foreach (var key in propertyDict.Keys)
            {
                if (key.Equals("Id"))
                    continue;
                var val = propertyDict[key];
                Java.Lang.Object javaVal = null;
                if (val is string str)
                    javaVal = new Java.Lang.String(str);
                else if (val is double dbl)
                    javaVal = new Java.Lang.Double(dbl);
                else if (val is int intVal)
                    javaVal = new Java.Lang.Integer(intVal);
                else if (val is DateTime dt)
                    javaVal = dt.ToString();
                else if (val is bool boolVal)
                    javaVal = new Java.Lang.Boolean(boolVal);

                if (javaVal != null)
                    dict.Add(key, javaVal);
            }

            return dict;
        }
    }
}
