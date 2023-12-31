﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Linq.Expressions;

namespace SistemaVenta.DAL.Repositorios.Contratos
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro);

        Task<TModel> Crear(TModel modelo);

        Task<bool> Editar(TModel modelo);

        Task<bool> Eliminar(TModel modelo);

        //ojo aca porque antes era 
        //Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro); pero le saque el filtro porque me tiraba error 
        //en  var listaRoles = await _rolRepositorio.Consultar();
        //Task<IQueryable<TModel>> Consultar();
        Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro);
        Task<IQueryable<TModel>> Consultar();


    }
}
