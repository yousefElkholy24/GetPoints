<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ItemImageList.aspx.cs" Inherits="GetPointAdmin.Admin.ItemImage.ItemImageList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

     <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title">Item Images List</p>
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


                <dx:BootstrapGridView ID="ItemImageGrid" runat="server" OnCustomButtonCallback="ItemImageGrid_CustomButtonCallback" OnToolbarItemClick="ItemImageGrid_ToolbarItemClick" EnableCallBacks="true" DataSourceID="SqlDataSource1">
                    <ClientSideEvents ToolbarItemClick="onToolbarItemClick" />
                    <Settings ShowFilterRow="True"></Settings>
                    <Columns>
                         <dx:BootstrapGridViewImageColumn FieldName="tbl_ItemImagePic" Width="120px" VisibleIndex="0" Caption="Pic">
                            <PropertiesImage ImageUrlFormatString="~/images/{0}" ImageHeight="100px" />
                        </dx:BootstrapGridViewImageColumn>

                        <dx:BootstrapGridViewTextColumn FieldName="tbl_ItemImageTitle" VisibleIndex="1" Caption="Title"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="ItemID" VisibleIndex="2" ></dx:BootstrapGridViewTextColumn>
                    </Columns>


                     <Toolbars>
                        <dx:BootstrapGridViewToolbar Position="Top" ShowInsidePanel="true">
                            <Items>
                                <dx:BootstrapGridViewToolbarItem Name="btnAddNew" Text="Add New Item Image"></dx:BootstrapGridViewToolbarItem>
                            </Items>
                        </dx:BootstrapGridViewToolbar>
                         </Toolbars>

                </dx:BootstrapGridView>
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:GetPointConnectionString2 %>' SelectCommand="SELECT [tbl_ItemImageTitle], [tbl_ItemImagePic], [ItemID] FROM [tbl_ItemImage] WHERE ([ItemID] = @ItemID)">
                    <SelectParameters>
                        <asp:QueryStringParameter QueryStringField="id" DefaultValue="0" Name="ItemID" Type="Int32"></asp:QueryStringParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            </div>
         </div>

</asp:Content>
