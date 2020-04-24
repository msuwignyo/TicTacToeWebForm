<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Game.ascx.cs" Inherits="TicTacToe.Components.Game" %>
<%@ Register src="Board.ascx" tagPrefix="m" tagName="Board" %>

<asp:UpdatePanel runat="server" class="game" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="game-board">
            <m:Board runat="server" ID="BoardControl"></m:Board>
        </div>
        <div class="game-info">
            <div></div>
            <ol></ol>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>