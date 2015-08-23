<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TypeDetail.aspx.cs" Inherits="TypeDetail" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Language,Id" DataSourceID="ObjectDataSource1" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="Language" HeaderText="语言" ReadOnly="True" SortExpression="Language" />
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id"
                Visible="False" />
            <asp:BoundField DataField="Name" HeaderText="分类名" SortExpression="Name" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Model.Type"
        SelectMethod="GetOne" TypeName="BLL.TypeManager" UpdateMethod="Update">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="id" QueryStringField="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
   
</asp:Content>

