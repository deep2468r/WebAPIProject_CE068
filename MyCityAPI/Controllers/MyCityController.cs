using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCityAPI.Models;
using MyCityAPI.Data;
using MyCityAPI.Dtos;
using AutoMapper;
using System.Net.Http;

namespace MyCityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyCityController : ControllerBase
    {

        private readonly IMyCityRepo _repository;
        private readonly IMapper _mapper;

        public MyCityController(IMyCityRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        //.............Users..............//

        //POST api/mycity
        [HttpPost]
        public ActionResult CreateUser(UserCreateDto userCreateDto)
        {
            var userModel = _mapper.Map<User>(userCreateDto);

            bool ans = _repository.AddUser(userModel);

            if (ans)
            {
                _repository.SaveChanges();

                return Created("Success", userModel);
            }

            return Conflict("UserId already exists");
        }

        //POST api/mycity/deep2468r
        [HttpPost("{userId}")]
        public ActionResult LogInUser( string userId, UserCreateDto userCreateDto )
        {
            var userModel = _mapper.Map<User>(userCreateDto);

            int ans = _repository.LogInUser(userModel);

            if( ans == 0 )
            {
                return Ok("Success");
            }
            else if( ans == 1 )
            {
                return NotFound("Account does not exist");
            }

            return Unauthorized("Incorrect password");

        }


        //.............Stores..............//

        //GET api/mycity
        [HttpGet()]
        public ActionResult<IEnumerable<Store>> GetAllStores()
        {
            var storeList = _repository.GetAllStores();

            return Ok(_mapper.Map<IEnumerable<StoreReadDto>>(storeList));
        }

        //GET api/mycity/stores/store_name
        [HttpGet("stores/{name}")]
        public ActionResult<IEnumerable<Store>> GetStoreByName( string name )
        {
            var storeList = _repository.GetStoreByName(name);

            return Ok(_mapper.Map<IEnumerable<StoreReadDto>>(storeList));
        }

        //GET api/mycity/storescat
        [HttpGet("storescat")]
        public ActionResult<IEnumerable<string>> GetAllCategories()
        {
            var categoryList = _repository.GetAllCategories();

            return Ok(categoryList);
        }

        //GET api/mycity/storescat/category
        [HttpGet("storescat/{category}")]
        public ActionResult<IEnumerable<Store>> GetStoreByCategory( string category )
        {
            var storeList = _repository.GetStoreByCategory(category);

            return Ok(_mapper.Map<IEnumerable<StoreReadDto>>(storeList));
        }

        //Admin
        //POST api/mycity/admin/store
        [HttpPost("admin/store")]
        public ActionResult AddStore( StoreCreateDto storeCreateDto )
        {
            var storeModel = _mapper.Map<Store>(storeCreateDto);

            _repository.AddStore(storeModel);
            _repository.SaveChanges();

            return Created("Success", storeModel);
        }


        //.............Items..............//

        //GET api/mycity/storeitems/store_name
        [HttpGet("storeitems/{storeId}")]
        public ActionResult<IEnumerable<Item>> GetItemsByStore(int storeId)
        {
            var itemList = _repository.GetItemsByStore(storeId);

            return Ok(_mapper.Map<IEnumerable<ItemReadDto>>(itemList));
        }

        //Admin
        //POST api/mycity/admin/item
        [HttpPost("admin/item")]
        public ActionResult AddItem( ItemCreateDto itemCreateDto )
        {
            var itemModel = _mapper.Map<Item>(itemCreateDto);

            _repository.AddItem(itemModel);
            _repository.SaveChanges();

            return Created("Success", itemModel);
        }


        //.............Wishlists..............//

        //GET api/mycity/wishlist/deep2468r
        [HttpGet("wishlist/{userid}")]
        public ActionResult<IEnumerable<Item>> GetItemsOfWishlist( string userId )
        {
            var itemList = _repository.GetItemsOfWishlist(userId);

            return Ok(_mapper.Map<IEnumerable<ItemReadDto>>(itemList));
        }

        //POST api/mycity/wishlist/deep2468r?itemId=9
        [HttpPost("wishlist")]
        public ActionResult AddItemToWishlist(WishlistCreateDto wishlistCreateDto)
        {
            var wishlistModel = _mapper.Map<Wishlist>(wishlistCreateDto);

            _repository.AddItemToWishlist(wishlistModel);
            _repository.SaveChanges();

            return Created("Success", wishlistModel);
        }

        //DELETE api/mycity/wishlist/deep2468r?itemId=9
        [HttpDelete("wishlist/{userId}")]
        public ActionResult RemoveItemFromWishlist( [FromRoute]string userId, [FromQuery]int itemId )
        {
            _repository.RemoveItemFromWishlist(userId, itemId);
            _repository.SaveChanges();

            return Ok();
        }


    }
}
