using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COMP2007_Project1_Part3_PatrickRyan.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

/**
 * @author: Patrick Ross - Ryan Jameson
 * @date: June 15th, 2016
 * @version: 0.0.3 - Populates gridview, change games viewed by date
 */

namespace COMP2007_Project1_Part3_PatrickRyan
{
    public partial class _default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //if loading page for the first time, populate the grid
            if (!IsPostBack)
            {
                //get the games data
                this.GetGames();
            }
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {

                // show the team add button
                AddingGameHolder.Visible = true;
                //hide admin only fields
                GameTableDate.Visible = false;
                GameTableDelete.Visible = false;
                GameTableEdit.Visible = false;
                //if user = admin
                if (HttpContext.Current.User.Identity.Name == "admin")
                {
                    //hide admin only fields
                    GameTableDate.Visible = true;
                    GameTableDelete.Visible = true;
                    GameTableEdit.Visible = true;
                }


            }
            else
            {
                AddingGameHolder.Visible = false;
                //hide admin only fields
                GameTableDate.Visible = false;
                GameTableDelete.Visible = false;
                GameTableEdit.Visible = false;
            }
            
        }

        /**
         * <summary>
         * This method gets the games from the database and puts them into the gridview based on the date specified in the dropdown menu
         * </summary>
         * @method GetGames
         * @return {void}
         * */
        protected void GetGames()
        {

            //connect to EF
            using (GameTrackerConnection db = new GameTrackerConnection())
            {
                DateTime date1 = new DateTime();
                DateTime date2 = new DateTime();
                date1 = Convert.ToDateTime(TrackingWeekDropDown.SelectedValue);
                date2 = Convert.ToDateTime(TrackingWeekDropDown.Items[TrackingWeekDropDown.SelectedIndex + 1].Value);

                //query the Games table using EF and LINQ
                var Games = (from allGames in db.Games
                             where allGames.Created >= date1.Date
                             && allGames.Created < date2.Date
                             select allGames);

                //bind results to gridview
                GamesGridView.DataSource = Games.AsQueryable().ToList();
                GamesGridView.DataBind();
                TrackingDateLabel.Text = date1.ToString("MMMM dd, yyyy") + " To " + date2.ToString("MMMM dd, yyyy");
            }
        }
        /**
         * <summary>
         * This event handler deletes a game from the databse using EF
         * </summary>
         * @method GamesGridView_RowDeleting
         * @param {object} sender
         * @param {GridViewDeleteEventArgs}
         * @returns {void}
         * */
        protected void GamesGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store which row was clicked
            int selectedRow = e.RowIndex;

            //get the selected gamename using the grids datakey collection
            int GameID = Convert.ToInt32(GamesGridView.DataKeys[selectedRow].Values["GameID"]);

            //use ef to find the slected game and delete it
            using (GameTrackerConnection db = new GameTrackerConnection())
            {
                //create object of the game class and store the query string inside of it
                Game deletedGame = (from gameRecords in db.Games
                                    where gameRecords.GameID == GameID
                                    select gameRecords).FirstOrDefault();

                //remove the selected game from the db
                db.Games.Remove(deletedGame);

                //save db changes
                db.SaveChanges();

                //refresh gridview
                this.GetGames();

            }
        }
        /**
         * <summary>
         * This method gets the games from the database and puts them into the gridview when a index is selected in the dropdown
         * </summary>
         * @method TrackingWeekDropDown_SelectedIndexChanged
         * @return {void}
         * */
        protected void TrackingWeekDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetGames();
        }
    }
}