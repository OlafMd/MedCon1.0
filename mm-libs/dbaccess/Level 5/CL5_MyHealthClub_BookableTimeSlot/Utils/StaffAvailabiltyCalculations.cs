using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MHCWidget_Web.Models.Backoffice;
using CL5_MyHealtClub_Slot.Model;
using CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval;
using CL5_MyHealtClub_Slot.Model.Emplyee;
using CL5_MyHealtClub_Slot.Model.AppointmentSpace;

namespace CL5_MyHealtClub_Slot.Utils
{
    class StaffAvailabiltyCalculations
    {
        public static List<RangeIntersection> FindAllIntersections(List<List<Availability>> availabilitiesPerEntities)
        {
             List<RangeIntersection> retVal = null;

            foreach (var row in availabilitiesPerEntities)
            {
                List<RangeIntersection> tempResult = null;
                if(retVal != null)
                    tempResult = new List<RangeIntersection>(retVal);
                retVal = new List<RangeIntersection>();
                if (tempResult == null)
                {
                    foreach (var item in row)
                        retVal.Add(new RangeIntersection()
                        {
                            DayOfWeek = item.DayOfWeek,
                            IsIntersects = true,
                            IntersectionStart = item.PeriodStart,
                            IntersectionEnd = item.PeriodEnd,
                            DurationInSec = (item.PeriodEnd - item.PeriodStart).TotalSeconds
                        });
                }
                else
                {
                    foreach (var item in row)
                        foreach (var intersection in tempResult)
                        {
                            var newIntersec = TimeRangeUtils.Intersection(intersection, item);
                            if (newIntersec.IsIntersects)
                                retVal.Add(newIntersec);
                        }

                    if (retVal.Count == 0)
                        break;
                }


            }

            return retVal;
        }

        public static List<RangeIntersection> FindAllIntersections(List<List<RangeIntersection>> intersectionsGroupedPerResource)
        {
            List<RangeIntersection> retVal = null;

            foreach (var resourceRanges in intersectionsGroupedPerResource)
            {
                List<RangeIntersection> tempResult = null;
                if (retVal != null)
                {
                    tempResult = new List<RangeIntersection>(retVal);
                }

                retVal = new List<RangeIntersection>();

                if (tempResult == null)
                {
                    tempResult = resourceRanges;
                    retVal = tempResult;
                }
                else
                {
                    foreach (var item in resourceRanges)
                        foreach (var intersection in tempResult)
                        {
                            var newIntersec = TimeRangeUtils.Intersection(intersection, item);
                            if (newIntersec.IsIntersects)
                                retVal.Add(newIntersec);
                        }

                    if (retVal.Count == 0)
                        break;
                }
            }

            return retVal;
        }

