using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyCityAPI.Models
{
    public class Wishlist
    {

        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public int ItemId { get; set; }

    }
}
