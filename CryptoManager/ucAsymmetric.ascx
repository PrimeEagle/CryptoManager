<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ucAsymmetric.ascx.cs" Inherits="CryptoManager.ucAsymmetric" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<DIV style="WIDTH: 700px; POSITION: relative; HEIGHT: 650px" ms_positioning="GridLayout">
	<asp:dropdownlist id="ddlAsymmetricKeySize" style="Z-INDEX: 101; LEFT: 200px; POSITION: absolute; TOP: 96px"
		runat="server" Width="128px"></asp:dropdownlist>
	<asp:label id="Label13" style="Z-INDEX: 102; LEFT: 40px; POSITION: absolute; TOP: 16px" runat="server"
		Font-Size="Large" Font-Names="Verdana" Font-Bold="True" ForeColor="SlateBlue">Asymmetric Encryption</asp:label>
	<asp:label id="Label24" style="Z-INDEX: 103; LEFT: 40px; POSITION: absolute; TOP: 104px" runat="server"
		Font-Size="X-Small" Font-Names="Verdana">Key Size:</asp:label>
	<asp:label id="Label21" style="Z-INDEX: 104; LEFT: 40px; POSITION: absolute; TOP: 72px" runat="server"
		Font-Size="X-Small" Font-Names="Verdana">Encryption Algorithm:</asp:label>
	<asp:dropdownlist id="ddlAsymmetricAlgorithms" style="Z-INDEX: 147; LEFT: 200px; POSITION: absolute; TOP: 64px"
		runat="server" Width="128px"></asp:dropdownlist>
	<asp:Button id="bAssignKey" style="Z-INDEX: 148; LEFT: 40px; POSITION: absolute; TOP: 136px"
		runat="server" Width="160px" Text="Generate New Key Pair"></asp:Button>
	<asp:Button id="bDeleteKeyFiles" style="Z-INDEX: 151; LEFT: 40px; POSITION: absolute; TOP: 224px"
		runat="server" Width="184px" Text="Delete Key Files from Server"></asp:Button>
	<asp:Button id="bUploadKeyFiles" style="Z-INDEX: 158; LEFT: 40px; POSITION: absolute; TOP: 264px"
		runat="server" Width="152px" Text="Upload New Key Files"></asp:Button>
	<asp:HyperLink id="PrivateKey" style="Z-INDEX: 159; LEFT: 88px; POSITION: absolute; TOP: 168px"
		runat="server" Font-Size="X-Small" Font-Names="Verdana" Target="_new">Download Private Key</asp:HyperLink>
	<asp:HyperLink id="PublicKey" style="Z-INDEX: 160; LEFT: 88px; POSITION: absolute; TOP: 192px"
		runat="server" Font-Size="X-Small" Font-Names="Verdana" Target="_new">Download Public Key</asp:HyperLink>
	<asp:label id="Label23" style="Z-INDEX: 161; LEFT: 88px; POSITION: absolute; TOP: 312px" runat="server"
		Font-Size="X-Small" Font-Names="Verdana">Private Key:</asp:label><INPUT id="UploadPrivateKey" style="Z-INDEX: 162; LEFT: 200px; WIDTH: 360px; POSITION: absolute; TOP: 304px; HEIGHT: 22px"
		type="file" size="40" name="UploadPrivateKey" runat="server">
	<asp:label id="Label22" style="Z-INDEX: 163; LEFT: 88px; POSITION: absolute; TOP: 344px" runat="server"
		Font-Size="X-Small" Font-Names="Verdana">Public Key:</asp:label><INPUT id="UploadPublicKey" style="Z-INDEX: 164; LEFT: 200px; WIDTH: 360px; POSITION: absolute; TOP: 336px; HEIGHT: 22px"
		type="file" size="40" name="UploadPublicKey" runat="server">
	<asp:label id="Label16" style="Z-INDEX: 165; LEFT: 40px; POSITION: absolute; TOP: 376px" runat="server"
		Font-Size="X-Small" Font-Names="Verdana">Plain Text:</asp:label>
	<asp:label id="Label17" style="Z-INDEX: 166; LEFT: 40px; POSITION: absolute; TOP: 408px" runat="server"
		Font-Size="X-Small" Font-Names="Verdana">Encrypted Text:</asp:label>
	<asp:label id="Label18" style="Z-INDEX: 167; LEFT: 40px; POSITION: absolute; TOP: 440px" runat="server"
		Font-Size="X-Small" Font-Names="Verdana">Decrypted Text:</asp:label>
	<asp:TextBox id="AsymmetricPlainText" style="Z-INDEX: 168; LEFT: 200px; POSITION: absolute; TOP: 368px"
		runat="server" Width="272px"></asp:TextBox>
	<asp:Button id="bAsymmetricEncrypt" style="Z-INDEX: 169; LEFT: 480px; POSITION: absolute; TOP: 368px"
		runat="server" Text="Encrypt"></asp:Button>
	<asp:TextBox id="AsymmetricEncrypted" style="Z-INDEX: 170; LEFT: 200px; POSITION: absolute; TOP: 400px"
		runat="server" Width="272px"></asp:TextBox>
	<asp:TextBox id="AsymmetricDecrypted" style="Z-INDEX: 171; LEFT: 200px; POSITION: absolute; TOP: 432px"
		runat="server" Width="272px"></asp:TextBox>
	<asp:Button id="bAsymmetricDecrypt" style="Z-INDEX: 172; LEFT: 480px; POSITION: absolute; TOP: 400px"
		runat="server" Text="Decrypt"></asp:Button>
	<asp:label id="ErrorLabel" style="Z-INDEX: 173; LEFT: 40px; POSITION: absolute; TOP: 528px"
		runat="server" Width="528px" Font-Size="X-Small" Font-Names="Verdana" Height="88px" ForeColor="Red"></asp:label>
	<asp:button id="bReset" style="Z-INDEX: 174; LEFT: 40px; POSITION: absolute; TOP: 480px" tabIndex="11"
		runat="server" Text="Reset All Settings"></asp:button></DIV>
