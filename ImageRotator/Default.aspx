<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ImageRotator._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    
    <p>Count: <asp:Literal runat="server" ID="ltlCount"></asp:Literal></p> 

    <p>Title: <asp:Literal runat="server" ID="ltlTitle"></asp:Literal></p> 
   
    <p><asp:HyperLink runat="server" ID="hlUrl"></asp:HyperLink></p> 
    
    <div class="frame">
        <asp:Image runat="server" ID="imgFlower" />
    </div>

</asp:Content>