        public static List<StaffCombination> GetFilteredStaffForAppointmentTypeBySkills(List<Staff> practiceStaff, AppointmentType appointmentType)
        {
            List<StaffCombination> retVal = new List<StaffCombination>();

            //potrebno osoblje, konkretno oznacneo
            var reqStaffByName = practiceStaff.Where(s => appointmentType.RequiredStaff.Select(selectStaff => selectStaff.StaffID).Contains(s.ID)).ToArray();

            //ako su svi raspolozivi
            if (reqStaffByName.Length == appointmentType.RequiredStaff.Count)
            {
                Dictionary<Guid, SelectedStaffPerAbility> usedStaffPerAbility = new Dictionary<Guid, SelectedStaffPerAbility>();

                foreach (var reqSA in appointmentType.ReqStaffByAbillities)
                {
                    //ako nema, iniciraj value
                    if (!usedStaffPerAbility.ContainsKey(reqSA.ID))
                    {
                        usedStaffPerAbility.Add(reqSA.ID, new SelectedStaffPerAbility());
                        usedStaffPerAbility[reqSA.ID].StillNeed = reqSA.Count;
                    }

                    //rasporedjeni zapolseni koji su odabrani po imenu
                    List<Guid> allreadySelectedStaffIDs = new List<Guid>();
                    foreach(var value in usedStaffPerAbility.Values)
                        allreadySelectedStaffIDs.AddRange(value.GetStaffIDs());

                    //ne rasporedjeni zapolseni koji su odabrani po imenu
                    var otherReqStaffByName = reqStaffByName.Where(s => !allreadySelectedStaffIDs.Contains(s.ID)).ToList();


                    var selectedStaff = GetAllStaffByStaffReqs(otherReqStaffByName, reqSA);

                    //dodati ga
                    if (selectedStaff.Count > reqSA.Count)
                    {
                        //uzeti prvih X TODO: napraviti bolji odabir
                        usedStaffPerAbility[reqSA.ID].AddStaff(selectedStaff.Take(reqSA.Count).ToList());
                        usedStaffPerAbility[reqSA.ID].StillNeed = 0;
                    }
                    else
                    {
                        usedStaffPerAbility[reqSA.ID].AddStaff(selectedStaff);
                        usedStaffPerAbility[reqSA.ID].StillNeed = reqSA.Count - selectedStaff.Count;
                    }
                }

                var unusedStaff = practiceStaff.Where(s => !reqStaffByName.Select(rss => rss.ID).Contains(s.ID)).ToList();

                Dictionary<Guid, SelectedStaffPerAbility> otherStaffPerAbility = new Dictionary<Guid, SelectedStaffPerAbility>();
                foreach (var usa in usedStaffPerAbility)
                {
                    var reqSA = appointmentType.ReqStaffByAbillities.First(s => s.ID == usa.Key);
                    if (usa.Value.StillNeed > 0)
                    {
                        otherStaffPerAbility.Add(reqSA.ID, new SelectedStaffPerAbility());
                        otherStaffPerAbility[reqSA.ID].AddStaff(GetAllStaffByStaffReqs(unusedStaff, reqSA));
                        otherStaffPerAbility[reqSA.ID].StillNeed = usa.Value.StillNeed;
                        if (otherStaffPerAbility[reqSA.ID].Staff.Count < reqSA.Count)
                            return retVal; // nema ih dovoljno za taj requ, kraj
                    }
                }

                var combinationPerMappedReqSA = new Dictionary<Guid, List<TemplateRequiredStaffInfo>>();
                var mappingKeysToRealRequs = new Dictionary<Guid, Guid>();

                foreach (var other in otherStaffPerAbility)
                {
                    for (int i = 0; i < other.Value.StillNeed; i++)
                    {
                        var tempKey = Guid.NewGuid();
                        mappingKeysToRealRequs.Add(tempKey, other.Key);

                        List<TemplateRequiredStaffInfo> tempList = new List<TemplateRequiredStaffInfo>();
                        foreach (var s in other.Value.Staff)
                            tempList.Add(new TemplateRequiredStaffInfo()
                            {
                                ID = tempKey,
                                Staff = s
                            });
                        combinationPerMappedReqSA.Add(tempKey, tempList);
                    }              
                }

                TreeNode tree = new TreeNode(Guid.Empty, Guid.Empty);
                int reqSkillsCounter = 0;
                foreach (var key in combinationPerMappedReqSA.Keys)
                {
                    var staff2ReqList = combinationPerMappedReqSA[key];
                    var leafs = TreeUtils.GetLeafs(tree);
                    foreach (var leaf in leafs)
                        foreach (var staff2Req in staff2ReqList)
                            if (!TreeUtils.IsAncestorsContainsID(leaf, staff2Req.Staff.ID) 
                                && TreeUtils.GetNodeDepth(leaf) == reqSkillsCounter)
                                leaf.Add(new TreeNode(staff2Req.Staff.ID, key));

                    reqSkillsCounter++;
                }

                var staffCombinationNodes = TreeUtils.GetBranchesCurrentSize(tree, combinationPerMappedReqSA.Keys.Count);
                if (staffCombinationNodes.Count > 0)
                {             
                    foreach (var combination in staffCombinationNodes)
                    {
                        var staff2reqConnections = new List<StaffID2ReqID>();
                        foreach(var c in combination)
                            if(c.StaffReqID != Guid.Empty)
                                staff2reqConnections.Add(new StaffID2ReqID()
                                {
                                    ReqID = mappingKeysToRealRequs[c.StaffReqID],
                                    StaffID = c.StaffID
                                });

                        var staffCombination = new List<TemplateRequiredStaffInfo>();
                        foreach(var staff in reqStaffByName)
                            staffCombination.Add(new TemplateRequiredStaffInfo()
                            {
                                Staff = staff,
                                ID = appointmentType.RequiredStaff.First(f => f.StaffID == staff.ID).ID
                            });

                        var staffCombinationFromTree = practiceStaff.Where(s => staff2reqConnections.Select(select => select.StaffID).Contains(s.ID)).ToList();
                        foreach (var staff in staffCombinationFromTree)
                            staffCombination.Add(new TemplateRequiredStaffInfo()
                            {
                                ID = staff2reqConnections.First(f => f.StaffID == staff.ID).ReqID,
                                Staff = staff
                            });


                        retVal.Add(new StaffCombination() { Data = staffCombination });
                    } 
                }
            }

            return retVal;
        }

