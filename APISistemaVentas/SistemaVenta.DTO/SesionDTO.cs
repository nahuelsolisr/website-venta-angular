using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.DTO
{
    //GUARDA LAS SESION DE DEL USUARIO QUIEN SE HA LOGEADO
    public class SesionDTO
    {
        public int IdUsuario { get; set; }

        public string? NombreCompleto { get; set; }

        public string? Correo { get; set; }

        public string? RolDescripcion { get; set; }
    }
}
