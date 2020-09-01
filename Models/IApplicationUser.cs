using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CrimerForum.Data.Models;

namespace CrimerForum.Data
{
    public interface IApplicationUser
    {
        ApplicationUser GetById(string id);
        IEnumerable<ApplicationUser> GetAllUsers();
        Task SetUserProfileImage(string id, string path);
        Task IncrementUserRating(string id, Type type);
    }
}