using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
using SistemaVenta.DAL.Repositorios.Contratos;
using SistemaVenta.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SistemaVenta.DAL.Repositorios
{
    public class GenericRepository<Tmodelo> : IGenericRepository<Tmodelo> where Tmodelo:class
    {

        private readonly DbventaContext _dbcontext;

        public GenericRepository(DbventaContext dbventaContext)
        {
            _dbcontext = dbventaContext;
        }



        //implimentar interface

        public Task<Tmodelo> Obtener(Expression<Func<Tmodelo, bool>> filtro)
        {
            throw new NotImplementedException();
        }
        public Task<Tmodelo> Crear(Tmodelo modelo)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Tmodelo>> Consultar(Expression<Func<Tmodelo, bool>> filtro)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(Tmodelo modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(Tmodelo modelo)
        {
            throw new NotImplementedException();
        }

       
    }
}