        public static List<Staff> GetAllStaffByStaffReqs(List<Staff> staff, ReqStaffByAbillity staffAbility)
        {
            List<Staff> retVal = new List<Staff>();

            List<Staff> staffByProfession = new List<Staff>();

            foreach (var st in staff)
            {
                if (st.Professions.Select(s => s.ID).Contains(staffAbility.ProfessionID))
                    staffByProfession.Add(st);
            }
            foreach (var s in staffByProfession)
                if(IsStaffMatchingSkillReqs(s, staffAbility))
                    retVal.Add(s);
                
            return retVal;
        }

        public static List<RangeIntersection> CalculateWeekAvailableFramesForStaffCombination(List<TemplateRequiredStaffInfo> staffCombination, List<Availability> practiceAvailabilities)
        {
            var allAbilities = staffCombination.Select(staff => staff.Staff).Select(s => s.Availabilities).ToList();
            allAbilities.Add(practiceAvailabilities);
            return StaffAvailabiltyCalculations.FindAllIntersections(allAbilities);
        }


        public static List<TimeSlot> MakeSlotsForPeriod(List<RangeIntersection> weekRanges, List<ExceptionTime> summedExlusions, DateTime periodStart, DateTime periodEnd)
        {
            var retVal = new List<TimeSlot>();

            var allExclusions = new List<ExceptionTime>(summedExlusions);

            if (weekRanges.Count > 0)
            {
                int periodTotalDays = (int)(periodEnd - periodStart).TotalDays;
                int weekNumber = periodTotalDays / 7;
                int lastWeekFraction = periodTotalDays % 7;

                for (int i = 0; i < weekNumber; i++)
                {
                    var currentWeekRanges = weekRanges;

                    if (i == 0) // first week
                    {
                        currentWeekRanges = currentWeekRanges.Where(w => w.DayOfWeek >= periodStart.DayOfWeek).ToList();
                    }
                    else if (i + 1 == weekNumber) // last week
                    {
                        currentWeekRanges = currentWeekRanges.Where(w => w.DayOfWeek <= periodEnd.DayOfWeek).ToList();
                    }

                    foreach (var range in currentWeekRanges)
                    {
                        DateTime realDate = periodStart.Date.AddDays(range.DayOfWeek - periodStart.DayOfWeek + i*7);

                        var slot = new TimeSlot()
                        {
                            PeriodStart = realDate.Add(new TimeSpan(range.IntersectionStart.Ticks)),
                            PeriodEnd = realDate.Add(new TimeSpan(range.IntersectionEnd.Ticks))
                        };

                        if (!IntersectionWithExclusions(slot, allExclusions))
                            retVal.Add(slot);
                    }
                }
            }

            return retVal;
        }

        public static bool IsStaffWebBookableInThisTameRange(Staff staff, TimeSlot timeRange)
        {
            bool retVal = false;
            if (staff.IsAvailabeForWebBooking)
                foreach (var ava in staff.WebAvailabilities)
                {
                    if (ava.DayOfWeek == timeRange.PeriodStart.DayOfWeek &&
                        ava.PeriodStart.TimeOfDay <= timeRange.PeriodStart.TimeOfDay &&
                        ava.PeriodEnd.TimeOfDay >= timeRange.PeriodEnd.TimeOfDay)
                    {
                        retVal = true;
                        break;
                    }
                }
            return retVal;
        }

