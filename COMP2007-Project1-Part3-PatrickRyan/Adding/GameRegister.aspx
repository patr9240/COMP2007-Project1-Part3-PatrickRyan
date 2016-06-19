<%@ Page Title="Game Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GameRegister.aspx.cs" Inherits="COMP2007_Project1_Part3_PatrickRyan.GameRegister" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- 
     GameRegister.aspx
     Patrick Ross - Ryan Jameson
     COMP2007_Project1_Part3_PatrickRyan
     This is the game registeration page for NorthStar Tracking
    -->
      <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">
                <h1>Add a Game</h1>
                <h5> All fields are Required</h5>
                <br />
                <div class="form-group">
                    <label class="control-label" for="GameNameTextBox">Game Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="GameNameTextBox" placeholder="Game Name" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="DescriptionTextBox">Game Description</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="DescriptionTextBox" placeholder="Game Description" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="RunsTextBox">Game Runs</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="RunsTextBox" placeholder="Game Runs" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="SpectatorsTextBox">Total Spectators</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="SpectatorsTextBox" placeholder="Total Spectators" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="Team1DropDownList">Select First Team</label>
                    <asp:DropDownList runat="server" CssClass="form-control" ID="Team1DropDownList" required="true">
                        <asp:ListItem Text="Select a Team..." Value="Placeholder" />
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label class="control-label" for="Team2DropDownList">Select Second Team</label>
                    <asp:DropDownList runat="server" CssClass="form-control" ID="Team2DropDownList" required="true">
                        <asp:ListItem Text="Select a Team..." Value="Placeholder" />
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label class="control-label" for="WinningTeamTextBox">Winning Team</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="WinningTeamTextBox" placeholder="Winning Team" required="true"></asp:TextBox>
                </div>
                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" CssClass="tbn btn-warning btn-lg" runat="server" UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click"/>
                    <asp:Button Text="Save" ID="SaveButton" CssClass="tbn btn-primary btn-lg" runat="server" OnClick="SaveButton_Click"/>
                </div>
            </div>
        </div>
    </div>
        
</asp:Content>
