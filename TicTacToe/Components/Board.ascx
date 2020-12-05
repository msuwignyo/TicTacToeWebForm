<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Board.ascx.cs" Inherits="TicTacToe.Components.Board" %>
<%@ Register src="Square.ascx" tagPrefix="m" tagName="Square" %>

<asp:UpdatePanel runat="server"
                 UpdateMode="Conditional"
                 ChildrenAsTriggers="False"
                 ID="upBoard">
    <ContentTemplate>
        <div class="board-row">
            <m:Square runat="server" ID="ucSquare0" />
            <m:Square runat="server" ID="ucSquare1" />
            <m:Square runat="server" ID="ucSquare2" />
        </div>
        <div class="board-row">
            <m:Square runat="server" ID="ucSquare3" />
            <m:Square runat="server" ID="ucSquare4" />
            <m:Square runat="server" ID="ucSquare5" />
        </div>
        <div class="board-row">
            <m:Square runat="server" ID="ucSquare6" />
            <m:Square runat="server" ID="ucSquare7" />
            <m:Square runat="server" ID="ucSquare8" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
