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

namespace Csharp_Login_and_Register
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxPasswordCondirmation_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxFirstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxUsername_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxLastname_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxFirstname_Enter(object sender, EventArgs e)
        {
            String fname = textBoxFirstname.Text;
            if(fname.ToLower().Trim().Equals("first name"))
            {
                textBoxFirstname.Text = "";
                textBoxFirstname.ForeColor = Color.Black;

            }
        }

        private void textBoxFirstname_Leave(object sender, EventArgs e)
        {
            String fname = textBoxFirstname.Text;
            if (fname.ToLower().Trim().Equals("first name") || fname.Trim().Equals(""))
            {
                textBoxFirstname.Text = "First Name";
                textBoxFirstname.ForeColor = Color.Gray;
            }
        }

        private void textBoxLastname_Enter(object sender, EventArgs e)
        {
            String lname = textBoxLastname.Text;
            if (lname.ToLower().Trim().Equals("last name"))
            {
                textBoxLastname.Text = "";
                textBoxLastname.ForeColor = Color.Black;

            }
        }

        private void textBoxLastname_Leave(object sender, EventArgs e)
        {
            String lname = textBoxLastname.Text;
            if (lname.ToLower().Trim().Equals("last name") || lname.Trim().Equals(""))
            {
                textBoxLastname.Text = "Last Name";
                textBoxLastname.ForeColor = Color.Gray;

            }
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            String email = textBoxEmail.Text;
            if (email.ToLower().Trim().Equals("e-mail"))
            {
                textBoxEmail.Text = "";
                textBoxEmail.ForeColor = Color.Black;

            }
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            String email = textBoxEmail.Text;
            if (email.ToLower().Trim().Equals("email") || email.Trim().Equals(""))
            {
                textBoxEmail.Text = "E-mail";
                textBoxEmail.ForeColor = Color.Gray;

            }
        }

        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            String username = textBoxUsername.Text;
            if (username.ToLower().Trim().Equals("username"))
            {
                textBoxUsername.Text = "";
                textBoxUsername.ForeColor = Color.Black;

            }
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            String username = textBoxUsername.Text;
            if (username.ToLower().Trim().Equals("username") || username.Trim().Equals(""))
            {
                textBoxUsername.Text = "Username";
                textBoxUsername.ForeColor = Color.Gray;

            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            String password = textBoxPassword.Text;
            if (password.ToLower().Trim().Equals("password"))
            {
                textBoxPassword.Text = "";
                textBoxPassword.UseSystemPasswordChar = true;
                textBoxPassword.ForeColor = Color.Black;

            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            String password = textBoxPassword.Text;
            if (password.ToLower().Trim().Equals("password") || password.Trim().Equals(""))
            {
                textBoxPassword.Text = "Password";
                textBoxPassword.UseSystemPasswordChar = false;
                textBoxPassword.ForeColor = Color.Gray;

            }
        }

        private void textBoxPasswordCondirmation_Enter(object sender, EventArgs e)
        {
            String passwordConfirm = textBoxPasswordCondirmation.Text;
            if (passwordConfirm.ToLower().Trim().Equals("confirm password"))
            {
                textBoxPasswordCondirmation.Text = "";
                textBoxPasswordCondirmation.UseSystemPasswordChar = true;
                textBoxPasswordCondirmation.ForeColor = Color.Black;

            }
        }

        private void textBoxPasswordCondirmation_Leave(object sender, EventArgs e)
        {
            String passwordConfirm = textBoxPasswordCondirmation.Text;
            if (passwordConfirm.ToLower().Trim().Equals("confirm password") ||
                passwordConfirm.ToLower().Trim().Equals("password") ||
                passwordConfirm.Trim().Equals(""))
            {
                textBoxPasswordCondirmation.Text = "Confirm Password";
                textBoxPasswordCondirmation.UseSystemPasswordChar = false;
                textBoxPasswordCondirmation.ForeColor = Color.Gray;

            }
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            //creating a new user

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users`( `Firstname`, `Lastname`, `email`, `username`, `password`) VALUES (@fn,@ln,@email,@usn,@pass)", db.getConnection());
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = textBoxFirstname.Text;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = textBoxLastname.Text;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = textBoxEmail.Text;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;

            // open the connection
            db.openConnection();

            // check if the textboxes contains the default values 
            if (!checkTextBoxesValues())
            {
            
                // check if the password equal the confirm password
                if (textBoxPassword.Text.Equals(textBoxPasswordCondirmation.Text))
                {
                    // check if this username already exists
                    if (checkUsername())
                    {
                        MessageBox.Show("This Username Already Exists, Select A Different One", "Duplicate Username", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // execute the query
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Your Account Has Been Created", "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("ERROR");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Confirmation Password", "Password Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Enter Your Informations First", "Empty Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }



            // close the connection
            db.closeConnection();

        }

        // check if username already exists
        public bool checkUsername()
        {
            DB db = new DB();
            String username = textBoxUsername.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username`= @usn", db.getConnection());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            // check if this username already exists in database
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
            //check if the fields contains the default value
            public Boolean checkTextBoxesValues()
            {
                String fname = textBoxFirstname.Text;
                String lname = textBoxLastname.Text;
                String email = textBoxEmail.Text;
                String uname = textBoxUsername.Text;
                String pass = textBoxPassword.Text;

                if (fname.ToLower().Trim().Equals("first name") || lname.ToLower().Trim().Equals("last name") ||
                    email.Equals("email address") || uname.ToLower().Trim().Equals("username")
                    || pass.Equals("password"))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        private void labelBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();

        }

        private void labelBack_Enter(object sender, EventArgs e)
        {
            labelBack.ForeColor = Color.Yellow;
        }

        private void labelBack_Leave(object sender, EventArgs e)
        {
            labelBack.ForeColor = Color.White;
        }

        private void labelBack_MouseEnter(object sender, EventArgs e)
        {
            labelBack.ForeColor = Color.Yellow;
        }

        private void labelBack_MouseLeave(object sender, EventArgs e)
        {
            labelBack.ForeColor = Color.White;
        }
    }
    }