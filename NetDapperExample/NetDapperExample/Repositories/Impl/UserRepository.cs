using System;
using NetDapperExample.Context;
using NetDapperExample.Models;
using Dapper;
using static Dapper.SqlMapper;

namespace NetDapperExample.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _dapperContext;

        public UserRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<int> DeleteUserByIdAsync(int id)
        {
            string query = $"delete from public.mt_user_tbl where id = @id";

            using var connection = _dapperContext.CreateConnection();
            var result = await connection.ExecuteAsync(query, new { id });
            return result;
        }

        public async Task<List<UserModel>> GetAllUserAsync()
        {
            string query = $"select * from public.mt_user_tbl";

            using var connection = _dapperContext.CreateConnection();
            var result = await connection.QueryAsync<UserModel>(query);
            return result.ToList();
        }

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            string query = $"select * from public.mt_user_tbl where id = @id";

            using var connection = _dapperContext.CreateConnection();
            var result = await connection.QueryAsync<UserModel>(query, new { id });
            return result.FirstOrDefault();
        }

        public async Task<int> SaveUserAsync(UserModel entity)
        {
            string query = $"insert into public.mt_user_tbl (fullname, username, password, email, number_phone) values (@fullname, @username, @password, @email, @number_phone)";

            using var connection = _dapperContext.CreateConnection();
            var result = await connection.ExecuteAsync(query, entity);
            return result;
        }

        public async Task<int> UpdateUserAsync(UserModel entity)
        {
            string query = $"update public.mt_user_tbl set (fullname, username, password, email, number_phone) = (@fullname, @username, @password, @email, @number_phone) where id = @id";

            using var connection = _dapperContext.CreateConnection();
            var result = await connection.ExecuteAsync(query, entity);
            return result;
        }
    }
}

