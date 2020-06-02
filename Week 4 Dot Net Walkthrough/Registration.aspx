<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Week_4_Dot_Net_Walkthrough.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label runat="server">Registration</asp:Label>
        <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Name"></asp:Label>
                    <asp:TextBox runat="server" ID="tbName" placeholder="Your Name"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Email"></asp:Label>
                    <asp:TextBox runat="server" ID="tbEmail" placeholder="Your Email"></asp:TextBox>
                    <asp:RegularExpressionValidator runat="server" id="validateEmail" ControlToValidate="tbEmail" ValidationExpression="([a-zA-Z_.]+)@([a-zA-Z]+).([a-zA-Z]+)(.[a-zA-Z]+)?" ErrorMessage="Please enter the correct email format." />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Gender"></asp:Label>
                    <asp:RadioButton ID="rbMale" GroupName="Gender" runat="server" Checked="true" Text="Male" />
                    <asp:RadioButton ID="rbFemale" GroupName="Gender" runat="server" Text="Female" />
                    <asp:RadioButton ID="rbNotApplicable" GroupName="Gender" runat="server" Text="Not applicable" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="What language do you know?"></asp:Label>
                    <asp:CheckBox runat="server" ID="cbDotNet" Text="Dot Net" />
                    <asp:CheckBox runat="server" ID="cbSQL" Text="SQL" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Choose your country from the dropdown:"></asp:Label>
                    <asp:DropDownList ID="list" CssClass="list-group" runat="server">
                        <asp:ListItem Selected="True" Value="Singapore"></asp:ListItem>
                        <asp:ListItem Value="Thailand"></asp:ListItem>
                        <asp:ListItem Value="Malaysia"></asp:ListItem>
                        <asp:ListItem Value="Philipphines"></asp:ListItem>
                        <asp:ListItem Value="India"></asp:ListItem>
                        <asp:ListItem Value="Australia"></asp:ListItem>
                        <asp:ListItem Value="Auckland"></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button runat="server" ID="bRegister" Text="Register" OnClick="bRegister_Click" />
        <asp:Button runat="server" ID="bUpdate" Text="Update" OnClick="bUpdate_Click" />
        <asp:Button runat="server" ID="bFetch" Text="Fetch Data" OnClick="bFetch_Click" />
        <!--<asp:Label runat="server" ID="lResult" Text="Result:"></asp:Label>-->
    </form>
</body>
</html>
