using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrimerForum.Data;
using CrimerForum.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CrimerForum.Services
{
    public class ApplicationUserService : IApplicationUser
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ApplicationUserService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public ApplicationUser GetById(string id)
        {
            return GetAllUsers().FirstOrDefault(user => user.Id == id);
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _applicationDbContext.ApplicationUsers;
        }

        public async Task SetUserProfileImage(string id, string path)
        {
            var user = GetById(id);
            user.ProfileImage = path;
            _applicationDbContext.Update(user);
            await _applicationDbContext.SaveChangesAsync();
        }

        public Task IncrementUserRating(string id, Type type)
        {
            throw new NotImplementedException();
        }
    }
}