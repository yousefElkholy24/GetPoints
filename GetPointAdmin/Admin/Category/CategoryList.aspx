<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="GetPointAdmin.Admin.Category.CategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title">Category List</p>
        </div>
        <div class="row">
            <div class="col-12">
                  <script> 
                    function onToolbarItemClick(s, e) {
                        switch (e.item.name) { 
                            case "btnAddNew":
                                e.processOnServer = true;
                                e.usePostBack = true;
                                break; 
                        } 
                      }


                  </script>
                <dx:BootstrapGridView ID="BootstrapGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" KeyFieldName="CategoryID" OnToolbarItemClick="BootstrapGridView1_ToolbarItemClick" OnCustomButtonCallback="BootstrapGridView1_CustomButtonCallback">
                    <Settings ShowFilterRow="True" />
                    <ClientSideEvents ToolbarItemClick="onToolbarItemClick" />

                    <Columns>
                        <dx:BootstrapGridViewCommandColumn ShowEditButton="false" ShowSelectCheckbox="false" VisibleIndex="100" Caption="Actions">
                            <CustomButtons>
                                <dx:BootstrapGridViewCommandColumnCustomButton ID="btnEdit" Text="Edit" IconCssClass="fa fa-edit" />
                                <dx:BootstrapGridViewCommandColumnCustomButton ID="btnDelete" Text="Delete" IconCssClass="fa fa-trash-alt" />
                                <dx:BootstrapGridViewCommandColumnCustomButton ID="btnSub" Text="Sub Categories" IconCssClass="fa fa-edit" />
                            </CustomButtons>
                        </dx:BootstrapGridViewCommandColumn>


                        <dx:BootstrapGridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0">
                        </dx:BootstrapGridViewCommandColumn>


                        <dx:BootstrapGridViewTextColumn FieldName="CategoryID" ReadOnly="True" VisibleIndex="1" Visible="false">
                            <SettingsEditForm Visible="False" />
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="CategoryTitleAr" VisibleIndex="2" Caption="Arabic Title">
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="CategoryTitleEn" VisibleIndex="3" Caption="English Title">
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewCheckColumn FieldName="CategoryIsActive" VisibleIndex="5" Caption="Active">
                        </dx:BootstrapGridViewCheckColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="CategorySort" VisibleIndex="6" Caption="Order">
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="CategoryDescription" VisibleIndex="7" Visible="false">
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewImageColumn FieldName="CategoryPic" Width="120px" VisibleIndex="0" Caption="Pic">
                            <PropertiesImage ImageUrlFormatString="~/Images/{0}" ImageHeight="100px" />
                        </dx:BootstrapGridViewImageColumn>
                    </Columns>
                    <Toolbars>
                        <dx:BootstrapGridViewToolbar Position="Top" ShowInsidePanel="true">
                            <Items>
                                <dx:BootstrapGridViewToolbarItem Name="btnAddNew" Text="Add New Category"></dx:BootstrapGridViewToolbarItem>
                            </Items>
                        </dx:BootstrapGridViewToolbar>
                    </Toolbars>
                    <SettingsSearchPanel Visible="True" />
                </dx:BootstrapGridView>
<%--                <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:GetPointsDBConnectionString %>' SelectCommand="SELECT [CategoryTitleAr], [CategoryTitleEn], [CategoryPic], [CategoryIsActive], [CategorySort], [CategoryDescription] FROM [tbl_Category]"></asp:SqlDataSource>--%>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GetPointConnectionString2 %>" SelectCommand="SELECT * FROM [tbl_Category]"></asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>
