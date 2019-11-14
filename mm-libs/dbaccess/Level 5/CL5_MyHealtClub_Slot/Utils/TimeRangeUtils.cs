using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CL5_MyHealtClub_Slot.Model;
using MHCWidget_Web.Models.Backoffice;
using CL5_MyHealtClub_Slot.Model.AppointmentSpace;

namespace CL5_MyHealtClub_Slot.Utils
{
    class TimeRangeUtils
    {
        public static RangeIntersection Intersection(Availability firstRange, Availability secondRange)
        {
            var retVal = new RangeIntersection();

            if (firstRange.DayOfWeek == secondRange.DayOfWeek
                && PeriodIntersectionsRawDates(firstRange.PeriodStart, firstRange.PeriodEnd, secondRange.PeriodStart, secondRange.PeriodEnd))
            {
                var IntersectionPeriodStart = firstRange.PeriodStart > secondRange.PeriodStart ? firstRange.PeriodStart : secondRange.PeriodStart;
                var IntersectionPeriodEnd = firstRange.PeriodEnd < secondRange.PeriodEnd ? firstRange.PeriodEnd : secondRange.PeriodEnd;

                retVal.DayOfWeek = firstRange.DayOfWeek;
                retVal.IsIntersects = true;
                retVal.IntersectionStart = IntersectionPeriodStart;
                retVal.IntersectionEnd = IntersectionPeriodEnd;
                retVal.DurationInSec = (IntersectionPeriodEnd - IntersectionPeriodStart).TotalSeconds;
            }
     
            return retVal;
        }

        public static RangeIntersection Intersection(RangeIntersection firstRange, Availability secondRange)
        {
            var retVal = new RangeIntersection();

            if (firstRange.DayOfWeek == secondRange.DayOfWeek
                && PeriodIntersectionsRawDates(firstRange.IntersectionStart, firstRange.IntersectionEnd, secondRange.PeriodStart, secondRange.PeriodEnd))
            {
                var IntersectionPeriodStart = firstRange.IntersectionStart > secondRange.PeriodStart ? firstRange.IntersectionStart : secondRange.PeriodStart;
                var IntersectionPeriodEnd = firstRange.IntersectionEnd < secondRange.PeriodEnd ? firstRange.IntersectionEnd : secondRange.PeriodEnd;

                retVal.DayOfWeek = firstRange.DayOfWeek;
                retVal.IsIntersects = true;
                retVal.IntersectionStart = IntersectionPeriodStart;
                retVal.IntersectionEnd = IntersectionPeriodEnd;
                retVal.DurationInSec = (IntersectionPeriodEnd - IntersectionPeriodStart).TotalSeconds;
            }

            return retVal;
        }

        public static RangeIntersection Intersection(RangeIntersection firstRange, RangeIntersection secondRange)
        {
            var retVal = new RangeIntersection();

            if (firstRange.DayOfWeek == secondRange.DayOfWeek 
                && PeriodIntersectionsRawDates(firstRange.IntersectionStart, firstRange.IntersectionEnd, secondRange.IntersectionStart, secondRange.IntersectionEnd))
            {
                var IntersectionPeriodStart = firstRange.IntersectionStart > secondRange.IntersectionStart ? firstRange.IntersectionStart : secondRange.IntersectionStart;
                var IntersectionPeriodEnd = firstRange.IntersectionEnd < secondRange.IntersectionEnd ? firstRange.IntersectionEnd : secondRange.IntersectionEnd;

                retVal.DayOfWeek = firstRange.DayOfWeek;
                retVal.IsIntersects = true;
                retVal.IntersectionStart = IntersectionPeriodStart;
                retVal.IntersectionEnd = IntersectionPeriodEnd;
                retVal.DurationInSec = (IntersectionPeriodEnd - IntersectionPeriodStart).TotalSeconds;
            }

            return retVal;
        }

        public static bool PeriodIntersectionsRawDates(DateTime firstStart, DateTime firstEnd, DateTime lastStart, DateTime lastEnd)
        {
            return firstStart < lastEnd && firstEnd > lastStart;
        }

        public static List<RangeIntersection> CalculateTimeFramesFromRanges(List<RangeIntersection> ranges, int windowDuratinInSec)
        {
            var retVal = new List<RangeIntersection>();

            foreach (var range in ranges)
            {
                DateTime tempWindowBorder = range.IntersectionStart;
                while(tempWindowBorder <= range.IntersectionEnd && (range.IntersectionEnd - tempWindowBorder).TotalSeconds >= windowDuratinInSec)
                {
                    retVal.Add(new RangeIntersection()
                    {
                        DayOfWeek = range.DayOfWeek,
                        DurationInSec = windowDuratinInSec,
                        IntersectionStart = tempWindowBorder,
                        IntersectionEnd = tempWindowBorder.AddSeconds(windowDuratinInSec),
                        IsIntersects = true
                    });

                    tempWindowBorder = tempWindowBorder.AddSeconds(windowDuratinInSec);
                }
            }

            return retVal;
        }

        public static bool SlotOverlapingWithSlotArray(TimeSlot slot, List<TimeSlot> slotArray)
        {
            bool retVal = false;
            foreach (var currentSlot in slotArray)
            {
                if (PeriodIntersectionsRawDates(slot.PeriodStart, slot.PeriodEnd, currentSlot.PeriodStart, currentSlot.PeriodEnd))
                {
                    retVal = true;
                    break;
                }
            }
            return retVal;
        }

        public static bool SlotOverlapingWithAppontmentArray(TimeSlot slot, List<Appointment> appointmentArray)
        {
            bool retVal = false;
            foreach (var currentAppointment in appointmentArray)
            {
                if (PeriodIntersectionsRawDates(slot.PeriodStart, slot.PeriodEnd, currentAppointment.AppointmentStart, currentAppointment.AppointmentEnd))
                {
                    retVal = true;
                    break;
                }
            }
            return retVal;
        }

        public static bool SlotExistingInArray(TimeSlot slot, List<TimeSlot> slotArray)
        {
            bool retVal = false;
            foreach (var currentSlot in slotArray)
            {
                if (slot.PeriodStart == currentSlot.PeriodStart && slot.PeriodEnd == currentSlot.PeriodEnd)
                {
                    retVal = true;
                    break;
                }
            }
            return retVal;
        }
    }
}
