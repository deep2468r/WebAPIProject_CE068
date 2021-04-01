using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCityAPI.Models;

namespace MyCityAPI.Data
{
    public interface IMyCityRepo
    {
        bool SaveChanges();

        //Users

        bool AddUser(User user);

        int LogInUser(User user);


        //Stores

        IEnumerable<Store> GetAllStores();

        IEnumerable<Store> GetStoreByName(string name);

        IEnumerable<string> GetAllCategories();

        IEnumerable<Store> GetStoreByCategory(string category);

        void AddStore(Store store);

        //Items

        IEnumerable<Item> GetItemsByStore(int storeId);

        void AddItem(Item item);

        //Wishlists

        IEnumerable<Item> GetItemsOfWishlist(string userId);

        void AddItemToWishlist(Wishlist wishlist);

        void RemoveItemFromWishlist(string userId, int itemId);

        
    }
}
