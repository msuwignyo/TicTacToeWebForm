using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TicTacToe.Components
{
    public class SquareClickEventArgs : EventArgs
    {
        public int Index { get; set; }

        public SquareClickEventArgs(int index)
        {
            Index = index;
        }
    }

    public class History
    {
        public IEnumerable<string> Squares { get; set; }
    }

    public partial class Game : System.Web.UI.UserControl
    {
        public IEnumerable<History> Histories
        {
            get => (IEnumerable<History>) Session[UniqueID + "History"]; 
            set => Session[UniqueID + "History"] = value;
        }

        public int StepNumber
        {
            get => (int) Session[UniqueID + "StepNumber"]; 
            set => Session[UniqueID + "StepNumber"] = value;
        }

        public bool XIsNext
        {
            get => (bool) Session[UniqueID + "XIsNext"]; 
            set => Session[UniqueID + "XIsNext"] = value;
        }

        public string Status
        {
            get => ltlStatus.Text;
            set => ltlStatus.Text = value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Histories = new History[]
                {
                    new History
                    {
                        Squares = Enumerable.Range(0, 9)
                            .Select(item => default(string))
                    }
                };

                StepNumber = 0;
                XIsNext = true;
            }

            ucBoard.Click += HandleClick;
        }

        protected override void OnPreRender(EventArgs e)
        {
            var histories = Histories.ToList();
            var current = histories[StepNumber];
            var squares = current.Squares.ToList();

            var winner = Helpers.CalculateWinner(squares.ToList());

            rptHistories.DataSource = histories.Select((step, move) 
                => move != 0 ? $"Go to move #{move}" : "Go to game start");
            
            rptHistories.DataBind();

            if (!string.IsNullOrEmpty(winner))
            {
                Status = "Winner: " + winner;
            }
            else
            {
                Status = "Next player: " + (XIsNext ? "X" : "O");
            }

            ucBoard.Squares = current.Squares;

            base.OnPreRender(e);
        }

        protected void HandleClick(object sender, SquareClickEventArgs e)
        {
            var histories = Histories.Take(StepNumber + 1).ToList();
            var current = histories.Last();
            var squares = current.Squares.ToList();

            if (Helpers.CalculateWinner(squares) != null || !string.IsNullOrEmpty(squares[e.Index]))
            {
                return;
            }

            squares[e.Index] = XIsNext ? "X" : "O";

            histories.Add(new History { Squares = squares });

            Histories = histories;
            StepNumber = histories.Count - 1;
            XIsNext = !XIsNext;

            upGame.Update();
        }

        protected void btnHistory_OnServerClick(object sender, EventArgs e)
        {
            // controls
            var btnHistory = (HtmlButton) sender;

            // data
            var rptItemHistory = (RepeaterItem) btnHistory.NamingContainer;

            StepNumber = rptItemHistory.ItemIndex;
            XIsNext = StepNumber % 2 == 0;

            upGame.Update();
        }
    }
}