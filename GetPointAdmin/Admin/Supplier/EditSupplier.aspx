<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EditSupplier.aspx.cs" Inherits="GetPointAdmin.Admin.Supplier.EditSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
     <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title">Edit Supplier</p>
        </div>
        <div class="row"> 
            <div class="col-12">

                <dx:BootstrapFormLayout ID="btnEdit" runat="server" AlignItemCaptionsInAllGroups="True">



                    <Items>
                        <dx:BootstrapLayoutItem FieldName="SupplierTitle" Caption="Title" >
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtTitle"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SupplierIsActive" Caption="Active" >
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapCheckBox runat="server" AccessibilityLabelText="" CheckState="Unchecked" ID="chkActive"></dx:BootstrapCheckBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SupplierEmail" Caption="Email" >
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtEmail"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SupplierMobile" Caption="Mobile" >
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtMobile"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SupplierTele" Caption="Telephone" >
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtTelephone"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SupplierContactPerson" Caption="Contact" >
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtContact"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SupplierContactMobile" Caption="Contact Mobile" >
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtContactMobile"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>

                        <dx:BootstrapLayoutItem ShowCaption="false" ColSpanLg="12" ColSpanMd="12">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapButton Text="Save" runat="server" ID="btnSave" OnClick="btnSave_Click">

                                    </dx:BootstrapButton>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                    </Items>
                </dx:BootstrapFormLayout>


            </div>
            </div>
         </div>
</asp:Content>
