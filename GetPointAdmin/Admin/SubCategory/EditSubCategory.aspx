<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EditSubCategory.aspx.cs" Inherits="GetPointAdmin.Admin.SubCategory.EditSubCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">


    <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title"> Edit Sub Category</p>
        </div>
        <div class="row">
            <div class="col-12">

                <dx:BootstrapFormLayout ID="EditSubCatForm" runat="server" AlignItemCaptionsInAllGroups="True" >

                    <Items>
                        <dx:BootstrapLayoutItem FieldName="SubCategoryTitleAr" Caption="Title in Arabic">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtTitleAr"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SubCategoryTitleEn" Caption="Title In English">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtTitleEn"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>



                         <dx:BootstrapLayoutItem FieldName="SubCategoryPic" Caption="Pic">
                            <ContentCollection>
                               <dx:ContentControl runat="server">
                                        <dx:BootstrapUploadControl runat="server"  ID="SubImage" ShowUploadButton="true" NullText="Select Image..." 
                                            AdvancedModeSettings-EnableMultiSelect="false" ClientInstanceName="F3">
                                            <ValidationSettings MaxFileSize="4194304" AllowedFileExtensions=".jpg,.jpeg,.gif,.png" />
                                        </dx:BootstrapUploadControl>
                                        <small>Allowed file extensions: .jpg, .jpeg, .gif, .png.</small>
                                        <br />
                                        <small>Maximum file size: 4 MB.</small>  
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SubCategoryIsActive" Caption="Active">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapCheckBox runat="server" AccessibilityLabelText="" CheckState="Unchecked" ID="chkActive"></dx:BootstrapCheckBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SubCategorySort" Caption="Order">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapSpinEdit runat="server" ID="chkSort"></dx:BootstrapSpinEdit>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SubCategoryDescription" Caption="Description">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtDescription"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>



                        <dx:BootstrapLayoutItem FieldName="CategoryID">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapSpinEdit runat="server" ID="CatID"></dx:BootstrapSpinEdit>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>

                         <dx:BootstrapLayoutItem ShowCaption="false" ColSpanLg="12" ColSpanSm="12">
                            <ContentCollection>
                                <dx:ContentControl  runat="server">
                                    <dx:BootstrapButton Text="Save" runat="server" ID="UpdateSub" OnClick="UpdateSub_Click"></dx:BootstrapButton>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                    </Items>
                </dx:BootstrapFormLayout>


            </div>
            </div>
        </div>
</asp:Content>
