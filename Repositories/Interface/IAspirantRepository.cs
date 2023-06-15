﻿using VoteApp.Models.Entities;
using System.Linq.Expressions;

namespace VoteApp.Repositories.Interface
{
    public interface IAspirantRepository : IBaseRepository<Aspirant>
    {
        Task<Aspirant> Get(int id);
        Task<Aspirant> Get(Expression<Func<Aspirant, bool>> expression);
        Task<ICollection<Aspirant>> GetAll();
    }
}
