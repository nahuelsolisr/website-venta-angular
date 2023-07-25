using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.DTO
{
    public class DashBoardDTO
    {
        public int TotalVenta { get; set; }

        public string TotalIngresos { get; set; }

        public List<VentaSemanaDTO>VentaUltimaSemana { get; set; }

    }
}
