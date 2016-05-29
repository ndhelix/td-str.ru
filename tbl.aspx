<%@ page language="C#" autoeventwireup="true" masterpagefile="~/MasterPage.master" CodeFile="~/tbl.aspx.cs" Inherits="tbl"  %>

<asp:Content ID="FV" ContentPlaceHolderID="BodyContent" runat="server">
<asp:HyperLink ID="hlUpper" CssClass="upperlink" runat=server />
<br>
<asp:Label ID="lblTitle" CssClass="titlelabel" runat=server />
<br>
      <asp:DataGrid ID="gvTbl" AutoGenerateColumns=false runat="server" DataSource="<%# DV %>"
       AllowPaging=false PageSize=50 >
       <Columns>
       
       <asp:TemplateColumn HeaderText="Наименование">
       <ItemTemplate>
       <asp:HyperLink ID="HyperLink1" Text='<%#  Eval("name") %>' 
       NavigateUrl='<%# "file.aspx?id=" + Eval("id") %>'  
       runat="server" />
       </ItemTemplate>
       </asp:TemplateColumn>

       <asp:TemplateColumn HeaderText="Марка">
       <ItemTemplate>
       <asp:HyperLink ID="HyperLink1" Text='<%#  Eval("mark") %>' 
       NavigateUrl='<%# "file.aspx?id=" + Eval("id") %>'  
       runat="server" />
       </ItemTemplate>
       </asp:TemplateColumn>

       
       </Columns>
      </asp:DataGrid>
      
      <p style="text-align:center">
      <asp:HyperLink ID=hlPrevPage  Text="←"  runat=server />
      <asp:HyperLink ID=hlNextPage  Text="→"  runat=server />
      </p>
</asp:Content>