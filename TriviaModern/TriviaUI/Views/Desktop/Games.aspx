<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="Games.aspx.cs" Inherits="TriviaGame.Views.Desktop.Games" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <title>Game Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" >
            <Scripts>
                <asp:ScriptReference Path="Script/jquery-1.2.6.js" />
            </Scripts>
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
                <asp:Label ID="DebugLabel" runat="server" Text="..."></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
