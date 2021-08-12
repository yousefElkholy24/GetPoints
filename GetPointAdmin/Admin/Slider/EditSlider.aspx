<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EditSlider.aspx.cs" Inherits="GetPointAdmin.Admin.Slider.EditSlider" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

     <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title"> Edit Slider</p>
        </div>
        <div class="row">
            <div class="col-12">

                <dx:BootstrapFormLayout ID="EditSliderForm" runat="server" AlignItemCaptionsInAllGroups="True" >

                        <Items>
                        <dx:BootstrapLayoutItem FieldName="SliderTitle">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtTitle"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="IsActive">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapCheckBox runat="server" AccessibilityLabelText="" CheckState="Unchecked" ID="chkActive"></dx:BootstrapCheckBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SliderPic" Caption="Pic">
                            <ContentCollection>
                               <dx:ContentControl runat="server">
                                        <dx:BootstrapUploadControl runat="server"  ID="SliderImage" ShowUploadButton="true" NullText="Select Image..."
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


                        <dx:BootstrapLayoutItem FieldName="ItemID">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapSpinEdit runat="server" ID="Item"></dx:BootstrapSpinEdit>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>

                         <dx:BootstrapLayoutItem ShowCaption="false" ColSpanLg="12" ColSpanSm="12">
                            <ContentCollection>
                                <dx:ContentControl  runat="server">
                                    <dx:BootstrapButton Text="Save" runat="server" ID="UpdateButton" OnClick="UpdateButton_Click"></dx:BootstrapButton>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                    </Items>




                    </dx:BootstrapFormLayout>

                    </div>
            </div>
         </div>
</asp:Content>
