<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Board.ascx.cs" Inherits="TicTacToe.Components.Board" %>
<%@ Reference Control="Square.ascx" %>

<div class="status"><%= Status %></div>
<div class="board-row">
    <asp:PlaceHolder runat="server" ID="Square0"></asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="Square1"></asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="Square2"></asp:PlaceHolder>
</div>
<div class="board-row">
    <asp:PlaceHolder runat="server" ID="Square3"></asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="Square4"></asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="Square5"></asp:PlaceHolder>
</div>
<div class="board-row">
    <asp:PlaceHolder runat="server" ID="Square6"></asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="Square7"></asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="Square8"></asp:PlaceHolder>
</div>
