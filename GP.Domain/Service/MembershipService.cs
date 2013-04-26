using System;
using System.Collections.Generic;
using CustomFramework.Security.Membership.Model;
using CustomFramework.Security.Membership;
using GP.Domain.Repository;

namespace GP.Domain.Service
{
    public class MembershipService : ICustomMembership
    {
        public User Login(string username, string password)
        {
            return new GenericRepository<User>().Find(u => u.UserName == username && u.Password == password); 
        }

        #region Feature

        public List<Feature> ListFeatures()
        {            
            return new GenericRepository<Feature>().FindAll();            
        }

        public void CreateFeature(Feature model)
        {
            new GenericRepository<Feature>().Create(model); 
        }

        public Feature FindFeatureById(int id)
        {
            return new GenericRepository<Feature>().Find(id);
        }

        public void DeleteFeature(int id)
        {
            new GenericRepository<Feature>().Delete(id);
        }

        public void UpdateFeature(Feature model)
        {
            new GenericRepository<Feature>().Update(model);
        }

        #endregion

        #region User

        public void CreateUser(User user)
        {
            new GenericRepository<User>().Create(user);
        }

        public void UpdateUser(User user)
        {
            new GenericRepository<User>().Update(user);
        }

        public void DeleteUser(User user)
        {
            new GenericRepository<User>().Delete(user);
        }

        public List<User> ListUsers()
        {
            return new GenericRepository<User>().FindAll();    
        }

        public List<User> SearchUsers(string name)
        {
            return new GenericRepository<User>().FindAll(user => user.FirstName.Contains(name) ||
                                                         user.LastName.Contains(name) ||
                                                         user.UserName.Contains(name));
        }

        public User FindUserById(int id)
        {
            return new GenericRepository<User>().Find(id);
        }




        public bool ValidateUser(string userName, string password)
        {
            return this.Login(userName, password) != null;
        }


        public List<Role> ListRoles()
        {
            return new GenericRepository<Role>().FindAll();
        }


        #endregion
    }
}
