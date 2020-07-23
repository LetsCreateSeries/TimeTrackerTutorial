using System;
using System.Collections.Generic;
using System.Linq;
using Firebase.CloudFirestore;
using Foundation;

namespace TimeTrackerTutorial.iOS.Extensions
{
    public static class DocumentSnapshotExtensions
    {
        public static T Convert<T>(this DocumentSnapshot snapshot)
        {
            var dict = new Dictionary<string, object>();
            var t = Activator.CreateInstance<T>();
            var tJson = Newtonsoft.Json.JsonConvert.SerializeObject(t);
            var tDict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(tJson);
            var keys = tDict.Keys.ToList();
            var data = snapshot.Data;
            foreach (var key in data.Keys)
            {
                var val = data[key];
                if (val is NSString str)
                {
                    tDict[key.ToString()] = str.ToString();
                }
                else if (val is NSNumber numVal)
                {
                    var num = numVal.ToString();
                    if (num.Contains("."))
                    {
                        tDict[key.ToString()] = numVal.DoubleValue;
                    }
                    else
                    {
                        tDict[key.ToString()] = numVal.Int32Value;
                    }
                }
                else if (val is Timestamp time)
                {
                    var formatter = new NSDateFormatter();
                    formatter.DateFormat = "yyyy-MM-dd'T'HH:mm:ssZZZZZ";
                    tDict[key.ToString()] = DateTime.Parse(formatter.ToString(time.DateValue));
                }
            }
            tDict["Id"] = snapshot.Id;
            tJson = Newtonsoft.Json.JsonConvert.SerializeObject(tDict);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(tJson);
        }
    }
}
