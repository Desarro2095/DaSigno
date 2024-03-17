using DaSigno.DT.Response;
using DaSigno.DT.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSigno.BM.Users
{
    public interface IBMUser
    {
        ResponseDTO<List<UserDTO>> GetUsers();
        public ResponseDTO<UserDTO> GetUserById(int userId);
        ResponseDTO<List<UserDTO>> GetUserByName(string firstName, string lastName, int pagination);
        ResponseDTO<bool> CreateUser(UserDTO user);
        ResponseDTO<UserDTO> UpdateUser(UserDTO user);
        ResponseDTO<bool> DeleteUser(int userId);
    }
}
