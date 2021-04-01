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
    public partial class LoginForm : Form
    {
        public static string userId;

        static HttpClient client = new HttpClient();

        public class User
        {
            public string UserId { get; set; }
            public string Password { get; set; }
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                UserId = userIdTextBox.Text,
                Password = passwordTextBox.Text
            };

            LogInUser(user);
        }

        private async void LogInUser(User user)
        {
            string url = "http://localhost:57620/api/mycity/" + user.UserId;

            var serializedUser = JsonConvert.SerializeObject(user);
            var content = new StringContent(serializedUser, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(url, content);

            if( result.IsSuccessStatusCode )
            {
                userId = user.UserId;

                if( userId.Equals("admin@mycity") )
                {
                    AdminForm af = new AdminForm();
                    af.Show();
                    this.Hide();
                }
                else
                {
                    StoreForm sf = new StoreForm();
                    sf.Show();
                    this.Hide();
                }

            }
            else if( result.StatusCode == System.Net.HttpStatusCode.NotFound )
            {
                errorLabel.Text = "Account does not exist.";
            }
            else if( result.StatusCode == System.Net.HttpStatusCode.Unauthorized )
            {
                errorLabel.Text = "Incorrect Password.";
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            RegisterForm rf = new RegisterForm();
            rf.Show();
            this.Hide();
        }
    }
}
