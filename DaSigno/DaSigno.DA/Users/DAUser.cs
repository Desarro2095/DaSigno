using Dapper;
using DaSigno.DA.Resources;
using DaSigno.DT.Users;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSigno.DA.Users
{
    public class DAUser : IDAUser
    {
        private readonly string connectionString;
        private readonly IConfiguration configuration;
        public DAUser(IConfiguration configuration) {
            this.configuration = configuration;
            this.connectionString = GetConnectionString();
        }
        public bool CreateUser(UserDTO user)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                int result = connection.Execute(Resource.CreateUser, user);
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool DeleteUser(int userId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                int result = connection.Execute(Resource.DeleteUser, new { UserId = userId });
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public UserDTO GetUserById(int userId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                UserDTO result = connection.QueryFirst<UserDTO>(Resource.GetUserById, new {UserId = userId });
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        public List<UserDTO> GetUserByName(string firstName, string lastName, int pagination)
        {
            List<UserDTO> users = new List<UserDTO>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                using (var multi = connection.QueryMultiple(string.Format(Resource.GetUserByName, firstName, lastName, pagination)))
                {
                    users = multi.Read<UserDTO>().ToList();
                }
                if (users != null && users.Count > 0)
                {
                    return users;
                }
            }
            return users;
        }

        public List<UserDTO> GetUsers()
        {
            List<UserDTO> users = new List<UserDTO>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                using (var multi = connection.QueryMultiple(Resource.GetUsers))
                {
                    users = multi.Read<UserDTO>().ToList();
                }
                if (users != null && users.Count > 0)
                {
                    return users;
                }
            }
            return users;
        }

        public UserDTO UpdateUser(UserDTO user)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                int result = connection.Execute(Resource.UpdateUser, user);
                if (result > 0)
                {
                    return user;
                }
            }
            return null;
        }

        private string GetConnectionString()
        {
            return this.configuration.GetConnectionString("DaSignoConnection");
        }
    }
}
