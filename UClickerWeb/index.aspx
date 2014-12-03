<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="UClickerWeb.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="contentBody" ContentPlaceHolderID="body" runat="server">
    <asp:Panel runat="server" ID="frmPollCode">
        <div align="center">
            <form runat="server">
                <p>Poll Code:</p>
                <asp:TextBox runat="server" ID="tbPollCode" />
                <p>UserID:</p>
                <asp:TextBox runat="server" ID="tbUserID" />
                <br /><br />
                <asp:Button runat="server" Text="Submit" OnClick="btn_PollCodeSubmit"/>
                <br />
                <asp:Label runat="server" ID="lblStatus" ForeColor="Red" />
            </form>
        </div>
    </asp:Panel>
    
</asp:Content>