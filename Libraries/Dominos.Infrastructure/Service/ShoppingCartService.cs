using Dominos.Core.Base;
using Dominos.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominos.Core.Repository;

namespace Dominos.Infrastructure.Service
{
    public class ShoppingCartService : BaseService<ShoppingCart>, IShoppingCartService
    {
        public ShoppingCartService(IRepository<ShoppingCart> baseRepository) : base(baseRepository)
        {
        }

        public bool AddShoppingCart(int productId, int userId, int quantity)
        {
            try
            {
                var cart = BaseRepository.Table.FirstOrDefault(p => p.UserId == userId && p.ProductId == productId);
                if (cart != null)
                {
                    cart.Quantity += quantity;
                    BaseRepository.Update(cart);
                }
                else
                {
                    var newCart = new ShoppingCart();
                    newCart.ProductId = productId;
                    newCart.UserId = userId;
                    newCart.Quantity = quantity;
                    BaseRepository.Insert(newCart);
                }
                return true;
            }
            catch (Exception ex)
            {
                //logger
                return false;
            }

        }
        public bool SetShoppingCartQuantity(int productId, int userId, int quantity)
        {
            try
            {
                var cart = BaseRepository.Table.FirstOrDefault(p => p.UserId == userId && p.ProductId == productId);

                if (cart != null)
                {
                    cart.Quantity = quantity;
                    BaseRepository.Update(cart);
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public bool SetShoppingCartQuantity(int shoppingCartItemId, int quantity)
        {
            try
            {
                var cart = BaseRepository.Table.FirstOrDefault(p => p.Id == shoppingCartItemId);
                if (cart != null)
                {
                    if (quantity != 0)
                    {
                        cart.Quantity = quantity;
                        BaseRepository.Update(cart);
                    }
                    else
                    {
                        BaseRepository.Delete(cart);
                    }
                    return true;
                }

            }
            catch (Exception ex)
            {
            }
            return false;
        }
        public List<ShoppingCart> GetShoppingCartItems(int userId)
        {
            return BaseRepository.Table.Where(p => p.UserId == userId).ToList();
        }
    }



    public interface IShoppingCartService : IBaseService<ShoppingCart>
    {
        bool AddShoppingCart(int productId, int userId, int quantity);
        bool SetShoppingCartQuantity(int productId, int userId, int quantity);
        bool SetShoppingCartQuantity(int shoppingCartItemId, int quantity);

        List<ShoppingCart> GetShoppingCartItems(int userId);
    }
}
