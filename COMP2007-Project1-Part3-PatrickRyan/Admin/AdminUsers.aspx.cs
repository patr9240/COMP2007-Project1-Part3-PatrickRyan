using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COMP2007_Project1_Part3_PatrickRyan.Models;
using System.Web.ModelBinding;

/**
 * @author: Patrick Ross - Ryan Jameson
 * @date: June 22nd, 2016
 * @version: 0.0.1 - Created page
 */
namespace COMP2007_Project1_Part3_PatrickRyan.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetUsers();
            }
        }

        /**
         * <summary>
         * This method gets the users from the database
         * </summary>
         * @method GetUsers
         * @return {void}
         * */
        protected void GetUsers()
        {
            using (UsersConnection db = new UsersConnection())
            {
                var Users = (from users in db.AspNetUsers
                             select users);
                UsersGridView.DataSource = Users.ToList();
                UsersGridView.DataBind();
            }
        }

        /**
         * <summary>
         * This method deletes a user from the database
         * </summary>
         * @method UsersGridView_RowDeleting
         * @return {void}
         * */
        protected void UsersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int selectedRow = e.RowIndex;

            string UserID = UsersGridView.DataKeys[selectedRow].Values["Id"].ToString();

            using (UsersConnection db = new UsersConnection())
            {
                AspNetUser deletedUser = (from users in db.AspNetUsers
                                          where users.Id == UserID
                                          select users).FirstOrDefault();

                db.AspNetUsers.Remove(deletedUser);
                db.SaveChanges();
            }
            //refresh user gridview
            this.GetUsers();
        }
    }
}
