<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="vote.aspx.cs" Inherits="UClickerWeb.vote" %>

<asp:Content ID="contentBody" ContentPlaceHolderID="body" runat="server">
    <div align="center" class="container">
        <form id="frmResponses" runat="server" class="form-signin" role="form">
            <asp:Label runat="server" ID="lblQuestion" />
            <br /><br />
        </form>
    </div>
</asp:Content>

