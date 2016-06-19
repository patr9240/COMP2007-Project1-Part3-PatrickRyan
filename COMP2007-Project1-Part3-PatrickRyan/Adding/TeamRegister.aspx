<%@ Page Title="Team Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TeamRegister.aspx.cs" Inherits="COMP2007_Project1_Part3_PatrickRyan.TeamRegister" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- 
     TeamRegister.aspx
     Patrick Ross - Ryan Jameson
     COMP2007_Project1_Part3_PatrickRyan
     This is the Team registeration page for NorthStar Tracking
    -->
    <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">
                <h1>Add a Team</h1>
                <h5> All fields are Required</h5>
                <br />
                <div class="form-group">
                    <label class="control-label" for="TeamNameTextBox">Team Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="TeamNameTextBox" placeholder="Team Name" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="DescriptionTextBox">Team Description</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="DescriptionTextBox" placeholder="Team Description" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="SportTextBox">Teams Sport</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="SportTextBox" placeholder="Teams Sport" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="CityTextBox">Teams City</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="CityTextBox" placeholder="Teams City" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="TotalRunsTextBox">Total Runs</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="TotalRunsTextBox" placeholder="Total Runs" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="AllowedRunsTextBox">Allowed Runs</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="AllowedRunsTextBox" placeholder="Allowed Runs" required="true"></asp:TextBox>
                </div>
                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" CssClass="tbn btn-warning btn-lg" runat="server" UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click"/>
                    <asp:Button Text="Save" ID="SaveButton" CssClass="tbn btn-primary btn-lg" runat="server" OnClick="SaveButton_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
