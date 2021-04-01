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
    public partial class AddStoreForm : Form
    {

        static HttpClient client = new HttpClient();


        public class Store
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public string Description { get; set; }
            public string Rating { get; set; }
        }

        public AddStoreForm()
        {
            InitializeComponent();
        }

        private void AddStoreForm_Load(object sender, EventArgs e)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void addStoreButton_Click(object sender, EventArgs e)
        {
            Store store = new Store()
            {
                Name = nameTextBox.Text,
                Category = categoryTextBox.Text,
                Description = descriptionTextBox.Text,
                Rating = ratingTextBox.Text
            };

            AddStore(store);
        }

        private async void AddStore( Store store )
        {
            string url = "http://localhost:57620/api/mycity/admin/store";

            var serializedStore = JsonConvert.SerializeObject(store);
            var content = new StringContent(serializedStore, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(url, content);

            if( result.StatusCode == System.Net.HttpStatusCode.Created )
            {
                messageLabel.Text = "Store added successfully.";
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "";
            categoryTextBox.Text = "";
            descriptionTextBox.Text = "";
            ratingTextBox.Text = "";

            messageLabel.Text = "";
        }
    }
}
