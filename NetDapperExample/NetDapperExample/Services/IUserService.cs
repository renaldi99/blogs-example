using System;
using NetDapperExample.Models;

namespace NetDapperExample.Services
{
	public interface IUserService
	{
		Task<int> CreateNewUser(UserModel entity);
		Task<List<UserModel>> GetAllUser();
		Task<UserModel> GetUserById(int id);
		Task<int> DeleteUserById(int id);
		Task<int> UpdateUser(UserModel entity);
    }
}

