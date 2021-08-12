<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GetPointAdmin.Admin.Account.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://fonts.googleapis.com/css?family=Lato:300,400,400i,700|Poppins:300,400,500,600,700|PT+Serif:400,400i&display=swap" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="/Content/Public/css/bootstrap.css" type="text/css" />
    <link rel="stylesheet" href="/Content/Public/css/style.css" type="text/css" />
    <link rel="stylesheet" href="/Content/Public/css/dark.css" type="text/css" />
    <link rel="stylesheet" href="/Content/Public/css/font-icons.css" type="text/css" />
    <link rel="stylesheet" href="/Content/Public/css/animate.css" type="text/css" />
    <link rel="stylesheet" href="/Content/Public/css/magnific-popup.css" type="text/css" />

    <link rel="stylesheet" href="/Content/Public/css/custom.css" type="text/css" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
      

        <!-- Content
        ============================================= -->
        <section id="content">
            <div class="content-wrap py-0">

                <div class="section p-0 m-0 h-100 position-absolute" style="background: url('~/Images/GetPointLogo.png') center center no-repeat; background-size: cover;"></div>

                <div class="section bg-transparent min-vh-100 p-0 m-0">
                    <div class="vertical-middle">
                        <div class="container-fluid py-5 mx-auto">
                            <div class="center">
                                <h2 style="color: #FFFFFF;">GetPoints</h2>
                            </div>

                            <div class="card mx-auto rounded-0 border-0" style="max-width: 400px; background-color: rgba(255,255,255,0.93);">
                                <div class="card-body" style="padding: 40px;">



                                    <form id="logForm" runat="server">
                                        <h3>Login to your Account</h3>
                                        <div class="row">



                                            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                                                <p class="text-danger">
                                                    <asp:Literal runat="server" ID="FailureText" />
                                                </p>

                                            </asp:PlaceHolder>

                                            <div class="col-12 form-group">
                                                <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email:</asp:Label>
                                                <div class="col-md-10">
                                                    <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                                        CssClass="text-danger" ErrorMessage="The email field is required." />
                                                </div>
                                            </div>
                                            <div class="col-12 form-group">
                                                <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-4 control-label">Password:</asp:Label>
                                                <div class="col-md-10">
                                                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-md-offset-2 col-md-10">
                                                    <div class="checkbox">
                                                        <asp:CheckBox runat="server" ID="RememberMe" />
                                                        <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-md-offset-2 col-md-10">
                                                    <asp:Button runat="server" OnClick="Unnamed_Click" Text="Log in" CssClass="button button-3d button-black m-0" />
<%--                                                    <asp:Button runat="server" OnClick="Unnamed_Click1" Text="Register" CssClass="button button-3d button-black m-0" />--%>
                                                </div>
                                            </div>
                                        </div>


                                    </form>
                                </div>




                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </section>

</body>
</html>




