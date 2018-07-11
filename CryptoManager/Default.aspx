<%@ Register TagPrefix="igtab" Namespace="Infragistics.WebUI.UltraWebTab" Assembly="Infragistics.WebUI.UltraWebTab.v4.3, Version=4.3.20043.84, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="CryptoManager._Default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Cryptography Manager</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#ffff99" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server" enctype="multipart/form-data">
			<asp:Label id="Label11" style="Z-INDEX: 101; LEFT: 176px; POSITION: absolute; TOP: 712px" runat="server"
				ForeColor="ForestGreen" Height="48px" Width="712px" Font-Names="Verdana" Font-Size="XX-Small">Using the features in green may cause compatibility issues, as they automatically fix improperly formatted strings. Since this fix is not a standard part of encryption algorithms, it may be difficult to decrypt or hash through the use of other libraries in the future. However, it can be necessary at times, such as when hasing a user's existing password.</asp:Label>
			<asp:Label id="Label12" style="Z-INDEX: 102; LEFT: 512px; POSITION: absolute; TOP: 40px" runat="server"
				Width="368px" Font-Size="XX-Small" Font-Names="Verdana" ForeColor="Red"> NOTE: The larger the encryption key, the stronger the encryption!</asp:Label>
			<igtab:UltraWebTab id="UltraWebTab1" style="Z-INDEX: 103; LEFT: 24px; POSITION: absolute; TOP: 56px"
				runat="server" Width="856px" Height="650px" Font-Names="Verdana" TabOrientation="LeftTop" BorderStyle="Solid"
				BackColor="#D0CDC0" BorderColor="Silver">
				<HoverTabStyle ForeColor="Black" BackColor="#BAB9AE"></HoverTabStyle>
				<DefaultTabStyle Font-Size="9pt" Font-Names="Microsoft Sans Serif" ForeColor="#666666" BackColor="#D0CDC0">
					<Padding Bottom="3px" Left="10px" Top="5px" Right="15px"></Padding>
					<BorderDetails WidthLeft="1px" StyleBottom="Solid" ColorBottom="131, 133, 116" WidthBottom="1px"
						StyleLeft="Solid" ColorLeft="131, 133, 116"></BorderDetails>
				</DefaultTabStyle>
				<DefaultTabSeparatorStyle Height="3px" Font-Names="Microsoft Sans Serif" ForeColor="#D0CDC0" BackColor="#D0CDC0"
					CustomRules="background-color:#D0CDC0">
					<BorderDetails StyleBottom="None" StyleTop="None" StyleRight="None" StyleLeft="Solid" ColorLeft="208, 205, 192"></BorderDetails>
				</DefaultTabSeparatorStyle>
				<SelectedTabStyle Font-Names="Microsoft Sans Serif" BorderColor="Transparent" ForeColor="SlateBlue"
					BackColor="#EFEFEB">
					<BorderDetails StyleBottom="Solid" ColorBottom="159, 160, 144" StyleLeft="Solid" ColorLeft="159, 160, 144"></BorderDetails>
				</SelectedTabStyle>
				<Tabs>
					<igtab:Tab Text="Symmetric Encryption">
						<ContentPane UserControlUrl="ucSymmetric.ascx"></ContentPane>
					</igtab:Tab>
					<igtab:Tab Text="Asymmetric Encryption">
						<ContentPane UserControlUrl="ucAsymmetric.ascx"></ContentPane>
					</igtab:Tab>
					<igtab:Tab Text="Hashing">
						<ContentPane UserControlUrl="ucHashing.ascx"></ContentPane>
					</igtab:Tab>
				</Tabs>
			</igtab:UltraWebTab>
			<asp:Label id="Label1" style="Z-INDEX: 104; LEFT: 24px; POSITION: absolute; TOP: 24px" runat="server"
				Font-Names="Microsoft Sans Serif" Font-Size="Large" ForeColor="SlateBlue">CryptoManager 1.0</asp:Label></form>
	</body>
</HTML>
