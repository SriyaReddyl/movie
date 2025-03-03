// MovieUserService.cs

using MovieManagement.DataDBContext;
using MovieManagement.Model;
using System;
using System.Linq;

namespace MovieManagement.Services
{
    public class UserService
    {
        private readonly MovieDBContext _dbContext;

        public UserService(MovieDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public MovieUser Authenticate(string username, string password)
        {
            var user = _dbContext.MovieUsers.SingleOrDefault(x => x.Username == username && x.Password == password);
            return user;
        }

        public MovieUser Register(string username, string password, string email)
        {
            if (_dbContext.MovieUsers.Any(x => x.Username == username))
                return null;

            var user = new MovieUser
            {
                Id = Guid.NewGuid(),
                Username = username,
                Password = password,
                Email = email
            };

            _dbContext.MovieUsers.Add(user);
            _dbContext.SaveChanges();
            return user;
        }
    }
}
