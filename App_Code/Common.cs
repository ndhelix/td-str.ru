using System;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;



  /// <summary>
  /// Purpose: Data Access class for the view 'v_DATABASE'.
  /// </summary>
  public class CommonUnit : cl_DBInteractionBase
  {
    #region Class Member Declarations
    private SqlInt64 _sERVER_ID, _dATABASE_ID;
    private SqlBoolean _iN_USE;
    private SqlString _sERVER, _aPP_COMMAND_LINE, _dATABASE_NAME, _dISPLAY_NAME;
    #endregion


    /// <summary>
    /// Purpose: Class constructor.
    /// </summary>
    public CommonUnit()
    {
      // Nothing for now.
    }

    public static DataTable Select(string strexec)
    {
      if (!CheckQueryString(ref strexec))
        throw new Exception("SqlException. Possible SQL injection.");

      SqlCommand cmdToExecute = new SqlCommand();
      cmdToExecute.CommandText = strexec;
      cmdToExecute.CommandTimeout = 60;
      DataTable toReturn = new DataTable("dt");
      SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

      if (_mainConnection == null)
      {
        CommonUnit cu = new CommonUnit();
        //throw new Exception("Error. _mainConnection is NULL ");
      }
    
      cmdToExecute.Connection = _mainConnection;

      
      try
      {
        _mainConnection.Open();
        adapter.Fill(toReturn);
        return toReturn;
      }
      catch (Exception ex)
      {
        throw new Exception("Error. CommonUnit > Select > "+ strexec, ex);
      }
      finally
      {
        _mainConnection.Close();
        cmdToExecute.Dispose();
        adapter.Dispose();
      } 
    }

    public static void ClearConlrols(Page page)
    {
      Label lblError = (Label)page.Master.FindControl("lblErrorStatus");
      if (lblError == null)
        return;
      lblError.Text = "";
      lblError.Visible = false;
    }

    public static void SetDG4Viewer(DataGrid DG)
    {
      foreach (DataGridItem dgi in DG.Items)
        foreach (TableCell tc in dgi.Cells)
          foreach (Control control in tc.Controls)
          {
            if (control is ImageButton)
              ((ImageButton)control).Enabled = false;
            if (control is CheckBox)
              ((CheckBox)control).Enabled = false;
          }
    }

    public static void ConfirmationShow(Page page, string msg)
    {
      Label lblError;
      if (page.Master != null)
      {
        lblError = (Label)page.Master.FindControl("lblConfirmation");
      }
      else
      {
        lblError = (Label)page.FindControl("lblConfirmation");
      }
      if (lblError == null)
        page.Response.Write(msg);
      else
      {
        lblError.Text = msg;
        lblError.Visible = true;
      }
    }

    public static void ErrorShow(Page page, string msg)
    {
      Label lblError;
      if (page.Master != null)
      {
        lblError = (Label)page.Master.FindControl("lblErrorStatus");
      }
      else
      {
        lblError = (Label)page.FindControl("lblErrorStatus");
      }
      if (lblError == null)
        page.Response.Write(msg);
      else
        ErrorShow(lblError, msg);
    }
    public static void ErrorShow(Label lblError, string msg)
    {
      string msgout = msg;
      string e = "Ошибка. ";
      if (msg.Contains(e))
      {
        e = "";
      }
      if (msg.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
      {
        msgout = "Запись не может быть удалена, так как на нее ссылается запись в другой таблице.";
      }
      if (msg.Contains("_notempty_"))
      {
        msgout = "Заполнены не все обязательные поля.";
      }
      if (msg.Contains(" KEY constraint"))
      {
        msgout = "Попытка вставки дублирующего значения. Запись с таким значением уже существует. Попробуйте задать иное значение.";
      }
      if (msg.Contains("Error converting data type"))
      {
        if (msg.Contains("to int."))
        {
          msgout = "В поле указано неверное (нечисловое) значение.";
        }
      }
      msgout = msgout.Replace("SqlException. ", "");
      lblError.Text = e + msgout;
      lblError.Visible = true;
    }




    public static int CheckNumber(string str, Boolean AllowEmpty, int min, int max)
    {
      int r;
      if (str.Length != 0)
      {
        if (!Int32.TryParse(str, out r)) return -2; //non-integer value
        if (r < min || r > max) return -3;// exceeds boundaries
      }
      else
        if (!AllowEmpty) return -1;// empty string
      return 0;
    }



    public static string sprocFileUpload(
      int elmid, string FileName, byte[] FileContent, int filetype,
      string login, string descr, string ContentType, int parentid//, int neg
      )
    {
      string sproc = "spElmfileIns";
      if (FileContent.Length > 1024*1024*100 )
      {
        return "Размер ";
      }

      SqlCommand cmdToExecute = new SqlCommand();
      cmdToExecute.CommandText = sproc;
      cmdToExecute.CommandType = CommandType.StoredProcedure;
      cmdToExecute.Connection = _mainConnection;

      try
      {
        SqlParameter prmfile = new SqlParameter("@data", SqlDbType.VarBinary);
        prmfile.Value = FileContent;
        cmdToExecute.Parameters.Add(prmfile);
      
        SqlParameter prmid = new SqlParameter("@elm", SqlDbType.Int);
        prmid.Value = elmid;
        cmdToExecute.Parameters.Add(prmid);

        if (parentid != 0)
        {
          SqlParameter prmparentid = new SqlParameter("@parentid", SqlDbType.Int);
          prmparentid.Value = parentid;
          cmdToExecute.Parameters.Add(prmparentid);
        }

        cmdToExecute.Parameters.Add(new SqlParameter("filename", SqlDbType.NVarChar, 255, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, FileName));
        cmdToExecute.Parameters.Add(new SqlParameter("filetype", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, filetype));
        //cmdToExecute.Parameters.Add(new SqlParameter("neg", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, neg));
        cmdToExecute.Parameters.Add(new SqlParameter("contenttype", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ContentType));
        cmdToExecute.Parameters.Add(new SqlParameter("login", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, login));
        cmdToExecute.Parameters.Add(new SqlParameter("descr", SqlDbType.NVarChar, 255, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, descr));

        _mainConnection.Open();
        cmdToExecute.ExecuteScalar(); //ExecuteNonQuery();
        return cmdToExecute.ToString();
      }
      catch (SqlException ex)
      {
        return "SqlException. " + ex.Message;
      }
      finally
      {
        _mainConnection.Close();
        cmdToExecute.Dispose();
      }
    }

    public static string sprocAddMsg(
  int elmid,  string login, string msg
  )
    {
      string sproc = "spChatIns";

      SqlCommand cmdToExecute = new SqlCommand();
      cmdToExecute.CommandText = sproc;
      cmdToExecute.CommandType = CommandType.StoredProcedure;
      cmdToExecute.Connection = _mainConnection;

      try
      {
        SqlParameter prmid = new SqlParameter("elm", SqlDbType.Int);
        prmid.Value = elmid;
        cmdToExecute.Parameters.Add(prmid);

        cmdToExecute.Parameters.Add(new SqlParameter("login", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, login));
        cmdToExecute.Parameters.Add(new SqlParameter("msg", SqlDbType.NVarChar, 4000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, msg));

        _mainConnection.Open();
        cmdToExecute.ExecuteScalar(); //ExecuteNonQuery();
        return cmdToExecute.ToString();
      }
      catch (SqlException ex)
      {
        return "SqlException. " + ex.Message;
      }
      finally
      {
        _mainConnection.Close();
        cmdToExecute.Dispose();
      }
    }



    public static string SessionExtract(
        System.Web.SessionState.HttpSessionState session
      , string strindex
      )
    {
      return SessionExtract(session, strindex, "");
    }
    public static string SessionExtract(
        System.Web.SessionState.HttpSessionState session
      , string strindex
      , string defvalue
      )
    {
      string ret = defvalue;
      if (session[strindex] != null)
        ret = session[strindex].ToString();
      if (ret == "")
        ret = defvalue;
      return ret;
    }

    public static byte[] sprocFileDwld(int id)
    {
      string filename = "";
      return sprocFileDwld(id, "spElmfileDwld", "@id", out filename);
    }
    public static byte[] sprocFileDwld(int id, string sproc, string prm_id_name, out string filename)
    {
      //string sproc = "spElmfileDwld";
      filename = "";
      SqlDataReader dr = null;
      byte[] result = null;
      SqlCommand cmdToExecute = new SqlCommand();
      cmdToExecute.CommandText = sproc;
      cmdToExecute.CommandType = CommandType.StoredProcedure;
      cmdToExecute.Connection = _mainConnection;

      try
      {
        SqlParameter prmid = new SqlParameter(prm_id_name, SqlDbType.Int);
        prmid.Value = id;
        cmdToExecute.Parameters.Add(prmid);

          SqlParameter prmfilename = null;
          if (sproc.Contains("spElmfileTemplateDwld"))
          {
            prmfilename = new SqlParameter("@filename", SqlDbType.NVarChar, 255);
            prmfilename.Direction = ParameterDirection.Output;
            cmdToExecute.Parameters.Add(prmfilename);
          }

        _mainConnection.Open();
        dr = cmdToExecute.ExecuteReader(); //ExecuteNonQuery();

        //try{
//          filename = cmdToExecute.Parameters["@filename"].Value.ToString();
        //}
        //catch {}
        dr.Read();
        result = (byte[])dr.GetValue(0);
        dr.Close();
        if (prmfilename != null)
          if (prmfilename.Value != null)
          {
            filename = prmfilename.Value.ToString();
          }

      }
      catch (SqlException ex)
      {
//        return "SqlException. " + ex.Message;
      }
      finally
      {
        _mainConnection.Close();
        cmdToExecute.Dispose();
      }
      return result;
    }

    public static bool CheckQueryString(ref string strexec)
    {
      if (strexec.EndsWith(", "))
        strexec = strexec.Remove(strexec.Length - 2);
      if (strexec.EndsWith(","))
        strexec = strexec.Remove(strexec.Length - 1);

      int count = strexec.Split("'"[0]).Length - 1;
      if (count % 2 != 0) //odd
      {
        strexec = strexec.Replace("', '", "_@, @_");
        strexec = strexec.Replace("='", "_=@_");
        strexec = strexec.Replace("',", "_@,_");
        strexec = strexec.Replace(", '", "_, @_");

        strexec = strexec.Replace("'", "’");
        if (strexec.EndsWith("’"))
          strexec = strexec.Substring(0, strexec.Length - 1) + "'";

        strexec = strexec.Replace("_@, @_", "', '");
        strexec = strexec.Replace("_=@_", "='");
        strexec = strexec.Replace("_@,_", "',");
        strexec = strexec.Replace("_, @_", ", '");
      }

      count = strexec.Split("'"[0]).Length - 1;
      return (count % 2 == 0);
    }

    public static string SqlExecute(string strexec)
    {
      if (!CheckQueryString(ref strexec))
        return ("SqlException. Possible SQL injection.");
      SqlCommand cmdToExecute = new SqlCommand();
      cmdToExecute.CommandText = strexec;
      
      if (_mainConnection == null)
      {
        CommonUnit cu = new CommonUnit();
      }
      _mainConnection.Open();
      cmdToExecute.Connection = _mainConnection;

      try
      {
//        if (_mainConnection != null)
  //      {
          object obj = cmdToExecute.ExecuteScalar();
          if (obj == null) return "";
          else return obj.ToString();
    //    }
      //  else
        //return "";
      }
      catch (SqlException ex)
      {
        //if (ex.Message.Contains("CHECK constraint"))
        {
          //if (ex.Message.Contains("_notempty_"))
          {
//            return "error_" + "ct_notempty_";
            return "SqlException. " + ex.Message;
          }
        }
        //else
        {
//          throw new Exception("CommonUnit : SqlExecute(" + strexec + ") : Error occured : " + ex.Message, ex);
        }
      }
      finally
      {
        if (_mainConnection != null)
          _mainConnection.Close();
        cmdToExecute.Dispose();
      }
    }




    public static Boolean ValidateUser(Page page)
    {
      return ValidateUser(page, false);
    }
    public static Boolean ValidateUser(Page page, Boolean ismodal)
    {
      if (page.Session["login"] == null || page.Session["org"] == null)
      {
        if (!ismodal)
        {
          page.Response.Redirect("~/reg/login.aspx");
        }
        return false;
      }

      return true;
    }

    public static Boolean IsAdmin(Page page)
    {
      if (page.Session["role"] == null) return false;
      string role = page.Session["role"].ToString();
      return (role == "admin" || role == "designer" || role == "dsmng" || role == "admin"  );
    }

    


   #region Class Property Declarations
    public SqlInt64 DATABASE_ID
    {
      get
      {
        return _dATABASE_ID;
      }
      set
      {
        SqlInt64 dATABASE_IDTmp = (SqlInt64)value;
        if (dATABASE_IDTmp.IsNull)
        {
          throw new ArgumentOutOfRangeException("DATABASE_ID", "DATABASE_ID can't be NULL");
        }
        _dATABASE_ID = value;
      }
    }


    public SqlInt64 SERVER_ID
    {
      get
      {
        return _sERVER_ID;
      }
      set
      {
        SqlInt64 sERVER_IDTmp = (SqlInt64)value;
        if (sERVER_IDTmp.IsNull)
        {
          throw new ArgumentOutOfRangeException("SERVER_ID", "SERVER_ID can't be NULL");
        }
        _sERVER_ID = value;
      }
    }


    public SqlString DATABASE_NAME
    {
      get
      {
        return _dATABASE_NAME;
      }
      set
      {
        SqlString dATABASE_NAMETmp = (SqlString)value;
        if (dATABASE_NAMETmp.IsNull)
        {
          throw new ArgumentOutOfRangeException("DATABASE_NAME", "DATABASE_NAME can't be NULL");
        }
        _dATABASE_NAME = value;
      }
    }


    public SqlString DISPLAY_NAME
    {
      get
      {
        return _dISPLAY_NAME;
      }
      set
      {
        _dISPLAY_NAME = value;
      }
    }


    public SqlString APP_COMMAND_LINE
    {
      get
      {
        return _aPP_COMMAND_LINE;
      }
      set
      {
        _aPP_COMMAND_LINE = value;
      }
    }


    public SqlBoolean IN_USE
    {
      get
      {
        return _iN_USE;
      }
      set
      {
        SqlBoolean iN_USETmp = (SqlBoolean)value;
        if (iN_USETmp.IsNull)
        {
          throw new ArgumentOutOfRangeException("IN_USE", "IN_USE can't be NULL");
        }
        _iN_USE = value;
      }
    }


    public SqlString SERVER
    {
      get
      {
        return _sERVER;
      }
      set
      {
        _sERVER = value;
      }
    }
    #endregion
  }
