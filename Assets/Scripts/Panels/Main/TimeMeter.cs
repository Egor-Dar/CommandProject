using System;
using UnityEngine;

namespace Panels.Main
{
    public class TimeMeter
    {
        public bool Create(out int value)
        {
            if (!PlayerPrefs.HasKey("DateDay") || !PlayerPrefs.HasKey("DateHour") || !PlayerPrefs.HasKey("DateMinute"))
            {
                value = 0;
                return false;
            }

            DateTime nowTime = DateTime.Now;
            DateTime nextTime = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                PlayerPrefs.GetInt("DateDay"),
                PlayerPrefs.GetInt("DateHour"),
                PlayerPrefs.GetInt("DateMinute"),
                DateTime.Now.Second);
            TimeSpan resultSpan = nowTime.Subtract(nextTime);
            var result = (int)resultSpan.TotalMinutes;
            if (result >= 1)
            {
                result = (int)resultSpan.TotalSeconds;
                value = result;
                return true;
            }
            else
            {
                value = 0;
                return false;
            }
        }

        public bool isTrue(out int value)
        {
            if (!PlayerPrefs.HasKey("DateDay") || !PlayerPrefs.HasKey("DateHour") || !PlayerPrefs.HasKey("DateMinute"))
            {
                value = 0;
                return false;
            }

            DateTime nowTime = DateTime.Now;
            DateTime nextTime = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                PlayerPrefs.GetInt("DateDay"),
                PlayerPrefs.GetInt("DateHour"),
                PlayerPrefs.GetInt("DateMinute"),
                DateTime.Now.Second);
            TimeSpan resultSpan = nowTime.Subtract(nextTime);
            var result = (int)resultSpan.TotalMinutes;
            value = result;
            return result >= 1440;

        }
    }
}