using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class upl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
      fu1.SaveAs(Server.MapPath("upl") + "//" + fu1.FileName);
      lblMessage.Text = "File Successfully Uploaded";
    }
}
