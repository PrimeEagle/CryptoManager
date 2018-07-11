using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using Dell.Pgit.Cryptography;

namespace CryptoManager
{
	public class _Default : System.Web.UI.Page
	{
		protected SymmetricEncryption SE;
		protected AsymmetricEncryption AE;
		protected SymmetricEncryptionConfigurator DESConfig;
		protected SymmetricEncryptionConfigurator RC2Config;
		protected SymmetricEncryptionConfigurator RijndaelConfig;
		protected SymmetricEncryptionConfigurator TripleDESConfig;
		protected Dell.Pgit.Cryptography.Hashing H;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.HtmlControls.HtmlInputFile privatepath;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.DropDownList ddlSignature;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.DropDownList ddlSignatureHashAlgorithm;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.TextBox SignaturePlainText;
		protected System.Web.UI.WebControls.CheckBox PadSignaturePlainText;
		protected System.Web.UI.WebControls.TextBox SignedText;
		protected System.Web.UI.WebControls.Label Label29;
		protected System.Web.UI.WebControls.Button bSign;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox SignatureVerify;
		protected System.Web.UI.WebControls.Label Label30;
		protected System.Web.UI.WebControls.Label Label31;
		protected System.Web.UI.WebControls.Label Label32;
		protected System.Web.UI.WebControls.Label Label1;
		protected Infragistics.WebUI.UltraWebTab.UltraWebTab UltraWebTab1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

	}
}
