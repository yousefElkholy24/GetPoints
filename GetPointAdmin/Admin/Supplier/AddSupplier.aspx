<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddSupplier.aspx.cs" Inherits="GetPointAdmin.Admin.Supplier.AddSuppplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

     <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title">Add New Supplier</p>
        </div>
        <div class="row">
            <div class="col-12">

                <dx:BootstrapFormLayout ID="AddSupplier" runat="server" AlignItemCaptionsInAllGroups="True" >


                    <Items>
                        <dx:BootstrapLayoutItem FieldName="SupplierTitle" Caption="Title">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtTitle"></dx:BootstrapTextBox>
                                    <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>     
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SupplierIsActive" Caption="Activity">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapCheckBox runat="server" AccessibilityLabelText="" CheckState="Unchecked" ID="chkActive"></dx:BootstrapCheckBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SupplierEmail" Caption="Email">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtEmail"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SupplierMobile" Caption="Mobile">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtMobile"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SupplierTele" Caption="Telephone">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtTelephone"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SupplierContactPerson" Caption="Contact Person">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtContact"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SupplierContactMobile" Caption="Contact Mobile">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtContactMobile"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>

                         <dx:BootstrapLayoutItem ShowCaption="false" ColSpanMd="12" ColSpanLg="12">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapButton Text="Save" runat="server" ID="btnSave" OnClick="btnSave_Click"></dx:BootstrapButton>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>

                    </Items>
                </dx:BootstrapFormLayout>

            </div>
            </div>
         </div>
</asp:Content>
