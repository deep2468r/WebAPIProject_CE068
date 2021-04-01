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
    public partial class StoreForm : Form
    {
        //public static int storeId = 0;

        public static Store selectedStore;

        static HttpClient client = new HttpClient();


        public class Store
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public string Description { get; set; }
            public string Rating { get; set; }
        }


        public StoreForm()
        {
            InitializeComponent();
        }

        private void StoreForm_Load(object sender, EventArgs e)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            welcomeLabel.Text += LoginForm.userId;

            categoryListBox.Items.Clear();

            categoryListBox.Items.Add("All");

            GetAllCategories();

            GetAllStores();
        }

        private async void GetAllCategories()
        {
            string url = "http://localhost:57620/api/mycity/storescat";

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                var categoryList = JsonConvert.DeserializeObject<string[]>(data).ToList();

                foreach( string s in categoryList )
                {
                    categoryListBox.Items.Add(s);
                }
            }
        }

        private async void GetAllStores()
        {
            string url = "http://localhost:57620/api/mycity";

            var response = await client.GetAsync(url);

            if( response.IsSuccessStatusCode )
            {
                string data = await response.Content.ReadAsStringAsync();

                dataGridView1.DataSource = JsonConvert.DeserializeObject<Store[]>(data).ToList();
            }
        }

        private void storeNameTextBox_TextChanged(object sender, EventArgs e)
        {
            string storeName = storeNameTextBox.Text;
            
            if( storeName == "" )
            {
                GetAllStores();
            }
            else
            {
                GetStoreByName(storeName);
            }
        }

        private async void GetStoreByName( string storeName )
        {
            string url = "http://localhost:57620/api/mycity/stores/" + storeName;

            var response = await client.GetAsync(url);

            if( response.IsSuccessStatusCode )
            {
                string data = await response.Content.ReadAsStringAsync();

                dataGridView1.DataSource = JsonConvert.DeserializeObject<Store[]>(data).ToList();
            }
        }

        private void categoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string storeCategory = categoryListBox.SelectedItem.ToString();

            if( storeCategory.Equals("All") )
            {
                GetAllStores();
            }
            else
            {
                GetStoreByCategory(storeCategory);
            }
        }

        private async void GetStoreByCategory(string storeCategory)
        {
            string url = "http://localhost:57620/api/mycity/storescat/" + storeCategory;

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                dataGridView1.DataSource = JsonConvert.DeserializeObject<Store[]>(data).ToList();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow r = dataGridView1.Rows[e.RowIndex];

            selectedStore = new Store()
            {
                Id = Int32.Parse(r.Cells[0].Value.ToString()),
                Name = r.Cells[1].Value.ToString(),
                Category = r.Cells[2].Value.ToString(),
                Description = r.Cells[3].Value.ToString(),
                Rating = r.Cells[4].Value.ToString()
            };

            ItemsForm itemsForm = new ItemsForm();
            itemsForm.Show();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            selectedStore = null;
            LoginForm.userId = "";

            LoginForm lf = new LoginForm();
            lf.Show();
            this.Hide();
        }

        private void wishlistButton_Click(object sender, EventArgs e)
        {
            WishlistForm wf = new WishlistForm();
            wf.Show();
        }
    }
}
