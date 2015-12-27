using System;
using System.Collections.Generic;
using System.Linq;
using Komsky.Data.DataAccess.Repositories;
using Komsky.Data.Entities;

namespace Komsky.Fakes
{
    public class FakeApplicationUserRepository : IApplicationUserRepository
    {
        public IQueryable<ApplicationUser> GetAll()
        {
            return GetFakeUsers();
        }

        private IQueryable<ApplicationUser> GetFakeUsers()
        {
            List<ApplicationUser> fakseUsers = new List<ApplicationUser>();
            for (int i = 0; i < 5; i++)
            {
                fakseUsers.Add(GetFakeUser());
            }
            return fakseUsers.AsQueryable();
        }

        public ApplicationUser GetById(int id)
        {
            return GetFakeUser();
        }

        public static ApplicationUser GetFakeUser()
        {
            return GetFakeUser(Guid.NewGuid());
        }

        public static ApplicationUser GetFakeUser(Guid id)
        {
            ApplicationUser fakeUser = new ApplicationUser
            {
                Email = "fake@email.com",
                UserName = "fake@email.com",
                Id = Guid.NewGuid().ToString(),
            };
            return fakeUser;
        }

        public ApplicationUser GetById(Guid id)
        {
            return GetFakeUser();
        }

        public ApplicationUser GetById(string id)
        {
            return GetFakeUser();
        }

        public void Delete(int id)
        {

        }

        public void Delete(Guid id)
        {

        }

        public void Delete(string id)
        {

        }

        public ApplicationUser GetByEmail(string email)
        {
            return GetFakeUser();
        }

        public void Delete(ApplicationUser entity)
        {

        }

        public void Update(ApplicationUser entity)
        {

        }

        public void Add(ApplicationUser entity)
        {

        }
    }
}
