using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Models.DB
{
    public class AuthPlayer
    {
        private Guid _id;
        [Key]
        public Guid ID
        {
            get { return _id; }
        }
        public int isUserValid { get; set; }
    }
}
