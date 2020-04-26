<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Game.ascx.cs" Inherits="TicTacToe.Components.Game" %>
<%@ Register Src="Board.ascx" TagPrefix="m" TagName="Board" %>

<div class="game">
    <div class="game-board">
        <m:Board runat="server" ID="BoardControl" />
    </div>
    <div class="game-info">
        <div runat="server" ID="Status"></div>
        <asp:Repeater runat="server" 
                      ID="HistoryRepeater"
                      OnItemDataBound="HistoryRepeater_OnItemDataBound">
            <HeaderTemplate>
                <ol>
            </HeaderTemplate>
            <ItemTemplate>
                <li runat="server" 
                    ID="HistoryItem">
                    <button runat="server" 
                            ID="HistoryItemButton">
                    </button>
                </li>
            </ItemTemplate>
            <FooterTemplate>
            </ol>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</div>
