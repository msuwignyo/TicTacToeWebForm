<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Square.ascx.cs" Inherits="TicTacToe.Components.Square" %>

<style>
    #<%= upSquare.ClientID %> button {
        background-color: transparent;
    }
</style>

<asp:UpdatePanel runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" class="square"
                 style="border: none;" ID="upSquare"> 
    <ContentTemplate>
        <button runat="server"
                class="square"
                ID="btnSquare"
                OnServerClick="btnSquare_OnServerClick">
            <%= Value %>
        </button>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSquare" EventName="ServerClick" />
    </Triggers>
</asp:UpdatePanel>