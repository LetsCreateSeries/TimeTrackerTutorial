using System;
using System.Collections.Generic;
using Firebase.CloudFirestore;
using Foundation;

namespace TimeTrackerTutorial.iOS.Extensions
{
    public static class DocumentSnapshotExtensions
    {
        public static T Convert<T>(this DocumentSnapshot doc)
        {
            var dict = new Dictionary<string, object>();
            var docDict = doc.Data;
            foreach (var key in docDict.Keys)
            {
                var val = docDict[key];
                if (val is NSString str)
                {
                    dict[key.ToString()] = str.ToString();
                }
                else if (val is NSNumber num)
                {
                    var numStr = num.ToString();
                    if (numStr.Contains("."))
                    {
                        dict[key.ToString()] = num.DoubleValue;
                    }
                    else
                    {
                        dict[key.ToString()] = num.Int32Value;
                    }
                }
                else if (val is Timestamp time)
                {
                    var formatter = new NSDateFormatter();
                    formatter.DateFormat = "yyyy-MM-dd'T'HH:mm:ssZZZZZ";
                    dict[key.ToString()] = DateTime.Parse(formatter.ToString(time.DateValue));
                }
            }
            dict["Id"] = doc.Id;
            var tJson = Newtonsoft.Json.JsonConvert.SerializeObject(dict);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(tJson);
        }
    }
}
