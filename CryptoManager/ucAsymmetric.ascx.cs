namespace CryptoManager
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.IO;
	using System.Xml;
	using Dell.Pgit.Cryptography;

	/// <summary>
	///		Summary description for ucAsymmetric.
	/// </summary>
	public class ucAsymmetric : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Button bUploadKeyFiles;
		protected System.Web.UI.WebControls.Button bDeleteKeyFiles;
		protected System.Web.UI.WebControls.HyperLink PublicKey;
		protected System.Web.UI.WebControls.HyperLink PrivateKey;
		protected System.Web.UI.WebControls.DropDownList ddlAsymmetricAlgorithms;
		protected System.Web.UI.WebControls.Button bAsymmetricDecrypt;
		protected System.Web.UI.WebControls.Button bAsymmetricEncrypt;
		protected System.Web.UI.WebControls.Button bAssignKey;
		protected System.Web.UI.WebControls.TextBox AsymmetricDecrypted;
		protected System.Web.UI.WebControls.TextBox AsymmetricEncrypted;
		protected System.Web.UI.WebControls.TextBox AsymmetricPlainText;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.Label Label23;
		protected System.Web.UI.WebControls.Label Label24;
		protected System.Web.UI.WebControls.DropDownList ddlAsymmetricKeySize;
		protected System.Web.UI.HtmlControls.HtmlInputFile UploadPublicKey;
		protected System.Web.UI.HtmlControls.HtmlInputFile UploadPrivateKey;
		protected string curPath;
		protected string publicKeyFile;
		protected string privateKeyFile;
		protected System.Web.UI.WebControls.Label ErrorLabel;
		protected System.Web.UI.WebControls.Button bReset;
		protected AsymmetricEncryption AE;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack) 
			{
				ddlAsymmetricAlgorithms.Items.Add(new ListItem("RSA", "RSA"));

				for(int i=384; i <= 512; i=i+8) 
				{
					ddlAsymmetricKeySize.Items.Add( new ListItem(i + "-bit", i.ToString()));
				}
			}
			ErrorLabel.Text = "";
			
			curPath = Request.ServerVariables["APPL_PHYSICAL_PATH"];
			privateKeyFile = curPath + "PrivateKey.xml";
			publicKeyFile = curPath + "PublicKey.xml";
			PrivateKey.NavigateUrl = "PrivateKey.xml";
			PublicKey.NavigateUrl = "PublicKey.xml";

			bDeleteKeyFiles.Visible = false;
			if(File.Exists(privateKeyFile)) 
			{
				PrivateKey.Visible = true;
				bDeleteKeyFiles.Visible = true;
			} 
			else 
			{
				PrivateKey.Visible = false;
			}

			if(File.Exists(publicKeyFile)) 
			{
				PublicKey.Visible = true;
				bDeleteKeyFiles.Visible = true;
			} 
			else 
			{
				PublicKey.Visible = false;
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
			this.bAssignKey.Click += new System.EventHandler(this.bAssignKey_Click);
			this.bDeleteKeyFiles.Click += new System.EventHandler(this.bDeleteKeyFiles_Click);
			this.bUploadKeyFiles.Click += new System.EventHandler(this.bUploadKeyFiles_Click);
			this.bAsymmetricEncrypt.Click += new System.EventHandler(this.bAsymmetricEncrypt_Click);
			this.bAsymmetricDecrypt.Click += new System.EventHandler(this.bAsymmetricDecrypt_Click);
			this.bReset.Click += new System.EventHandler(this.bReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void bAssignKey_Click(object sender, System.EventArgs e)
		{
			try 
			{
				XmlDocument publicKey = new XmlDocument();
				XmlDocument privateKey = new XmlDocument();

				switch (this.ddlAsymmetricAlgorithms.SelectedValue) 
				{
					case "RSA":
						AE = new AsymmetricEncryption(AsymmetricAlgorithmType.RSA, Convert.ToInt32(ddlAsymmetricKeySize.SelectedValue));
						break;
					default:
						break;
				}

				privateKey.LoadXml(AE.GetNewKey(AsymmetricKeyType.Private));
				publicKey.LoadXml(AE.GetNewKey(AsymmetricKeyType.Public));

				DeleteKeyFiles();
				privateKey.Save(privateKeyFile);
				publicKey.Save(publicKeyFile);

				PublicKey.Visible = true;
				PrivateKey.Visible = true;
				bDeleteKeyFiles.Visible = true;
			} 
			catch (Exception exc)
			{
				((Label)Parent.FindControl("ErrorLabel")).Text = exc.Message;
			}
		}

		private void bAsymmetricEncrypt_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(PublicKey.Visible) 
				{
					switch (this.ddlAsymmetricAlgorithms.SelectedValue) 
					{
						case "RSA":
							AE = new AsymmetricEncryption(AsymmetricAlgorithmType.RSA, Convert.ToInt32(ddlAsymmetricKeySize.SelectedValue));
							break;
						default:
							break;
					}

					XmlDocument publicKey = new XmlDocument();
					publicKey.Load(publicKeyFile);
					AsymmetricEncrypted.Text = AE.Encrypt(AsymmetricPlainText.Text, publicKey.DocumentElement.OuterXml);
				} 
				else 
				{
					((Label)Parent.FindControl("ErrorLabel")).Text = "You cannot encrypt without a public key file.";
				}
			} 
			catch(Exception exc) 
			{
				((Label)Parent.FindControl("ErrorLabel")).Text = exc.Message;
			}
		}

		private void bAsymmetricDecrypt_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(PrivateKey.Visible) 
				{
					switch (this.ddlAsymmetricAlgorithms.SelectedValue) 
					{
						case "RSA":
							AE = new AsymmetricEncryption(AsymmetricAlgorithmType.RSA, Convert.ToInt32(ddlAsymmetricKeySize.SelectedValue));
							break;
						default:
							break;
					}

					XmlDocument privateKey = new XmlDocument();
					privateKey.Load(privateKeyFile);
					AsymmetricDecrypted.Text = AE.Decrypt(AsymmetricEncrypted.Text, privateKey.DocumentElement.OuterXml);
				} 
				else 
				{
					((Label)Parent.FindControl("ErrorLabel")).Text = "You cannot decrypt without a private key file.";
				}
			} 
			catch(Exception exc) 
			{
				((Label)Parent.FindControl("ErrorLabel")).Text = exc.Message;
			}
		}

		private void bDeleteKeyFiles_Click(object sender, System.EventArgs e)
		{
			DeleteKeyFiles();
			PublicKey.Visible = false;
			PrivateKey.Visible = false;
			bDeleteKeyFiles.Visible = false;
		}

		private void DeleteKeyFiles() 
		{
			File.Delete(publicKeyFile);
			File.Delete(privateKeyFile);
		}

		private void bUploadKeyFiles_Click(object sender, System.EventArgs e)
		{
			if(UploadPublicKey.Value.Length > 0) 
			{
				string ext = Path.GetExtension(UploadPublicKey.Value).ToLower();
				if(ext == ".xml") 
				{
					UploadFile(UploadPublicKey.PostedFile, publicKeyFile);
					PublicKey.Visible = true;
				} 
				else 
				{
					((Label)Parent.FindControl("ErrorLabel")).Text = "You may only upload XML files.";
				}
			}

			if(UploadPrivateKey.Value.Length > 0) 
			{
				string ext = Path.GetExtension(UploadPrivateKey.Value).ToLower();
				if(ext == ".xml") 
				{
					UploadFile(UploadPrivateKey.PostedFile, privateKeyFile);
					PrivateKey.Visible = true;
				} 
				else 
				{
					((Label)Parent.FindControl("ErrorLabel")).Text = "You may only upload XML files.";
				}
			}
		}

		private void UploadFile(System.Web.HttpPostedFile file, string targetFile) 
		{
			if(File.Exists(targetFile)) 
			{
				File.Delete(targetFile);
			}

			// Get size of uploaded file
			int fileLen = file.ContentLength;

			// Allocate a buffer for reading of the file
			byte[] fileData = new byte[fileLen];

			// Read uploaded file from the Stream
			file.InputStream.Read(fileData, 0, fileLen);

			// Create a file
			FileStream newFile = new FileStream(targetFile, FileMode.Create);

			// Write data to the file
			newFile.Write(fileData, 0, fileData.Length);

			// Close file
			newFile.Close();
		}

		private void bReset_Click(object sender, System.EventArgs e)
		{
			ErrorLabel.Text = string.Empty;
			this.ddlAsymmetricAlgorithms.SelectedValue = "RSA";
			this.AsymmetricDecrypted.Text = string.Empty;
			this.AsymmetricEncrypted.Text = string.Empty;
			this.AsymmetricPlainText.Text = string.Empty;		
		}


	}
}
