<%@ Page Title="Team" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Team.aspx.cs" Inherits="COMP2007_Project1_Part3_PatrickRyan.Teams" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- 
     Team.aspx
     Patrick Ross - Ryan Jameson
     COMP2007_Project1_Part3_PatrickRyan
     This is the team information page for NorthStar Tracking
    -->
    <div class="img2">
        <img src="Assets/teams.jpg" width="500" height="250" />
    </div>
    <div class="container">
        <div class="row">
            <div class="container">
                <div class="row">
                    <div class="col-md-offset-2 col-md-8">
                        <h3>Teams</h3>
                        <a href="TeamRegister.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"></i>Add a Team</a>
                        <asp:GridView ID="TeamsGridView" runat="server" CssClass="table table-bordered table-striped table-hover"
                            AutoGenerateColumns="false" DataKeyNames="TeamID" OnRowDeleting="TeamsGridView_RowDeleting">
                            <Columns>
                                <asp:BoundField DataField="TeamID" Visible="false" />
                                <asp:BoundField DataField="TeamName" HeaderText="Team Name" Visible="true" />
                                <asp:BoundField DataField="Description" HeaderText="Description" Visible="true" />
                                <asp:BoundField DataField="Sport" HeaderText="Sport" Visible="true" />
                                <asp:BoundField DataField="City" HeaderText="City" Visible="true" />
                                <asp:BoundField DataField="TotalRuns" HeaderText="Total Runs" Visible="true" />
                                <asp:BoundField DataField="AllowedRuns" HeaderText="Allowed Runs" Visible="true" />
                                <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete" ShowDeleteButton="true" ButtonType="Link"
                                    ControlStyle-CssClass="btn btn-danger btn-sm" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
