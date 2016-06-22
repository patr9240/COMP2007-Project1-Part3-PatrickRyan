using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COMP2007_Project1_Part3_PatrickRyan.Models;
using System.Web.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
/**
 * @author: Patrick Ross - Ryan Jameson
 * @date: June 22nd, 2016
 * @version: 0.0.1 - Created page
 */
namespace COMP2007_Project1_Part3_PatrickRyan.Admin
{
    public partial class AdminUserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {
                    PasswordPlaceHolder.Visible = false;
                    this.GetUser();
                }
                else
                {
                    PasswordPlaceHolder.Visible = true;
                }

            }
        }

        /**
         * <summary>
         * This method gets the user from the database
         * </summary>
         * @method GetUsers
         * @return {void}
         * */
        protected void GetUser()
        {
            string UserID = Request.QueryString["Id"].ToString();
            using (UsersConnection db = new UsersConnection())
            {
                AspNetUser updatedUser = (from user in db.AspNetUsers
                                          where user.Id == UserID
                                          select user).FirstOrDefault();
                if (updatedUser != null)
                {
                    UserNameTextBox.Text = updatedUser.UserName;
                    PhoneNumberTextBox.Text = updatedUser.PhoneNumber;
                    EmailTextBox.Text = updatedUser.Email;
                }
            }
        }

        /**
         * <summary>
         * This method returns the admin to the AdminUsers page
         * </summary>
         * @method GetUsers
         * @return {void}
         * */
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AdminUsers.aspx");
        }

        /**
         * <summary>
         * This method saves a new user to the database
         * </summary>
         * @method SaveButton_Click
         * @return {void}
         * */
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string UserID = "";

            //if updating user
            if (Request.QueryString.Count > 0)
            {
                using (UsersConnection db = new UsersConnection())
                {
                    AspNetUser newUser = new AspNetUser();
                    UserID = Request.QueryString["Id"].ToString();
                    newUser = (from users in db.AspNetUsers
                               where users.Id == UserID
                               select users).FirstOrDefault();

                    newUser.UserName = UserNameTextBox.Text;
                    newUser.PhoneNumber = PhoneNumberTextBox.Text;
                    newUser.Email = EmailTextBox.Text;

                    db.SaveChanges();

                    Response.Redirect("~/Admin/AdminUsers.aspx");
                }
            }

            //if creating a new user
            if (UserID == "")
            {

                // create new userStore and userManager objects
                var userStore = new UserStore<IdentityUser>();
                var userManager = new UserManager<IdentityUser>(userStore);

                //create a new user object
                var user = new IdentityUser()
                {
                    UserName = UserNameTextBox.Text,
                    PhoneNumber = PhoneNumberTextBox.Text,
                    Email = EmailTextBox.Text
                };
                //create new user on db and store the result
                IdentityResult result = userManager.Create(user, PasswordTextBox.Text);
                //check if successfully registered
                if (result.Succeeded)
                {
                    Response.Redirect("~/Admin/AdminUsers.aspx");
                }
                else
                {
                    StatusLabel.Text = result.Errors.FirstOrDefault();
                    AlertFlash.Visible = true;
                }
            }
        }
    }
}