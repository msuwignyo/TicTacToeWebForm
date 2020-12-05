<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Game.ascx.cs" Inherits="TicTacToe.Components.Game" %>
<%@ Register Src="Board.ascx" TagPrefix="m" TagName="Board" %>

<asp:UpdatePanel runat="server" class="game"
                 UpdateMode="Conditional"
                 ChildrenAsTriggers="False"
                 ID="upGame">
    <ContentTemplate>
        <div class="game-board">
            <m:Board runat="server" ID="ucBoard" />
        </div>
        <div class="game-info">
            <div>
                <asp:Literal runat="server" ID="ltlStatus" />
            </div>
            <asp:Repeater runat="server" 
                          ID="rptHistories">
                <HeaderTemplate>
                <ol>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <button runat="server" 
                                ID="btnHistory"
                                OnServerClick="btnHistory_OnServerClick">
                            <%# (string) Container.DataItem %>
                        </button>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                </ol>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
