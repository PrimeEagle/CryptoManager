<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ucHashing.ascx.cs" Inherits="CryptoManager.ucHashing" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<DIV style="WIDTH: 700px; POSITION: relative; HEIGHT: 650px" ms_positioning="GridLayout">
	<asp:textbox id="HashKey" style="Z-INDEX: 100; LEFT: 208px; POSITION: absolute; TOP: 96px" tabIndex="1"
		runat="server" Enabled="False" Width="200px"></asp:textbox>
	<asp:label id="Label9" style="Z-INDEX: 101; LEFT: 40px; POSITION: absolute; TOP: 24px" runat="server"
		Font-Size="Large" Font-Names="Verdana" Font-Bold="True" ForeColor="SlateBlue">Hashing</asp:label>
	<asp:label id="Label10" style="Z-INDEX: 102; LEFT: 40px; POSITION: absolute; TOP: 72px" runat="server"
		Font-Size="X-Small" Font-Names="Verdana">Hashing Algorithm</asp:label>
	<asp:dropdownlist id="ddlHashingAlgorithm" style="Z-INDEX: 103; LEFT: 208px; POSITION: absolute; TOP: 64px"
		tabIndex="12" runat="server" Width="312px" AutoPostBack="True"></asp:dropdownlist>
	<asp:label id="HashKeyLabel" style="Z-INDEX: 104; LEFT: 40px; POSITION: absolute; TOP: 104px"
		runat="server" Enabled="False" Font-Size="X-Small" Font-Names="Verdana">Passphrase (Key):</asp:label>
	<asp:checkbox id="PadHashKey" style="Z-INDEX: 105; LEFT: 208px; POSITION: absolute; TOP: 128px"
		tabIndex="13" runat="server" Enabled="False" Font-Size="X-Small" Font-Names="Verdana" Text="Pad Key (length of key must be divisible by 4)"
		ForeColor="ForestGreen"></asp:checkbox>
	<asp:label id="Label3" style="Z-INDEX: 106; LEFT: 40px; POSITION: absolute; TOP: 168px" runat="server"
		Font-Size="X-Small" Font-Names="Verdana">Plain Text:</asp:label>
	<asp:textbox id="HashedPlainText" style="Z-INDEX: 108; LEFT: 208px; POSITION: absolute; TOP: 160px"
		tabIndex="14" runat="server" Width="200px"></asp:textbox>
	<asp:button id="bHash" style="Z-INDEX: 109; LEFT: 432px; POSITION: absolute; TOP: 200px" tabIndex="15"
		runat="server" Text="Hash"></asp:button>
	<asp:checkbox id="PadHashedPlainText" style="Z-INDEX: 110; LEFT: 208px; POSITION: absolute; TOP: 232px"
		tabIndex="13" runat="server" Font-Size="X-Small" Font-Names="Verdana" Text="Pad Text (length of plain text + salt must be divisible by 4)"
		ForeColor="ForestGreen"></asp:checkbox>
	<asp:label id="Label4" style="Z-INDEX: 111; LEFT: 40px; POSITION: absolute; TOP: 272px" runat="server"
		Font-Size="X-Small" Font-Names="Verdana">Hashed Text:</asp:label>
	<asp:textbox id="HashedText" style="Z-INDEX: 112; LEFT: 208px; POSITION: absolute; TOP: 264px"
		tabIndex="16" runat="server" Width="312px"></asp:textbox>
	<asp:label id="ErrorLabel" style="Z-INDEX: 113; LEFT: 40px; POSITION: absolute; TOP: 352px"
		runat="server" Width="520px" Font-Size="X-Small" Font-Names="Verdana" ForeColor="Red" Height="152px"></asp:label>
	<asp:button id="bReset" style="Z-INDEX: 114; LEFT: 40px; POSITION: absolute; TOP: 312px" tabIndex="11"
		runat="server" Text="Reset All Settings"></asp:button>
	<asp:label id="Label1" style="Z-INDEX: 115; LEFT: 40px; POSITION: absolute; TOP: 200px" runat="server"
		Font-Names="Verdana" Font-Size="X-Small">Salt (optional):</asp:label>
	<asp:textbox id="HashSalt" style="Z-INDEX: 116; LEFT: 208px; POSITION: absolute; TOP: 200px"
		tabIndex="14" Width="200px" runat="server"></asp:textbox></DIV>
