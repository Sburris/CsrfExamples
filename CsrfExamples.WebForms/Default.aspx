<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CsrfExamples.WebForms.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap-reboot.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-grid.css" rel="stylesheet" />
    <link href="Content/bootstrap.cosmo.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Transfer Money</h3>
                </div>
                <div class="panel-body">
                    <div>
                        From
                        <asp:DropDownList runat="server" id="ddlFrom"/>
                    </div>
                    <div>
                        To
                        <asp:DropDownList runat="server" id="ddlTo"/>
                    </div>
                    <div>
                        Amount
                        <asp:TextBox runat="server" id="txtAmount" MaxLength="10"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button runat="server" id="btnTransfer" Text="Transfer" OnClick="btnTransfer_OnClick"/>
                    </div>
                </div>
            </div>
            
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Balances</h3>
                </div>
                <div class="panel-body">
                    <asp:ListView runat="server" id="lvBalances" OnItemDataBound="lvBalances_OnItemDataBound">
                        <LayoutTemplate>
                            <table class="table">
                                <thead>
                                    <tr>
                                        <th scope="col">Account Id</th>
                                        <th scope="col">Name</th>
                                        <th scope="col">Amount</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr id="itemPlaceholder" runat="server"></tr>
                                </tbody>
                                
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><asp:Literal runat="server" ID="litAccountId"></asp:Literal></td>
                                <td><asp:Literal runat="server" ID="litName"></asp:Literal></td>
                                <td><asp:Literal runat="server" ID="litAmount"></asp:Literal></td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
            
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Transactions</h3>
                </div>
                <div class="panel-body">
                    <asp:ListView runat="server" id="lvTransactiosn" OnItemDataBound="lvTransactiosn_OnItemDataBound">
                        <LayoutTemplate>
                            <table class="table">
                                <thead>
                                <tr>
                                    <th scope="col">Date & Time</th>
                                    <th scope="col">Transactions</th>
                                </tr>
                                </thead>
                                <tbody>
                                <tr id="itemPlaceholder" runat="server"></tr>
                                </tbody>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><asp:Literal runat="server" ID="litDateTime"></asp:Literal></td>
                                <td><asp:Literal runat="server" ID="litTransaction"></asp:Literal></td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            No Transactions at this time.
                        </EmptyDataTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
