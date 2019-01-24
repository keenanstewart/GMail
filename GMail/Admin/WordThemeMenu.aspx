<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WordThemeMenu.aspx.cs" Inherits="GMail.WordThemeMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Word Theme Menu</title>
        <link href="~/Styles/keen.css" rel="stylesheet" />
        <link href="~/Styles/responsive.css" rel="stylesheet" />
    </head>

    <body>
        <form id="frmWordsmith" runat="server">
			<div runat="server" class="div-table" id="divWords">
				<div class="div-table-row" id="divSpacer">
					<div class="div-table-col">
						&nbsp;
					</div>

					<div class="div-table-col2">
						&nbsp;
					</div>
				</div>
					
				<div class="div-table-row" id="div1">
					<div class="div-table-col">
							 
					</div>

					<div class="div-table-col2">
						<asp:Label ID="lblHome" runat="server"
                            Text="<%$ Resources:Wordsmith, Page01DefaultItem01Home  %>"></asp:Label>
					</div>
				</div>
					
				<div class="div-table-row" id="divLogout">
					<div class="div-table-col">
							 
					</div>

					<div class="div-table-col2">
                        <asp:LinkButton ID="lbLogout" runat="server" OnClick="lbLogout_Click"
                            Text="<%$ Resources:Wordsmith, Page01DefaultItem02Logout %>"
                            ></asp:LinkButton>
					</div>
				</div>
					
				<div class="div-table-row" id="div5">
					<div class="div-table-col">
							 
					</div>

					<div class="div-table-col2">
						
					</div>
				</div>
					
				<div class="div-table-row" id="div7">
					<div class="div-table-col">
							 
					</div>

					<div class="div-table-col2">
						<asp:HyperLink ID="hypAdminWords" runat="server" NavigateUrl="~/Admin/ViewWordsTheme.aspx" 
                            Text="<%$ Resources:Wordsmith, Page01DefaultItem04ViewWords  %>"></asp:HyperLink>
					</div>
				</div>
					
				<div class="div-table-row" id="div3">
					<div class="div-table-col">
							&nbsp;
					</div>

					<div class="div-table-col2">
						<asp:HyperLink ID="hypInputWord" runat="server" NavigateUrl="~/Admin/InputWords.aspx" 
                            Text="<%$ Resources:Wordsmith, Page01DefaultItem05InputWords %>"></asp:HyperLink>
					</div>
				</div>
					
				<div class="div-table-row" id="div4">
					<div class="div-table-col">
							&nbsp;
					</div>

					<div class="div-table-col2">
						&nbsp;
					</div>
				</div>
					
				<div class="div-table-row" id="div6">
					<div class="div-table-col">
							&nbsp;
					</div>

					<div class="div-table-col2">
						<asp:HyperLink ID="hypGetArchive" runat="server" NavigateUrl="~/GetArchive.aspx" 
                            Text="<%$ Resources:Wordsmith, Page01DefaultItem08GetArchive  %>"></asp:HyperLink>
					</div>
				</div>
					
				<div class="div-table-row" id="div8">
					<div class="div-table-col">
							&nbsp;
					</div>

					<div class="div-table-col2">
						&nbsp;
					</div>
				</div>
					
				<div class="div-table-row" id="divLoginName" runat="server">
					<div class="div-table-col">
						<asp:Label ID="lblUsername" runat="server" 
                            Text="<%$ Resources:Wordsmith, Page01DefaultItem06LoginName %>"></asp:Label>
					</div>

					<div class="div-table-col2">
						<asp:TextBox ID="txtUsername" runat="server" ></asp:TextBox>
					</div>
				</div>
					
				<div class="div-table-row" id="divPassword" runat="server">
					<div class="div-table-col">
							<asp:Label ID="lblPassword" runat="server"  
                                Text="<%$ Resources:Wordsmith, Page01DefaultItem07LoginPassword %>"></asp:Label>
					</div>

					<div class="div-table-col2">
						<asp:TextBox ID="txtPassword" runat="server" ></asp:TextBox>
					</div>
				</div>
					
				<div class="div-table-row" id="divSpacer1" runat="server">
					<div class="div-table-col">
						&nbsp;
					</div>

					<div class="div-table-col2">
						&nbsp;
					</div>
				</div>
					
				<div class="div-table-row" id="divSpacer2" runat="server">
					<div class="div-table-col">
							&nbsp;
					</div>

					<div class="div-table-col2">
						<asp:Button ID="cmdLogin" runat="server" 
                            Text="<%$ Resources:Wordsmith, Page01DefaultItem07LoginButton %>" 
                            OnClick="cmdLogin_Click" />
					</div>
				</div>
					
				<div class="div-table-row" id="divSpacer3" runat="server">
					<div class="div-table-col">
						&nbsp;
					</div>

					<div class="div-table-col2">
						&nbsp;
					</div>
				</div>
					
				<div class="div-table-row2" id="divLanguageBar">
					<div class="div-table-colTaller">							
						<asp:ListBox runat="server" ID="lstCulture" AutoPostBack="True">
							<asp:ListItem Value="en-CA" Selected="True">English</asp:ListItem>
							<asp:ListItem Value="fr-CA">French</asp:ListItem>
							<asp:ListItem Value="ar-SY">العربية</asp:ListItem>
				</asp:ListBox>
					</div>
					<div class="div-table-col2">
						&nbsp;
					</div>
				</div>
					
				<div class="div-table-row">

					<div class="div-table-col200">
						<asp:Label runat="server" ID="lblMessage"></asp:Label>
					</div>
				</div>
					
				<div class="div-table-row">
					<div class="div-table-col200">
						<asp:Label runat="server" ID="lblMessage2"></asp:Label>
					</div>
				</div>
					
				<div class="div-table-row">
					<div class="div-table-col">
						&nbsp;
					</div>

					<div class="div-table-col2">
						&nbsp;
					</div>
				</div>
            </div>
        </form>
    </body>
</html>
