using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Models.DB
{
    public class AuthPlayer
    {
        [Key]
        public decimal userId { get; set; }
    }
}
