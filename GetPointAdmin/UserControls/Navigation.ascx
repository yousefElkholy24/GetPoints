<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navigation.ascx.cs" Inherits="GetPointAdmin.Navigation" %>

<dx:BootstrapTreeView runat="server" >
    
    <CssClasses
        IconExpandNode="demo-icon demo-icon-col m-0"
        IconCollapseNode="demo-icon demo-icon-ex m-0"
        NodeList="demo-treeview-nodes m-0" Node="demo-treeview-node" Control="demo-treeview" />
    <Nodes>
        <dx:BootstrapTreeViewNode Text="Dashboard" NavigateUrl="~/Admin/Default.aspx"></dx:BootstrapTreeViewNode>
        <dx:BootstrapTreeViewNode Text="Customer" Expanded="false">
            <Nodes>
                <dx:BootstrapTreeViewNode Text="New Customer" NavigateUrl="~/Admin/Customer/AddCustomer.aspx"></dx:BootstrapTreeViewNode>
                <dx:BootstrapTreeViewNode Text="Customers List" NavigateUrl="~/Admin/Customer/CustomersList.aspx"></dx:BootstrapTreeViewNode>
            </Nodes>
        </dx:BootstrapTreeViewNode>
        <dx:BootstrapTreeViewNode Text="Category" Expanded="false">
            <Nodes>
                <dx:BootstrapTreeViewNode Text="New Category" NavigateUrl="~/Admin/Category/AddCategory.aspx"></dx:BootstrapTreeViewNode>
                <dx:BootstrapTreeViewNode Text="Category List" NavigateUrl="~/Admin/Category/CategoryList.aspx"></dx:BootstrapTreeViewNode>
            </Nodes>
        </dx:BootstrapTreeViewNode>


         <dx:BootstrapTreeViewNode Text="Slider" Expanded="false">
            <Nodes>
                <dx:BootstrapTreeViewNode Text="New Slider" NavigateUrl="~/Admin/Slider/AddSlider.aspx"></dx:BootstrapTreeViewNode>
                <dx:BootstrapTreeViewNode Text="Slider List" NavigateUrl="~/Admin/Slider/SlidersList.aspx"></dx:BootstrapTreeViewNode>
            </Nodes>
        </dx:BootstrapTreeViewNode>

              <dx:BootstrapTreeViewNode Text="Supplier" Expanded="false">
            <Nodes>
                <dx:BootstrapTreeViewNode Text="New Supplier" NavigateUrl="~/Admin/Supplier/AddSupplier.aspx"></dx:BootstrapTreeViewNode>
                <dx:BootstrapTreeViewNode Text="Suppliers List" NavigateUrl="~/Admin/Supplier/SuppliersList.aspx"></dx:BootstrapTreeViewNode>
            </Nodes>
        </dx:BootstrapTreeViewNode>

              <dx:BootstrapTreeViewNode Text="Item" Expanded="false">
            <Nodes>
                <dx:BootstrapTreeViewNode Text="New Item" NavigateUrl="~/Admin/Item/AddItem.aspx"></dx:BootstrapTreeViewNode>
                <dx:BootstrapTreeViewNode Text="Items List" NavigateUrl="~/Admin/Item/ItemsList.aspx"></dx:BootstrapTreeViewNode>
            </Nodes>
        </dx:BootstrapTreeViewNode>


        <dx:BootstrapTreeViewNode Text="Orders List" NavigateUrl="~/Admin/Order/OrdersList.aspx"></dx:BootstrapTreeViewNode>


        <dx:BootstrapTreeViewNode Text="Configuration" Expanded="false">
            <Nodes>
                <dx:BootstrapTreeViewNode Text="About" NavigateUrl="~/Admin/Configuration/About.aspx"></dx:BootstrapTreeViewNode>
                <dx:BootstrapTreeViewNode Text="Terms" NavigateUrl="~/Admin/Configuration/Terms.aspx"></dx:BootstrapTreeViewNode>
                <dx:BootstrapTreeViewNode Text="Login Screen" NavigateUrl="~/Admin/Configuration/LoginScreen.aspx"></dx:BootstrapTreeViewNode>
                <dx:BootstrapTreeViewNode Text="Launch Screen" NavigateUrl="~/Admin/Configuration/LaunchScreen.aspx"></dx:BootstrapTreeViewNode>
            </Nodes>
        </dx:BootstrapTreeViewNode>


    </Nodes>
</dx:BootstrapTreeView>