using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using Dominos.Core.Repository;
using Dominos.Core.Domain;
using Dominos.Core.Base;

namespace Dominos.Infrastructure.Service
{
    public class MediumService : BaseService<Media>, IMediumService
    {

        public MediumService(IRepository<Media> mediaRepository) : base(mediaRepository)
        {
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {

            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }


        public System.Drawing.Image GetImageById(int id)
        {
            var image = BaseRepository.Table.Where(p => p.Id == id).Select(s => s.FileBinary).FirstOrDefault();
            if (image != null)
            {
                return ByteArrayToImage(image);
            }
            return null;
        }





    }

    public partial interface IMediumService : IBaseService<Media>
    {

        byte[] ImageToByteArray(System.Drawing.Image imageIn);

        System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn);

        System.Drawing.Image GetImageById(int id);
        

    }
}
