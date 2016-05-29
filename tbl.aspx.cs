using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class tbl : System.Web.UI.Page
{
  protected DataView DV;
  int page, categ, pagesize;
  
  protected void Page_Load(object sender, EventArgs e)
  {
    GetParams();    
    GetData();
    SetPaging();
  }

  void GetParams()
  {
    pagesize = 50;
    page = 1;
    if (Request["page"] != null)
      int.TryParse(Request["page"], out page);
    categ = 2;
    if (Request["categ"] != null)
      int.TryParse(Request["categ"], out categ);
  }

  void GetData()
    {

      string sqlexec = string.Format("spGetPage {0}, {1}, {2}", categ, page, pagesize);
      DV = CommonUnit.Select(sqlexec).DefaultView;
      gvTbl.DataBind();

      hlUpper.Text = CommonUnit.SqlExecute("spGetCategParentName " + categ);
      hlUpper.NavigateUrl = "categ.aspx?parent=" + CommonUnit.SqlExecute("spGetCategParent " + categ);

      lblTitle.Text = CommonUnit.SqlExecute("spGetCategName " + categ);
    }

    void SetPaging()
    {
      hlPrevPage.NavigateUrl = string.Format("tbl.aspx?categ={0}&page={1}", categ, page - 1);
      hlPrevPage.Visible = page != 1;
      
      hlNextPage.NavigateUrl = string.Format("tbl.aspx?categ={0}&page={1}", categ, page + 1);
      string sqlexec = string.Format("spPageExist {0}, {1}, {2}", categ, page+1, pagesize);
      string pageexists = CommonUnit.SqlExecute(sqlexec);
      hlNextPage.Visible = pageexists == "1";
    }
    

}
