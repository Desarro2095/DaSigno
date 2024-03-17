using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DaSigno.DT.Users
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FisrtLastName { get; set; }
        public string SecondLastName { get; set; }   
        public DateTime DateBorn { get; set; }
        public double Salary { get; set; }
    }
}
