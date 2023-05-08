using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;
using WebApi.Repositories.Interface;

namespace WebApi.Repositories.Repository
{
    public class ApiRepository : IApiRepository
    {
        #region Ctor

        private readonly ApiContext _context;
        public ApiRepository(ApiContext context)
        {
            _context = context;
        }

        #endregion

        #region User

        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }


        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        #endregion

        #region Save

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
