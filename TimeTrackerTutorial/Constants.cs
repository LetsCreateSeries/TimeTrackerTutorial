using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTrackerTutorial
{
    public static class Constants
    {
        /// <summary>
        /// The very first payment date, which covers pay period 4/26 - 5/9/2020. Used to 
        /// calculate future payment dates.
        /// </summary>
        public static readonly DateTime FIRST_PAYMENT_DATE = new DateTime(2020, 5, 15);
        public static readonly DateTime FIRST_PAY_PERIOD_START = new DateTime(2020, 4, 26, 0, 0, 1);
        public static readonly DateTime FIRST_PAY_PERIOD_END = new DateTime(2020, 5, 9, 23, 59, 59);

        public static class Collections
        {
            public static readonly string Users = "users";
            public static readonly string Work = "work";
        }
    }
}
