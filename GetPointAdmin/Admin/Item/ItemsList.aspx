<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ItemsList.aspx.cs" Inherits="GetPointAdmin.Admin.Item.ItemsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title">Items List</p>
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

                <dx:BootstrapGridView ID="ItemsGrid" runat="server" KeyFieldName="ItemID" OnCustomButtonCallback="ItemsGrid_CustomButtonCallback" OnToolbarItemClick="ItemsGrid_ToolbarItemClick" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                    <ClientSideEvents ToolbarItemClick="onToolbarItemClick" />
                    <Settings ShowFilterRow="True"></Settings>
                    <SettingsDataSecurity AllowEdit="True" AllowInsert="True" AllowDelete="True"></SettingsDataSecurity>
                    <Columns>
                         <dx:BootstrapGridViewCommandColumn ShowEditButton="false" ShowSelectCheckbox="false" VisibleIndex="100" Caption="Actions">
                            <CustomButtons>
                                <dx:BootstrapGridViewCommandColumnCustomButton ID="btnEdit" Text="Edit" IconCssClass="fa fa-edit" />
                                <dx:BootstrapGridViewCommandColumnCustomButton ID="btnDelete" Text="Delete" IconCssClass="fa fa-trash-alt" />
                                <dx:BootstrapGridViewCommandColumnCustomButton ID="btnItemImages" Text="Item Images" IconCssClass="fa fa-file" />
                            </CustomButtons>
                        </dx:BootstrapGridViewCommandColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="ItemID" ReadOnly="True" VisibleIndex="1">
                            <SettingsEditForm Visible="False"></SettingsEditForm>
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="CategoryID" VisibleIndex="2"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="ItemTitle" VisibleIndex="3"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="ItemDescription" VisibleIndex="4"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="ItemPrice" VisibleIndex="5"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="SupplierID" VisibleIndex="6"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="SubCategoryId" VisibleIndex="7"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="Points" VisibleIndex="8"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="PointsCredit" VisibleIndex="9"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="NoOfViews" VisibleIndex="10"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewImageColumn FieldName="ItemPic" Width="120px" VisibleIndex="0" Caption="Pic">
                            <PropertiesImage ImageUrlFormatString="~/images/{0}" ImageHeight="100px" />
                        </dx:BootstrapGridViewImageColumn>
                    </Columns>

                    <Toolbars>
                        <dx:BootstrapGridViewToolbar Position="Top" ShowInsidePanel="true">
                            <Items>
                                <dx:BootstrapGridViewToolbarItem Name="btnAddNew" Text="Add New Item"></dx:BootstrapGridViewToolbarItem>
                            </Items>
                        </dx:BootstrapGridViewToolbar>
                    </Toolbars>


                    <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
                </dx:BootstrapGridView>

                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:GetPointConnectionString2 %>' SelectCommand="SELECT * FROM [tbl_Item]"></asp:SqlDataSource>
            </div>


        </div>
    </div>
</asp:Content>
