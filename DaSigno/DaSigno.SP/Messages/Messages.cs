using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSigno.SP.Messages
{
    public static class Messages
    {
        public static string RecordUserSuccseful { get; } = "Se ha registrado el usuario exitosamente";
        public static string RecordUserUnSuccseful { get; } = "No se realizo el registro";
        public static string DeleteUserSuccseful { get; } = "Se ha eliminado el usuario exitosamente";
        public static string DeleteUserUnSuccseful { get; } = "No se realizo la eliminación";

        public static string GetUserSuccseful { get; } = "Se consulto el usuario correctamente";
        public static string GetUsersSuccseful { get; } = "Se consulto los usuarios correctamente";
        public static string GetUserUnSuccseful { get; } = "No se encontraron resultados";

        public static string UpdateUserSuccseful { get; } = "Se ha actualizado el usuario exitosamente";
        public static string UpdateUserUnSuccseful { get; } = "No se realizo la actualización";
        public static string PaginationError { get; } = "La paginación no puede ser menor a cero";
    }
}
