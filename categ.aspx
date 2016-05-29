<%@ page language="C#" autoeventwireup="true" masterpagefile="~/MasterPage.master" CodeFile="categ.aspx.cs"  Inherits="categ" %>

<asp:Content ID="FV" ContentPlaceHolderID="BodyContent" runat="server">
<asp:Label ID="lblTitle" CssClass="titlelabel" runat=server />
<br>
      <asp:DataGrid ID="gvTbl" AutoGenerateColumns=false runat="server" DataSource="<%# DV %>"
       AllowPaging=false PageSize=50 ShowHeader=false >
       <Columns>
       
       <asp:TemplateColumn>
       <ItemTemplate>
       <asp:HyperLink Text='<%#  Eval("name") %>' 
       NavigateUrl='<%# string.IsNullOrEmpty(Eval("parent").ToString()) ?  "categ.aspx?parent=" + Eval("id") : "tbl.aspx?categ=" + Eval("id")%>' 
       runat="server" />
       </ItemTemplate>
       </asp:TemplateColumn>
       
       </Columns>
      </asp:DataGrid>
      
</asp:Content>