using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class categ : System.Web.UI.Page
{
  protected DataView DV;
  int  parent;
  
  protected void Page_Load(object sender, EventArgs e)
  {
    GetParams();    
    GetData();
  }

  void GetParams()
  {
    parent = 0;
    if (Request["parent"] != null)
      int.TryParse(Request["parent"], out parent);
  }

  void GetData()
    {

      string sqlexec = "spGetCateg " + parent.ToString();
      DV = CommonUnit.Select(sqlexec).DefaultView;
      gvTbl.DataBind();
      
      lblTitle.Text = CommonUnit.SqlExecute("spGetCategName " + parent);
    }

    

}
