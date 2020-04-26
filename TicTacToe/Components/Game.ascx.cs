using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TicTacToe.Components
{
    public partial class Game : System.Web.UI.UserControl
    {
        // state
        public static List<string[]> History { get; set; }
        public static int StepNumber { get; set; }
        public static bool XIsNext { get; set; }
        // -----

        protected override void OnInit(EventArgs e)
        {
            if (!IsPostBack) // only called first time
            {
                var tempSquares = Enumerable.Repeat<string>(null, 9).ToArray();

                History = new List<string[]> { tempSquares };
                XIsNext = true;
                StepNumber = 0;
            }

            base.OnInit(e);
        }

        protected void HandleClick(int i)
        {
            var history = History;
            var current = history.Last();
            var squares = new string[current.Length];
            current.CopyTo(squares, 0);

            // ignore if someone has won the game or if
            // a Square is already filled
            if (Helpers.CalculateWinner(current) != null || current[i] != null)
            {
                return;
            }

            squares[i] = XIsNext ? "X" : "O";

            // set state
            History.Add(squares);
            StepNumber = History.Count;
            XIsNext = !XIsNext;


            // karena data-nya berubah, perlu diatur ulang data-nya

            var winner = Helpers.CalculateWinner(current);

            var moves = history.Select((step, move) => new
            {
                move,
                desc = move == 0 ? "Go to game start" : $"Go to move #{move}"
            });

            HistoryRepeater.DataSource = moves;
            HistoryRepeater.DataBind();

            if (winner != null)
            {
                Status.InnerText = $"Winner: {winner}";
            }
            else
            {
                Status.InnerText = "Next player: " + (XIsNext ? "X" : "O");
            }

            BoardControl.Squares = squares;
            BoardControl.OnClick = HandleClick;
        }

        protected void JumpTo(int stepNo)
        {
            // set state
            StepNumber = stepNo;
            XIsNext = (StepNumber % 2) == 0;
            History = History.GetRange(0, StepNumber + 1);

            // karena data-nya berubah, perlu diatur ulang data-nya

            var history = History;
            var current = history.Last();
            var squares = new string[current.Length];
            current.CopyTo(squares, 0);
            var winner = Helpers.CalculateWinner(current);

            var moves = history.Select((step, move) => new
            {
                move,
                desc = move == 0 ? "Go to game start" : $"Go to move #{move}"
            });

            HistoryRepeater.DataSource = moves;
            HistoryRepeater.DataBind();

            if (winner != null)
            {
                Status.InnerText = $"Winner: {winner}";
            }
            else
            {
                Status.InnerText = "Next player: " + (XIsNext ? "X" : "O");
            }

            BoardControl.Squares = squares;
            BoardControl.OnClick = HandleClick;
            BoardControl.DataBind();

            //Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var history = History;
            var current = history.Last();
            var winner = Helpers.CalculateWinner(current);

            var moves = history.Select((step, move) => new
            {
                move,
                desc = move == 0 ? "Go to game start" : $"Go to move #{move}"
            });

            HistoryRepeater.DataSource = moves;
            HistoryRepeater.DataBind();

            if (winner != null)
            {
                Status.InnerText = $"Winner: {winner}";
            }
            else
            {
                Status.InnerText = "Next player: " + (XIsNext ? "X" : "O");
            }

            BoardControl.Squares = current;
            BoardControl.OnClick = HandleClick;
        }

        protected void HistoryRepeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                dynamic data = e.Item.DataItem;
                var move = (int)data.move;
                var desc = (string)data.desc;

                var historyItem = (HtmlGenericControl)e.Item.FindControl("HistoryItem");
                var historyItemButton = (HtmlButton)e.Item.FindControl("HistoryItemButton");

                historyItem.Attributes["key"] = move.ToString();
                historyItemButton.InnerText = desc;
                historyItemButton.ServerClick += (o, args) => JumpTo(move);
            }
        }
    }
}