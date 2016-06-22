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
namespace COMP2007_Project1_Part3_PatrickRyan
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetUser();
            }
        }

        /**
         * <summary>
         * This method gets the user from the database and populates the fields
         * </summary>
         * @method GetUser
         * @return {void}
         * */
        protected void GetUser()
        {
            string UserID = (HttpContext.Current.User.Identity.GetUserId().ToString());
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
        * This method returns the user to the home page
        * </summary>
        * @method CancelButton_Click
        * @return {void}
        * */
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        /**
         * <summary>
         * This method saves the changed information of the user to the database
         * </summary>
         * @method SaveButton_Click
         * @return {void}
         * */
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string UserID = (HttpContext.Current.User.Identity.GetUserId().ToString());

            using (UsersConnection db = new UsersConnection())
            {
                AspNetUser newUser = new AspNetUser();
                newUser = (from users in db.AspNetUsers
                           where users.Id == UserID
                           select users).FirstOrDefault();

                newUser.UserName = UserNameTextBox.Text;
                newUser.PhoneNumber = PhoneNumberTextBox.Text;
                newUser.Email = EmailTextBox.Text;

                db.SaveChanges();

                Response.Redirect("~/Default.aspx");

            }
        }
    }
}