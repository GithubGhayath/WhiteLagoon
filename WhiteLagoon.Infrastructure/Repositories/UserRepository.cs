using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WhiteLagoon.Application.Common;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AppDbContext _Context;
        public UserRepository(AppDbContext context) : base(context)
        {
            _Context = context;
        }
        public void Update(User NewUserData)
        {
            var OldUserData = _Context.Users.AsNoTracking().FirstOrDefault(u => u.Id == NewUserData.Id);

            NewUserData.UpdatedAt = DateTime.Now;
            NewUserData.CreatedAt = OldUserData!.CreatedAt;

            if (!string.IsNullOrEmpty(NewUserData.Password))
                NewUserData.Password = BCrypt.Net.BCrypt.HashPassword(NewUserData.Password);
            else
                NewUserData.Password = OldUserData.Password;

            _Context.Entry(NewUserData).State = EntityState.Modified;

            _Context.Users.Update(NewUserData);
        }
        public override void Remove(User entity)
        {
            // Change the remove behavior we don't need to remove the user record from database 
            // we just want to make IsDelete = true

            var UserToDelete  = _Context.Users.FirstOrDefault(u=>u.Id== entity.Id);
            UserToDelete!.IsDeleted = true;
        }

        public override void Add(User entity)
        {
            string HashPassword = BCrypt.Net.BCrypt.HashPassword(entity.Password);
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = null;
            entity.Password = HashPassword;
            _Context.Users.Add(entity);

        }
    }
}
