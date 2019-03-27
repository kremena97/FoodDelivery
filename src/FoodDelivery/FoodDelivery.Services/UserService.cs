using FoodDelivery.Data;
using FoodDelivery.Data.Models;
using FoodDelivery.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace FoodDelivery.Services
{
    public class UserService:IUserService
    {
        private readonly UserManager<FoodDeliveryUser> _userManager;
        private readonly FoodDeliveryContext _db;

        public UserService(FoodDeliveryContext db,
            UserManager<FoodDeliveryUser> userManager)
        {
            this._userManager = userManager;
            this._db = db;
        }

        public FoodDeliveryUser GetUserByUsername(string username)
        {
            return this._userManager.FindByNameAsync(username).GetAwaiter().GetResult();
        }

        public bool AddUserToRole(string username, string role)
        {
            var user = GetUserByUsername(username);
            if (user == null)
            {
                return false;
            }

            this._userManager.AddToRoleAsync(user, role).GetAwaiter().GetResult();
            return true;
        }

        public bool RemoveUserFromToRole(string name, string role)
        {
            var user = GetUserByUsername(name);
            if (user == null)
            {
                return false;
            }

            this._userManager.RemoveFromRoleAsync(user, role).GetAwaiter().GetResult();
            return true;
        }

        public void EditFirstName(FoodDeliveryUser user, string firstName)
        {
            if (user == null)
            {
                return;
            }

            user.FirstName = firstName;
            this._db.SaveChanges();
        }

        public void EditLastName(FoodDeliveryUser user, string lastName)
        {
            if (user == null)
            {
                return;
            }

            user.LastName = lastName;
            this._db.SaveChanges();
        }
    }
}
