//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace COMP2007_Project1_Part3_PatrickRyan.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Game
    {
        public int GameID { get; set; }
        public string GameName { get; set; }
        public string Description { get; set; }
        public int Runs { get; set; }
        public int Spectators { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public string WinningTeam { get; set; }
        public System.DateTime Created { get; set; }
    }
}
