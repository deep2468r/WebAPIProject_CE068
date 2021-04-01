using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyCityAPI.Models;
using MyCityAPI.Dtos;

namespace MyCityAPI.Profiles
{
    public class StoresProfile:Profile
    {

        public StoresProfile()
        {
            CreateMap<Store, StoreReadDto>();
            CreateMap<StoreCreateDto, Store>();
        }

    }
}
