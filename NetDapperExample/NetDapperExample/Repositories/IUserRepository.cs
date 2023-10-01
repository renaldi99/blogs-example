using System;
using NetDapperExample.Models;

namespace NetDapperExample.Repositories
{
	public interface IUserRepository
	{
		Task<int> SaveUserAsync(UserModel entity);
		Task<int> UpdateUserAsync(UserModel entity);
		Task<List<UserModel>> GetAllUserAsync();
        Task<UserModel> GetUserByIdAsync(int id);
        Task<int> DeleteUserByIdAsync(int id);
    }
}

