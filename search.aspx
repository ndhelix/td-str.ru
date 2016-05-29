<%@ page language="C#" autoeventwireup="true" masterpagefile="~/MasterPage.master" CodeFile="Search.aspx.cs" Inherits=search %>
<asp:Content ID="FV" ContentPlaceHolderID="BodyContent" runat="server">
<asp:TextBox ID="txtsearch" runat=server />
<asp:Button ID="btnsearch" Text="Искать"  runat=server />
<br><br>
      <asp:DataGrid ID="gvTbl" AutoGenerateColumns=false runat="server" DataSource="<%# DV %>"
       AllowPaging=false >
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
      
</asp:Content>