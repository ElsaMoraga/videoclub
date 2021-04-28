using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videoclub.DAO
{
    public static class ColeccionArticulo
    {
        public static int AgregarPelicula(pelicula p)
        {
            int id = 0;
            pelicula newItem = new pelicula();

            using (videoclubEntities context = new videoclubEntities())
            {
                newItem.CodigoProducto = p.CodigoProducto;
                newItem.Titulo = p.Titulo;
                newItem.Duracion = p.Duracion;
                newItem.AnioCompra = p.AnioCompra;
                newItem.AnioPublicacion = p.AnioPublicacion;
                newItem.Estado = p.Estado;
                newItem.NumeroDvd = p.NumeroDvd;                              

                context.articuloes.Add(newItem);

                context.SaveChanges();

                id = newItem.Id;
            }

            return id;
        }

        public static List<pelicula> TodasPeliculas()
        {
            using (videoclubEntities context = new videoclubEntities())
            {
                return context.articuloes.OfType<pelicula>().ToList();
            }
        }

        public static pelicula ObtenerPeliculaPorID(int id)
        {
            using (videoclubEntities context = new videoclubEntities())
            {
                pelicula item = (from a in context.articuloes.OfType<pelicula>()
                               where a.Id == id
                               select a).FirstOrDefault();
                return item;
            }
        }

        public static List<pelicula> ObtenerPeliculasPorEstado(string estado)
        {
            using (videoclubEntities context = new videoclubEntities())
            {
                var item = (from a in context.articuloes.OfType<pelicula>()
                            where a.Estado == estado
                                 select a).ToList();
                return item;
            }
        }

        public static pelicula BuscarPelicula(string titulo)
        {
            using (videoclubEntities context = new videoclubEntities())
            {
                pelicula item = (from p in context.articuloes.OfType<pelicula>()
                               where p.Titulo.StartsWith(titulo) || p.Titulo.EndsWith(titulo)
                                 select p).FirstOrDefault();
                return item;
            }
        }

        public static bool ActualizarPelicula(pelicula i)
        {
            bool actualizado = true;
            try
            {
                using (videoclubEntities context = new videoclubEntities())
                {
                    pelicula p = context.articuloes.OfType<pelicula>().FirstOrDefault(item => item.Id == i.Id);

                    if (p != null)
                    {
                        p.CodigoProducto = i.CodigoProducto;
                        p.Titulo = i.Titulo;
                        p.Duracion = i.Duracion;
                        p.AnioCompra = i.AnioCompra;
                        p.AnioPublicacion = i.AnioPublicacion;
                        p.Estado = i.Estado;
                        p.NumeroDvd = i.NumeroDvd;

                        context.SaveChanges();
                    }
                }
            }
            catch
            {
                actualizado = false;
            }

            return actualizado;

        }
        public static int AgregarVideojuego(videoJuego p)
        {
            int id = 0;
            videoJuego newItem = new videoJuego();

            using (videoclubEntities context = new videoclubEntities())
            {
                newItem.CodigoProducto = p.CodigoProducto;
                newItem.Titulo = p.Titulo;
                newItem.NumeroDiscos = p.NumeroDiscos;
                newItem.Estado = p.Estado;
                newItem.Plataforma = p.Plataforma;

                context.articuloes.Add(newItem);

                context.SaveChanges();

                id = newItem.Id;
            }

            return id;
        }

        public static bool ActualizarVideojuego(videoJuego i)
        {
            bool actualizado = true;
            try
            {
                using (videoclubEntities context = new videoclubEntities())
                {
                    videoJuego p = context.articuloes.OfType<videoJuego>().FirstOrDefault(item => item.Id == i.Id);

                    if (p != null)
                    {
                        p.CodigoProducto = i.CodigoProducto;
                        p.Titulo = i.Titulo;
                        p.NumeroDiscos = i.NumeroDiscos;
                        p.Estado = i.Estado;
                        p.Plataforma = i.Plataforma;

                        context.SaveChanges();
                    }
                }
            }
            catch
            {
                actualizado = false;
            }

            return actualizado;

        }
        public static videoJuego ObtenerVideojuegoPorID(int id)
        {
            using (videoclubEntities context = new videoclubEntities())
            {
                videoJuego item = (from a in context.articuloes.OfType<videoJuego>()
                                 where a.Id == id
                                 select a).FirstOrDefault();
                return item;
            }
        }

        public static List<videoJuego> TodosVideojuegos()
        {
            using (videoclubEntities context = new videoclubEntities())
            {
                return context.articuloes.OfType<videoJuego>().ToList();
            }
        }

        public static videoJuego BuscarVideojuego(string titulo)
        {
            using (videoclubEntities context = new videoclubEntities())
            {
                videoJuego item = (from p in context.articuloes.OfType<videoJuego>()
                                 where p.Titulo == titulo
                                 select p).FirstOrDefault();
                return item;
            }
        }

        public static articulo BuscarArticulo(string codigoProd, string titulo)
        {
            using (videoclubEntities context = new videoclubEntities())
            {
                articulo item = (from a in context.articuloes
                                 where a.Titulo.StartsWith(codigoProd) || a.Titulo.EndsWith(titulo)
                                 || a.CodigoProducto == codigoProd
                                 select a).FirstOrDefault();
                
                return item;
            }
        }
    }
}
