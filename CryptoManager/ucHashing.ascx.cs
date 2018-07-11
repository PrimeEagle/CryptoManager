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
	///		Summary description for ucHashing.
	/// </summary>
	public class ucHashing : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.CheckBox PadHashedPlainText;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox HashedText;
		protected System.Web.UI.WebControls.TextBox HashedPlainText;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.DropDownList ddlHashingAlgorithm;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Button bHash;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.CheckBox PadHashKey;
		protected System.Web.UI.WebControls.Label HashKeyLabel;
		protected System.Web.UI.WebControls.TextBox HashKey;
		protected System.Web.UI.WebControls.Label ErrorLabel;
		protected System.Web.UI.WebControls.Button bReset;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox HashSalt;
		protected Dell.Pgit.Cryptography.Hashing H;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack) 
			{
				ddlHashingAlgorithm.Items.Add(new ListItem("MD5 (128-bit, moderate security, medium speed)", "MD5"));
				ddlHashingAlgorithm.Items.Add(new ListItem("SHA1 (160-bit, moderate security, medium speed)", "SHA1"));
				ddlHashingAlgorithm.Items.Add(new ListItem("SHA256 (256-bit, high security, slow)", "SHA256"));
				ddlHashingAlgorithm.Items.Add(new ListItem("SHA384 (384-bit, high security, slow)", "SHA384"));
				ddlHashingAlgorithm.Items.Add(new ListItem("SHA512 (512-bit, extreme security, slow)", "SHA512"));
				ddlHashingAlgorithm.Items.Add(new ListItem("HMACSHA1 (keyed hash, using SHA1)", "HMACSHA1"));
			}
			ErrorLabel.Text = "";
		}

		private void bHash_Click(object sender, System.EventArgs e)
		{
			try
			{
				switch (ddlHashingAlgorithm.SelectedValue) 
				{
					case "MD5":
						H = new Hashing(HashType.MD5);
						break;
					case "SHA1":
						H = new Hashing(HashType.SHA1);
						break;
					case "SHA256":
						H = new Hashing(HashType.SHA256);
						break;
					case "SHA384":
						H = new Hashing(HashType.SHA384);
						break;
					case "SHA512":
						H = new Hashing(HashType.SHA512);
						break;
					case "HMACSHA1":
						H = new Hashing(HashType.HMACSHA1);
						break;
					default:
						break;
				}
				bool hash = true;
				string combinedText = HashedPlainText.Text + HashSalt.Text;

				if(!PadHashedPlainText.Checked) 
				{
					if(combinedText.Length % 4 != 0) 
					{
						ErrorLabel.Text = "The numbers of characters in plain text (plus the optional salt) must be divisible by 4 before it can be hashed. The one you entered has " + combinedText.Length + " character(s). Either change the text, change the salt, or check the 'Pad Text' checkbox.";
						hash = false;
					}
				}

				if(!PadHashKey.Checked) 
				{
					if(HashKey.Text.Length % 4 != 0) 
					{
						ErrorLabel.Text = "The numbers of characters in the hash key text must be divisible by 4 before it can be hashed. The one you entered has " + HashKey.Text.Length + " character(s). Either change the text, or check the 'Pad Key' checkbox.";
						hash = false;
					}
				}

				if(hash) 
				{
					if(this.ddlHashingAlgorithm.SelectedValue == "HMACSHA1") 
					{
						if(HashSalt.Text.Length == 0) 
						{
							HashedText.Text = H.GetHash(HashedPlainText.Text, PadHashedPlainText.Checked, HashKey.Text, PadHashKey.Checked);
						} 
						else 
						{
							HashedText.Text = H.GetHash(HashedPlainText.Text, PadHashedPlainText.Checked, HashKey.Text, PadHashKey.Checked, HashSalt.Text);
						}
					} 
					else 
					{
						if(HashSalt.Text.Length == 0) 
						{
							HashedText.Text = H.GetHash(HashedPlainText.Text, PadHashedPlainText.Checked);
						} 
						else 
						{
							HashedText.Text = H.GetHash(HashedPlainText.Text, PadHashedPlainText.Checked, HashSalt.Text);
						}
					}
				} 
				else 
				{
					
				}
			} 
			catch(Exception exc)
			{
				ErrorLabel.Text = exc.Message;
			}
		}

		private void ddlHashingAlgorithm_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.ddlHashingAlgorithm.SelectedValue == "HMACSHA1") 
			{
				HashKey.Enabled = true;
				HashKeyLabel.Enabled = true;
				PadHashKey.Enabled = true;
			} 
			else 
			{
				HashKey.Enabled = false;
				HashKeyLabel.Enabled = false;
				PadHashKey.Enabled = false;
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
			this.ddlHashingAlgorithm.SelectedIndexChanged += new System.EventHandler(this.ddlHashingAlgorithm_SelectedIndexChanged);
			this.bHash.Click += new System.EventHandler(this.bHash_Click);
			this.bReset.Click += new System.EventHandler(this.bReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void bReset_Click(object sender, System.EventArgs e)
		{
			ErrorLabel.Text = string.Empty;
			this.ddlHashingAlgorithm.SelectedIndex = 0;
			this.HashedPlainText.Text = string.Empty;
			this.HashedText.Text = string.Empty;
		}
	}
}
