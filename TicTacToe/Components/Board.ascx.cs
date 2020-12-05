using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace TicTacToe.Components
{
    public partial class Board : UserControl
    {
        public IEnumerable<string> Squares
        {
            get => (IEnumerable<string>) Session[UniqueID + "Squares"];
            set
            {
                Session[UniqueID + "Squares"] = value;
                RenderSquares();
            }
        }

        public event EventHandler<SquareClickEventArgs> Click;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Squares = Enumerable.Range(0, 9)
                    .Select(item => default(string));
            }

            Enumerable.Range(0, 9)
                .ToList()
                .ForEach(elm =>
                {
                    var ucSquare = (Square) FindControl($"ucSquare{elm}");

                    ucSquare.Click += (o, evt)
                        => Click?.Invoke(o, new SquareClickEventArgs(elm));
                });
        }

        private void RenderSquares()
        {
            Enumerable.Range(0, 9)
                .ToList()
                .ForEach(elm =>
                {
                    var ucSquare =
                        (Square) FindControl($"ucSquare{elm}");

                    ucSquare.Value = Squares.ElementAt(elm);
                });
        }
    }
}