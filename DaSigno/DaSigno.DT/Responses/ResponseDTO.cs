using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DaSigno.DT.Response
{
    public class ResponseDTO<T>
    {
        public bool Result { get; set; }
        public string Messagge { get; set; }
        public T Value { get; set; }
    }
}
