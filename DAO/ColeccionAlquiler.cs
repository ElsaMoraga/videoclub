using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videoclub.DAO
{
    public static class ColeccionAlquiler
    {
        public static int RealizarAlquiler( int idCliente, int idArticulo, int dias, double totalPagar)
        {
            int idAlquiler = 0;
            // introducir id, idpelicula, dias
            try
            {
                using (videoclubEntities context = new videoclubEntities())
                {
                    var articulo = (from a in context.articuloes
                                    where a.Id == idArticulo
                                    select a).FirstOrDefault();

                    articulo.Estado = "Alquilado";

                    var cliente = (from c in context.clientes
                                   where c.idCliente == idCliente
                                   select c).FirstOrDefault();

                    alquiler newalquiler = new alquiler();
                    newalquiler.articulo = articulo;
                    newalquiler.cliente = cliente;
                    newalquiler.Dias = dias;
                    newalquiler.TotalPagar = totalPagar;
                    newalquiler.Fecha = DateTime.Today;
                    context.alquilers.Add(newalquiler);
                    context.SaveChanges();
                    idAlquiler = newalquiler.idAlquiler;
                }
            }
            catch
            {
                idAlquiler = 0;
            }

            return idAlquiler;
        }

        public static List<alquiler> ListarAlquiler()
        {
            using (videoclubEntities context = new videoclubEntities())
            {
                var alquileres = (from a in context.alquilers.Include("articulo").Include("cliente")
                                  select a).ToList();
                return alquileres;
            }
        }

        public static alquiler DevolverAlquiler(int codigoArticulo)
        {
            using (videoclubEntities context = new videoclubEntities())
            {
                alquiler item = (from a in context.alquilers.Include("articulo").Include("cliente")
                                 where a.articulo.Id == codigoArticulo
                                 select a).FirstOrDefault();

                item.articulo.Estado = "Disponible";
                context.SaveChanges();

                return item;
            }
        }

    }
}
