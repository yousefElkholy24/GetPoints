<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="LaunchScreen.aspx.cs" Inherits="GetPointAdmin.Admin.Configuration.LaunchScreen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title"> Edit Launch Screen Image</p>
        </div>
           <div class="row">
            <div class="col-6">
                <dx:BootstrapGridView ID="ShowImage" runat="server" AlignItemCaptionsInAllGroups="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                    <Columns>
                         <dx:BootstrapGridViewImageColumn FieldName="Info" Width="120px" VisibleIndex="0" Caption="Pic">
                            <PropertiesImage ImageUrlFormatString="~/images/{0}" ImageHeight="100px" />
                        </dx:BootstrapGridViewImageColumn>
                    </Columns>
                </dx:BootstrapGridView>
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:GetPointConnectionString2 %>' SelectCommand="SELECT [Info] FROM [tbl_Systemconfig] WHERE ([ID] = @ID)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="ID" Type="Int32"></asp:Parameter>
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            </div>
          <br />
          <hr />
        <div class="row">
            <div class="col-12">
                <dx:BootstrapFormLayout ID="EditLoginPic" runat="server" AlignItemCaptionsInAllGroups="True" DataSourceID="SqlDataSource1">
                    <Items>
                        <dx:BootstrapLayoutItem FieldName="Info">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                        <dx:BootstrapUploadControl runat="server"  ID="EditImage" ShowUploadButton="true" NullText="Select Image..."
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
