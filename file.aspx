<%@ page language="C#" autoeventwireup="true" masterpagefile="~/MasterPage.master" CodeFile="~/file.aspx.cs" Inherits="file"  %>

<asp:Content ID="FV" ContentPlaceHolderID="BodyContent" runat="server">
<link href="css/file.css" rel="stylesheet" />
<link rel="stylesheet" href="css/style.css" type="text/css" >
<asp:HyperLink ID="hlUpper" runat=server />
<br><br>
<asp:Label ID="lblTitle" CssClass="titlelabel" runat=server />

<div class="filebody">
<asp:Literal ID="body" runat=server />
</div>
</asp:Content>