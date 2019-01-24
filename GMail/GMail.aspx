<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GMail.aspx.cs" Inherits="GMail.GMail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmGmailReader" runat="server">

            Mail Server Name:
            <asp:TextBox ID="txtMailServer" runat="server" />
            <br />
            Email ID:
            <asp:TextBox ID="txtEmail" Width="250px" runat="server" />
            <br />
            Password:
            <asp:TextBox ID="txtPassword" runat="server"  />
            <br />
            Port:
            <asp:TextBox ID="txtPort" runat="server" Text="995" />
            <br />
            SSL:
            <asp:CheckBox ID="chkSSL" checked="true" runat="server" />
            <br />
            <asp:Button ID="btnReadEmails" runat="server" Text="Read Emails" OnClick = "Read_Emails" />

            <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>

            <br /><hr />
            <asp:GridView ID="gvEmails" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText = "From" DataField = "From" />
                    <asp:HyperLinkField HeaderText = "Subject" DataNavigateUrlFields = "MessageNumber" 
                        DataNavigateUrlFormatString ="~/ShowMessageCS.aspx?MessageNumber={0}" 
                        DataTextField = "Subject" />
                    <asp:BoundField HeaderText = "Date" DataField = "DateSent" />
                </Columns>
            </asp:GridView>
        </form>
</body>
</html>
