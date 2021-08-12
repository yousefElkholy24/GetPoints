<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SuppliersList.aspx.cs" Inherits="GetPointAdmin.Admin.Supplier.SuppliersList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

     <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title">Suppliers List</p>
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
                            case "btnReport":
                                e.processOnServer = true;
                                e.usePostBack = true;
                                break;
                        }
                    }
                  </script>


                <dx:BootstrapGridView ID="SuplierGrid" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" KeyFieldName="SupplierID" OnToolbarItemClick="SuplierGrid_ToolbarItemClick" OnCustomButtonCallback="SuplierGrid_CustomButtonCallback">
                     <Settings ShowFilterRow="True" />
                                        <ClientSideEvents ToolbarItemClick="onToolbarItemClick" />

                    <Columns>
                           <dx:BootstrapGridViewCommandColumn ShowEditButton="false" ShowSelectCheckbox="false" VisibleIndex="100" Caption="Actions">
                            <CustomButtons>
                                <dx:BootstrapGridViewCommandColumnCustomButton ID="btnEdit" Text="Edit" IconCssClass="fa fa-edit" />
                                <dx:BootstrapGridViewCommandColumnCustomButton ID="btnDelete" Text="Delete" IconCssClass="fa fa-trash-alt" />
                            </CustomButtons>
                        </dx:BootstrapGridViewCommandColumn>

                        <dx:BootstrapGridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0">
                        </dx:BootstrapGridViewCommandColumn>

                        <dx:BootstrapGridViewTextColumn FieldName="SupplierID" ReadOnly="True" VisibleIndex="1"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="SupplierTitle" VisibleIndex="1"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewCheckColumn FieldName="SupplierIsActive" VisibleIndex="2"></dx:BootstrapGridViewCheckColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="SupplierEmail" VisibleIndex="3"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="SupplierMobile" VisibleIndex="4"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="SupplierTele" VisibleIndex="5"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="SupplierContactPerson" VisibleIndex="6"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="SupplierContactMobile" VisibleIndex="7"></dx:BootstrapGridViewTextColumn>

                    </Columns>
                     <Toolbars>
                        <dx:BootstrapGridViewToolbar Position="Top" ShowInsidePanel="true">
                            <Items>
                                <dx:BootstrapGridViewToolbarItem Name="btnAddNew" Text="Add New Supplier"></dx:BootstrapGridViewToolbarItem>
                            </Items>
                        </dx:BootstrapGridViewToolbar>
                          <dx:BootstrapGridViewToolbar Position="Top" ShowInsidePanel="true">
                            <Items>
                                <dx:BootstrapGridViewToolbarItem Name="btnReport" Text="Generate Report"></dx:BootstrapGridViewToolbarItem>
                            </Items>
                        </dx:BootstrapGridViewToolbar>
                    </Toolbars>
                    <SettingsSearchPanel Visible="True" />

                </dx:BootstrapGridView>
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:GetPointConnectionString2 %>' SelectCommand="SELECT * FROM [tbl_Supplier]"></asp:SqlDataSource>
            </div>
            </div>
         </div>
</asp:Content>
