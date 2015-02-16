using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharityTracker.User
{
    public partial class YourActivities : System.Web.UI.Page
    {
        private const string ACTIVITY_TYPE_LIST = "ACTIVITY_TYPE_LIST";

        private TrackerFacade _facade = new TrackerFacade();

        protected void Page_Init(object sender, EventArgs e)
        {
            btnAddMileage.Click += btnAddMileage_Click;
        }

        void btnAddMileage_Click(object sender, EventArgs e)
        {
            decimal mileage = 0;

            if (!string.IsNullOrEmpty(txtMileage.Text))
            {
                if (Decimal.TryParse(txtMileage.Text, out mileage))
                {
                    var username = System.Web.HttpContext.Current.User.Identity.Name;
                    MembershipUser user = Membership.GetUser(username);

                    var userId = new Guid(user.ProviderUserKey.ToString());

                    _facade.AddActivity(new Activity()
                    {
                        UserId = userId,
                        ActivityTypeId = Convert.ToInt32(ddlActivityType.SelectedItem.Value),
                        IsActive = true,
                        LastUpdated = DateTime.Now,
                        DateAdded = dtActivityDate.SelectedDate,
                        Mileage = mileage
                    });

                    ActivitiesByType(userId);
                    Activities(userId);

                    txtMileage.Text = string.Empty;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    var username = System.Web.HttpContext.Current.User.Identity.Name;
                    MembershipUser user = Membership.GetUser(username);
                    SetupForm(new Guid(user.ProviderUserKey.ToString()));
                }
            }

            dtActivityDate.SelectedDate = DateTime.Today;
        }

        private void SetupForm(Guid userId)
        {
            FillActivityTypes();
            ActivitiesByType(userId);
            Activities(userId);
        }

        private void FillActivityTypes()
        {
            List<ActivityType> lstActivityType = (List<ActivityType>)Cache[ACTIVITY_TYPE_LIST];

            if (lstActivityType == null)
            {
                lstActivityType = _facade.GetAllActivityTypes();
                Cache.Insert(ACTIVITY_TYPE_LIST, lstActivityType);
            }

            ddlActivityType.DataSource = lstActivityType;
            ddlActivityType.DataTextField = "ActivityType1";
            ddlActivityType.DataValueField = "Id";
            ddlActivityType.DataBind();
        }

        private void ActivitiesByType(Guid userId)
        {
            List<vwActivitiesByType> lstActivityTypes = _facade.GetActivitiesByTypeByUser(userId);

            litTotalMileage.Text = lstActivityTypes.Sum(s => s.TotalMileage).ToString();

            ActivitiesByTypeRepeater.DataSource = lstActivityTypes;
            ActivitiesByTypeRepeater.DataBind();
        }

        private void Activities(Guid userId)
        {
            ActivitiesRepeater.DataSource = _facade.GetActivities(userId);
            ActivitiesRepeater.DataBind();
        }
    }
}