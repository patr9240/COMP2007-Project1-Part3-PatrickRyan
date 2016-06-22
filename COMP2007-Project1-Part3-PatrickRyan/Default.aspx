<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="COMP2007_Project1_Part3_PatrickRyan._default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- 
     Default.aspx
     Patrick Ross - Ryan Jameson
     COMP2007_Project1_Part3_PatrickRyan
     This is the home page for NorthStar Tracking
        Home
    -->
    <div class="img1">
        <img src="Assets/baseball.gif" />
    </div>

    <div class="container">
        <div class="row">
            <div class="col-md-offset-1 col-md-8">
                <h3><asp:Label ID="TrackingDateLabel" runat="server"></asp:Label></h3>
                <asp:PlaceHolder ID="AddingGameHolder" runat="server">
                <a href="/Adding/GameRegister.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"></i>Add a Game</a>
                </asp:PlaceHolder>
                <asp:GridView ID="GamesGridView" runat="server" CssClass="table table-bordered table-striped table-hover"
                    AutoGenerateColumns="false" DataKeyNames="GameID" OnRowDeleting="GamesGridView_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="GameID" Visible="false" />
                        <asp:BoundField DataField="GameName" HeaderText="Game Name" Visible="true" />
                        <asp:BoundField DataField="Description" HeaderText="Description" Visible="true" />
                        <asp:BoundField DataField="Runs" HeaderText="Runs" Visible="true" />
                        <asp:BoundField DataField="Spectators" HeaderText="Spectators" Visible="true" />
                        <asp:BoundField DataField="Team1" HeaderText="First Team" Visible="true" />
                        <asp:BoundField DataField="Team2" HeaderText="Second Team" Visible="true" />
                        <asp:BoundField DataField="WinningTeam" HeaderText="Winner" Visible="true" />
                        <asp:BoundField DataField="Created" HeaderText="Current Date" DataFormatString="{0:d}" Visible="false" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div>
            <label for="PageSizeDropDownList"></label>
            <asp:DropDownList runat="server" ID="TrackingWeekDropDown" AutoPostBack="true"
                CssClass="btn btn-default bt-sm dropdown-toggle" OnSelectedIndexChanged="TrackingWeekDropDown_SelectedIndexChanged">
                <asp:ListItem Text="First Week" Value="2016-06-05" />
                <asp:ListItem Text="Second Week" Value="2016-06-12" />
                <asp:ListItem Text="Third Week" Value="2016-06-19" />
                <asp:ListItem Text="Fourth Week" Value="2016-06-26" />
                <asp:ListItem Text="Placeholder" Value="2016-07-03" Enabled="False" />
            </asp:DropDownList> 
        </div>
    </div>
</asp:Content>
