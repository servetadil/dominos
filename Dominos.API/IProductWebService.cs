﻿using Dominos.WCFService.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Dominos.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IProductWebService
    {
        [OperationContract]
        List<ProductDTO> GetProducts();
        [OperationContract]
        ProductDTO GetProductById(int id);
        [OperationContract]
        List<ShoppingCartDTO> GetShoppingCartItems(int userId);
        [OperationContract]
        bool AddShoppingCart(int productId, int userId, int quantity);
        [OperationContract]
        bool SetShoppingCartQuantity(int productId, int userId, int quantity);
        [OperationContract]
        MediaDTO GetProductImageById(int imageId);
        [OperationContract]
        MediaDTO GetProductImageWithoutBinary(int imageId);
    }
}
