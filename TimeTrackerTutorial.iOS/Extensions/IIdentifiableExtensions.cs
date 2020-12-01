using System;
using System.Collections.Generic;
using Foundation;
using TimeTrackerTutorial.Services;

namespace TimeTrackerTutorial.iOS.Extensions
{
    public static class IIdentifiableExtensions
    {
        public static NSDictionary<NSString, NSObject> Convert(this IIdentifiable item)
        {
            var dict = new NSMutableDictionary<NSString, NSObject>();

            var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(item);
            var propertyDict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonStr);
            foreach (var key in propertyDict.Keys)
            {
                if (key.Equals("Id"))
                    continue;

                var nsKey = new NSString(key);
                NSObject nsVal = null;
                var value = propertyDict[key];
                if (value is string str)
                    nsVal = new NSString(str);
                else if (value is double dblVal)
                    nsVal = new NSNumber(dblVal);
                else if (value is bool boolVal)
                    nsVal = new NSNumber(boolVal);
                else if (Int32.TryParse(value.ToString(), out int intVal))
                    nsVal = new NSNumber(intVal);
                else if (value is DateTime dtVal)
                {
                    var formatter = new NSDateFormatter();
                    var dateFormat = "yyyy-MM-ddHH:mm:ss";
                    formatter.DateFormat = dateFormat;
                    var dtStr = dtVal.ToString(dateFormat);
                    nsVal = formatter.Parse(dtStr);
                }

                if (nsVal != null)
                    dict.Add(nsKey, nsVal);

            }
            return NSDictionary<NSString, NSObject>.FromObjectsAndKeys(dict.Values, dict.Keys);
        }
    }
}
