using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyCityAPI.Models;
using MyCityAPI.Dtos;

namespace MyCityAPI.Profiles
{
    public class ItemsProfile:Profile
    {

        public ItemsProfile()
        {
            CreateMap<Item, ItemReadDto>();
            CreateMap<ItemCreateDto, Item>();
        }

    }
}
