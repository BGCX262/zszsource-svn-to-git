<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TypeManage.aspx.cs" Inherits="Default2" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<input Id="New" type="button" value="添加新分类" onclick="AddNew()"/>
    <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" AllowPaging="True" CellPadding="4" DataKeyNames="Id" ForeColor="#333333" GridLines="None">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language"
                Visible="False" />
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" Visible="False" />
            <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="TypeDetail.aspx?id={0}"
                DataTextField="Name" HeaderText="分类名" />
            <asp:BoundField DataField="Order" HeaderText="排序值" SortExpression="Order" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <EditRowStyle BackColor="#999999" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetTypes"
        TypeName="BLL.TypeManager" DataObjectTypeName="Model.Type" DeleteMethod="Delete" InsertMethod="Add" UpdateMethod="Update">
        <SelectParameters>
            <asp:Parameter Name="language" Type="Int32" DefaultValue="0" />
        </SelectParameters>
    </asp:ObjectDataSource>
   <div id="AddType" style="display:none">
        <ul>
            <li>新分类中文名&nbsp;
                <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                排序值&nbsp;
                <asp:TextBox ID="tbOrder" runat="server"></asp:TextBox>
                <asp:Button ID="Add" runat="server" Text="添加" OnClick="Add_Click" />
                </li></ul>
   </div>
<script type="text/javascript">
function AddNew()
{
    document.getElementById("AddType").style["display"]="";
}
</script> 
</asp:Content>

