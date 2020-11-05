using System;
using System.Collections.Generic;
using Foundation;
using TimeTrackerTutorial.Services;

namespace TimeTrackerTutorial.iOS.Extensions
{
    public static class IIdentifiableExtensions
    {
        public static Dictionary<object, object> Convert(this IIdentifiable item)
        {
            var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(item);
            var dict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<object, object>>(jsonStr);
            return dict;
        }
    }
}
