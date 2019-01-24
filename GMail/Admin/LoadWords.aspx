<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadWords.aspx.cs" Inherits="GMail.Admin.LoadWords" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Load Words</title>
        <link href="~/Styles/keen.css" rel="stylesheet" />
        <link href="~/Styles/responsive.css" rel="stylesheet" />
</head>
<body>
    <form id="frmLoadWords" runat="server">
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
						<asp:HyperLink ID="hypHome" runat="server" NavigateUrl="~/Default.aspx" 
                            Text="<%$ Resources:Wordsmith, Page01DefaultItem01Home  %>"></asp:HyperLink>
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
						<asp:Label ID="lblLoadWords" runat="server"
                            Text="<%$ Resources:Wordsmith, Page01DefaultItem03LoadWords  %>"></asp:Label>
					</div>
				</div>
					
				<div class="div-table-row" id="div7">
					<div class="div-table-col">
							 
					</div>

					<div class="div-table-col2">
						<asp:HyperLink ID="hypViewWords" runat="server" NavigateUrl="~/Admin/ViewWords.aspx" 
                            Text="<%$ Resources:Wordsmith, Page01DefaultItem04ViewWords  %>"></asp:HyperLink>
					</div>
				</div>
					
				<div class="div-table-row" id="div2">
					<div class="div-table-col">
						&nbsp;
					</div>

					<div class="div-table-col2">
						<asp:HyperLink ID="hypInputWord" runat="server" NavigateUrl="~/Admin/InputWords.aspx" 
                            Text="<%$ Resources:Wordsmith, Page01DefaultItem05InputWords  %>"></asp:HyperLink>
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
					
				<div class="div-table-row" id="divSpacer3" runat="server">
					<div class="div-table-col">
						<asp:Label ID="lblWordURL" runat="server"
                            Text="<%$ Resources:Wordsmith, Page03LoadWords01LoadWords %>"></asp:Label>
					</div>

					<div class="div-table-col2">
                        <asp:TextBox 
                            ID="txtWordURL"
                            AutoCompleteType="None"
                            Width="500"
                            runat="server" /> 
					</div>
				</div>
					
				<div class="div-table-row" id="div6">
					<div class="div-table-col">
						&nbsp;
					</div>

					<div class="div-table-col2">
					    &nbsp;
					</div>
				</div>
					
				<div class="div-table-row" id="div3" runat="server">
					<div class="div-table-col">
						&nbsp;
					</div>

					<div class="div-table-col2">
						&nbsp;
					</div>
				</div>
					
				<div class="div-table-row" id="div8" runat="server">
					<div class="div-table-col">
						&nbsp;
					</div>

					<div class="div-table-col2">
						&nbsp;
					</div>
				</div>
					
				<div class="div-table-row" id="div9" runat="server">
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
