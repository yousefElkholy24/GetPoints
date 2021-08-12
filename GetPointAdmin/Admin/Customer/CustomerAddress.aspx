<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CustomerAddress.aspx.cs" Inherits="GetPointAdmin.Admin.Customer.CustomerAddress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title">Address List</p>
        </div>
        <div class="row"> 
            <div class="col-12">
                <script>
                    function onToolbarItemClick(s, e) {
                        switch (e.item.name) { 
                            case "GoBack":
                                e.processOnServer = true;
                                e.usePostBack = true;
                                break;


                        }
                    }
                </script>

                <dx:BootstrapGridView ID="AddressGrid" runat="server" AutoGenerateColumns="False" OnCustomButtonCallback="AddressGrid_CustomButtonCallback" OnToolbarItemClick="AddressGrid_ToolbarItemClick" DataSourceID="SqlDataSource1">

                <ClientSideEvents ToolbarItemClick="onToolbarItemClick" />

                    <Columns>
                        <dx:BootstrapGridViewTextColumn FieldName="CustomerAddressTitle" VisibleIndex="0" Caption="Address Title"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="CustomerAddressDetails" VisibleIndex="1" Caption="Address Details"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="CustomerAddressLat" VisibleIndex="2" Caption="Arabic Address"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="CustomerAddressLng" VisibleIndex="3" Caption="English Address"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="CustomerAddressMapLocation" VisibleIndex="4" Caption="Map Location"></dx:BootstrapGridViewTextColumn>
                    </Columns>
                    <Toolbars>
                        <dx:BootstrapGridViewToolbar Position="Top" ShowInsidePanel="true">
                            <Items>
                                <dx:BootstrapGridViewToolbarItem Name="GoBack" Text="Back"></dx:BootstrapGridViewToolbarItem>

                            </Items>
                        </dx:BootstrapGridViewToolbar>
                    </Toolbars>
                </dx:BootstrapGridView>


                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:GetPointConnectionString2 %>' SelectCommand="SELECT [CustomerAddressTitle], [CustomerAddressCityID], [CustomerAddressAreaID], [CustomerAddressDetails], [CustomerAddressLat], [CustomerAddressLng], [CustomerAddressMapLocation] FROM [tbl_CustomerAddress] WHERE ([CustomerID] = @CustomerID)">
                    <SelectParameters>
                        <asp:QueryStringParameter QueryStringField="id" DefaultValue="0" Name="CustomerID" Type="Int32"></asp:QueryStringParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            </div>
        </div>
</asp:Content>
