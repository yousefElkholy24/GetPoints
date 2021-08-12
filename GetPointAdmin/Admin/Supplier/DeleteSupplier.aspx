<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="DeleteSupplier.aspx.cs" Inherits="GetPointAdmin.Admin.Supplier.DeleteSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title">Delete Category</p> 
        </div>
        <div class="row"> 
            <div class="col-12">
              
                <dx:bootstrapformlayout id="DelSupplier" runat="server" alignitemcaptionsinallgroups="True">
                    
                    <Items>

                        
                         <dx:BootstrapLayoutItem ShowCaption="False" ColSpanLg="12" ColSpanMd="12"  HorizontalAlign="Center"  >
                           <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <asp:Label runat="server" ID="lblError" Visible="false" Text="" CssClass="text-danger"></asp:Label>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SupplierTitle" Caption="Title">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtTitle" ReadOnly="true"></dx:BootstrapTextBox>
                                    <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>     
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SupplierIsActive" Caption="Activity">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapCheckBox runat="server" AccessibilityLabelText="" CheckState="Unchecked" ID="chkActive" Enabled="false"></dx:BootstrapCheckBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SupplierEmail" Caption="Email">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtEmail" ReadOnly="true"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SupplierMobile" Caption="Mobile">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtMobile" ReadOnly="true"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SupplierTele" Caption="Telephone">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtTelephone" ReadOnly="true"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SupplierContactPerson" Caption="Contact Person">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtContact" ReadOnly="true"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SupplierContactMobile" Caption="Contact Mobile">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtContactMobile" ReadOnly="true"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>

                         <dx:BootstrapLayoutItem ShowCaption="false" ColSpanMd="12" ColSpanLg="12">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapButton Text="Delete" runat="server" ID="btnDelete" OnClick="btnDelete_Click"></dx:BootstrapButton>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>

                    </Items>


                 </dx:bootstrapformlayout>
                </div>
            </div>
        </div>
</asp:Content>
