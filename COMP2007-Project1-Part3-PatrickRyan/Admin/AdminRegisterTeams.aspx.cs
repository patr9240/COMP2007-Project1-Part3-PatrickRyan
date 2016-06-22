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
    public partial class AdminRegisterTeams : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetTeams();
            }
        }

        /**
       * <summary>
       * This method gets the team being edited and enters it's data into the text fields
       * </summary>
       * @method GetTeam
       * @return {void}
       * */
        protected void GetTeams()
        {
            // populate the form with existing data from the database
            int TeamID = Convert.ToInt32(Request.QueryString["TeamID"]);

            // connect to the EF DB
            using (GameTrackerConnection db = new GameTrackerConnection())
            {
                // populate a team object instance with the TeamID from the URL Parameter
                Team UpdatedTeam = (from team in db.Teams
                                    where team.TeamID == TeamID
                                    select team).FirstOrDefault();

                // map the team properties to the form controls
                if (UpdatedTeam != null)
                {
                    TeamNameTextBox.Text = UpdatedTeam.TeamName;
                    DescriptionTextBox.Text = UpdatedTeam.Description;
                    SportTextBox.Text = UpdatedTeam.Sport;
                    CityTextBox.Text = UpdatedTeam.City;
                    TotalRunsTextBox.Text = UpdatedTeam.TotalRuns.ToString();
                    AllowedRunsTextBox.Text = UpdatedTeam.AllowedRuns.ToString();
                }
            }
        }

        /**
         * <summary>
         * This method creates a new team object and adds it to the database, redirects the user to team viewing page
         * </summary>
         * @method SaveButton_Click
         * @return {void}
         * */
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to connect to the server
            using (GameTrackerConnection db = new GameTrackerConnection())
            {
                // use the Teams model to create a new team object and save a new record
                Team newTeam = new Team();

                int TeamID = 0;

                if (Request.QueryString.Count > 0) // our URL has a Team in it
                {
                    // get the id from the URL
                    TeamID = Convert.ToInt32(Request.QueryString["TeamID"]);

                    // get the current team from EF DB
                    newTeam = (from team in db.Teams
                               where team.TeamID == TeamID
                               select team).FirstOrDefault();
                }

                // add form data to the new teams record
                newTeam.TeamName = TeamNameTextBox.Text;
                newTeam.Description = DescriptionTextBox.Text;
                newTeam.Sport = SportTextBox.Text;
                newTeam.City = CityTextBox.Text;
                newTeam.TotalRuns = Convert.ToInt32(TotalRunsTextBox.Text);
                newTeam.AllowedRuns = Convert.ToInt32(AllowedRunsTextBox.Text);

                // use LINQ to ADO.NET to add / insert new team into the database

                if (TeamID == 0)
                {
                    db.Teams.Add(newTeam);
                }


                // save our changes - also updates and inserts
                db.SaveChanges();

                // Redirect back to the updated admin teams page
                Response.Redirect("~/Admin/AdminTeams.aspx");
            }
        }

        /**
         * <summary>
         * This method redirects the user back to the team viewing page
         * </summary>
         * @method CancelButton_Click
         * @return {void}
         * */
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AdminTeams.aspx");
        }
    }
}