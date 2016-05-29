using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class search : System.Web.UI.Page
{
  protected DataView DV;
  //int page, categ, pagesize;
  
  protected void Page_Load(object sender, EventArgs e)
  {
    GetParams();    
    GetData();
    
  }

  void GetParams()
  {
  }

  void GetData()
    {
      //if (PreviousPage == null) return;
      //if (PreviousPage.FindControl("txtsearch") == null) return;
      //string searchstring = ((TextBox)PreviousPage.FindControl("txtsearch")).Text;
      string searchstring = txtsearch.Text;
      string sqlexec = string.Format("spSearch '{0}'", searchstring);
      DV = CommonUnit.Select(sqlexec).DefaultView;
      if (DV.Count > 0)
      gvTbl.DataBind();
    }



 
}
