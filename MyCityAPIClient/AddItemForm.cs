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
    public partial class AddItemForm : Form
    {

        static HttpClient client = new HttpClient();

        public class ItemRead
        {
            public string Name { get; set; }
            public float Price { get; set; }
        }

        public class ItemCreate
        {
            public int StoreId { get; set; }
            public string Name { get; set; }
            public float Price { get; set; }
        }


        public AddItemForm()
        {
            InitializeComponent();
        }

        private void AddItemForm_Load(object sender, EventArgs e)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            storeIdLabel.Text += AdminForm.storeId.ToString();
            storeNameLabel.Text += AdminForm.storeName;


            GetItemsByStore(AdminForm.storeId);
        }

        private async void GetItemsByStore(int storeId)
        {
            string url = "http://localhost:57620/api/mycity/storeitems/" + storeId.ToString();

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                itemDataGridView.DataSource = JsonConvert.DeserializeObject<ItemRead[]>(data).ToList();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ItemCreate item = new ItemCreate()
            {
                StoreId = AdminForm.storeId,
                Name = itemNameTextBox.Text,
                Price = float.Parse(itemPriceTextBox.Text)
            };

            AddItem(item);
        }

        private async void AddItem( ItemCreate item )
        {
            string url = "http://localhost:57620/api/mycity/admin/item";

            var serializedItem = JsonConvert.SerializeObject(item);
            var content = new StringContent(serializedItem, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(url, content);

            if (result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                messageLabel.Text = "Store added successfully.";
            }

            GetItemsByStore(AdminForm.storeId);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            itemNameTextBox.Text = "";
            itemPriceTextBox.Text = "";

            messageLabel.Text = "";
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            GetItemsByStore(AdminForm.storeId);
        }
    }
}
