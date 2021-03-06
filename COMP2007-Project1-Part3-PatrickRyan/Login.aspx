﻿<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="COMP2007_Project1_Part3_PatrickRyan.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- 
     Login.aspx
     Patrick Ross - Ryan Jameson
     COMP2007_Project1_Part3_PatrickRyan
     This is the login page for NorthStar Game Tracking
    -->
   <div class="container">    
        <div class="row">
            <div class="col-md-offset-3 col-md-4"> 
                <div class="alert alert-danger" id="AlertFlash" runat="server" visible="false">
                    <asp:Label runat="server" ID="StatusLabel" />
                </div>
                <h1>Login Page</h1>
                   <br />
                        <div class="form-group">
                            <label class="control-label" for="UserNameTextBox">Username:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="UserNameTextBox" placeholder="Username" required="true" TabIndex="0"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label class="control-label" for="PasswordTextBox">Password:</label>
                            <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="PasswordTextBox" placeholder="Password" required="true" TabIndex="0"></asp:TextBox>
                        </div>
                        <div class="text-right">
                            <asp:Button Text="Login" ID="LoginButton" runat="server" CssClass="btn btn-primary" OnClick="LoginButton_Click" TabIndex="0" />
                        </div>
                    </div>
        </div>
    </div>
</asp:Content>
