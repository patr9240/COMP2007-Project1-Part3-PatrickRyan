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
 * @date: June 21st, 2016
 * @version: 0.0.1 - Page Created
 */
namespace COMP2007_Project1_Part3_PatrickRyan.Admin
{
    public partial class AdminRegisterGames : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetGame();
            }     
        }

        /**
        * <summary>
        * This method gets the game being edited and enters it's data into the text fields
        * </summary>
        * @method GetGame
        * @return {void}
        * */
        protected void GetGame()
        {
            // populate the form with existing data from the database
            int GameID = Convert.ToInt32(Request.QueryString["GameID"]);

            // connect to the EF DB
            using (GameTrackerConnection db = new GameTrackerConnection())
            {
                // populate a game object instance with the GameID from the URL Parameter
                Game UpdatedGame = (from game in db.Games
                                          where game.GameID == GameID
                                          select game).FirstOrDefault();

                // map the game properties to the form controls
                if (UpdatedGame != null)
                {
                    GameNameTextBox.Text = UpdatedGame.GameName;
                    DescriptionTextBox.Text = UpdatedGame.Description;
                    RunsTextBox.Text = UpdatedGame.Runs.ToString();
                    SpectatorsTextBox.Text = UpdatedGame.Spectators.ToString();
                    Team1TextBox.Text = UpdatedGame.Team1;
                    Team2TextBox.Text = UpdatedGame.Team2;
                    WinningTeamTextBox.Text = UpdatedGame.WinningTeam;
                    CreatedDate.Text = UpdatedGame.Created.ToString("yyyy-MM-dd");
                }
            }
        }

        /**
         * <summary>
         * This method creates a game object based on that information, then redirects the user back to the admin games page.
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

                if (Request.QueryString.Count > 0) // our URL has a GameID in it
                {
                    // get the id from the URL
                    GameID = Convert.ToInt32(Request.QueryString["GameID"]);

                    // get the current game from EF DB
                    newGame = (from game in db.Games
                                  where game.GameID == GameID
                                  select game).FirstOrDefault();
                }

                // add form data to the new games record
                newGame.GameName = GameNameTextBox.Text;
                newGame.Description = DescriptionTextBox.Text;
                newGame.Runs = Convert.ToInt32(RunsTextBox.Text);
                newGame.Spectators = Convert.ToInt32(SpectatorsTextBox.Text);
                newGame.Team1 = Team1TextBox.Text;
                newGame.Team2 = Team2TextBox.Text;
                newGame.WinningTeam = WinningTeamTextBox.Text;
                newGame.Created = Convert.ToDateTime(CreatedDate.Text).Date;
                // use LINQ to ADO.NET to add / insert new game into the database
                if (GameID == 0)
                {
                    db.Games.Add(newGame);
                }
                // save our changes - also updates and inserts
                db.SaveChanges();
                // Redirect back to the updated games page
                Response.Redirect("~/Admin/AdminGames.aspx");
            }
        }

        /**
         * <summary>
         * This method returns the user to admin games page
         * </summary>
         * @method CancelButton_Click
         * @return {void}
         * */
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AdminGames.aspx");
        }
    }
}