<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Square.ascx.cs" Inherits="TicTacToe.Components.Square" %>

<button type="button"
        runat="server"
        class="square"
        onserverclick="OnServerClick">
    <%= Value %>
</button>