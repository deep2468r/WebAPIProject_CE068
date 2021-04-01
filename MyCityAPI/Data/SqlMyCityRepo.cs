using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCityAPI.Models;

namespace MyCityAPI.Data
{
    public class SqlMyCityRepo:IMyCityRepo
    {

        private readonly MyCityContext _context;

        public SqlMyCityRepo( MyCityContext context )
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }


        //.............Users..............//

        public bool AddUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var temp_user = _context.Users.FirstOrDefault(u => u.UserId == user.UserId);

            if(temp_user == null)
            {
                _context.Users.Add(user);
                return true;
            }

            return false;
        }

        public int LogInUser(User user)
        {
            //0 => Succesfull login
            //1 => UserId does not exist
            //2 => Incorrect password

            var checkUser = _context.Users.FirstOrDefault(u => u.UserId == user.UserId);

            if( checkUser == null )
            {
                return 1;
            }
            else if( checkUser.Password.Equals(user.Password) )
            {
                return 0;
            }
            else
            {
                return 2;
            }
        }


        //.............Stores..............//

        public IEnumerable<Store> GetAllStores()
        {
            var storeList = _context.Stores.ToList();

            return storeList;
        }

        public IEnumerable<Store> GetStoreByName( string name )
        {
            name = name.ToLower();

            var storeByName = _context.Stores.Where(s => s.Name.ToLower().Contains(name)).ToList();

            return storeByName;
        }

        public IEnumerable<string> GetAllCategories()
        {
            var categorylist = _context.Stores.GroupBy(s => s.Category).Select(c => c.Key).ToList();

            return categorylist;
        }

        public IEnumerable<Store> GetStoreByCategory( string category )
        {

            var storeByCategory = _context.Stores.Where(s => s.Category.Equals(category)).ToList();

            return storeByCategory;
        }

        public void AddStore( Store store )
        {
            if( store == null )
            {
                throw new ArgumentNullException(nameof(store));
            }

            _context.Stores.Add(store);
        }

        //.............Items..............//

        public IEnumerable<Item> GetItemsByStore( int storeId )
        {
            var itemList = _context.Items.Where(i => i.StoreId == storeId);

            return itemList;
        }

        public void AddItem( Item item )
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _context.Items.Add(item);
        }

        //.............Wishlists..............//

        public IEnumerable<Item> GetItemsOfWishlist( string userId )
        {
            var itemIdList = _context.Wishlists.Where(w => w.UserId.Equals(userId)).Select( i => i.ItemId ).ToList();

            List<Item> itemList = new List<Item>();
            Item temp = new Item();

            foreach( int id in itemIdList )
            {
                temp = _context.Items.FirstOrDefault( i => i.Id == id );

                if( temp != null )
                {
                    itemList.Add(temp);
                }

            }

            return itemList;

        }

        public void AddItemToWishlist( Wishlist wishlist )
        {
            if (wishlist == null)
            {
                throw new ArgumentNullException(nameof(wishlist));
            }

            var checkItem = _context.Wishlists.FirstOrDefault(w => (w.UserId.Equals(wishlist.UserId) && w.ItemId == wishlist.ItemId));

            if( checkItem == null )
            {
                _context.Wishlists.Add(wishlist);
            }
        }

        public void RemoveItemFromWishlist( string userId, int itemId )
        {
            Wishlist itemToRemove = _context.Wishlists.FirstOrDefault(w => (w.UserId.Equals(userId) && w.ItemId == itemId));

            _context.Wishlists.Remove(itemToRemove);
        }

    }
}
