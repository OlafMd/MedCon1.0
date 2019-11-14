using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logger;
using System.Xml.Serialization;


namespace DLDanuTaskCommons.Constants
{
    [Serializable]
    public class UserAccountRunningTimes
    {
        public List<RunningTime> RunningTimes { get; set; }
    }

    [Serializable]
    public class RunningTime
    {

        public Guid Id { get; set; }

        public List<RunningTimeIntrval> Intervals {get; set;}

        public String Title { get; set; }

        public bool IsActive { 
            get{
                if(this.Intervals == null || this.Intervals.Count == 0)
                    return false;
                return this.Intervals.Exists(it => it.IsActive);
            }
            set
            {
                IsActive = value;
            }
        }

        public double TotalDurationSeconds
        {
            get
            {
                if (this.Intervals == null || this.Intervals.Count == 0)
                    return 0;
                if(!this.Intervals.Exists(it=>it.IsActive))
                    return this.Intervals.Sum(it => it.DurationSeconds);
                return this.Intervals.Where(it => !it.IsActive).Sum(it => it.DurationSeconds) +
                      (DateTime.Now - this.Intervals.Where(it => it.IsActive).FirstOrDefault().StartTimeStamp).TotalSeconds;
            }
        }

        public Guid TenantID { get; set; }

        public Boolean IsToFinish { get; set; }
    }

    [Serializable]
    public class RunningTimeIntrval
    {

        public double DurationSeconds { get; set; }

        public DateTime StartTimeStamp { get; set; }

        public bool IsActive { get; set; }
    }

    #region JavaScriptSpecific

    public class JSRunningTimes
    {
        public static List<JSRunningTime> GetRunningTimesForJS(List<RunningTime> Source)
        {
            List<JSRunningTime> tempResult = new List<JSRunningTime>();
            double TotalSeconds = 0;
            foreach (var currentRunningTime in Source)
            {
                JSRunningTime tempJSRunningTime = new JSRunningTime();
                tempJSRunningTime.id = currentRunningTime.Id.ToString();
                tempJSRunningTime.title = currentRunningTime.Title;
                tempJSRunningTime.timerClass = currentRunningTime.IsActive ? "running" : "paused";
                tempJSRunningTime.editTitle = false;
                TotalSeconds = Math.Round(currentRunningTime.TotalDurationSeconds,0);
                TimeSpan ts = TimeSpan.FromSeconds(TotalSeconds);
                tempJSRunningTime.duration = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
                tempResult.Add(tempJSRunningTime);
            }
            return tempResult;
        }
    }

    public class JSRunningTime
    {
        public string id { get; set; }
        public string title { get; set; }
        public string duration { get; set; }
        public string timerClass { get; set; }
        public Boolean editTitle { get; set; }
    }

  

    #endregion
}
