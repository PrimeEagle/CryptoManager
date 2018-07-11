<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ucSymmetric.ascx.cs" Inherits="CryptoManager.ucSymmetric" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<DIV style="WIDTH: 700px; POSITION: relative; HEIGHT: 650px" ms_positioning="GridLayout">
	<asp:textbox id="EncryptionPlainText" style="Z-INDEX: 101; LEFT: 192px; POSITION: absolute; TOP: 272px"
		tabIndex="6" Width="200px" runat="server"></asp:textbox>
	<asp:label id="Label8" style="Z-INDEX: 102; LEFT: 40px; POSITION: absolute; TOP: 16px" runat="server"
		Font-Size="Large" Font-Names="Verdana" Font-Bold="True" ForeColor="SlateBlue"> Symmetric Encryption</asp:label>
	<asp:label id="Label5" style="Z-INDEX: 103; LEFT: 40px; POSITION: absolute; TOP: 75px" runat="server"
		Font-Size="X-Small" Font-Names="Verdana">Encryption Algorithm:</asp:label>
	<asp:dropdownlist id="ddlEncryptionAlgorithm" style="Z-INDEX: 104; LEFT: 192px; POSITION: absolute; TOP: 72px"
		Width="304px" runat="server" AutoPostBack="True"></asp:dropdownlist>
	<asp:label id="Label6" style="Z-INDEX: 105; LEFT: 40px; POSITION: absolute; TOP: 112px" runat="server"
		Font-Size="X-Small" Font-Names="Verdana">Passphrase (Key):</asp:label>
	<asp:textbox id="Passphrase" style="Z-INDEX: 106; LEFT: 192px; POSITION: absolute; TOP: 104px"
		tabIndex="1" Width="200px" runat="server"></asp:textbox>
	<asp:checkbox id="PadKey" style="Z-INDEX: 107; LEFT: 192px; POSITION: absolute; TOP: 128px" tabIndex="2"
		runat="server" Font-Size="X-Small" Font-Names="Verdana" AutoPostBack="True" Text="Pad Key (automatically fixes incorrect key sizes)"
		ForeColor="ForestGreen"></asp:checkbox>
	<asp:checkbox id="UseInitVector" style="Z-INDEX: 108; LEFT: 40px; POSITION: absolute; TOP: 152px"
		tabIndex="3" runat="server" Font-Size="X-Small" Font-Names="Verdana" AutoPostBack="True" Text="Use Initialization Vector (IV)"></asp:checkbox>
	<asp:label id="Label19" style="Z-INDEX: 109; LEFT: 64px; POSITION: absolute; TOP: 184px" runat="server"
		Font-Size="X-Small" Font-Names="Verdana" Enabled="False">Cipher Mode:</asp:label>
	<asp:dropdownlist id="ddlCipherMode" style="Z-INDEX: 110; LEFT: 216px; POSITION: absolute; TOP: 176px"
		tabIndex="4" runat="server" AutoPostBack="True" Enabled="False">
		<asp:ListItem Value="Auto Generated">Auto Generated</asp:ListItem>
		<asp:ListItem Value="Manually Entered">Manually Entered</asp:ListItem>
	</asp:dropdownlist>
	<asp:dropdownlist id="VectorType" style="Z-INDEX: 111; LEFT: 216px; POSITION: absolute; TOP: 208px"
		tabIndex="4" runat="server" AutoPostBack="True" Enabled="False">
		<asp:ListItem Value="Auto Generated">Auto Generated</asp:ListItem>
		<asp:ListItem Value="Manually Entered">Manually Entered</asp:ListItem>
	</asp:dropdownlist>
	<asp:label id="VectorTypeLabel" style="Z-INDEX: 112; LEFT: 64px; POSITION: absolute; TOP: 216px"
		runat="server" Font-Size="X-Small" Font-Names="Verdana" Enabled="False">Source of IV:</asp:label>
	<asp:label id="VectorLabel" style="Z-INDEX: 113; LEFT: 64px; POSITION: absolute; TOP: 248px"
		runat="server" Font-Size="X-Small" Font-Names="Verdana" Enabled="False">IV:</asp:label>
	<asp:textbox id="Vector" style="Z-INDEX: 114; LEFT: 216px; POSITION: absolute; TOP: 240px" tabIndex="5"
		Width="200px" runat="server" Enabled="False"></asp:textbox>
	<asp:label id="Label1" style="Z-INDEX: 115; LEFT: 40px; POSITION: absolute; TOP: 280px" runat="server"
		Font-Size="X-Small" Font-Names="Verdana">Plain Text:</asp:label>
	<asp:label id="Label14" style="Z-INDEX: 116; LEFT: 40px; POSITION: absolute; TOP: 312px" runat="server"
		Font-Size="X-Small" Font-Names="Verdana">Encrypted Text:</asp:label>
	<asp:label id="Label2" style="Z-INDEX: 117; LEFT: 40px; POSITION: absolute; TOP: 344px" runat="server"
		Font-Size="X-Small" Font-Names="Verdana">Decrypted Text:</asp:label>
	<asp:textbox id="EncryptedText" style="Z-INDEX: 118; LEFT: 192px; POSITION: absolute; TOP: 304px"
		tabIndex="8" Width="200px" runat="server"></asp:textbox>
	<asp:textbox id="DecryptedText" style="Z-INDEX: 119; LEFT: 192px; POSITION: absolute; TOP: 336px"
		tabIndex="10" Width="200px" runat="server"></asp:textbox>
	<asp:button id="bEncrypt" style="Z-INDEX: 120; LEFT: 416px; POSITION: absolute; TOP: 304px"
		tabIndex="7" runat="server" Text="Encrypt"></asp:button>
	<asp:button id="bDecrypt" style="Z-INDEX: 121; LEFT: 416px; POSITION: absolute; TOP: 336px"
		tabIndex="9" runat="server" Text="Decrypt"></asp:button>
	<asp:label id="ErrorLabel" style="Z-INDEX: 122; LEFT: 40px; POSITION: absolute; TOP: 432px"
		Width="440px" runat="server" Font-Size="X-Small" Font-Names="Verdana" ForeColor="Red" Height="88px"></asp:label>
	<asp:button id="bReset" style="Z-INDEX: 133; LEFT: 40px; POSITION: absolute; TOP: 392px" tabIndex="11"
		runat="server" Text="Reset All Settings"></asp:button></DIV>
