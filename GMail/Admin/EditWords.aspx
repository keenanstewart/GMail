<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditWords.aspx.cs" Inherits="GMail.Admin.EditWords" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>Edit Words</title>
		<link href="../Styles/keen.css" rel="stylesheet" />
		<link href="../Styles/responsive.css" rel="stylesheet" />
	</head>

	<body>
		<form id="frmEditLinks" runat="server">
			
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
						<asp:HyperLink ID="hypLoadWords" runat="server" NavigateUrl="~/Admin/LoadWords.aspx" 
                            Text="<%$ Resources:Wordsmith, Page01DefaultItem03LoadWords  %>"></asp:HyperLink>
					</div>
				</div>
					
				<div class="div-table-row" id="div7">
					<div class="div-table-col">
							 
					</div>

					<div class="div-table-col2">
						<asp:HyperLink ID="hypAdminWords" runat="server" NavigateUrl="~/Admin/ViewWords.aspx" 
                            Text="<%$ Resources:Wordsmith, Page01DefaultItem04ViewWords  %>"></asp:HyperLink>
					</div>
				</div>
					
				<div class="div-table-row" id="div2">
					<div class="div-table-col">
						&nbsp;
					</div>

					<div class="div-table-col2">
						<asp:HyperLink ID="hypInputWords" runat="server" NavigateUrl="~/Admin/InputWords.aspx" 
                            Text="<%$ Resources:Wordsmith, Page01DefaultItem05InputWords  %>"></asp:HyperLink>
					</div>
				</div>
					
				<div class="div-table-row" id="div13" runat="server">
					<div class="div-table-col">
						&nbsp;
					</div>

					<div class="div-table-col2">
						&nbsp;
					</div>
				</div>
					
				<div class="div-table-row2" id="divLanguageBar">
					<div class="div-table-colTaller">							
						<asp:ListBox runat="server" ID="ListBox1" AutoPostBack="True">
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
					
				<div class="div-table-row" id="divWordEditWord" runat="server">
					<div class="div-table-col">
						<asp:Label ID="lblWordEditWord" runat="server"
                            Text="<%$ Resources:Wordsmith, Page05EditWords01WordEditWord %>"></asp:Label>
					</div>

					<div class="div-table-col2">
                        <asp:TextBox 
                            ID="txtWordEditWord"
                            AutoCompleteType="None"
                            Width="500"
                            runat="server" /> 
					</div>
				</div>
					
				<div class="div-table-row" id="div" runat="server">
					<div class="div-table-col">
						<asp:Label ID="lblWordThemeName" runat="server"
                            Text="<%$ Resources:Wordsmith, Page05EditWords02WordEditWordThemeName %>"></asp:Label>
					</div>

					<div class="div-table-col2">
						<asp:DropDownList ID="ddlWordsmithTheme" runat="server" />
                        <%--<asp:TextBox 
                            ID="txtWordThemeName"
                            AutoCompleteType="None"
                            Width="500"
                            runat="server" /> --%>
					</div>
				</div>
				
				<!-- Pronounciation -->					
				<div class="div-table-row" id="divWordEditPronounciation">
					<div class="div-table-col">
						<asp:Label ID="lblWordEditPronounciation" runat="server"
                            Text="<%$ Resources:Wordsmith, Page05EditWords03WordEditPronounciation %>"></asp:Label>
					</div>

					<div class="div-table-col2">
					    <asp:TextBox 
						   ID="txtWordEditPronounciation"
						   AutoCompleteType="None"
						   Width="500"
						   runat="server" /> 
					</div>
				</div>
				
				<!-- Meaning -->
				<div class="div-table-row" id="divWordEditMeaning">
					<div class="div-table-colTaller">
						<asp:Label ID="lblWordEditMeaning" runat="server"
                            Text="<%$ Resources:Wordsmith, Page05EditWords04WordEditMeaning %>"></asp:Label>
					</div>

					<div class="div-table-col2Tallerer">
					    <asp:TextBox 
						   ID="txtWordEditMeaning"
						   AutoCompleteType="None"
						   MaxLength="2500" Width="500" Height="90" TextMode="MultiLine" CssClass="noresize"
						   runat="server" /> 
					</div>
				</div>

				<!-- Etymology -->
				<div class="div-table-row" id="divWordEditEtymology">
					<div class="div-table-colTaller">
						<asp:Label ID="lblWordEditEtymology" runat="server"
                            Text="<%$ Resources:Wordsmith, Page05EditWords05WordEditEtymology %>"></asp:Label>
					</div>

					<div class="div-table-col2Tallerer">
                        <asp:TextBox 
                            ID="txtWordEditEtymology"
                            AutoCompleteType="None"
                            MaxLength="2500" Width="500" Height="90" TextMode="MultiLine" CssClass="noresize"
                            runat="server" /> 
					</div>
				</div>
				
				<!-- Usage -->
				<div class="div-table-row" id="divWordEditUsage" runat="server">
					<div class="div-table-colTaller">
						<asp:Label ID="lblWordEditUsage" runat="server"
                            Text="<%$ Resources:Wordsmith, Page05EditWords06WordEditUsage %>"></asp:Label>
					</div>

					<div class="div-table-col2Tallerer">
                        <asp:TextBox 
                            ID="txtWordEditUsage"
                            AutoCompleteType="None"
                            MaxLength="2500" Width="500" Height="90" TextMode="MultiLine" CssClass="noresize"
                            runat="server" /> 
					</div>
				</div>
				
				<!-- Thought a Day -->
				<div class="div-table-row" id="divEditThoughtADay">
					<div class="div-table-colTaller">
						<asp:Label ID="lblEditThoughtADay" runat="server"
                            Text="<%$ Resources:Wordsmith, Page05EditWords07WordEditThoughtADay %>"></asp:Label>
					</div>

					<div class="div-table-col2Tallerer">
                        <asp:TextBox 
                            ID="txtWordEditThoughtADay"
                            AutoCompleteType="None"
                            MaxLength="2500" Width="500" Height="90" TextMode="MultiLine" CssClass="noresize"
                            runat="server" /> 
					</div>
				</div>
				
				<!-- Notes -->
				<div class="div-table-row" id="divWordEditNotes" runat="server">
					<div class="div-table-colTaller">
						<asp:Label ID="lblWordEditNotes" runat="server"
                            Text="<%$ Resources:Wordsmith, Page05EditWords08WordEditNotes %>"></asp:Label>
					</div>

					<div class="div-table-col2Tallerer">
                        <asp:TextBox 
                            ID="txtWordEditNotes"
                            AutoCompleteType="None"
                            MaxLength="2500" Width="500" Height="90" TextMode="MultiLine" CssClass="noresize"
                            runat="server" /> 
					</div>
				</div>
					
				<!-- Insert Date -->
				<div class="div-table-row" id="divInsertDate" runat="server">
					<div class="div-table-col">
						<asp:Label ID="lblWordEditInputDate" runat="server"
                              Text="<%$ Resources:Wordsmith, Page05EditWords09WordInsert %>"
                              ></asp:Label>
					</div>

					<div class="div-table-col2">
						<asp:Label ID="txtWordEditInputDate" runat="server"
                              MaxLength="50" Width="300"
                              ></asp:Label>
					</div>
				</div>
					
				<!-- Update Date -->
				<div class="div-table-row" id="divUpdateDate">
					<div class="div-table-col">
						<asp:Label ID="lblWordEditUpdateDate" runat="server"
                              Text="<%$ Resources:Wordsmith, Page05EditWords10WordUpdate %>"
                              ></asp:Label>
					</div>

					<div class="div-table-col2">
						<asp:Label ID="txtWordEditUpdateDate" runat="server"
                              MaxLength="50" Width="200"
                              ></asp:Label>
					</div>
				</div>
					
				<!-- Reviewed row -->
				<div class="div-table-row" id="divWordEditReviewed" runat="server">
					<div class="div-table-col">
						<asp:Label ID="lblReviewed" runat="server"
                              Text="<%$ Resources:Wordsmith, Page05EditWords11WordReviewed %>"
                              ></asp:Label>
					</div>

					<div class="div-table-col2">
						<asp:CheckBox ID="chkReviewed" runat="server"
                              Text="<%$ Resources:Wordsmith, Page05EditWords11WordReviewed %>" />
					</div>
				</div>
				
				<!-- Empty spacer row -->
				<div class="div-table-row" id="div4">
					<div class="div-table-col">
							&nbsp;
					</div>

					<div class="div-table-col2">
						&nbsp;
					</div>
				</div>
				
				<!-- Update record -->
				<div class="div-table-row" id="div12" runat="server">
					<div class="div-table-col">
						&nbsp;
					</div>

					<div class="div-table-col2">
						<asp:Button ID="cmdWordUpdate" runat="server" 
                            Text="<%$ Resources:Wordsmith, Page05EditWords10WordUpdate %>" OnClick="cmdWordUpdate_Click" />
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
