using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using SistemaVenta.DAL.DBContext;
using SistemaVenta.DAL.Repositorios.Contratos;
using SistemaVenta.Model;

namespace SistemaVenta.DAL.Repositorios
{
    public class VentaRepository : GenericRepository<Venta>, IVentaRepository
    {
        private readonly DbventaContext _dbventaContext;
        //Constructor de Dbventa
        public VentaRepository(DbventaContext dbventaContext) : base(dbventaContext)
        {
            _dbventaContext = dbventaContext;
        }

        //implementar interfaz de IventaReposirory 
        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta ventaGenerada = new Venta();

            //la logica para generar la venta
            using (var transaction = _dbventaContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (DetalleVenta dv in modelo.DetalleVenta)
                    {
                        // crea una variable producto encontrado, hace una consulta en la tabla producto y encuentra el producto q el id del producto es igual a l de la lista, y devuelve el primero encontrado
                        Producto producto_encontrado = _dbventaContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();

                        //restamos el stock 
                        producto_encontrado.Stock = producto_encontrado.Stock - dv.Cantidad;

                        _dbventaContext.Update(producto_encontrado);
                    }
                    //guardamos de forma asincrona 
                    await _dbventaContext.SaveChangesAsync();

                    //creamos un numero de documento, accedemos a numero documento y devuelve el primero
                    NumeroDocumento correlativo = _dbventaContext.NumeroDocumentos.First();

                    //suma a ultimo numero 1
                    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
                    //actualiza la fecha ahora
                    correlativo.FechaRegistro = DateTime.Now;
                    //guarda
                    await _dbventaContext.SaveChangesAsync();


                    int CantidadDigitos = 4;
                    string ceros = string.Concat(Enumerable.Repeat("0", CantidadDigitos));
                    string numeroVenta = ceros + correlativo.UltimoNumero.ToString();
                    //00001 ahora es asi

                    numeroVenta = numeroVenta.Substring(numeroVenta.Length - CantidadDigitos, CantidadDigitos);

                    modelo.NumeroDocumento = numeroVenta;

                    await _dbventaContext.Venta.AddAsync(modelo);
                    await _dbventaContext.SaveChangesAsync();


                    ventaGenerada = modelo;

                    //esto confirma la transaccion
                    transaction.Commit();

                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }

                return ventaGenerada;
            }
        }
    }
}
