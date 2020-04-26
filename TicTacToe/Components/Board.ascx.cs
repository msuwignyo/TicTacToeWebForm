using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace TicTacToe.Components
{
    public partial class Board : UserControl
    {
        // props
        public string[] Squares { get; set; }
        public Action<int> OnClick { get; set; }
        // -----

        protected void Page_Load(object sender, EventArgs e)
        {
            Square0.Controls.Add(RenderSquare(0));
            Square1.Controls.Add(RenderSquare(1));
            Square2.Controls.Add(RenderSquare(2));
            Square3.Controls.Add(RenderSquare(3));
            Square4.Controls.Add(RenderSquare(4));
            Square5.Controls.Add(RenderSquare(5));
            Square6.Controls.Add(RenderSquare(6));
            Square7.Controls.Add(RenderSquare(7));
            Square8.Controls.Add(RenderSquare(8));
        }

        protected override void Render(HtmlTextWriter writer)
        {
            for (int i = 0; i < 9; i++)
            {
                var tempControl =
                    (Square)FindControl($"Square{i}").Controls[0];

                tempControl.Value = Squares[i];
            }

            base.Render(writer);
        }

        private Square RenderSquare(int i)
        {
            var square = (Square) LoadControl("~/Components/Square.ascx");

            square.Value = Squares[i];
            square.ClickSquare = () => OnClick(i);

            return square;
        }
    }
}