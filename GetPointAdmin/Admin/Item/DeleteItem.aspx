<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="DeleteItem.aspx.cs" Inherits="GetPointAdmin.Admin.Item.DeleteItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

     <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title">Delete Item</p> 
        </div>
        <div class="row"> 
            <div class="col-12">
              
                <dx:BootstrapFormLayout ID="BootstrapFormLayout1" runat="server" AlignItemCaptionsInAllGroups="True">
                    <Items>
                         <dx:BootstrapLayoutItem ShowCaption="False" ColSpanLg="12" ColSpanMd="12"  HorizontalAlign="Center"  >
                           <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <asp:Label runat="server" ID="lblError" Visible="false" Text="" CssClass="text-danger"></asp:Label>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>

                        <dx:BootstrapLayoutItem FieldName="CategoryID" Caption="Category">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapSpinEdit runat="server" ID="BootstrapFormLayout1_E1"></dx:BootstrapSpinEdit>

                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>



                        <dx:BootstrapLayoutItem FieldName="ItemTitle" Caption="Item Title">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtTitle" ReadOnly="true"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem FieldName="ItemDescription" Caption="Description">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtDescription" ReadOnly="true"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem FieldName="ItemPrice" Caption="Item Price">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapSpinEdit runat="server" ID="Price" ReadOnly="true"></dx:BootstrapSpinEdit>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem FieldName="ItemPic" Caption="Item Picture">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapImage runat="server" ID="Image" Width="120"></dx:BootstrapImage>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem FieldName="SupplierID" Caption="Supplier">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapSpinEdit runat="server" ID="Supplier" ReadOnly="true"></dx:BootstrapSpinEdit>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem FieldName="SubCategoryId" Caption="Sub Category">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapSpinEdit runat="server" ID="SubCat" ReadOnly="true"></dx:BootstrapSpinEdit>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem FieldName="NoOfViews" Caption="Views Number">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapSpinEdit runat="server" ID="Vnum" ReadOnly="true"></dx:BootstrapSpinEdit>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                     

                         <dx:BootstrapLayoutItem ShowCaption="false">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapButton Text="Delete" runat="server" ID="btnDelete" OnClick="btnDelete_Click"></dx:BootstrapButton>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                    </Items>
                </dx:BootstrapFormLayout>
            </div>
            </div>
         </div>
</asp:Content>
