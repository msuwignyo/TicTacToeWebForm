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
        public string Value
        {
            get => (string) Session[UniqueID + "Value"]; 
            set => Session[UniqueID + "Value"] = value;
        }

        public event EventHandler Click;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Value = null;
            }

            //btnSquare.ServerClick += Click;
        }

        protected void btnSquare_OnServerClick(object sender, EventArgs e)
        {
            Click?.Invoke(sender, e);
        }
    }
}