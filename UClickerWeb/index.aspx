<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="UClickerWeb.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="contentBody" ContentPlaceHolderID="body" runat="server">

    <div align="center">
        <form runat="server">
            <p>Poll Code:</p>
            <asp:TextBox runat="server" ID="tbPollCode" />
            <br /><br />
            <asp:Button runat="server" Text="Submit"/>
        </form>
    </div>
    
</asp:Content>