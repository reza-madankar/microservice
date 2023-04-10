using Basket.Api.Entities;

namespace Basket.Api.Repositories
{
    public interface IBasketRepository
    {
        Task<Order> GetUserBasket(string userName);

        Task<Order> UpdateBasket(Order basket);

        Task DeleteBasket(string userName);

    }
}
