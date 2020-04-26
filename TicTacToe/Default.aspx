<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TicTacToe._Default" %>

<%@ Register Src="Components/Game.ascx" TagPrefix="m" TagName="Game" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div id="errors" style="background: #c00; color: #fff; display: none; margin: -20px -20px 20px; padding: 20px; white-space: pre-wrap;"></div>
            <m:Game runat="server" ID="GameControl"></m:Game>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script>
        window.addEventListener('mousedown',
            function (e) {
                document.body.classList.add('mouse-navigation');
                document.body.classList.remove('kbd-navigation');
            });
        window.addEventListener('keydown',
            function (e) {
                if (e.keyCode === 9) {
                    document.body.classList.add('kbd-navigation');
                    document.body.classList.remove('mouse-navigation');
                }
            });
        window.addEventListener('click',
            function (e) {
                if (e.target.tagName === 'A' && e.target.getAttribute('href') === '#') {
                    e.preventDefault();
                }
            });
        window.onerror = function (message, source, line, col, error) {
            const text = error ? error.stack || error : message + ' (at ' + source + ':' + line + ':' + col + ')';
            window.errors.textContent += text + '\n';
            window.errors.style.display = '';
        };
        console.error = (function (old) {
            return function error() {
                window.errors.textContent += Array.prototype.slice.call(arguments).join(' ') + '\n';
                window.errors.style.display = '';
                old.apply(this, arguments);
            };
        })(console.error);
    </script>


</asp:Content>
