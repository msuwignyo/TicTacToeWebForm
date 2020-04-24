using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicTacToe.Components
{

    public partial class Game : System.Web.UI.UserControl
    {
        public List<string[]> History { get; set; }
        public bool XIsNext { get; set; }

        protected override void OnInit(EventArgs e)
        {
            History = new List<string[]>();

            if (!IsPostBack) // only called first time
            {
                var tempSquares = Enumerable.Repeat<string>(null, 9).ToArray();
                History.Add(tempSquares);
                XIsNext = true;

                Session["squares"] = tempSquares;
                Session["xIsNext"] = XIsNext;
            }

            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}