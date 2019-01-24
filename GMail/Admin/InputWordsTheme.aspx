<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InputWordsTheme.aspx.cs" Inherits="GMail.Admin.InputWordsTheme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Input Words</title>
        <link href="~/Styles/keen.css" rel="stylesheet" />
        <link href="~/Styles/responsive.css" rel="stylesheet" />
    </head>

    <body>
        <form id="frmInputWords" runat="server">
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
						<asp:Label ID="lblInputWords" runat="server"
                            Text="<%$ Resources:Wordsmith, Page01DefaultItem05InputWords  %>"></asp:Label>
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
					
				<div class="div-table-row" id="div4">
					<div class="div-table-col">
							&nbsp;
					</div>

					<div class="div-table-col2">
						&nbsp;
					</div>
				</div>
					
				<div class="div-table-row" id="divWordInputWord" runat="server">
					<div class="div-table-col">
						<asp:Label ID="lblWordInputWord" runat="server"
                            Text="<%$ Resources:Wordsmith, Page04InputWords01WordInputWord %>"></asp:Label>
					</div>

					<div class="div-table-col2">
                        <asp:TextBox 
                            ID="txtWordInputWord"
                            AutoCompleteType="None"
                            Width="500"
                            runat="server" /> 
					</div>
				</div>
				
				<!-- Theme Name -->
				<div class="div-table-row" id="divWordThemeName" runat="server">
					<div class="div-table-col">
						<asp:Label ID="lblWordThemeName" runat="server"
                            Text="<%$ Resources:Wordsmith, Page04InputWords02WordInputWordThemeName %>"></asp:Label>
					</div>

					<div class="div-table-col2">
					    <%--asp:TextBox 
						   ID="txtWordThemeName"
						   AutoCompleteType="None"
						   Width="500"
						   runat="server" /> --%>
						<asp:DropDownList ID="ddlWordThemeName" runat="server" />
					</div>
				</div>
				
				<!-- Pronounciation -->
				<div class="div-table-row" id="div6">
					<div class="div-table-col">
						<asp:Label ID="lblWordInputPronounciation" runat="server"
                            Text="<%$ Resources:Wordsmith, Page04InputWords03WordInputPronounciation %>"></asp:Label>
					</div>

					<div class="div-table-col2">
                        <asp:TextBox 
                            ID="txtWordInputPronounciation"
                            AutoCompleteType="None"
                            Width="500"
                            runat="server" /> 
					</div>
				</div>
				
				<!-- Meaning -->
				<div class="div-table-row" id="div10" runat="server">
					<div class="div-table-colTaller">
						<asp:Label ID="lblWordInputMeaning" runat="server"
                            Text="<%$ Resources:Wordsmith, Page04InputWords04WordInputMeaning %>"></asp:Label>
					</div>

					<div class="div-table-col2Tallerer">
                        <asp:TextBox 
                            ID="txtWordInputMeaning"
                            AutoCompleteType="None"
						   MaxLength="2500" Width="500" Height="90" TextMode="MultiLine" CssClass="noresize"
                            runat="server" /> 
					</div>
				</div>
				
				<!-- Etymology -->
				<div class="div-table-row" id="divWordInputEtymology">
					<div class="div-table-colTaller">
						<asp:Label ID="lblWordInputEtymology" runat="server"
                            Text="<%$ Resources:Wordsmith, Page04InputWords05WordInputEtymology %>"></asp:Label>
					</div>

					<div class="div-table-col2Tallerer">
                        <asp:TextBox 
                            ID="txtWordInputEtymology"
                            AutoCompleteType="None"
						   MaxLength="2500" Width="500" Height="90" TextMode="MultiLine" CssClass="noresize"
                            runat="server" /> 
					</div>
				</div>
				
				<!-- Usage -->
				<div class="div-table-row" id="divWordInputUsage" runat="server">
					<div class="div-table-colTaller">
						<asp:Label ID="lblWordInputUsage" runat="server"
                            Text="<%$ Resources:Wordsmith, Page04InputWords06WordInputUsage %>"></asp:Label>
					</div>

					<div class="div-table-col2Tallerer">
                        <asp:TextBox 
                            ID="txtWordInputUsage"
                            AutoCompleteType="None"
						   MaxLength="2500" Width="500" Height="90" TextMode="MultiLine" CssClass="noresize"
                            runat="server" /> 
					</div>
				</div>
				
				<!-- Thought a Day -->
				<div class="div-table-row" id="divWordInputThoughtADay">
					<div class="div-table-colTaller">
						<asp:Label ID="lblWordInputThoughtADay" runat="server"
                            Text="<%$ Resources:Wordsmith, Page04InputWords07WordInputThoughtADay %>"></asp:Label>
					</div>

					<div class="div-table-col2Tallerer">
                        <asp:TextBox 
                            ID="txtWordInputThoughtADay"
                            AutoCompleteType="None"
						   MaxLength="2500" Width="500" Height="90" TextMode="MultiLine" CssClass="noresize"
                            runat="server" /> 
					</div>
				</div>
				
				<!-- Notes -->
				<div class="div-table-row" id="divWordInputNotes" runat="server">
					<div class="div-table-colTaller">
						<asp:Label ID="lblWordInputNotes" runat="server"
                            Text="<%$ Resources:Wordsmith, Page04InputWords08WordInputNotes %>"></asp:Label>
					</div>

					<div class="div-table-col2Tallerer">
                        <asp:TextBox 
                            ID="txtWordInputNotes"
                            AutoCompleteType="None"
						   MaxLength="2500" Width="500" Height="90" TextMode="MultiLine" CssClass="noresize"
                            runat="server" /> 
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
						<asp:Button ID="cmdWordCreate" runat="server" 
                            Text="<%$ Resources:Wordsmith, Page04InputWords09WordCreate %>" OnClick="cmdWordCreate_Click" />
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
