using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominos.WCFService.DTO
{
    public class MediaDTO
    {
        public int Id { get; set; }
        public byte[] FileBinary { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public int FileSize { get; set; }
        public string FileContentType { get; set; }
    }
}