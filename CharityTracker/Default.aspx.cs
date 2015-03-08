using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharityTracker
{
    public partial class Default : System.Web.UI.Page
    {
        private const string USER_LIST = "USER_LIST";
        private const string ACTIVITY_TYPE_LIST = "ACTIVITY_TYPE_LIST";

        private TrackerFacade _facade = new TrackerFacade();

        protected void Page_Init(object sender, EventArgs e)
        {
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
            FillOffices();
            FillActivitiesByUser();
        }

        private void FillOffices()
        {
            List<Office> lstOffices = _facade.GetOffices();
            ActivityOffices.DataSource = lstOffices;
            ActivityOffices.DataBind();

            litTotalOfficeMiles.Text = lstOffices.Sum(o => o.Mileage).ToString();
        }

        private void FillActivitiesByUser()
        {
            List<vwActivitiesByUser> lstActivitiesByUser = _facade.GetActivitiesLeaderBoard();
            ActivitiesRepeater.DataSource = lstActivitiesByUser;
            ActivitiesRepeater.DataBind();

            litTotalMileage.Text = lstActivitiesByUser.Sum(s => s.TotalMileage).ToString();
            litTotalUsersMiles.Text = litTotalMileage.Text;
        }
    }
}