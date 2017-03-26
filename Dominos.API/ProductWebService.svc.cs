using Dominos.Infrastructure.Service;
using Dominos.WCFService.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Dominos.WCFService
{

    public class ProductWebService : IProductWebService
    {
        private IProductService _productService;
        private IShoppingCartService _shoppingCartService;
        private IMediumService _mediumService;
        private IUserService _userService;

        public ProductWebService(IProductService productService,
            IShoppingCartService shoppingCartService,
            IMediumService mediumService,
            IUserService userService)
        {
            _productService = productService;
            _shoppingCartService = shoppingCartService;
            _mediumService = mediumService;
            _userService = userService;
        }

        public List<ProductDTO> GetProducts()
        {
            var x = _productService.GetProducts()
                .Select(s => new ProductDTO()
                {
                    Id = s.Id,
                    Title = s.Title,
                    Price = s.Price,
                    ImageId = s.ImageId
                }).ToList();
            return x;
        }
        public ProductDTO GetProductById(int id)
        {
            var product = _productService.GetById(id);
            var dto = new ProductDTO()
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                ImageId = product.ImageId,
            };
            return dto;
        }

        public List<ShoppingCartDTO> GetShoppingCartItems(int userId)
        {
            var list = _shoppingCartService.GetShoppingCartItems(userId)
                .Select(s =>
                        new ShoppingCartDTO
                        {
                            Id = s.Id,
                            ProductId = s.ProductId,
                            UserId = s.UserId,
                            Quantity = s.Quantity,
                            ProductPrice = s.Product.Price,
                            ProductTitle = s.Product.Title,
                            ProductImageId = s.Product.ImageId
                        }
                    ).ToList();

            return list;
        }

        public bool AddShoppingCart(int productId, int userId, int quantity)
        {
            return _shoppingCartService.AddShoppingCart(productId, userId, quantity);
        }

        public bool SetShoppingCartQuantity(int productId, int userId, int quantity)
        {
            return _shoppingCartService.SetShoppingCartQuantity(productId, userId, quantity);
        }

        public bool SetShoppingCartQuantityById(int shoppingCartItemId, int quantity)
        {
            return _shoppingCartService.SetShoppingCartQuantity(shoppingCartItemId, quantity);
        }

        public MediaDTO GetProductImageById(int imageId)
        {
            var media = _mediumService.GetById(imageId);
            if (media != null)
            {
                var dto = new MediaDTO()
                {
                    Id = media.Id,
                    FileBinary = media.FileBinary,
                    FileSize = media.FileSize,
                    FileContentType = media.FileContentType,
                    FileExtension = media.FileExtension,
                    FileName = media.FileName
                };
                return dto;
            }
            return null;
        }

        public MediaDTO GetProductImageWithoutBinary(int imageId)
        {
            var media = _mediumService.GetById(imageId);
            if (media != null)
            {
                var dto = new MediaDTO()
                {
                    Id = media.Id,
                    //FileBinary = media.FileBinary,
                    FileSize = media.FileSize,
                    FileContentType = media.FileContentType,
                    FileExtension = media.FileExtension,
                    FileName = media.FileName
                };
                return dto;
            }
            return null;
        }

        public UserDTO Login(string email, string password)
        {
            var user = _userService.Login(email, password);
            if(user != null)
            {
                return new UserDTO()
                {
                    Success = true,
                    UserId = user.Id,
                    Email = user.Email,
                };
            }
            return new UserDTO();
        }
    }
}
