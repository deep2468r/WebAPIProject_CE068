using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyCityAPI.Dtos
{
    public class UserCreateDto
    {

        [Required]
        public string UserId { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
