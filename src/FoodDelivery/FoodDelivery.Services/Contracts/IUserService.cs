using System.Collections.Generic;
using FoodDelivery.Data.Models;

namespace FoodDelivery.Services.Contracts
{
    public interface IUserService
    {
        FoodDeliveryUser GetUserByUsername(string username);
        
        bool AddUserToRole(string username, string role);

        bool RemoveUserFromToRole(string name, string role);
        
        void EditFirstName(FoodDeliveryUser user, string firstName);

        void EditLastName(FoodDeliveryUser user, string lastName);
    }
}
