<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddItemImage.aspx.cs" Inherits="GetPointAdmin.Admin.ItemImage.AddItemImage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title"> Add New Item Image</p>
        </div>
        <div class="row">
            <div class="col-12">
                <dx:BootstrapFormLayout ID="AddItemImageForm" runat="server" AlignItemCaptionsInAllGroups="True">

                    <Items>

                        <dx:BootstrapLayoutItem FieldName="tbl_ItemImageTitle" Caption="Title">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtTitle"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem FieldName="ItemID" Caption="Item ID" Visible="false" >
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapSpinEdit runat="server" ID="ItemID" ></dx:BootstrapSpinEdit>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="tbl_ItemImagePic" Caption="Pic">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapUploadControl runat="server" ClientInstanceName="F3" ShowUploadButton="True" NullText="Select Image..." ID="ItemImage">
                                        <ValidationSettings AllowedFileExtensions=".jpg, .jpeg, .gif, .png" MaxFileSize="4194304"></ValidationSettings>

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
                                    <dx:BootstrapButton Text="Save" runat="server" ID="SaveButton" OnClick="SaveButton_Click"></dx:BootstrapButton>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        
                    </Items>
                </dx:BootstrapFormLayout>
            </div>
            </div>
        </div>
</asp:Content>
