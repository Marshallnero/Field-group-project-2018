using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using MySql.Data;

namespace HouseRental.Forms
{
	public partial class TenantForm : Form
	{
		public TenantForm()
		{
			InitializeComponent();
		}
		MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=student_housing; password = 1234");

		private void TenantForm_Load(object sender, EventArgs e)
		{

		}

		private void groupBox2_Enter(object sender, EventArgs e)
		{

		}

		private void groupBox3_Enter(object sender, EventArgs e)
		{

		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			const string message = "Are you sure you would like to exit?";
			const string closing = "Closing Program";
			var result = MessageBox.Show(message, closing, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			//if user chooses yes
			if (result == DialogResult.Yes)
			{
				Application.Exit();
			}
		}
		public static void ClearForm(System.Windows.Forms.Control parent)
		{
			foreach (System.Windows.Forms.Control ctrControl in parent.Controls)
			{
				//Loop through all controls 
				if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.TextBox)))
				{
					//Check to see if it's a textbox 
					((System.Windows.Forms.TextBox)ctrControl).Text = string.Empty;
					//If it is then set the text to String.Empty (empty textbox) 
				}
				else if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.RichTextBox)))
				{
					//If its a RichTextBox clear the text
					((System.Windows.Forms.RichTextBox)ctrControl).Text = string.Empty;
				}
				else if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.ComboBox)))
				{
					//Next check if it's a dropdown list 
					((System.Windows.Forms.ComboBox)ctrControl).SelectedIndex = -1;
					//If it is then set its SelectedIndex to 0 
				}
				else if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.CheckBox)))
				{
					//Next uncheck all checkboxes
					((System.Windows.Forms.CheckBox)ctrControl).Checked = false;
				}
				else if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.RadioButton)))
				{
					//Unselect all RadioButtons
					((System.Windows.Forms.RadioButton)ctrControl).Checked = false;
				}
				else if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.PictureBox)))
				{
					//Unselect all RadioButtons
					((System.Windows.Forms.PictureBox)ctrControl).Image = null;
				}
				if (ctrControl.Controls.Count > 0)
				{
					//Call itself to get all other controls in other containers 
					ClearForm(ctrControl);
				}
			}
		}

		string imgLocation = "";
		MySqlCommand cmd;

		private void btnReset_Click(object sender, EventArgs e)
		{
			ClearForm(this);
		}

		private void btnSubmit_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtFName.Text))
			{
				txtFName.Focus();
				MessageBox.Show("Enter your Username", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtFName.Focus();
				return;
			}
			else if (string.IsNullOrEmpty(txtLastName.Text))
			{
				txtLastName.Focus();
				MessageBox.Show("Enter password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtLastName.Focus();
				return;
			}
			else if (string.IsNullOrEmpty(txtMiddleName.Text))
			{
				txtMiddleName.Focus();
				MessageBox.Show("Enter Last Name", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtMiddleName.Focus();
				return;
			}
			else if (string.IsNullOrEmpty(txtEmail.Text))
			{
				txtEmail.Focus();
				MessageBox.Show("Enter ID", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtEmail.Focus();
				return;
			}
			else if (string.IsNullOrEmpty(txtHomePhone.Text))
			{
				txtHomePhone.Focus();
				MessageBox.Show("Enter Role", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtHomePhone.Focus();
				return;
			}
			else if (string.IsNullOrEmpty(txtPhotoID.Text))
			{
				txtPhotoID.Focus();
				MessageBox.Show("Enter Salary", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtPhotoID.Focus();
				return;
			}
			else if (string.IsNullOrEmpty(txtPresentCity.Text))
			{
				txtPresentCity.Focus();
				MessageBox.Show("Enter Title", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtPresentCity.Focus();
				return;
			}
			else if (string.IsNullOrEmpty(txtPresentMonths.Text))
			{
				txtPresentMonths.Focus();
				MessageBox.Show("Enter TRN", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtPresentMonths.Focus();
				return;
			}
			else if (pictureBox1 == null)
			{
				MessageBox.Show("Add and Image");

			}

			//if (passwordTextBox.Text != confirmPasswordTextBox.Text)
			//{
			//	MessageBox.Show("Password not matching");
			//	confirmPasswordTextBox.Focus();
			//	return;
			//}

			byte[] images = null;
			FileStream Stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
			BinaryReader brs = new BinaryReader(Stream);
			images = brs.ReadBytes((int)Stream.Length);

			conn.Open();

			//DateTime date = employmentDateDateTimePicker.Value;
			//var d = date.ToString("MMMM dd, yyyy");




			string query = "INSERT INTO tenant_table(EMP_ID, EMP_FNAME,EMP_LNAME,EMP_TITLE,EMP_ROLE,EMP_SALARY,EMPLOYMENT_DATE,PASSWORD,EMP_TRN,PHOTO) VALUES('" + idTextBox.Text + "', '" + firstNameTextBox.Text + "', '" + lastNameTextBox.Text + "', '" + titleComboBox.Text + "','" + roleComboBox.Text + "','" + salaryTextBox.Text + "', '" + d + "','" + passwordTextBox.Text + "','" + trnTextBox.Text + "', @images)";

			//string quer = "INSERT INTO login (USERNAME, PASSWORD, role) VALUES ('" + idTextBox.Text + "', '" + passwordTextBox.Text + "', '" + roleComboBox.Text + "')";
			cmd = new MySqlCommand(query, conn);
			//cmd = new MySqlCommand(quer, connect);
			cmd.Parameters.Add(new MySqlParameter("@images", images));
			int N = cmd.ExecuteNonQuery();
			conn.Close();
			MessageBox.Show(N.ToString() + " Data Saved successfully...!");

		}

		private void btnUpload_Click(object sender, EventArgs e)
		{
			// open file dialog   
			OpenFileDialog open = new OpenFileDialog();
			// image filters  
			open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
			if (open.ShowDialog() == DialogResult.OK)
			{
				// display image in picture box  
				imgLocation = open.FileName.ToString();
				//pictureBox1.Image = new Bitmap(open.FileName);
				pictureBox1.ImageLocation = imgLocation;
			}
		}
	}
}
