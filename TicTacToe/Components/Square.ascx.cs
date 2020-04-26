using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicTacToe.Components
{
    public partial class Square : System.Web.UI.UserControl
    {
        // props
        public string Value { get; set; }
        public Action ClickSquare { get; set; }
        // -----

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void OnServerClick(object sender, EventArgs e)
        {
            ClickSquare();
        }
    }
}