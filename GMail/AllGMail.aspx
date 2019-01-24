<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllGMail.aspx.cs" Inherits="GMail.AllGMail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>All GMail</title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:Button ID="cmdAllEmail" runat="server" Text="Get email" OnClick="cmdAllEmail_Click" />
            </div>
        </form>
    </body>
</html>
