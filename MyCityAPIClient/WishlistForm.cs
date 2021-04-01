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
    public partial class WishlistForm : Form
    {

        static HttpClient client = new HttpClient();

        public class Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Price { get; set; }
        }


        public WishlistForm()
        {
            InitializeComponent();
        }

        private void WishlistForm_Load(object sender, EventArgs e)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            GetItemsOfWishlist(LoginForm.userId);
        }

        private async void GetItemsOfWishlist( string userId )
        {
            string url = "http://localhost:57620/api/mycity/wishlist/" + userId;

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                wishlistDataGridView.DataSource = JsonConvert.DeserializeObject<Item[]>(data).ToList();
            }
        }

        private void wishlistDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if( wishlistDataGridView.Columns[e.ColumnIndex].Name == "Remove" )
            {
                int itemId = Int32.Parse(wishlistDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());

                RemoveItemFromWishlist(LoginForm.userId, itemId);
            }
        }

        private async void RemoveItemFromWishlist( string userId, int itemId )
        {
            string url = "http://localhost:57620/api/mycity/wishlist/" + userId + "?itemId=" + itemId.ToString();

            var result = await client.DeleteAsync(url);

            GetItemsOfWishlist(LoginForm.userId);
        }
    }
}
