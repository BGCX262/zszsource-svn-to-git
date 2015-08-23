<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SysManage.aspx.cs" Inherits="SysManage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <input Id="New" type="button" value="添加类型" onclick="AddNew()"/>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataSourceID="ObjectDataSource1" DataKeyNames="Language,Name" Width="100%">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" />
            <asp:HyperLinkField DataNavigateUrlFields="name" DataNavigateUrlFormatString="SysDetail.aspx?name={0}"
                DataTextField="Name" HeaderText="菜单项" />
            <asp:BoundField DataField="Value" HeaderText="显示值" SortExpression="Value" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetSyss"
        TypeName="BLL.SysManager" DataObjectTypeName="Model.Sys" UpdateMethod="Update" DeleteMethod="Delete">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="language" QueryStringField="language"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
       <div id="AddSys" style="display:none">
        <ul>
            <li>
                项名称&nbsp;
                <asp:TextBox ID="tbName" runat="server"></asp:TextBox>&nbsp;
                中文显示值&nbsp;
                <asp:TextBox ID="tbValue" runat="server"></asp:TextBox>
                <asp:Button ID="Add" runat="server" Text="添加" OnClick="Add_Click" />
                </li></ul>
   </div>
<script language="javascript">
function AddNew()
{
    document.getElementById("AddSys").style["display"]="";
}
</script>  
</asp:Content>

