using WebApi.Models;

namespace WebApi.Repositories.Interface
{
    public interface IApiRepository
    {
        #region User

        void AddUser(User user);
        void DeleteUser(User user);
        Task<User> GetUserById(int id);
        Task<List<User>> GetAllUsers();

        #endregion

        #region Save

        Task SaveChange();

        #endregion
    }
}
