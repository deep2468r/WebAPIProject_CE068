using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyCityAPI.Models;
using MyCityAPI.Dtos;

namespace MyCityAPI.Profiles
{
    public class UsersProfile:Profile
    {

        public UsersProfile()
        {
            CreateMap<UserCreateDto, User>();
        }

    }
}
