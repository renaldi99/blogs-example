using System;
namespace NetDapperExample.Services
{
	public interface IUnitOfWork
	{
		public IUserService UserService { get; }
	}
}

