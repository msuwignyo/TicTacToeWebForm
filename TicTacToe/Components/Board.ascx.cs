using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Services;
using System.Web.UI;

namespace TicTacToe.Components
{
    public partial class Board : UserControl
    {
        public static string Status { get; set; }
        public static string[] Squares { get; set; }
        public bool XIsNext { get; set; }

        protected override void OnInit(EventArgs e)
        {
            if (!IsPostBack)
            {
                Squares = Enumerable.Repeat<string>(null, 9).ToArray();
                XIsNext = true;

                Session["squares"] = Squares;
                Session["xIsNext"] = XIsNext;
            }
            else
            {
                Squares = (string[])Session["squares"];
                XIsNext = (bool)Session["xIsNext"];
            }

            Status = "Next player: " + (XIsNext ? "X" : "O");

            base.OnInit(e);
        }

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

        protected void HandleClick(int i)
        {
            Squares = Squares.Select((item, index) =>
            {
                var tempItem = item;
                var tempControl = (Square)FindControl($"Square{i}").Controls[0];

                if (index == i)
                {
                    tempItem = XIsNext ? "X" : "O";
                    tempControl.Value = tempItem;
                }

                return tempItem;
            }).ToArray();

            XIsNext = !XIsNext;
            Session["squares"] = Squares;
            Session["xIsNext"] = XIsNext;

            var winner = Helpers.CalculateWinner(Squares);

            if (winner != null)
            {
                Status = $"Winner: {winner}";
            }
            else
            {
                Status = "Next player: " + (XIsNext ? "X" : "O");
            }
        }

        private Square RenderSquare(int i)
        {
            var square = (Square) LoadControl("~/Components/Square.ascx");

            square.Value = Squares[i];
            square.ClickSquare = () => HandleClick(i);

            return square;
        }
    }
}