using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaVenta.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
using SistemaVenta.DAL.Repositorios.Contratos;
using SistemaVenta.DAL.Repositorios;
using SistemaVenta.Model;

namespace SistemaVenta.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<DbventaContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            });
            //método proporcionado por ASP.NET Core que permite registrar el contexto de la base de datos para su uso en toda la aplicación. En este caso, se está utilizando el proveedor de base de datos SQL Server mediante UseSqlServer, y se obtiene la cadena de conexión de la configuración de la aplicación con el nombre "cadenaSQL".


            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            // La interfaz IGenericRepository<> representa un repositorio genérico que proporciona operaciones CRUD (Crear, Leer, Actualizar y Eliminar) para entidades de la base de datos. La implementación genérica GenericRepository<> proporciona la lógica para manejar estas operaciones de forma genérica y reutilizable.




            services.AddScoped<IVentaRepository, VentaRepository>();
            //La interfaz IVentaRepository representa un repositorio específico para las operaciones relacionadas con ventas.La implementación VentaRepository contiene la lógica concreta para manejar las operaciones de ventas específicas.

        }
    }
}
