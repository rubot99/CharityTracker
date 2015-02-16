using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharityTracker.Admin
{
    public partial class AddUsers : System.Web.UI.Page
    {
        private TrackerFacade _facade = new TrackerFacade();

        protected void Page_Init(object sender, EventArgs e)
        {
            btnAddUser.Click += btnAddUser_Click;
        }

        void btnAddUser_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text))
            {
                MembershipUser newUser = Membership.CreateUser(txtUserName.Text, txtPassword.Text);
                Roles.AddUserToRole(newUser.UserName, ddlRoleType.SelectedItem.Text);

                txtPassword.Text = string.Empty;
                txtUserName.Text = String.Empty;
                ddlRoleType.SelectedIndex = 0;

                FillUsers();
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
            FillUsers();
            FillRoles();
        }

        private void FillUsers()
        {
            UserRepeater.DataSource = _facade.GetAllActiveUsers();
            UserRepeater.DataBind();
        }

        private void FillRoles()
        {
            List<string> lstRoles = Roles.GetAllRoles()
                .OrderByDescending(r => r)
                .ToList<string>();

            ddlRoleType.DataSource = lstRoles;
            ddlRoleType.DataBind();

            ddlRoleType.SelectedIndex = 0;
        }
    }
}