        public static bool IntersectionWithExclusions(TimeSlot slot, List<ExceptionTime> exceptions)
        {
            bool retVal = false;

            foreach (var exception in exceptions)
            {
                switch(exception.Recurency)
                {
                    case Recurency.None:
                        retVal = TimeRangeUtils.PeriodIntersectionsRawDates(slot.PeriodStart, slot.PeriodEnd, exception.PeriodStart, exception.PeriodEnd);
                        break;
                    case Recurency.Daily:
                        DateTime currentDayStart = slot.PeriodStart.Date.Add(exception.PeriodStart.TimeOfDay);
                        DateTime currentDayEnd = slot.PeriodStart.Date.Add(exception.PeriodStart.TimeOfDay);

                      retVal = TimeRangeUtils.PeriodIntersectionsRawDates(slot.PeriodStart, slot.PeriodEnd, currentDayStart, currentDayEnd);
                        break;
                    case Recurency.Weekly:
                        DateTime currentWeekStart = slot.PeriodStart.Date.AddDays((int)(slot.PeriodStart - exception.PeriodStart).TotalDays % 7).Add(exception.PeriodStart.TimeOfDay);
                        DateTime currentWeekEnd = slot.PeriodStart.Date.AddDays((int)(slot.PeriodStart - exception.PeriodEnd).TotalDays % 7).Add(exception.PeriodEnd.TimeOfDay);
                        retVal = TimeRangeUtils.PeriodIntersectionsRawDates(slot.PeriodStart, slot.PeriodEnd, currentWeekStart, currentWeekEnd);
                        break;
                    case Recurency.Monthly:
                        DateTime currentMonthStart;
                        DateTime currentMonthEnd;
                        try
                        {
                            currentMonthStart = new DateTime(slot.PeriodStart.Year, slot.PeriodStart.Month, exception.PeriodStart.Day, exception.PeriodStart.Hour, exception.PeriodStart.Minute, exception.PeriodStart.Second);
                        }
                        catch
                        {
                            currentMonthStart = new DateTime(slot.PeriodStart.Year, slot.PeriodStart.Month, exception.PeriodStart.Day - 1, exception.PeriodStart.Hour, exception.PeriodStart.Minute, exception.PeriodStart.Second);
                        }
                        try
                        {
                            currentMonthEnd = new DateTime(slot.PeriodEnd.Year, slot.PeriodStart.Month, exception.PeriodEnd.Day, exception.PeriodEnd.Hour, exception.PeriodEnd.Minute, exception.PeriodEnd.Second);
                        }
                        catch
                        {
                            currentMonthEnd = new DateTime(slot.PeriodEnd.Year, slot.PeriodStart.Month, exception.PeriodEnd.Day - 1, exception.PeriodEnd.Hour, exception.PeriodEnd.Minute, exception.PeriodEnd.Second);
                        }
                        retVal = TimeRangeUtils.PeriodIntersectionsRawDates(slot.PeriodStart, slot.PeriodEnd, currentMonthStart, currentMonthEnd);
                        break;
                    case Recurency.Yearly:
                        DateTime currentYearStart;
                        DateTime currentYearEnd;
                        try
                        {
                            currentYearStart = new DateTime(slot.PeriodStart.Year, exception.PeriodStart.Month, exception.PeriodStart.Day, exception.PeriodStart.Hour, exception.PeriodStart.Minute, exception.PeriodStart.Second);
                        }
                        catch
                        {
                            currentYearStart = new DateTime(slot.PeriodStart.Year, exception.PeriodStart.Month, exception.PeriodStart.Day - 1, exception.PeriodStart.Hour, exception.PeriodStart.Minute, exception.PeriodStart.Second);
                        }
                        try
                        {
                            currentYearEnd = new DateTime(slot.PeriodEnd.Year, exception.PeriodEnd.Month, exception.PeriodEnd.Day, exception.PeriodEnd.Hour, exception.PeriodEnd.Minute, exception.PeriodEnd.Second);
                        }
                        catch
                        {
                            currentYearEnd = new DateTime(slot.PeriodEnd.Year, exception.PeriodEnd.Month, exception.PeriodEnd.Day - 1, exception.PeriodEnd.Hour, exception.PeriodEnd.Minute, exception.PeriodEnd.Second);
                        }
                        retVal = TimeRangeUtils.PeriodIntersectionsRawDates(slot.PeriodStart, slot.PeriodEnd, currentYearStart, currentYearEnd);
                        
                        break;
                }

                if(retVal)
                    break;
            }

            return retVal;
        }

        public static bool IsSlotSteelValid(List<List<TemplateRequiredStaffInfo>> allPosibleCombinations, List<TemplateRequiredStaffInfo> chosenCombination)
        {
            bool retVal = false;

            var selectedCombinationStaffIDs = chosenCombination.Select(sm => sm.Staff).Select(s => s.ID).ToList();

            //staffByProfession.Where(s => !s.SkillIds.Except(staffAbility.SkillIDs).Any()).ToList();
            foreach (var comb in allPosibleCombinations)
            {
                var combStaffIDs = comb.Select(sm => sm.Staff).Select(s => s.ID).ToList();
                bool goToNextCombination = false;

                foreach(Guid staffID in selectedCombinationStaffIDs)
                    if (combStaffIDs.Contains(staffID))
                    {
                        goToNextCombination = true;
                        break;
                    }

                if (goToNextCombination)
                    continue;

                retVal = true;

                if (retVal)
                    break;

            }

            return retVal;
        }

        public static bool IsStaffMatchingSkillReqs(Staff staff, ReqStaffByAbillity staffAbility)
        {
            var retVal = !staffAbility.SkillIDs.Except(staff.Skills.Select(s => s.ID)).Any();
            if (!retVal)
            {
                var allSkillByStaff = staff.Professions.SelectMany( s => s.Skills.Select(ss => ss.ID));
                retVal = !staffAbility.SkillIDs.Except(allSkillByStaff).Any();
            }
            return retVal;
        }
    }
}
