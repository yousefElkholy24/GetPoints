<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="GetPointAdmin.Admin.Configuration.About" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title">About Us</p>
        </div>
        <div class="row">
            <div class="col-12">
              
                <dx:ASPxHtmlEditor runat="server" ID="HtmlEditor" Height="370px" Width="100%">
                    <SettingsDialogs>
                        <InsertImageDialog>
                            <SettingsImageUpload UploadFolder="~/Images/">
                                <ValidationSettings AllowedFileExtensions=".jpe,.jpeg,.jpg,.gif,.png" MaxFileSize="500000">
                                </ValidationSettings>
                            </SettingsImageUpload>
                        </InsertImageDialog>
                    </SettingsDialogs>

                </dx:ASPxHtmlEditor>


                <dx:BootstrapButton runat="server" Text="Save" ID="btnSave" OnClick="AboutSave_Click"></dx:BootstrapButton>

            </div>
        </div>
    </div>




</asp:Content>

