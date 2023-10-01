using System;
using NetDapperExample.Models;
using NetDapperExample.Repositories;

namespace NetDapperExample.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateNewUser(UserModel entity)
        {
            try
            {
                var createUser = await _repository.SaveUserAsync(entity);
                if (createUser == 0)
                {
                    throw new Exception("Error when insert data");
                }

                return createUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> DeleteUserById(int id)
        {
            try
            {
                var deleteUser = await _repository.DeleteUserByIdAsync(id);
                if (deleteUser == 0)
                {
                    throw new Exception("Error when delete data");
                }

                return deleteUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UserModel>> GetAllUser()
        {
            try
            {
                var getAllUser = await _repository.GetAllUserAsync();

                return getAllUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserModel> GetUserById(int id)
        {
            try
            {
                var getUser = await _repository.GetUserByIdAsync(id);

                return getUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> UpdateUser(UserModel entity)
        {
            try
            {
                var updateUser = await _repository.UpdateUserAsync(entity);
                if (updateUser == 0)
                {
                    throw new Exception("Error when update data");
                }

                return updateUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

