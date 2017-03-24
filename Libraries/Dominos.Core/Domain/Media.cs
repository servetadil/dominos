using Dominos.Core.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominos.Core.Domain
{
    public partial class Media : BaseEntity
    {
        public byte[] FileBinary { get; set; }

        [StringLength(100)]
        public string FileName { get; set; }

        [StringLength(10)]
        public string FileExtension { get; set; }

        public int FileSize { get; set; }

        [StringLength(50)]
        public string FileContentType { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }

    }
}
