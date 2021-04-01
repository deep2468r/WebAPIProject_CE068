using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MyCityAPIClient
{
    public partial class RegisterForm : Form
    {

        static HttpClient client = new HttpClient();

        public class User
        {
            public string UserId { get; set; }
            public string Password { get; set; }
        }

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                UserId = userIdTextBox.Text,
                Password = passwordTextBox.Text
            };

            RegisterUser(user);
        }

        private async void RegisterUser( User user )
        {
            string url = "http://localhost:57620/api/mycity";

            var serializedUser = JsonConvert.SerializeObject(user);
            var content = new StringContent(serializedUser, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(url, content);

            if( result.StatusCode == System.Net.HttpStatusCode.Created )
            {
                errorLabel.Text = "Account created successfully !!!";
                errorLabel.ForeColor = Color.LimeGreen;
            }
            else if( result.StatusCode == System.Net.HttpStatusCode.Conflict )
            {
                errorLabel.Text = "UserId already exists.";
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            userIdTextBox.Text = "";
            passwordTextBox.Text = "";
            errorLabel.Text = "";
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            lf.Show();
            this.Hide();
        }
    }
}
