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
    public partial class ItemsForm : Form
    {

        static HttpClient client = new HttpClient();


        public class Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public float Price { get; set; }
        }

        public class Wishlist
        {
            public string UserId { get; set; }
            public int ItemId { get; set; }
        }


        public ItemsForm()
        {
            InitializeComponent();
        }

        private void ItemsForm_Load(object sender, EventArgs e)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            storeNameLabel.Text = StoreForm.selectedStore.Name;
            categoryLabel.Text += StoreForm.selectedStore.Category;
            descriptionLabel.Text += StoreForm.selectedStore.Description;
            ratingLabel.Text += StoreForm.selectedStore.Rating;

            int storeId = StoreForm.selectedStore.Id;

            GetItemsByStore(storeId);
        }

        private async void GetItemsByStore( int storeId )
        {
            string url = "http://localhost:57620/api/mycity/storeitems/" + storeId.ToString();

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                itemsDataGridView.DataSource = JsonConvert.DeserializeObject<Item[]>(data).ToList();
            }
        }

        private void itemsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if( itemsDataGridView.Columns[e.ColumnIndex].Name == "Add" )
            {
                int itemId = Int32.Parse(itemsDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());

                Wishlist wishlist = new Wishlist()
                {
                    UserId = LoginForm.userId,
                    ItemId = itemId
                };

                AddItemToWishlist(wishlist);
            }
        }

        private async void AddItemToWishlist( Wishlist wishlist )
        {

            string url = "http://localhost:57620/api/mycity/wishlist";

            var serializedWishlist = JsonConvert.SerializeObject(wishlist);
            var content = new StringContent(serializedWishlist, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(url, content);

        }
    }
}
