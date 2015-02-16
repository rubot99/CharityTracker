using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace CharityTracker
{
    public class TrackerFacade
    {
        public TrackerFacade()
        { }

        public List<ActivityType> GetAllActivityTypes()
        {
            using (CharityTrackerEntities _context = new CharityTrackerEntities())
            {
                return _context.ActivityTypes
                    .Where(a => a.IsActive == true)
                    .OrderBy(a => a.ActivityType1)
                    .ToList<ActivityType>();
            }
        }

        public List<vwGetUser> GetAllActiveUsers()
        {
            using (CharityTrackerEntities _context = new CharityTrackerEntities())
            {
                return _context.vwGetUsers
                    .Where(u => u.UserId != new Guid("B7D36A7B-B613-4CE6-998B-B22086A0347A"))
                    .OrderBy(u => u.UserName)
                    .ToList<vwGetUser>();
            }
        }

        public List<Office> GetOffices()
        {
            using (CharityTrackerEntities _context = new CharityTrackerEntities())
            {
                return _context.Offices
                    .Where(o => o.IsActive == true)
                    .ToList<Office>();
            }
        }

        public List<vwActivity> GetActivities(Guid userId)
        {
            using (CharityTrackerEntities _context = new CharityTrackerEntities())
            {
                return _context.vwActivities
                    .Where(u => u.UserId == userId)
                    .OrderByDescending(u => u.DateAdded)
                    .ToList<vwActivity>();
            }
        }
        
        public List<vwActivitiesByType> GetActivitiesByType()
        {
            using (CharityTrackerEntities _context = new CharityTrackerEntities())
            {
                return _context.vwActivitiesByTypes.ToList<vwActivitiesByType>();
            }
        }

        public List<vwActivitiesByUser> GetActivitiesByUser()
        {
            using (CharityTrackerEntities _context = new CharityTrackerEntities())
            {
                return _context.vwActivitiesByUsers
                    .Where(u => u.UserId != new Guid("B7D36A7B-B613-4CE6-998B-B22086A0347A"))
                    .OrderBy(u => u.UserName)
                    .ToList<vwActivitiesByUser>();
            }
        }

        public List<vwActivitiesByType> GetActivitiesByTypeByUser(Guid userid)
        {
            using (CharityTrackerEntities _context = new CharityTrackerEntities())
            {
                return _context.vwActivitiesByTypes
                   .Where(a => a.UserId == userid)
                   .OrderBy(a => a.ActivityType)
                   .ToList<vwActivitiesByType>();
            }
        }
        
        public void AddActivity(Activity activity)
        {
            using (CharityTrackerEntities _context = new CharityTrackerEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    List<Office> lstOffices = _context.Offices
                        .Where(o => o.IsActive == true)
                        .Where(o => o.IsCompleted == false)
                        .Take(2)
                        .OrderBy(o => o.ListOrder)
                        .ToList<Office>();

                    var remainingOfficeMileage = lstOffices[0].Mileage - lstOffices[0].MileageCompleted;

                    if (remainingOfficeMileage >= activity.Mileage)
                    {
                        lstOffices[0].MileageCompleted += activity.Mileage;
                    }
                    else if (remainingOfficeMileage <= activity.Mileage)
                    {
                        var currentMileage = activity.Mileage - remainingOfficeMileage;

                        lstOffices[0].MileageCompleted += remainingOfficeMileage;
                        lstOffices[0].IsCompleted = true;
                        lstOffices[1].MileageCompleted += currentMileage;
                    }

                    _context.Activities.Add(activity);
                    _context.SaveChanges();

                    scope.Complete();
                }
            }
        }
    }
}