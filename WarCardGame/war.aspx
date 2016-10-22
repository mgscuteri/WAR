<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="war.aspx.cs" Inherits="warSpace.war" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Style.css" rel="stylesheet" />
    <title>War</title>
</head>
<body>
    <form id="form1" runat="server">      
        <div id ="ClickTheButton">
            <h1>WAR</h1>
            This is an asp.net webforms application version of the popular card game, WAR.&nbsp; It is a quick project I threw together to demo basic asp.net/c# functionality.&nbsp; There project currently has 2 known limitations.&nbsp; 1) In the event that a a &quot;war&quot; occurs, should the result of this tie be another tie, the game will not process a second war, 
            instead it will destroy the cards that were in play.&nbsp; 2) I believe the official rules state that decks are supposed to be re-shuffled at some point.&nbsp; This version of the game will simply place all cards earned at the bottom of your hand. 
            <br />
            <br />
            <asp:Label ID="bodyText" runat="server" Text="Now Go Ahead, Click the button. You know you want to. "></asp:Label>
        </div>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Draw" Height="47px" Width="242px" />
        <br />
        <asp:Button ID="warButton" runat="server" Height="42px" OnClick="Button2_Click" Text="GO TO WAR!" Visible="False" Width="241px" />
        <br />
        <asp:Button ID="Button2" runat="server" Height="43px" OnClick="Button2_Click1" Text="Play Again" Width="240px" Visible="False" />
        <br />
        <br />

        <div id ="winLoss">
            <asp:Label ID="winLossTracker" runat="server"></asp:Label>
            <br />
            <div id ="smallText">
                Player Wins: <asp:Label ID="playerWinsLabel" runat="server" Text="0"></asp:Label>
                <br />
                Computer Wins: <asp:Label ID="computerWinsLabel" runat="server" Text="0"></asp:Label>
                <br />
            </div>
        </div>

        <div id="container">
            <div id="left">
                Your Card
                <br />
                <asp:Image ID="playerCardImage" runat="server" Height="273px" />
                <br />
                <asp:Image ID="playerWarCard1" runat="server" Height="272px" style="margin-top: 0px" Visible="False" />
                <br />
                <asp:Image ID="playerWarCard2" runat="server" Height="272px" style="margin-top: 0px" Visible="False" />
                <br />
            </div>
            <div id="right"> 
                 Computer's Card 
                <br />
                <asp:Image ID="computerCardImage" runat="server" Height="273px" />
                <br />
                <asp:Image ID="computerWarCard1" runat="server" Height="272px" style="margin-top: 0px" Visible="False" />
                <br />
                <asp:Image ID="computerWarCard2" runat="server" Height="272px" style="margin-top: 0px" Visible="False" />
                <br />
            </div>
        </div>

        <div id="container2">
            <div id="left2">               
                Hand Sizes<br />
                Your Hand:
                <br />
                Computer&#39;s Hand:</div>
            <div id ="right2">
                <br />
                <asp:Label ID="playerStack" runat="server" Text="[]"></asp:Label>
                <br />
                <asp:Label ID="computerStack" runat="server" Text="[]"></asp:Label>
            </div>
        </div>

        <div id ="winLoss0">
            <asp:Label ID="finalResult" runat="server"></asp:Label>
            <br />
            <br />
            <br />
        </div>

    </form>
</body>
</html>
