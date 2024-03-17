using DaSigno.DT.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSigno.DA.Users
{
    public interface IDAUser
    {
        List<UserDTO> GetUsers();
        UserDTO GetUserById(int userId);
        List<UserDTO> GetUserByName(string firstName, string lastName, int pagination);
        bool CreateUser(UserDTO user);
        UserDTO UpdateUser(UserDTO user);
        bool DeleteUser(int userId);
    }
}
