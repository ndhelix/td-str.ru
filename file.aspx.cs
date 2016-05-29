using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class file : System.Web.UI.Page
{
  
  protected void Page_Load(object sender, EventArgs e)
  {
    if (Request["id"] == null)
      Response.Redirect("~/");
    GetData();
  }
    void GetData()
    {
      string sqlexec = string.Format("spGetFile {0}", Request["id"]);
      body.Text = CommonUnit.SqlExecute(sqlexec);

      string sqlexec2 = string.Format("spGetFileTitle {0}", Request["id"]);
      this.Title = CommonUnit.SqlExecute(sqlexec2);
      
      HtmlMeta keywords = new HtmlMeta();
      keywords.Name = "description";
      keywords.Content = this.Title;
      this.Header.Controls.Add(keywords);

      lblTitle.Text = CommonUnit.SqlExecute("spGetFileTitle " + Request["id"]);

      hlUpper.Text = CommonUnit.SqlExecute("spGetCategName NULL, "+Request["id"]);
      hlUpper.NavigateUrl = "tbl.aspx?categ=" + CommonUnit.SqlExecute("spGetCategId NULL, "+Request["id"]);
    }

}
