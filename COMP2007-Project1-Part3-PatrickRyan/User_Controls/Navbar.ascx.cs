using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

/**
 * @author: Patrick Ross - Ryan Jameson
 * @date: June 6th, 2016
 * @version: 0.0.2 - Updated setActivePage method to include new links
 */

namespace COMP2007_Project1_Part3_PatrickRyan
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // check if a user is logged in
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {

                    // show the logged in Content area
                    AdminPlaceHolder.Visible = false;
                    LoginPlaceHolder.Visible = false;
                    AddingPlaceHolder.Visible = true;
                    PublicPlaceHolder.Visible = true;
                    

                    //check if admin is logged in
                    if (HttpContext.Current.User.Identity.GetUserName() == "admin")
                    {
                        //show admin links
                        AdminPlaceHolder.Visible = true;
                        PublicPlaceHolder.Visible = false;
                    }
                                                    
                }
                else
                {
                    // only show login and register
                    AdminPlaceHolder.Visible = false;
                    AddingPlaceHolder.Visible = false;
                    LoginPlaceHolder.Visible = true;
                    PublicPlaceHolder.Visible = true;

                }
                SetActivePage();
            }

        }

        /**
         * This method adds a css class of "active" to list items
         * relating to the current page
         * 
         * @private
         * @method SetActivePage
         * @return {void}
         */
        private void SetActivePage()
        {
            switch (Page.Title)
            {
                case "Home Page":
                    home.Attributes.Add("class", "active");
                    break;
                case "Game Register":
                    home.Attributes.Add("class", "active");
                    break;
                case "Team":
                    team.Attributes.Add("class", "active");
                    break;
                case "Team Register":
                    team.Attributes.Add("class", "active");
                    break;
                case "Register":
                    register.Attributes.Add("class", "active");
                    break;
                case "Login":
                    login.Attributes.Add("class", "active");
                    break;
                case "Logout":
                    logout.Attributes.Add("class", "active");
                    break;
                case "Profile":
                    profile.Attributes.Add("class", "active");
                    break;

                case "AdminGames":
                    admingames.Attributes.Add("class", "active");
                    break;
                case "Admin Game Register":
                    admingames.Attributes.Add("class", "active");
                    break;
                case "AdminTeams":
                    adminteams.Attributes.Add("class", "active");
                    break;
                case "AdminRegisterTeams":
                    adminteams.Attributes.Add("class", "active");
                    break;
                case "AdminUsers":
                    adminusers.Attributes.Add("class", "active");
                    break;
                case "AdminUserDetails":
                    adminusers.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}