<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="GetPointAdmin.Admin.Category.AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title">Add New Category</p>
        </div>
        <div class="row">
            <div class="col-12"> 
             
                <dx:bootstrapformlayout id="BootstrapFormLayout1" runat="server" alignitemcaptionsinallgroups="True">
                    <Items>


                        <dx:BootstrapLayoutItem FieldName="CategoryTitleAr" Caption="Arabic Title" >
                           <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtTitleAr">
                                        <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>     
                                    </dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="CategoryTitleEn" Caption="English Title">
                             <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtTitleEn">
                                         <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings> 
                                    </dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="CategoryPic" Caption="Image" ColSpanLg="6" ColSpanMd="6">
                           <ContentCollection>
                                <dx:ContentControl runat="server">
                                  <dx:BootstrapUploadControl runat="server" ID="F1" ShowUploadButton="true" NullText="Select Image..."
                                        AdvancedModeSettings-EnableMultiSelect="false" ClientInstanceName="F2">
                                        <ValidationSettings MaxFileSize="4194304" AllowedFileExtensions=".jpg,.jpeg,.gif,.png" />
                                       

                                    </dx:BootstrapUploadControl>
                                    <small>Allowed file extensions: .jpg, .jpeg, .gif, .png.</small>
                                    <br />
                                    <small>Maximum file size: 4 MB.</small>
                                </dx:ContentControl>
                           </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="CategoryIsActive" Caption="Active" ColSpanLg="3" ColSpanSm="3" >
                            <ContentCollection> 
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapCheckBox runat="server" ID="chkActive"></dx:BootstrapCheckBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem FieldName="CategorySort" Caption="Order"  ColSpanLg="3" ColSpanSm="3">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapSpinEdit runat="server" ID="txtOrder"></dx:BootstrapSpinEdit>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem ColSpanMd="12" ColSpanLg="12" FieldName="CategoryDescription" Caption="Description">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapMemo runat="server" ID="txtDescription"></dx:BootstrapMemo>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>

                        <dx:BootstrapLayoutItem ShowCaption="false">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapButton Text="Save" runat="server" ID="btnSave" OnClick="btnSave_Click"></dx:BootstrapButton>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>

                    </Items>
                </dx:bootstrapformlayout>

            </div>
        </div>
    </div>
   
</asp:Content>
