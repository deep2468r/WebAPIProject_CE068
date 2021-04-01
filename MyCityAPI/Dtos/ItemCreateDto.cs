using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyCityAPI.Dtos
{
    public class ItemCreateDto
    {
        [Required]
        public int StoreId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }

    }
}
