<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SlidersList.aspx.cs" Inherits="GetPointAdmin.Admin.Slider.SlidersList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

     <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title">Sliders List</p>
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


                <dx:BootstrapGridView ID="SliderGrid" runat="server" KeyFieldName="SliderId" OnToolbarItemClick="SliderGrid_ToolbarItemClick" OnCustomButtonCallback="SliderGrid_CustomButtonCallback" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">

                    <Settings ShowFilterRow="True"></Settings>
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
                        <dx:BootstrapGridViewTextColumn FieldName="SliderId" ReadOnly="True" VisibleIndex="1" Caption="ID">
                            <SettingsEditForm Visible="False"></SettingsEditForm>
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="SliderTitle" VisibleIndex="2" Caption="Title"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewCheckColumn FieldName="IsActive" VisibleIndex="3" Caption="Active"></dx:BootstrapGridViewCheckColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="ItemID" VisibleIndex="4" Caption="Item ID"></dx:BootstrapGridViewTextColumn>

                        <dx:BootstrapGridViewImageColumn FieldName="SliderPic" Width="120px" VisibleIndex="0" Caption="Pic">
                            <PropertiesImage ImageUrlFormatString="~/Images/{0}" ImageHeight="100px" />
                        </dx:BootstrapGridViewImageColumn>
                    </Columns>

                     <Toolbars>
                        <dx:BootstrapGridViewToolbar Position="Top" ShowInsidePanel="true">
                            <Items>
                                <dx:BootstrapGridViewToolbarItem Name="btnAddNew" Text="Add New Slider"></dx:BootstrapGridViewToolbarItem>
                            </Items>
                        </dx:BootstrapGridViewToolbar>
                    </Toolbars>


                    <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
                </dx:BootstrapGridView>

                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:GetPointConnectionString2 %>' SelectCommand="SELECT * FROM [tbl_Slider]"></asp:SqlDataSource>
            </div>
            </div>
         </div>
</asp:Content>
