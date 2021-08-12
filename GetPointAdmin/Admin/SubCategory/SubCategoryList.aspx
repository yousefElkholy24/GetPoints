<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SubCategoryList.aspx.cs" Inherits="GetPointAdmin.Admin.SubCategoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

   <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title">SubCategory List</p>
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



                <dx:BootstrapGridView ID="SubCatGrid" runat="server" KeyFieldName="SubCategoryID" OnToolbarItemClick="SubGrid_ToolbarItemClick" OnCustomButtonCallback="SubGrid_CustomButtonCallback" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">

                    
                     <Settings ShowFilterRow="True" />
                     <ClientSideEvents ToolbarItemClick="onToolbarItemClick" />


                    <Columns>
                         <dx:BootstrapGridViewCommandColumn ShowEditButton="false" ShowSelectCheckbox="false" VisibleIndex="100" Caption="Actions">
                            <CustomButtons>
                                <dx:BootstrapGridViewCommandColumnCustomButton ID="btnEdit" Text="Edit" IconCssClass="fa fa-edit" />
                                <dx:BootstrapGridViewCommandColumnCustomButton ID="btnDelete" Text="Delete" IconCssClass="fa fa-trash-alt" />
                                <dx:BootstrapGridViewCommandColumnCustomButton ID="btnSub" Text="Sub Categories" IconCssClass="fa fa-trash-alt" />
                            </CustomButtons>
                        </dx:BootstrapGridViewCommandColumn>
                        <dx:BootstrapGridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0">
                        </dx:BootstrapGridViewCommandColumn>

                        <dx:BootstrapGridViewTextColumn FieldName="SubCategoryID" ReadOnly="True" VisibleIndex="1">
                            <SettingsEditForm Visible="False"></SettingsEditForm>
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="SubCategoryTitleAr" VisibleIndex="2"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="SubCategoryTitleEn" VisibleIndex="3"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewCheckColumn FieldName="SubCategoryIsActive" VisibleIndex="4"></dx:BootstrapGridViewCheckColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="SubCategorySort" VisibleIndex="5"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="SubCategoryDescription" VisibleIndex="6"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="CategoryID" VisibleIndex="7"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewImageColumn FieldName="SubCategoryPic" Width="120px" VisibleIndex="0" Caption="Pic">
                            <PropertiesImage ImageUrlFormatString="~/Images/{0}" ImageHeight="100px" />
                        </dx:BootstrapGridViewImageColumn>

                    </Columns>

                     <Toolbars>
                        <dx:BootstrapGridViewToolbar Position="Top" ShowInsidePanel="true">
                            <Items>
                                <dx:BootstrapGridViewToolbarItem Name="btnAddNew" Text="Add New SubCategory"></dx:BootstrapGridViewToolbarItem>
                            </Items>
                        </dx:BootstrapGridViewToolbar>
                    </Toolbars>

                    <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
                </dx:BootstrapGridView>
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:GetPointConnectionString2 %>' SelectCommand="SELECT * FROM [tbl_SubCategory]"></asp:SqlDataSource>
            </div>

            </div>
       </div>
</asp:Content>
