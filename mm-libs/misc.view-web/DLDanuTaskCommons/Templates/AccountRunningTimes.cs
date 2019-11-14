using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DLDanuTaskCommons.Templates
{
    public class AccountRunningTimes
    {
        [XmlArrayItem(Type = typeof(AccountRunningTime))]
        public AccountRunningTime[] RunningTimes;
    }

    public class AccountRunningTime
    {
        public Guid RunningTimeID { get; set; }
        public string Title { get; set; }
        public long TotalDurationSeconds { get; set; }
        public bool IsActive { get; set; }
        public bool IsFinished { get; set; }
        [XmlArrayItem(Type = typeof(RunningTimeInterval))]
        public RunningTimeInterval[] RunningTimeIntervals { get; set; }
    }


    public class RunningTimeInterval
    {
        public DateTime IntervalStartDate { get; set; }
        public long IntervalDurationSeconds { get; set; }
    }


}
