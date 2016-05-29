<%@ Page Language="C#" AutoEventWireup="true" CodeFile="upl.aspx.cs" Inherits="upl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:FileUpload runat="server" ID="fu1" />
      <asp:Button  runat="server" ID="btnUpload" Text="Upload" 
            onclick="btnUpload_Click"  />
                <asp:Label runat="server" ID="lblMessage" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
