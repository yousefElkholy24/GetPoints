<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="GetPointAdmin.Admin.Customer.AddCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
        
    
    <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title">Add New Customer</p>
        </div> 
        <div class="row">
            <div class="col-12">


                <dx:BootstrapFormLayout ID="BootstrapFormLayout2" runat="server" AlignItemCaptionsInAllGroups="True">

                    <Items>


                        <dx:BootstrapLayoutItem FieldName="CustomerFullName" Caption="Full Name">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtFullName"></dx:BootstrapTextBox>
                                     <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>     

                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>



                        <dx:BootstrapLayoutItem FieldName="CustomerUserName" Caption="User Name">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtUser"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="CustomerPassword" Caption="Password">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtPassword"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>



                        <dx:BootstrapLayoutItem FieldName="CustomerIsActive" Caption="Activity" ColSpanLg="3" ColSpanSm="3">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapCheckBox runat="server" AccessibilityLabelText="" CheckState="Unchecked" ID="chkActive"></dx:BootstrapCheckBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>

                        <dx:BootstrapLayoutItem FieldName="CustomerEmail" Caption="Email">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtEmail"></dx:BootstrapTextBox>
                                     <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>     
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="CustomerMobile" Caption="Mobile">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtMobile"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="CustomerTele" Caption="Telephone">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtTelephone"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="CustomerIsVerified" Caption="Is Verified" ColSpanLg="3" ColSpanSm="3">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapCheckBox runat="server" AccessibilityLabelText="" CheckState="Unchecked" ID="chkVerified"></dx:BootstrapCheckBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="CustomerProfilePic" Caption="Profile Picture">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                        <dx:BootstrapUploadControl runat="server"  ID="F2" ShowUploadButton="true" NullText="Select Image..."
                                        AdvancedModeSettings-EnableMultiSelect="false" ClientInstanceName="F3">
<%--                                            <ClientSideEvents FileUploadComplete="onFileUploadComplete" FilesUploadStart="onFilesUploadStart" />--%>
                                            <ValidationSettings MaxFileSize="4194304" AllowedFileExtensions=".jpg,.jpeg,.gif,.png" />
                                        </dx:BootstrapUploadControl>
                                        <small>Allowed file extensions: .jpg, .jpeg, .gif, .png.</small>
                                        <br />
                                        <small>Maximum file size: 4 MB.</small>  
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>

                        <dx:BootstrapLayoutItem ShowCaption="false" ColSpanLg="12" ColSpanSm="12">
                            <ContentCollection>
                                <dx:ContentControl  runat="server">
                                    <dx:BootstrapButton Text="Save" runat="server" ID="Save" OnClick="Save_Click"></dx:BootstrapButton>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                    </Items>
                </dx:BootstrapFormLayout>
            </div>
            </div>
            </div>
    
</asp:Content>
