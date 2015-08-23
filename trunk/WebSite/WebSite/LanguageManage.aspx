<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LanguageManage.aspx.cs" Inherits="LanguageManage" Title="语言管理" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <input Id="New" type="button" value="添加新语言" onclick="AddNew()"/>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="#333333" GridLines="None"
        Width="447px" DataKeyNames="Id">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" ReadOnly="True" Visible="False" />
            <asp:BoundField DataField="Name" HeaderText="名称" SortExpression="Name" />
        </Columns>
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <EditRowStyle BackColor="#999999" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Model.Language"
        DeleteMethod="Delete" InsertMethod="Add" SelectMethod="GetLanguages" TypeName="BLL.LanguageManager"
        UpdateMethod="Update"></asp:ObjectDataSource>
   <div id="AddLanguage" style="display:none">
        <ul>
            <li>
                语言&nbsp;
                <asp:TextBox ID="tbNewLang" runat="server"></asp:TextBox>
                <asp:Button ID="Add" runat="server" Text="添加" OnClick="Add_Click" />
                </li></ul>
   </div>
<script type="text/javascript">
function AddNew()
{
    document.getElementById("AddLanguage").style["display"]="";
}
</script>   
</asp:Content>


