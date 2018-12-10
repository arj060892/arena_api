using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Models.DB
{
    public class PlayerDtls
    {
        public string name { get; set; }
        [Key]
        public string email { get; set; }
        public string mobile { get; set; }
    }
}
