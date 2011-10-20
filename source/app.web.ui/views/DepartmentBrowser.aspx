<%@ MasterType VirtualPath="App.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="app.web.ui.views.DepartmentBrowser"
CodeFile="DepartmentBrowser.aspx.cs"
 MasterPageFile="App.master" %>
<%@ Import Namespace="app.models" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>
            <table>            
              <%-- for each department --%>
              <% foreach (var department in ((IEnumerable<DepartmentItem>)this.Context.Items["blah"]))
                 { %>

              <tr class="ListItem">
               <td><a href="#"><%= department.name %></a></td>
           	  </tr>        
              <% } %>
      	    </table>            
</asp:Content>
