<%@ Page Title="AdminTeams" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminTeams.aspx.cs" Inherits="COMP2007_Project1_Part3_PatrickRyan.Admin.AdminTeams" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- 
     AdminTeams.aspx
     Patrick Ross - Ryan Jameson
     COMP2007_Project1_Part3_PatrickRyan
     This is the admin team information page for NorthStar Tracking
    -->
    <div class="img2">
        <img src="Assets/teams.jpg" width="500" height="250" />
    </div>
    <div class="container">
        <div class="row">
            <div class="container">
                <div class="row">
                    <div class="col-md-offset-1 col-md-8">
                        <h3>Teams</h3>
                         <asp:PlaceHolder ID="AddingTeamHolder" runat="server">
                        <a href="/Admin/AdminRegisterTeams.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"></i>Add a Team</a>
                        </asp:PlaceHolder>
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
                            <asp:HyperLinkField HeaderText="Edit" Text="<i calss='fa fa-encil-square-o fa-lg'></i> Edit"
                            NavigateUrl="/Admin/AdminRegisterTeams.aspx"  ControlStyle-CssClass="btn btn-primary btn-sm" DataNavigateUrlFields="TeamID"
                            runat="server" DataNavigateUrlFormatString="/Admin/AdminRegisterTeams.aspx?TeamID={0}" />
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
