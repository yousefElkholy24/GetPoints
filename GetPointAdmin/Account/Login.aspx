<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GetPointAdmin.Admin.Account.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

     <asp:PlaceHolder runat="server">
        <link id="themeLink" rel="stylesheet"
            href='<%= Page.ResolveUrl("~/Content/light/bootstrap.min.css")%>'
            data-theme-dark-url='<%= Page.ResolveUrl("~/Content/dark/bootstrap.min.css")%>'
            data-theme-light-url='<%= Page.ResolveUrl("~/Content/light/bootstrap.min.css")%>' />
        <link href='<%= Page.ResolveUrl("~/Content/demo-icons.css")%>' rel="stylesheet" />
        <link href='<%= Page.ResolveUrl("~/Content/common.css")%>' rel="stylesheet" />
        <link href='<%= Page.ResolveUrl("~/Content/Custom.css")%>' rel="stylesheet" />
        <link href='<%= Page.ResolveUrl("~/Content/Font/css/all.css")%>' rel="stylesheet" />
        <script src='<%= Page.ResolveUrl("~/Content/common.js")%>' defer></script>
          <%--<script src="https://code.jquery.com/jquery-3.5.0.js"></script>--%>

    </asp:PlaceHolder>
</head>

<body>
    <form id="form1" runat="server" style="text-align: center">
        <div>

             <dx:BootstrapImage ID="BootstrapImage1" runat="server" ImageUrl="~/Images/GetPointLogo.png" ShowLoadingImage="True" Width="300" ImageAlign="AbsMiddle"></dx:BootstrapImage>
            <dx:BootstrapFormLayout ID="BootstrapFormLayout1" runat="server" >
                 <Items>

                 <dx:BootstrapLayoutItem Caption="User Name"  HorizontalAlign="Center">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtUser" Width="400" ></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                 </dx:BootstrapLayoutItem>
                    <dx:BootstrapLayoutItem  HorizontalAlign="Center" ShowCaption="False">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                </dx:ContentControl>
                            </ContentCollection>
                 </dx:BootstrapLayoutItem>
                   <dx:BootstrapLayoutItem Caption="Password">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtPassword" Password="true" Width="400" ></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                         <dx:BootstrapLayoutItem  HorizontalAlign="Center" ShowCaption="False">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                </dx:ContentControl>
                            </ContentCollection>
                 </dx:BootstrapLayoutItem>
                     <dx:BootstrapLayoutItem ShowCaption="false" >
                            <ContentCollection>
                                <dx:ContentControl  runat="server">
                                    <dx:BootstrapButton Text="Login" runat="server" ID="LoginBtn" OnClick="Login_Click" Width="200"></dx:BootstrapButton>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                     </Items>
            </dx:BootstrapFormLayout>
        </div>
    </form>
</body>
</html>
