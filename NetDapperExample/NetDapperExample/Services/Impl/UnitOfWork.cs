using System;
namespace NetDapperExample.Services.Impl
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserService UserService { get; set; }

        public UnitOfWork(IUserService userService)
        {
            UserService = userService;
        }
    }
}

