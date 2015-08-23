<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MenuDetail.aspx.cs" Inherits="MenuDetail" Title="Untitled Page" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;请选择语言：<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"
        DataSourceID="ObjectDataSource2" DataTextField="Name" DataValueField="Id">
    </asp:DropDownList><asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetLanguages"
        TypeName="BLL.LanguageManager"></asp:ObjectDataSource>
    &nbsp;
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="ObjectDataSource1"
        Height="50px" Width="100%" OnDataBound="DetailsView1_DataBound">
        <Fields>
            <asp:BoundField DataField="Name" HeaderText="菜名" SortExpression="Name" />
            <asp:TemplateField HeaderText="说明" SortExpression="Trait">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Trait") %>'></asp:TextBox>
                    <FTB:FreeTextBox ID="FreeTextBox1" runat="server">
                    </FTB:FreeTextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Trait") %>'></asp:TextBox>
                    <FTB:FreeTextBox ID="FreeTextBox2" runat="server">
                    
                    </FTB:FreeTextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Trait") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
            <asp:BoundField DataField="Code" HeaderText="编码" SortExpression="Code" />
            <asp:BoundField DataField="Price" HeaderText="价格" SortExpression="Price" />
            <asp:BoundField DataField="Unit" HeaderText="单位" SortExpression="Unit" />
            <asp:TemplateField HeaderText="所属菜系">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="ObjectDataSource1"
                        DataTextField="Name" DataValueField="Id">
                    </asp:DropDownList><asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetTypes"
                        TypeName="BLL.TypeManager">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownList1" DefaultValue="0" Name="language"
                                PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="ObjectDataSource1"
                        DataTextField="Name" DataValueField="Id">
                    </asp:DropDownList><asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetTypes"
                        TypeName="BLL.TypeManager">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownList1" DefaultValue="0" Name="language"
                                PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text=''></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Model.Menu"
        DeleteMethod="Delete" InsertMethod="AddNew" SelectMethod="GetMenuById" TypeName="BLL.MenuManager"
        UpdateMethod="Update">
        <SelectParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
            <asp:ControlParameter ControlID="DropDownList1" DefaultValue="0" Name="language"
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

