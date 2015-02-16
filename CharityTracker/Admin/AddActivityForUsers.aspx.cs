using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharityTracker.Admin
{
    public partial class AddActivityForUsers : System.Web.UI.Page
    {
        private const string ACTIVITY_TYPE_LIST = "ACTIVITY_TYPE_LIST";

        private TrackerFacade _facade = new TrackerFacade();

        protected void Page_Init(object sender, EventArgs e)
        {
            btnAddMileage.Click += btnAddMileage_Click;
            ddlUsers.SelectedIndexChanged += ddlUsers_SelectedIndexChanged;
        }

        void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlUsers.SelectedItem.Value))
            {
                var userId = new Guid(ddlUsers.SelectedItem.Value);
                Activities(userId);
            }
        }

        void btnAddMileage_Click(object sender, EventArgs e)
        {
            decimal mileage = 0;

            if (!string.IsNullOrEmpty(txtMileage.Text))
            {
                if (Decimal.TryParse(txtMileage.Text, out mileage))
                {
                    if (!string.IsNullOrEmpty(ddlUsers.SelectedItem.Value))
                    {
                        var userId = new Guid(ddlUsers.SelectedItem.Value);

                        _facade.AddActivity(new Activity()
                        {
                            UserId = userId,
                            ActivityTypeId = Convert.ToInt32(ddlActivityType.SelectedItem.Value),
                            IsActive = true,
                            LastUpdated = DateTime.Now,
                            DateAdded = dtActivityDate.SelectedDate,
                            Mileage = mileage
                        });

                        Activities(userId);

                        txtMileage.Text = string.Empty;
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetupForm();
            }
        }

        private void SetupForm()
        {
            FillActivityTypes();
            FillUsers();

            dtActivityDate.SelectedDate = DateTime.Today;
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

        private void FillUsers()
        {
            List<vwGetUser> lstUsers = _facade.GetAllActiveUsers();
            lstUsers.Insert(0, new vwGetUser());
            ddlUsers.DataSource = lstUsers;
            ddlUsers.DataTextField = "UserName";
            ddlUsers.DataValueField = "UserId";
            ddlUsers.DataBind();
        }

        private void Activities(Guid userId)
        {
            ActivitiesRepeater.DataSource = _facade.GetActivities(userId);
            ActivitiesRepeater.DataBind();
        }
    }
}