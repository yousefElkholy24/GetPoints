<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="DeleteCustomer.aspx.cs" Inherits="GetPointAdmin.Admin.Customer.DeleteCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title">Delete Customer</p>
        </div>
        <div class="row"> 
            <div class="col-12">
              
                <dx:BootstrapFormLayout ID="DelCust" runat="server" AlignItemCaptionsInAllGroups="True">



                    <Items>
                        <dx:BootstrapLayoutItem ShowCaption="False" ColSpanLg="12" ColSpanMd="12"  HorizontalAlign="Center"  >
                           <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <asp:Label runat="server" ID="lblError" Visible="false" Text="" CssClass="text-danger"></asp:Label>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="CustomerFullName">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtFullName" readonly="true"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem FieldName="CustomerUserName">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtUser" readonly="true"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem FieldName="CustomerIsActive">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapCheckBox runat="server" AccessibilityLabelText="" CheckState="Unchecked" ID="chkActive" Enabled="false"></dx:BootstrapCheckBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem FieldName="CustomerPassword">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtPassword" readonly="true"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem FieldName="CustomerEmail">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtEmail" readonly="true"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem FieldName="CustomerMobile">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtMobile" readonly="true"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem FieldName="CustomerTele">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtTele" readonly="true"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem FieldName="CustomerProfilePic">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapImage runat="server" ID="Image" Width="120"></dx:BootstrapImage>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem FieldName="CustomerIsVerified">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapCheckBox runat="server" AccessibilityLabelText="" CheckState="Unchecked" ID="chkVerfied" Enabled="false"></dx:BootstrapCheckBox>
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
