<%@ Page Title="Calculator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="Week_4_Dot_Net_Walkthrough.Calculator" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>
                <h1>Calculator</h1>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow runat="server">
            <asp:TableCell>
                First Number:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator3" ControlToValidate="TextBox1" ValidationExpression="\d*(\.\d+)?" ErrorMessage="Please enter correct numbers!" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell>
                Operator:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBox4" runat="server" placeholder="+"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ID="rexNumber" ControlToValidate="TextBox4" ValidationExpression="^(\/|\+|\-|\*){1}$" ErrorMessage="Please enter correct operator!" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell>
                Second Number:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator2" ControlToValidate="TextBox2" ValidationExpression="^[1-9]\d*(\.\d+)?$" ErrorMessage="Please enter correct numbers!" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell>
                Result:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBox3" runat="server" Enabled="false"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableFooterRow>
            <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                <asp:Button ID="addButton" runat="server" CssClass="btn btn-info" OnClick="Button1_Click" Text="Button" />
            </asp:TableCell>
        </asp:TableFooterRow>
    </asp:Table>

</asp:Content>
