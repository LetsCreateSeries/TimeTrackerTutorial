using System;
using System.Collections.Generic;

namespace TimeTrackerTutorial.Models
{
    public class PayStatement
    {
        /// <summary>
        /// Pay Period Start Date
        /// </summary>
        public DateTime Start { get; set; }
        /// <summary>
        /// Pay Period End Date
        /// </summary>
        public DateTime End { get; set; }
        /// <summary>
        /// Payout Date for Period
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Payout Amount
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// A List of Associated Work Items for the Pay Period
        /// </summary>
        public List<WorkItem> WorkItems { get; set; }
    }
}
