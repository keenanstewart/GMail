<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetArchive.aspx.cs" Inherits="GMail.GetArchive" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Get Archive</title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:Button ID="cmdGetArchive" runat="server" 
                    Text="Get email" 
                    Visible="false"
                    OnClick="cmdGetArchive_Click" />
            </div>

            <div>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>

            <div>
                <asp:Label ID="lblMessage2" runat="server"></asp:Label>
            </div>

            <div>
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </div>

            <div>
                <asp:ListBox ID="lbWords" runat="server" 
                    AutoPostBack="true"
                    Height="400" OnSelectedIndexChanged="lbWords_SelectedIndexChanged"></asp:ListBox>
            </div>

            <div>
                <asp:TextBox ID="txtContent" 
                    Visible="false"
                    TextMode="MultiLine"
                    width="500"
                    Height="500"
                    Rows="10"
                    runat="server"></asp:TextBox>
            </div>
        </form>
    </body>
</html>
