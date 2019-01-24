<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewWordsTheme.aspx.cs" Inherits="GMail.Admin.ViewWordsTheme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>View Words</title>
        <script src="//code.jquery.com/jquery-1.10.2.js"></script> 
        <script src="//code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
        <link rel="Stylesheet" href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" />
        <link href="~/Styles/keen.css" rel="stylesheet" />
        <link href="~/Styles/responsive.css" rel="stylesheet" />

		<script type="text/javascript">
		    $(function () {
		        $("#" + "<%=txtSearchWords.ClientID %>").autocomplete({
		            source: function (request, response) {
		                //alert($("#"+'<%=txtSearchWords.ClientID %>').val());
		                var param = { strStart: $("#" + '<%=txtSearchWords.ClientID %>').val() };
		                $.ajax({
		                    //url: "AddressLookup.asmx/GetAddressess",
		                    url: "ViewWords.aspx/GetWords",
		                    data: JSON.stringify(param),
		                    dataType: "json",
		                    type: "POST",
		                    autoFocus: true,
		                    selectFirst: true,
		                    contentType: "application/json; charset=utf-8",
		                    dataFilter: function (data) { return data; },
		                    success: function (data) {
		                        //alert("success");
		                        response($.map(data.d, function (item) {
		                            return {
		                                value: item
		                            }
		                        }))
		                    },
		                    error: function (XMLHttpRequest, textStatus, errorThrown) {
		                        alert(textStatus);
		                    }
		                });
		            },
		            minLength: 1
		        });
		    });
		</script>

    </head>
    <body>
        <form id="frmViewWords" runat="server">
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
						<asp:Label ID="lblViewWords" runat="server"
                            Text="<%$ Resources:Wordsmith, Page01DefaultItem04ViewWords  %>"></asp:Label>
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
						<asp:Label runat="server" ID="lblSearch" 
                                Text="<%$ Resources:Wordsmith, Page02ViewWords01Search %>"></asp:Label>
					</div>

					<div class="div-table-col2">
						<asp:TextBox ID="txtSearchWords" runat="server" AutoPostBack="True" 
                            OnTextChanged="txtSearchWords_TextChanged" Wrap="False"></asp:TextBox>
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
					
				<div class="div-table-row" id="div8" runat="server">
					<div class="div-table-col">
						&nbsp;
					</div>

					<div class="div-table-col2">
						&nbsp;
					</div>
				</div>
					
				<div class="div-table-row" id="div6" runat="server">
					<div class="div-table-col">
						&nbsp;
					</div>

					<div class="div-table-col2">
						<asp:Label ID="lblRecords" runat="server"></asp:Label>
					</div>
				</div>
					
				<div class="div-table-row-grid-view" style="height: 500px;">
					<div class="div-table-colfull">
						<asp:GridView ID="grdWords" runat="server" 
                            CssClass="gridViewWidth"
                            AllowPaging="True" PageSize="10"
                            AutoGenerateColumns="false"
                            AllowSorting="true"
                            OnPageIndexChanging="grdWords_PageIndexChanging"
                            OnRowCancelingEdit="grdWords_RowCancelingEdit" 
					   OnRowDataBound="grdWords_RowDataBound"
                            OnRowEditing="grdWords_RowEditing" 
                            OnRowUpdating="grdWords_RowUpdating"
                            OnSorting="grdWords_Sorting"
                            >
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="cmdEdit" runat="server" Text="Edit" CommandName="Edit" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="cmdUpdate" runat="server" Text="Update" CommandName="Update" />
                                        <asp:LinkButton ID="cmdCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ID" SortExpression="ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="WordsmithThemeName" SortExpression="WordsmithThemeName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblWSHID" runat="server" Text='<%# Bind("WordsmithThemeName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="DailyWord">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDailyWord" runat="server"
                                            Text='<%# Bind("DailyWord") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Pronunciation">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPronunciation" runat="server" 
                                            Text='<%# Bind("Pronunciation") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Meaning">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMeaning" runat="server" 
                                            Text='<%# Bind("Meaning") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                            <RowStyle Width="150px" />
						</asp:GridView>
					</div>
				</div>
					
                    <!--  Panel for results -- >
                    <asp:Panel ID="panResults" runat ="server" ScrollBars="Vertical"
                        Height="200px" Width="800px"
                        ></asp:Panel>
					<div class="div-table-row">
						<div class="div-table-col">
							&nbsp;
						</div>

						<div class="div-table-col2">
							&nbsp;
						</div>
					</div>
                    <!-- -->
					
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