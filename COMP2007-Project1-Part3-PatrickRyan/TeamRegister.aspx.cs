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
 * @date: June 15th, 2016
 * @version: 0.0.2 - adds a new team to the database
 */
namespace COMP2007_Project1_Part3_PatrickRyan
{
    public partial class TeamRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            Response.Redirect("~/Team.aspx");
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

                // Redirect back to the updated departments page
                Response.Redirect("~/Team.aspx");
            }
        }
    }
}

