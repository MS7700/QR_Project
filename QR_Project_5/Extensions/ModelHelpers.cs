using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using Microsoft.AspNet.Identity;
using System.Security.Principal;
using QR_Project_5.Models;

namespace QR_Project_5.Extensions
{
    public static class ModelHelpers
    {
        
        public static string getNombreCompletoUsuario(IIdentity user)
        {
            string nombre = "";
            DB_QR_PEntities db = new DB_QR_PEntities();
            string userName = user.GetUserId();
            List<Empleado> empleados = db.Empleado.Where(e => e.Id_UserName == userName).ToList<Empleado>();
            if(empleados.Count() > 0)
            {
                Empleado empleado = empleados.First<Empleado>();
                nombre += empleado.Nombre + " " + empleado.Apellido;
                return nombre;
            }
            else
            {
                List<Cliente> clientes = db.Cliente.Where(e => e.Id_UserName == userName).ToList<Cliente>();
                if(clientes.Count() > 0)
                {
                    Cliente cliente = clientes.First<Cliente>();
                    nombre += cliente.Nombre + " " + cliente.Apellido;
                    return nombre;
                }

                
            }
            nombre = userName;

            return nombre;
        }
    }
}