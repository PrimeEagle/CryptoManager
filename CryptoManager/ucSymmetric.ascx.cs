namespace CryptoManager
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Dell.Pgit.Cryptography;

	/// <summary>
	///		Summary description for ucSymmetric.
	/// </summary>
	public class ucSymmetric : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label VectorTypeLabel;
		protected System.Web.UI.WebControls.DropDownList VectorType;
		protected System.Web.UI.WebControls.Label VectorLabel;
		protected System.Web.UI.WebControls.TextBox Vector;
		protected System.Web.UI.WebControls.CheckBox UseInitVector;
		protected System.Web.UI.WebControls.CheckBox PadKey;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.DropDownList ddlEncryptionAlgorithm;
		protected System.Web.UI.WebControls.TextBox Passphrase;
		protected System.Web.UI.WebControls.Button bDecrypt;
		protected System.Web.UI.WebControls.Button bEncrypt;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox DecryptedText;
		protected System.Web.UI.WebControls.TextBox EncryptedText;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.DropDownList ddlCipherMode;
		protected System.Web.UI.WebControls.TextBox EncryptionPlainText;
		protected SymmetricEncryption SE;
		protected SymmetricEncryptionConfigurator DESConfig;
		protected SymmetricEncryptionConfigurator RC2Config;
		protected SymmetricEncryptionConfigurator RijndaelConfig;
		protected System.Web.UI.WebControls.Label ErrorLabel;
		protected System.Web.UI.WebControls.Button bReset;
		protected SymmetricEncryptionConfigurator TripleDESConfig;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack) 
			{
				ddlEncryptionAlgorithm.Items.Add(new ListItem("DES (max 64-bit, some known vulnerabilities)", "DES"));
				ddlEncryptionAlgorithm.Items.Add(new ListItem("RC2 (max 128-bit, some known vulnerabilities)", "RC2"));
				ddlEncryptionAlgorithm.Items.Add(new ListItem("Rijndael (max 256-bit, no known vulnerabilities)", "Rijndael"));
				ddlEncryptionAlgorithm.Items.Add(new ListItem("TripleDES (max 192-bit, no known vulnerabilities)", "TripleDES"));

				ddlCipherMode.Items.Add(new ListItem("CBC", "CBC"));
				ddlCipherMode.Items.Add(new ListItem("EBC", "EBC"));
				ddlCipherMode.SelectedValue = "EBC";
			}
			ErrorLabel.Text = "";
		}

		private IVMethod GetIVMethod() 
		{
			IVMethod ret = IVMethod.None;

			if(!UseInitVector.Checked) 
			{
				ret = IVMethod.None;
			}

			if(UseInitVector.Checked) 
			{
				if(VectorType.SelectedValue == "Auto Generated") 
				{
					ret = IVMethod.Auto;
				} 
				else 
				{
					ret = IVMethod.Manual;
				}
			}
			return ret;
		}

		private void bEncrypt_Click(object sender, System.EventArgs e)
		{
			try 
			{
				switch (ddlEncryptionAlgorithm.SelectedValue) 
				{
					case "DES":
						DESConfig = new SymmetricEncryptionConfigurator(SymmetricAlgorithmType.DES, GetIVMethod(), PadKey.Checked);
						SE = new SymmetricEncryption(DESConfig);
						break;
					case "RC2":
						RC2Config = new SymmetricEncryptionConfigurator(SymmetricAlgorithmType.RC2, GetIVMethod(), PadKey.Checked);
						SE = new SymmetricEncryption(RC2Config);
						break;
					case "Rijndael":
						RijndaelConfig = new SymmetricEncryptionConfigurator(SymmetricAlgorithmType.Rijndael, GetIVMethod(), PadKey.Checked);
						SE = new SymmetricEncryption(RijndaelConfig);
						break;
					case "TripleDES":
						TripleDESConfig = new SymmetricEncryptionConfigurator(SymmetricAlgorithmType.TripleDES, GetIVMethod(), PadKey.Checked);
						SE = new SymmetricEncryption(TripleDESConfig);
						break;
					default:
						break;
				}
					
				bool encrypt = true;
				if(!PadKey.Checked) 
				{
					if(!IsPassphraseLengthValid(SE)) 
					{
						encrypt = false;
						this.DisplayPassphraseLengthError(SE);
					}
				}

				if(encrypt)
				{
					if(UseInitVector.Checked && VectorType.SelectedValue == "Manually Entered") 
					{
						EncryptedText.Text = SE.Encrypt(EncryptionPlainText.Text, Passphrase.Text, Vector.Text);
					} 
					else 
					{
						EncryptedText.Text = SE.Encrypt(EncryptionPlainText.Text, Passphrase.Text);
					}
				}

				if(UseInitVector.Checked && VectorType.SelectedValue == "Auto Generated") 
				{
					Vector.Text = Convert.ToBase64String(SE.CryptoService.IV);
				}
			} 
			catch(Exception exc) 
			{
				ErrorLabel.Text = exc.Message;
			}
		}

		private void bDecrypt_Click(object sender, System.EventArgs e)
		{
			try 
			{
				switch (ddlEncryptionAlgorithm.SelectedValue) 
				{
					case "DES":
						DESConfig = new SymmetricEncryptionConfigurator(SymmetricAlgorithmType.DES, GetIVMethod(), PadKey.Checked);
						SE = new SymmetricEncryption(DESConfig);
						break;
					case "RC2":
						RC2Config = new SymmetricEncryptionConfigurator(SymmetricAlgorithmType.RC2, GetIVMethod(), PadKey.Checked);
						SE = new SymmetricEncryption(RC2Config);
						break;
					case "Rijndael":
						RijndaelConfig = new SymmetricEncryptionConfigurator(SymmetricAlgorithmType.Rijndael, GetIVMethod(), PadKey.Checked);
						SE = new SymmetricEncryption(RijndaelConfig);
						break;
					case "TripleDES":
						TripleDESConfig = new SymmetricEncryptionConfigurator(SymmetricAlgorithmType.TripleDES, GetIVMethod(), PadKey.Checked);
						SE = new SymmetricEncryption(TripleDESConfig);
						break;
					default:
						break;
				}
				bool decrypt = true;
								
				if(!PadKey.Checked) 
				{
					if(!IsPassphraseLengthValid(SE)) 
					{
						decrypt = false;
						this.DisplayPassphraseLengthError(SE);
					}
				}

				if(decrypt)
				{
					if(UseInitVector.Checked) 
					{
						DecryptedText.Text = SE.Decrypt(EncryptedText.Text, Passphrase.Text, Vector.Text);
					} 
					else 
					{
						DecryptedText.Text = SE.Decrypt(EncryptedText.Text, Passphrase.Text);
					}
				}
			}
			catch(Exception exc) 
			{
				ErrorLabel.Text = exc.Message;
			}
		} 

		private bool IsPassphraseLengthValid(SymmetricEncryption E)
		{
			bool valid = false;
			int passphraseLenInBits = Passphrase.Text.Length * 8;
			int minSize = E.CryptoService.LegalKeySizes[0].MinSize;
			int maxSize = E.CryptoService.LegalKeySizes[0].MaxSize;
			int increment = E.CryptoService.LegalKeySizes[0].SkipSize;

			if(minSize == maxSize) 
			{
				if(minSize == passphraseLenInBits) 
				{
					valid = true;
				}
			} 
			else 
			{
				for(int i=minSize; i <= maxSize; i = i + increment) 
				{
					if(passphraseLenInBits == i) 
					{
						valid = true;
					}
				}
			}

			return valid;
		}

		private void DisplayPassphraseLengthError(SymmetricEncryption E) 
		{
			bool same = false;
			int minSize = E.CryptoService.LegalKeySizes[0].MinSize;
			int maxSize = E.CryptoService.LegalKeySizes[0].MaxSize;
			int increment = E.CryptoService.LegalKeySizes[0].SkipSize;
			if(minSize == maxSize) 
			{
				same = true;
			}
			string msg = string.Empty;
			if(same) 
			{
				msg = "The key for this algorithm must be " + minSize / 8 + " characters long. The one you entered is " + Passphrase.Text.Length + " character(s). Either correct the passphrase, or check the 'Pad Key' checkbox.";
			} 
			else 
			{
				msg = "The key for this algorithm must be between " + minSize / 8 + " and " + maxSize / 8 + " characters long, in increments of " + increment / 8 + " characters. The one you entered is " + Passphrase.Text.Length + " character(s). Either correct the passphrase, or check the 'Pad Key' checkbox.";
			}
			ErrorLabel.Text = msg;
		}

		private void UseInitVector_CheckedChanged(object sender, System.EventArgs e)
		{
			if(UseInitVector.Checked) 
			{
				VectorType.Enabled = true;
				VectorTypeLabel.Enabled = true;
				ddlCipherMode.SelectedValue = "CBC";
			} 
			else 
			{
				VectorType.Enabled = false;
				VectorTypeLabel.Enabled = false;
				VectorType.SelectedValue = "Auto Generated";
				Vector.Enabled = false;
				VectorLabel.Enabled = false;
				ddlCipherMode.SelectedValue = "EBC";
			}
		}

		private void VectorType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(VectorType.SelectedValue == "Manually Entered") 
			{
				Vector.Enabled = true;
				VectorLabel.Enabled = true;
			} 
			else 
			{
				Vector.Enabled = false;
				VectorLabel.Enabled = false;
			}
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.UseInitVector.CheckedChanged += new System.EventHandler(this.UseInitVector_CheckedChanged);
			this.VectorType.SelectedIndexChanged += new System.EventHandler(this.VectorType_SelectedIndexChanged);
			this.bEncrypt.Click += new System.EventHandler(this.bEncrypt_Click);
			this.bDecrypt.Click += new System.EventHandler(this.bDecrypt_Click);
			this.bReset.Click += new System.EventHandler(this.bReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void bReset_Click(object sender, System.EventArgs e)
		{
			ErrorLabel.Text = string.Empty;
			this.ddlEncryptionAlgorithm.SelectedIndex = 0;
			this.VectorType.SelectedIndex = 0;
			PadKey.Checked = false;
			Passphrase.Text = string.Empty;
			Vector.Text = string.Empty;
			Vector.Enabled = false;
			VectorType.Enabled = false;
			VectorLabel.Enabled = false;
			VectorTypeLabel.Enabled = false;
			UseInitVector.Checked = false;
			this.EncryptionPlainText.Text = string.Empty;
			this.EncryptedText.Text = string.Empty;
			this.DecryptedText.Text = string.Empty;
		
		}
	}
}
