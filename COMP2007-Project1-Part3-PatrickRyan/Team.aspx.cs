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
 * @version: 0.0.1 - adds teams to the teamgridview
 */
namespace COMP2007_Project1_Part3_PatrickRyan
{
    public partial class Teams : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if loading page for the first time, populate the grid
            if (!IsPostBack)
            {

                //get the Team data
                this.GetTeams();
            }
        }

        /**
         * <summary>
         * This method gets the teams from the database
         * </summary>
         * @method GetTeams
         * @return {void}
         * */
        protected void GetTeams()
        {
            //connect to EF
            using (GameTrackerConnection db = new GameTrackerConnection())
            {
                //query the teams table using EF and LINQ
                var Teams = (from allTeams in db.Teams select allTeams);

                //bind results to gridview
                TeamsGridView.DataSource = Teams.AsQueryable().ToList();
                TeamsGridView.DataBind();
            }
        }


        /**
        * <summary>
        * This event handler deletes a team from the database using EF
        * </summary>
        * @method TeamsGridView_RowDeleting
        * @param {object} sender
        * @param {GridViewDeleteEventArgs}
        * @returns {void}
        * */
        protected void TeamsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store which row was clicked
            int selectedRow = e.RowIndex;

            //get the selected teamID using the grids datakey collection
            int TeamID = Convert.ToInt32(TeamsGridView.DataKeys[selectedRow].Values["TeamID"]);

            //use ef to find the selected team and delete it
            using (GameTrackerConnection db = new GameTrackerConnection())
            {
                //create object of the team class and store the query int inside of it
                Team deletedTeam = (from teamRecords in db.Teams
                                    where teamRecords.TeamID == TeamID
                                    select teamRecords).FirstOrDefault();

                //remove the selected team from the db
                db.Teams.Remove(deletedTeam);

                //save db changes
                db.SaveChanges();

                //refresh gridview
                this.GetTeams();

            }
        }
    }
}