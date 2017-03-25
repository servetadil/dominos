using Dominos.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominos.Core.Base
{
    public abstract class AdminViewModel : BaseEntity
    {
        public bool IsValid { get; set; }

        public bool HasError
        {
            get
            {
                return !String.IsNullOrEmpty(ErrorMessage);
            }
        }
        public string ErrorMessage { get; set; }
    }
}
