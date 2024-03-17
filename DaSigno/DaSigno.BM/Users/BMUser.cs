using DaSigno.DA.Users;
using DaSigno.DT.Response;
using DaSigno.DT.Users;
using DaSigno.SP.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSigno.BM.Users
{
    public class BMUser : IBMUser
    {
        private readonly IDAUser dAUser;
        public BMUser(IDAUser dAUser) {
            this.dAUser = dAUser;
        }
        public ResponseDTO<bool> CreateUser(UserDTO user)
        {
            ResponseDTO<bool> responseDTO = new ResponseDTO<bool>();
            if (this.dAUser.CreateUser(user))
            {
                responseDTO.Messagge = Messages.RecordUserSuccseful;
                responseDTO.Result = true; 
            }
            else
            {
                responseDTO.Messagge = Messages.RecordUserUnSuccseful;
                responseDTO.Result = false;
            }
            return responseDTO;
        }

        public ResponseDTO<bool> DeleteUser(int userId)
        {
            ResponseDTO<bool> responseDTO = new ResponseDTO<bool>();
            if (this.dAUser.DeleteUser(userId))
            {
                responseDTO.Messagge = Messages.DeleteUserSuccseful;
                responseDTO.Result = true;
            }
            else
            {
                responseDTO.Messagge = Messages.DeleteUserUnSuccseful;
                responseDTO.Result = false;
            }
            return responseDTO;
        }

        public ResponseDTO<UserDTO> GetUserById(int userId)
        {
            ResponseDTO<UserDTO> responseDTO = new ResponseDTO<UserDTO>();
            responseDTO.Value = this.dAUser.GetUserById(userId);
            if (responseDTO.Value != null)
            {
                responseDTO.Messagge = Messages.GetUserSuccseful;
                responseDTO.Result = true;
            }
            else
            {
                responseDTO.Messagge = Messages.GetUserUnSuccseful;
                responseDTO.Result = false;
            }
            return responseDTO;
        }

        public ResponseDTO<List<UserDTO>> GetUserByName(string firstName, string lastName, int pagination)
        {
            ResponseDTO<List<UserDTO>> responseDTO = new ResponseDTO<List<UserDTO>>();
            if (pagination < 1)
            {
                responseDTO.Messagge = Messages.PaginationError;
                responseDTO.Result = true;
            }
            else
            {
                responseDTO.Value = this.dAUser.GetUserByName(firstName, lastName, pagination);
                if (responseDTO.Value != null && responseDTO.Value.Count > 0)
                {
                    responseDTO.Messagge = Messages.GetUsersSuccseful;
                    responseDTO.Result = true;
                }
                else
                {
                    responseDTO.Messagge = Messages.GetUserUnSuccseful;
                    responseDTO.Result = false;
                }
            }
            return responseDTO;
        }

        public ResponseDTO<List<UserDTO>> GetUsers()
        {
            ResponseDTO<List<UserDTO>> responseDTO = new ResponseDTO<List<UserDTO>>();
            responseDTO.Value = this.dAUser.GetUsers();
            if (responseDTO.Value != null && responseDTO.Value.Count > 0)
            {
                responseDTO.Messagge = Messages.GetUsersSuccseful;
                responseDTO.Result = true;
            }
            else
            {
                responseDTO.Messagge = Messages.GetUserUnSuccseful;
                responseDTO.Result = false;
            }
            return responseDTO;
        }

        public ResponseDTO<UserDTO> UpdateUser(UserDTO user)
        {
            ResponseDTO<UserDTO> responseDTO = new ResponseDTO<UserDTO>();
            responseDTO.Value = this.dAUser.UpdateUser(user);
            if (user != null)
            {
                responseDTO.Messagge = Messages.UpdateUserSuccseful;
                responseDTO.Result = true;
            }
            else
            {
                responseDTO.Messagge = Messages.UpdateUserUnSuccseful;
                responseDTO.Result = false;
            }
            return responseDTO;
        }
    }
}
