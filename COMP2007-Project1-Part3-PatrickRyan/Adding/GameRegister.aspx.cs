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
 * @version: 0.0.3 - adds a new game to the database
 */

namespace COMP2007_Project1_Part3_PatrickRyan
{
    public partial class GameRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get the games data
            this.GetTeamNames();
        }

        /**
         * <summary>
         * This method gets teamnames and enters them into the team name dropdown lists
         * </summary>
         * @method GetTeamNames
         * @return {void}
         * */
        protected void GetTeamNames()
        {

            //connect to EF
            using (GameTrackerConnection db = new GameTrackerConnection())
            {

                //query the teams table using EF and LINQ
                var Teams = (from allTeamNames in db.Teams
                             select allTeamNames.TeamName);
                //adds team names to Team1dropdownlist
                Team1DropDownList.DataSource = Teams.AsQueryable().ToList();
                Team1DropDownList.DataBind();
                //adds team names to Team2dropdownlist
                Team2DropDownList.DataSource = Teams.AsQueryable().ToList();
                Team2DropDownList.DataBind();
            }
        }

        /**
         * <summary>
         * This method returns the user to games page
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
         * This method creates a game object based on that information, then redirects the user back to the home page.
         * </summary>
         * @method SaveButton_Click
         * @return {void}
         * */
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to connect to the server
            using (GameTrackerConnection db = new GameTrackerConnection())
            {
                // use the Games model to create a new Game object and save a new record
                Game newGame = new Game();

                int GameID = 0;

                // add form data to the new games record
                newGame.GameName = GameNameTextBox.Text;
                newGame.Description = DescriptionTextBox.Text;
                newGame.Runs = Convert.ToInt32(RunsTextBox.Text);
                newGame.Spectators = Convert.ToInt32(SpectatorsTextBox.Text);
                newGame.Team1 = Team1DropDownList.SelectedValue;
                newGame.Team2 = Team2DropDownList.SelectedValue;
                newGame.WinningTeam = WinningTeamTextBox.Text;
                newGame.Created = DateTime.Now.Date;

                // use LINQ to ADO.NET to add / insert new game into the database
                if (GameID == 0)
                {
                    db.Games.Add(newGame);
                }
                // save our changes - also updates and inserts
                db.SaveChanges();
                // Redirect back to the updated games page
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}