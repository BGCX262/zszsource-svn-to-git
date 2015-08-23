<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SysDetail.aspx.cs" Inherits="SysDetail" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Language,Name"
        DataSourceID="ObjectDataSource1" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="Language" HeaderText="语言" SortExpression="Language" ReadOnly="True" />
            <asp:BoundField DataField="Value" HeaderText="值" SortExpression="Value" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Model.Sys"
        SelectMethod="GetOne" TypeName="BLL.SysManager" UpdateMethod="Update">
        <SelectParameters>
            <asp:QueryStringParameter Name="name" QueryStringField="name" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

