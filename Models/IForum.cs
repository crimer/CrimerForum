using CrimerForum.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimerForum.Data
{
    public interface IForum
    {
        Forum GetById(int id);
        IEnumerable<Forum> GetAll();
        IEnumerable<ApplicationUser> GetAllActiveUsers();
        Task Create(Forum forum);
        Task Delete(int forumId);
        Task UpdateTitle(int forumId, string newTitle);
        Task UpdateImage(int forumId, string newUrlImage);
        Task UpdateDescription(int forumId, string newDescription);

    }
}
