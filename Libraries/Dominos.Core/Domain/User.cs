using Dominos.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominos.Core.Domain
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}




