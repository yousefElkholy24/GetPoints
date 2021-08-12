<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CustomersList.aspx.cs" Inherits="GetPointAdmin.Admin.CustomersList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title">Customers List</p>
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



                <dx:BootstrapGridView ID="grdList" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" KeyFieldName="CustomerID" OnCustomButtonCallback="grdList_CustomButtonCallback" OnToolbarItemClick="grdList_ToolbarItemClick" EnableCallBacks="true">
                    <ClientSideEvents ToolbarItemClick="onToolbarItemClick" />
                    <Settings ShowFilterRow="True"></Settings>
                    <SettingsDataSecurity AllowEdit="True" AllowInsert="True" AllowDelete="True"></SettingsDataSecurity>
                    <Columns>
                        <dx:BootstrapGridViewCommandColumn ShowEditButton="false" ShowSelectCheckbox="false" VisibleIndex="100">
                            <CustomButtons>
                                <dx:BootstrapGridViewCommandColumnCustomButton ID="btnEdit" Text="Edit" IconCssClass="fa fa-edit" />
                                <dx:BootstrapGridViewCommandColumnCustomButton ID="btnAddresses" Text="Addresses" IconCssClass="fa fa-map-marked-alt" />
                                <dx:BootstrapGridViewCommandColumnCustomButton ID="btnDelete" Text="Delete" IconCssClass="fa fa-trash-alt" />
                            </CustomButtons>
                        </dx:BootstrapGridViewCommandColumn>


                        <dx:BootstrapGridViewTextColumn FieldName="CustomerID" ReadOnly="True" VisibleIndex="1">
                            <SettingsEditForm Visible="False"></SettingsEditForm>
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="CustomerFullName" VisibleIndex="2"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="CustomerUserName" VisibleIndex="3"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="CustomerPassword" VisibleIndex="4"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewCheckColumn FieldName="CustomerIsActive" VisibleIndex="5"></dx:BootstrapGridViewCheckColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="CustomerEmail" VisibleIndex="6"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="CustomerMobile" VisibleIndex="7"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="CustomerTele" VisibleIndex="8"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewCheckColumn FieldName="CustomerIsVerified" VisibleIndex="9"></dx:BootstrapGridViewCheckColumn>
                        <dx:BootstrapGridViewImageColumn FieldName="CustomerProfilePic" Width="120px" VisibleIndex="0" Caption="Pic">
                            <PropertiesImage ImageUrlFormatString="~/images/{0}" ImageHeight="100px" />
                        </dx:BootstrapGridViewImageColumn>
                    </Columns>
                    <Toolbars>
                        <dx:BootstrapGridViewToolbar Position="Top" ShowInsidePanel="true">
                            <Items>
                                <dx:BootstrapGridViewToolbarItem Name="btnAddNew" Text="Add New Customer"></dx:BootstrapGridViewToolbarItem>

                            </Items>
                        </dx:BootstrapGridViewToolbar>
                         <dx:BootstrapGridViewToolbar Position="Top" ShowInsidePanel="true">
                            <Items>
                                <dx:BootstrapGridViewToolbarItem Name="btnReport" Text="Generate Report"></dx:BootstrapGridViewToolbarItem>
                            </Items>
                        </dx:BootstrapGridViewToolbar>
                    </Toolbars>

                    <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
                </dx:BootstrapGridView>

                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConflictDetection="CompareAllValues" ConnectionString='<%$ ConnectionStrings:GetPointConnectionString2 %>' DeleteCommand="DELETE FROM [tbl_Customer] WHERE [CustomerID] = @original_CustomerID AND (([CustomerFullName] = @original_CustomerFullName) OR ([CustomerFullName] IS NULL AND @original_CustomerFullName IS NULL)) AND (([CustomerUserName] = @original_CustomerUserName) OR ([CustomerUserName] IS NULL AND @original_CustomerUserName IS NULL)) AND (([CustomerPassword] = @original_CustomerPassword) OR ([CustomerPassword] IS NULL AND @original_CustomerPassword IS NULL)) AND (([CustomerIsActive] = @original_CustomerIsActive) OR ([CustomerIsActive] IS NULL AND @original_CustomerIsActive IS NULL)) AND (([CustomerEmail] = @original_CustomerEmail) OR ([CustomerEmail] IS NULL AND @original_CustomerEmail IS NULL)) AND (([CustomerMobile] = @original_CustomerMobile) OR ([CustomerMobile] IS NULL AND @original_CustomerMobile IS NULL)) AND (([CustomerTele] = @original_CustomerTele) OR ([CustomerTele] IS NULL AND @original_CustomerTele IS NULL)) AND (([CustomerIsVerified] = @original_CustomerIsVerified) OR ([CustomerIsVerified] IS NULL AND @original_CustomerIsVerified IS NULL)) AND (([CustomerProfilePic] = @original_CustomerProfilePic) OR ([CustomerProfilePic] IS NULL AND @original_CustomerProfilePic IS NULL))" InsertCommand="INSERT INTO [tbl_Customer] ([CustomerFullName], [CustomerUserName], [CustomerPassword], [CustomerIsActive], [CustomerEmail], [CustomerMobile], [CustomerTele], [CustomerIsVerified], [CustomerProfilePic]) VALUES (@CustomerFullName, @CustomerUserName, @CustomerPassword, @CustomerIsActive, @CustomerEmail, @CustomerMobile, @CustomerTele, @CustomerIsVerified, @CustomerProfilePic)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [tbl_Customer]" UpdateCommand="UPDATE [tbl_Customer] SET [CustomerFullName] = @CustomerFullName, [CustomerUserName] = @CustomerUserName, [CustomerPassword] = @CustomerPassword, [CustomerIsActive] = @CustomerIsActive, [CustomerEmail] = @CustomerEmail, [CustomerMobile] = @CustomerMobile, [CustomerTele] = @CustomerTele, [CustomerIsVerified] = @CustomerIsVerified, [CustomerProfilePic] = @CustomerProfilePic WHERE [CustomerID] = @original_CustomerID AND (([CustomerFullName] = @original_CustomerFullName) OR ([CustomerFullName] IS NULL AND @original_CustomerFullName IS NULL)) AND (([CustomerUserName] = @original_CustomerUserName) OR ([CustomerUserName] IS NULL AND @original_CustomerUserName IS NULL)) AND (([CustomerPassword] = @original_CustomerPassword) OR ([CustomerPassword] IS NULL AND @original_CustomerPassword IS NULL)) AND (([CustomerIsActive] = @original_CustomerIsActive) OR ([CustomerIsActive] IS NULL AND @original_CustomerIsActive IS NULL)) AND (([CustomerEmail] = @original_CustomerEmail) OR ([CustomerEmail] IS NULL AND @original_CustomerEmail IS NULL)) AND (([CustomerMobile] = @original_CustomerMobile) OR ([CustomerMobile] IS NULL AND @original_CustomerMobile IS NULL)) AND (([CustomerTele] = @original_CustomerTele) OR ([CustomerTele] IS NULL AND @original_CustomerTele IS NULL)) AND (([CustomerIsVerified] = @original_CustomerIsVerified) OR ([CustomerIsVerified] IS NULL AND @original_CustomerIsVerified IS NULL)) AND (([CustomerProfilePic] = @original_CustomerProfilePic) OR ([CustomerProfilePic] IS NULL AND @original_CustomerProfilePic IS NULL))">
                    <DeleteParameters>
                        <asp:Parameter Name="original_CustomerID" Type="Int32"></asp:Parameter>
                        <asp:Parameter Name="original_CustomerFullName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_CustomerUserName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_CustomerPassword" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_CustomerIsActive" Type="Boolean"></asp:Parameter>
                        <asp:Parameter Name="original_CustomerEmail" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_CustomerMobile" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_CustomerTele" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_CustomerIsVerified" Type="Boolean"></asp:Parameter>
                        <asp:Parameter Name="original_CustomerProfilePic" Type="String"></asp:Parameter>
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="CustomerFullName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="CustomerUserName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="CustomerPassword" Type="String"></asp:Parameter>
                        <asp:Parameter Name="CustomerIsActive" Type="Boolean"></asp:Parameter>
                        <asp:Parameter Name="CustomerEmail" Type="String"></asp:Parameter>
                        <asp:Parameter Name="CustomerMobile" Type="String"></asp:Parameter>
                        <asp:Parameter Name="CustomerTele" Type="String"></asp:Parameter>
                        <asp:Parameter Name="CustomerIsVerified" Type="Boolean"></asp:Parameter>
                        <asp:Parameter Name="CustomerProfilePic" Type="String"></asp:Parameter>
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="CustomerFullName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="CustomerUserName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="CustomerPassword" Type="String"></asp:Parameter>
                        <asp:Parameter Name="CustomerIsActive" Type="Boolean"></asp:Parameter>
                        <asp:Parameter Name="CustomerEmail" Type="String"></asp:Parameter>
                        <asp:Parameter Name="CustomerMobile" Type="String"></asp:Parameter>
                        <asp:Parameter Name="CustomerTele" Type="String"></asp:Parameter>
                        <asp:Parameter Name="CustomerIsVerified" Type="Boolean"></asp:Parameter>
                        <asp:Parameter Name="CustomerProfilePic" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_CustomerID" Type="Int32"></asp:Parameter>
                        <asp:Parameter Name="original_CustomerFullName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_CustomerUserName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_CustomerPassword" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_CustomerIsActive" Type="Boolean"></asp:Parameter>
                        <asp:Parameter Name="original_CustomerEmail" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_CustomerMobile" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_CustomerTele" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_CustomerIsVerified" Type="Boolean"></asp:Parameter>
                        <asp:Parameter Name="original_CustomerProfilePic" Type="String"></asp:Parameter>
                    </UpdateParameters>
                </asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>
