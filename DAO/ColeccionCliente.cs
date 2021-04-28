using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace videoclub.DAO
{
    static class ColeccionCliente
    {
        public static int AgregarCliente(cliente c)
        {
            int id = 0;
            cliente newCliente = new cliente();
            using (videoclubEntities context = new videoclubEntities())
            {
                newCliente.Nombre = c.Nombre;
                newCliente.Apellido = c.Apellido;
                newCliente.Direccion = c.Direccion;
                newCliente.NIF = c.NIF;
                newCliente.Telefono1 = c.Telefono1;
                newCliente.Telefono2 = c.Telefono2;
                newCliente.Email = c.Email;
                newCliente.FechaAlta = c.FechaAlta;
                newCliente.Estado = c.Estado;
                newCliente.VIP = c.VIP;

                context.clientes.Add(newCliente);

                context.SaveChanges();

                id = newCliente.idCliente;
            }

            return id;
        }
    
        public static List<cliente> ObtenerClientes()
        {
            using (videoclubEntities context = new videoclubEntities())
            {
                var clientes = (from c in context.clientes
                                select c).ToList();
                return clientes;
            }
        }

        public static bool ActualizarCliente(cliente c)
        {
            bool actualizado = true;
            try
            {
                using (videoclubEntities context = new videoclubEntities())
                {
                    var mycliente = context.clientes.FirstOrDefault(item => item.idCliente == c.idCliente);

                    if (mycliente != null)
                    {
                        mycliente.FechaNacimiento = c.FechaNacimiento;
                        mycliente.Email = c.Email;
                        mycliente.Apellido = c.Apellido;
                        mycliente.Direccion = c.Direccion;
                        mycliente.Estado = c.Estado;
                        mycliente.NIF = c.NIF;
                        mycliente.Nombre = c.Nombre;
                        mycliente.Telefono1 = c.Telefono1;
                        mycliente.Telefono2 = c.Telefono2;
                        
                        context.SaveChanges();
                    }
                }
            } catch
            {
                actualizado = false;
            }
                
            return actualizado;    
        }
        
        public static cliente ObtenerClientesPorID(int id)
        {
            using (videoclubEntities context = new videoclubEntities())
            {
                var cliente = (from c in context.clientes
                               where c.idCliente == id
                               select c).FirstOrDefault();
                return cliente;
            }
        }

        public static cliente BuscarCliente(string NIF)
        {
            using (videoclubEntities context = new videoclubEntities())
            {
                var cliente = (from c in context.clientes
                               where c.NIF == NIF
                               select c).FirstOrDefault();
                return cliente;
            }
        }

        public static bool ActualizarPorcentajeDescuento()
        {
            bool ok = true;

            using (videoclubEntities context = new videoclubEntities())
            {
                List<cliente> clientes = (from c in context.clientes
                                          where c.VIP == true
                                          select c).ToList();
                foreach (var client in clientes)
                {
                    int alquileres = (from a in context.alquilers
                                      where a.cliente.idCliente == client.idCliente
                                      select a
                                      ).Count();
                    decimal descuento=0.1M;

                    if(alquileres >= 5 && alquileres <= 9)
                    {
                        descuento = 0.10M;
                    }
                    else if(alquileres >= 10 && alquileres <= 14)
                    {
                        descuento = 0.10M;
                    }
                    else if (alquileres >= 15 && alquileres <= 19)
                    {
                        descuento = 0.15M;
                    }
                    else if (alquileres >= 20 && alquileres <= 29)
                    {
                        descuento = 0.25M;
                    }
                    else if (alquileres >= 30)
                    {
                        descuento = 0.5M;
                    }
                    client.Descuento = descuento;
                    context.SaveChanges();
                }
            }

            return ok;
        }

        public static bool ActualizarStatusCliente()
        {
            bool ok = true;
            using (videoclubEntities context = new videoclubEntities())
            {
                List<cliente> clientes = (from c in context.clientes
                                          join alq in context.alquilers on c.idCliente equals alq.cliente.idCliente
                                          select c).ToList();
                foreach (var client in clientes)
                {
                    int alquileres = (from a in context.alquilers
                                      where a.cliente.idCliente == client.idCliente
                                      select a
                                      ).Count();

                    if (alquileres >= 1 && ((DateTime.Today - (DateTime)client.FechaAlta).TotalDays >= 1))
                    {
                        client.VIP = true;
                        context.SaveChanges();
                    }
                }
            }

            return ok;
        }
    }
}
