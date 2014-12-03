<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="UClickerWeb.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="contentBody" ContentPlaceHolderID="body" runat="server">
    <asp:Panel runat="server" ID="frmPollCode">
        <div align="center" class="container">
            <form runat="server" class="form-signin" role="form">
                <asp:TextBox placeholder="Poll Code" CssClass="form-control" runat="server" ID="tbPollCode" />
                <asp:TextBox placeholder="Name" CssClass="form-control" runat="server" ID="tbUserID" />
                <br /><br />
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" runat="server" Text="Submit" OnClick="btn_PollCodeSubmit"/>
                <br />
                <asp:Label runat="server" ID="lblStatus" ForeColor="Red" />
            </form>
        </div>
    </asp:Panel>
    
</asp:Content>