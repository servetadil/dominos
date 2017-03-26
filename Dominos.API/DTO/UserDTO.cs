using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominos.WCFService.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public bool Success
        {
            get; set;
        }
    }
}