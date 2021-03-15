using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QR_Project_5.Models
{
    [MetadataType(typeof(ClienteMetadata))]
    public partial class Cliente
    {

    }

    [MetadataType(typeof(DepartamentoMetadata))]
    public partial class Departamento
    {

    }
    [MetadataType(typeof(DireccionMetadata))]
    public partial class Direccion
    {

    }

    [MetadataType(typeof(EmpleadoMetadata))]
    public partial class Empleado
    {
        public string NombreApellido
        {
            get
            {
                return Nombre + " " + Apellido;
            }
        }
    }

    [MetadataType(typeof(Estado_ClienteMetadata))]
    public partial class Estado_Cliente
    {

    }

    [MetadataType(typeof(Estado_QRMetadata))]
    public partial class Estado_QR
    {
        public const string ABIERTO = "Abierto";
        public const string REABIERTO_DISCONFORMIDAD = "Reabierto por inconformidad";
        public const string REDIRIGIDO_DEPARTAMENTO = "Redirigido a departamento";
        public const string REDIRIGIDO_SUCURSAL = "Redirigido a sucursal";
        public const string REDIRIGIDO_EMPLEADO = "Redirigido a empleado";
        public const string PENDIENTE_VALORACION = "Pendiente valoración";
        public const string CERRADO = "Cerrado";

        public static Estado_QR GetEstadoByDescripcion(string descripcion)
        {
            DB_QR_PEntities db = new DB_QR_PEntities();
            return db.Estado_QR.Where(e => e.Descripcion == descripcion).FirstOrDefault<Estado_QR>();
        }
        public static int? GetIdByDescripcion(string descripcion)
        {
            DB_QR_PEntities db = new DB_QR_PEntities();
            return db.Estado_QR.Where(e => e.Descripcion == descripcion).FirstOrDefault<Estado_QR>().ID_Estado_QR;
        }
    }

    [MetadataType(typeof(Estado_TransaccionMetadata))]
    public partial class Estado_Transaccion
    {

    }

    [MetadataType(typeof(PaisMetadata))]
    public partial class Pais
    {

    }

    [MetadataType(typeof(ProductoMetadata))]
    public partial class Producto
    {

    }

    [MetadataType(typeof(QuejaMetadata))]
    public partial class Queja
    {

    }

    [MetadataType(typeof(ReclamacionMetadata))]
    public partial class Reclamacion
    {

    }

    [MetadataType(typeof(Rel_Transaccion_ProductoMetadata))]
    public partial class Rel_Transaccion_Producto
    {

    }

    [MetadataType(typeof(Respuesta_ClienteMetadata))]
    public partial class Respuesta_Cliente : IRespuesta
    {

    }

    [MetadataType(typeof(Respuesta_EmpleadoMetadata))]
    public partial class Respuesta_Empleado : IRespuesta
    {

    }

    [MetadataType(typeof(SucursalMetadata))]
    public partial class Sucursal
    {

    }

    [MetadataType(typeof(Tipo_IdentificacionMetadata))]
    public partial class Tipo_Identificacion
    {

    }

    [MetadataType(typeof(Tipo_ProductoMetadata))]
    public partial class Tipo_Producto
    {

    }

    [MetadataType(typeof(Tipo_QuejaMetadata))]
    public partial class Tipo_Queja
    {

    }

    [MetadataType(typeof(Tipo_ReclamacionMetadata))]
    public partial class Tipo_Reclamacion
    {

    }

    [MetadataType(typeof(TransaccionMetadata))]
    public partial class Transaccion
    {

    }

}