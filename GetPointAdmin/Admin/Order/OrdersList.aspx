<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="OrdersList.aspx.cs" Inherits="GetPointAdmin.Admin.Order.OrdersList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

     <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title">Orders List</p>
        </div>
        <div class="row"> 
            <div class="col-12">
                <script>
                    function onToolbarItemClick(s, e) {
                        switch (e.item.name) { 
                            case "btnReport":
                                e.processOnServer = true;
                                e.usePostBack = true;
                                break;
                        }
                    }
                </script>

                  <dx:BootstrapDateEdit runat="server" ID="DateEntered"></dx:BootstrapDateEdit>

                <dx:BootstrapGridView ID="OrdersGrid" runat="server" KeyFieldName="OrderID" OnCustomButtonCallback="OrdersGrid_CustomButtonCallback" OnToolbarItemClick="OrdersGrid_ToolbarItemClick" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                   <ClientSideEvents ToolbarItemClick="onToolbarItemClick" />
                    <Settings ShowFilterRow="True"></Settings>

                    <SettingsDataSecurity AllowEdit="True" AllowInsert="True" AllowDelete="True"></SettingsDataSecurity>

                    <Columns>
                       

                        <dx:BootstrapGridViewTextColumn FieldName="OrderID" ReadOnly="True" VisibleIndex="0">
                            <SettingsEditForm Visible="False"></SettingsEditForm>
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="CustomerID" VisibleIndex="1" Caption="Customer ID"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewDateColumn FieldName="OrderDate" VisibleIndex="2" Caption="Date"></dx:BootstrapGridViewDateColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="Total" VisibleIndex="3" Caption="Total Price"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="Discount" VisibleIndex="4"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="DeliveryFees" VisibleIndex="5" Caption="Delivery Fees"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="Net" VisibleIndex="6"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="Remarks" VisibleIndex="7"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="OrderStatusID" VisibleIndex="8" Caption="Status ID"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="PaymentType" VisibleIndex="9" Caption="Payment Type"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="CustomerAddressID" VisibleIndex="10" Caption="Customer Address"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="UsedPoints" VisibleIndex="11" Caption="Used Points"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="UsedPointsCredit" VisibleIndex="12" Caption="Used Points Value"></dx:BootstrapGridViewTextColumn>
                        
                    </Columns>
                    <SettingsSearchPanel Visible="True" ></SettingsSearchPanel>
                     <Toolbars>
                        <dx:BootstrapGridViewToolbar Position="Top" ShowInsidePanel="true">
                            <Items>
                                <dx:BootstrapGridViewToolbarItem Name="btnReport" Text="Generate Report"></dx:BootstrapGridViewToolbarItem>
                            </Items>
                        </dx:BootstrapGridViewToolbar>
                    </Toolbars>
                </dx:BootstrapGridView>
                
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:GetPointConnectionString2 %>' SelectCommand="SELECT * FROM [tbl_Order]"></asp:SqlDataSource>
            </div>
            </div>
         </div>
</asp:Content>
