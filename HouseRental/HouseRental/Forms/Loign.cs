using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using HouseRental.Forms;

namespace HouseRental
{
	public partial class Loign : Form
	{
		public Loign()
		{
			InitializeComponent();
		}
		MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=student_housing; password = 1234");

		private void btnLogin_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtUserName.Text))
			{
				txtUserName.Focus();
				MessageBox.Show("Enter your Username", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtUserName.Focus();
				return;
			}
			else if (string.IsNullOrEmpty(txtPassword.Text))
			{
				txtPassword.Focus();
				MessageBox.Show("Enter your password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtPassword.Focus();
				return;
			}

			MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM login WHERE userName ='" + txtUserName.Text.Trim() + "' and password = '" + txtPassword.Text.Trim() + "'  ", conn);

			DataTable dt = new DataTable();
			sda.Fill(dt);

			if (dt.Rows.Count == 1)
			{
				TenantForm tenant = new TenantForm();
				this.Hide();
				tenant.Show();
				//((Form)main).Controls["labe1"].Text = dt.Rows[0][0].ToString();
			}
			else
			{

				MessageBox.Show("Check user name or password");

			}
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
	}
}




