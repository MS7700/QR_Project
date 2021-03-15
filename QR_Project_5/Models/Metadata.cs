using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QR_Project_5.Models
{
    [DisplayColumn("Identificacion")]
    [DisplayName("Cliente")]
    public class ClienteMetadata
    {
        [Display(Name = "Cliente")]
        public int ID_Cliente { get; set; }
        [Display(Name = "Tipo de identificación")]
        public Nullable<int> Id_Tipo_Identificacion { get; set; }
        
        [MinLength(11, ErrorMessage = "Identificación inválida")]
        [MaxLength(11, ErrorMessage = "Identificación inválida")]
        [Display(Name = "No. Identificación")]
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Display(Name = "Estado del cliente")]
        public Nullable<int> Id_Estado_Cliente { get; set; }
        [Display(Name = "Dirección")]
        public Nullable<int> Id_Direccion { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de ingreso")]
        public Nullable<System.DateTime> Fecha_Ingreso { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [StringLength(10,ErrorMessage = "Teléfono inválido", MinimumLength = 10)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        [Display(Name = "Email")]
        public string Id_UserName { get; set; }


        [Display(Name = "Email")]
        public virtual AspNetUsers AspNetUsers { get; set; }
        [Display(Name = "Dirección")]
        public virtual Direccion Direccion { get; set; }
        [Display(Name = "Estado del cliente")]
        public virtual Estado_Cliente Estado_Cliente { get; set; }
        [Display(Name = "Tipo de identificación")]
        public virtual Tipo_Identificacion Tipo_Identificacion { get; set; }
    }

    [DisplayName("Departamento")]
    public class DepartamentoMetadata
    {
        [Display(Name = "Departamento")]
        public int ID_Departamento { get; set; }
        [Display(Name = "Departamento")]
        public string Nombre { get; set; }
        [Display(Name = "Representante")]
        public Nullable<int> Id_Empleado_Representante { get; set; }
        [Display(Name = "Representante")]
        public virtual Empleado Empleado { get; set; }
    }

    [DisplayColumn("Id_Direccion")]
    [DisplayName("Dirección")]
    public class DireccionMetadata
    {
        [Display(Name = "Dirección")]
        public int Id_Direccion { get; set; }
        public string Provincia { get; set; }
        public string Sector { get; set; }
        public string Municipio { get; set; }
        public string Barrio { get; set; }
        [Display(Name = "Dirección 1")]
        public string Direccion_1 { get; set; }
        [Display(Name = "Dirección 2")]
        public string Direccion_2 { get; set; }
        [Display(Name = "País")]
        public Nullable<int> Id_Pais { get; set; }
        [Display(Name = "País")]
        public virtual Pais Pais { get; set; }
    }

    [DisplayColumn("Identificacion")]
    [DisplayName("Empleado")]
    public class EmpleadoMetadata
    {
        public int ID_Empleado { get; set; }
        [Display(Name = "Tipo de identificación")]
        public Nullable<int> Id_Tipo_Identificacion { get; set; }
        [Display(Name = "No. Identificación")]
        [MinLength(11, ErrorMessage = "Identificación inválida")]
        [MaxLength(11, ErrorMessage = "Identificación inválida")]
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Display(Name = "Estado del empleado")]
        public Nullable<int> Id_Estado_Cliente { get; set; }
        [Display(Name = "Dirección")]
        public Nullable<int> Id_Direccion { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de ingreso")]
        public Nullable<System.DateTime> Fecha_Ingreso { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [StringLength(10, ErrorMessage = "Teléfono inválido", MinimumLength = 10)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        [Display(Name = "Email")]
        public string Id_UserName { get; set; }
        [Display(Name = "Sucursal")]
        public Nullable<int> Id_Sucursal { get; set; }
        [Display(Name = "Departamento")]
        public Nullable<int> ID_Departamento { get; set; }
        [Display(Name = "Email")]
        public virtual AspNetUsers AspNetUsers { get; set; }
        [Display(Name = "Departamento")]
        public virtual Departamento Departamento1 { get; set; }
        [Display(Name = "Dirección")]
        public virtual Direccion Direccion { get; set; }
        [Display(Name = "Estado del empleado")]
        public virtual Estado_Cliente Estado_Cliente { get; set; }
        [Display(Name = "Sucursal")]
        public virtual Sucursal Sucursal { get; set; }
        [Display(Name = "Tipo de identificación")]
        public virtual Tipo_Identificacion Tipo_Identificacion { get; set; }
        
    }

    [DisplayName("Estado del cliente")]
    public class Estado_ClienteMetadata
    {
        [Display(Name = "Estado del cliente")]
        public int Id_Estado_Cliente { get; set; }
        [Display(Name = "Estado del cliente")]
        public string Descripcion { get; set; }
    }

    [DisplayName("Estado")]
    public class Estado_QRMetadata
    {
        [Display(Name = "Estado")]
        public int ID_Estado_QR { get; set; }
        [Display(Name = "Estado")]
        public string Descripcion { get; set; }
    }

    [DisplayName("Estado de transacción")]
    public class Estado_TransaccionMetadata
    {
        [Display(Name = "Estado de transacción")]
        public int ID_Estado_Transaccion { get; set; }
        [Display(Name = "Estado de transacción")]
        public string Descripcion { get; set; }
    }

    [DisplayName("País")]
    public class PaisMetadata
    {
        [Display(Name = "País")]
        public int Id_Pais { get; set; }
        [Display(Name = "País")]
        public string Nombre_Pais { get; set; }
    }
    [DisplayName("Producto")]
    public class ProductoMetadata
    {
        [Display(Name = "Producto")]
        public int ID_Producto { get; set; }
        [Display(Name = "Nombre del producto")]
        public string Nombre { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Precio")]
        public Nullable<decimal> Monto { get; set; }
        [Display(Name = "Tipo de producto")]
        public Nullable<int> ID_Tipo_Producto { get; set; }
        [Display(Name = "Tipo de producto")]
        public virtual Tipo_Producto Tipo_Producto { get; set; }
    }

    [DisplayColumn("ID_Queja")]
    [DisplayName("Queja")]
    public class QuejaMetadata
    {
        [Display(Name = "Queja")]
        public int ID_Queja { get; set; }
        [Display(Name = "Cliente")]
        public Nullable<int> ID_Cliente { get; set; }
        [Display(Name = "Redactor de la queja")]
        public string Id_UserName { get; set; }
        [Display(Name = "Empleado")]
        public Nullable<int> Id_Empleado { get; set; }
        [Display(Name = "Departamento")]
        public Nullable<int> ID_Departamento { get; set; }
        [Display(Name = "Tipo de queja")]
        public Nullable<int> ID_Tipo_Queja { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public Nullable<System.DateTime> Fecha { get; set; }
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        [Display(Name = "Hora")]
        public Nullable<System.TimeSpan> Hora { get; set; }
        [Display(Name = "Sucursal")]
        public Nullable<int> ID_Sucursal { get; set; }
        [Display(Name = "Sucursal")]
        public virtual Sucursal Sucursal { get; set; }
        [Display(Name = "Estado de queja")]
        public Nullable<int> ID_Estado_QR { get; set; }
        [DataType(DataType.MultilineText)]
        public string Comentario { get; set; }

        [Display(Name = "Redactor de la queja")]
        public virtual AspNetUsers AspNetUsers { get; set; }
        [Display(Name = "Cliente")]
        public virtual Cliente Cliente { get; set; }
        [Display(Name = "Departamento")]
        public virtual Departamento Departamento { get; set; }
        [Display(Name = "Empleado")]
        public virtual Empleado Empleado { get; set; }
        [Display(Name = "Estado de queja")]
        public virtual Estado_QR Estado_QR { get; set; }
        [Display(Name = "Tipo de queja")]
        public virtual Tipo_Queja Tipo_Queja { get; set; }
    }

    [DisplayColumn("ID_Reclamacion")]
    [DisplayName("Reclamación")]
    public class ReclamacionMetadata
    {
        [Display(Name = "Reclamación")]
        public int ID_Reclamacion { get; set; }
        [Display(Name = "Cliente")]
        public Nullable<int> ID_Cliente { get; set; }
        [Display(Name = "Redactor de la reclamación")]
        public string Id_UserName { get; set; }
        [Display(Name = "Empleado")]
        public Nullable<int> Id_Empleado { get; set; }
        [Display(Name = "Departamento")]
        public Nullable<int> ID_Departamento { get; set; }
        [Display(Name = "Tipo de reclamación")]
        public Nullable<int> ID_Tipo_Reclamacion { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public Nullable<System.DateTime> Fecha { get; set; }
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        [Display(Name = "Hora")]
        public Nullable<System.TimeSpan> Hora { get; set; }
        [Display(Name = "Sucursal")]
        public Nullable<int> ID_Sucursal { get; set; }
        [Display(Name = "Sucursal")]
        public virtual Sucursal Sucursal { get; set; }
        [Display(Name = "Estado de reclamación")]
        public Nullable<int> ID_Estado_QR { get; set; }
        [DataType(DataType.MultilineText)]
        public string Comentario { get; set; }

        [Display(Name = "Redactor de la reclamación")]
        public virtual AspNetUsers AspNetUsers { get; set; }
        [Display(Name = "Cliente")]
        public virtual Cliente Cliente { get; set; }
        [Display(Name = "Departamento")]
        public virtual Departamento Departamento { get; set; }
        [Display(Name = "Empleado")]
        public virtual Empleado Empleado { get; set; }
        [Display(Name = "Estado de reclamación")]
        public virtual Estado_QR Estado_QR { get; set; }
        [Display(Name = "Tipo de reclamación")]
        public virtual Tipo_Reclamacion Tipo_Reclamacion { get; set; }
    }

    [DisplayColumn("ID_Transaccion")]
    [DisplayName("Transacción de productos")]
    public class Rel_Transaccion_ProductoMetadata{
        [Display(Name = "Transacción")]
        public int ID_Transaccion { get; set; }
        [Display(Name = "Producto")]
        public int ID_Producto { get; set; }
        [Display(Name = "Cantidad de productos")]
        public Nullable<int> Cantidad_Producto { get; set; }
        [Display(Name = "Producto")]
        public virtual Producto Producto { get; set; }
        [Display(Name = "Transacción")]
        public virtual Transaccion Transaccion { get; set; }
    }

    [DisplayColumn("ID_Respuesta_Cliente")]
    [DisplayName("Respuesta del cliente")]
    public class Respuesta_ClienteMetadata
    {
        [Display(Name = "Respuesta del cliente")]
        public int ID_Respuesta_Cliente { get; set; }
        [Display(Name = "Queja")]
        public Nullable<int> Id_Queja { get; set; }
        [Display(Name = "Reclamación")]
        public Nullable<int> Id_Reclamacion { get; set; }
        [Display(Name = "Estado origen")]
        public Nullable<int> ID_Estado_Origen { get; set; }
        [Display(Name = "Estado destino")]
        public Nullable<int> ID_Estado_Destino { get; set; }
        [Display(Name = "Valoración")]
        [Range(typeof(int),"1","5",ErrorMessage = "Valor incorrecto")]
        public Nullable<int> Valoracion { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public Nullable<System.DateTime> Fecha { get; set; }
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        [Display(Name = "Hora")]
        public Nullable<System.TimeSpan> Hora { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Comentario")]
        public string Detalle { get; set; }

        [Display(Name = "Estado origen")]
        public virtual Estado_QR Estado_QR { get; set; }
        [Display(Name = "Estado destino")]
        public virtual Estado_QR Estado_QR1 { get; set; }
        [Display(Name = "Queja")]
        public virtual Queja Queja { get; set; }
        [Display(Name = "Reclamación")]
        public virtual Reclamacion Reclamacion { get; set; }
    }

    [DisplayColumn("ID_Respuesta_QR")]
    [DisplayName("Respuesta del empleado")]
    public class Respuesta_EmpleadoMetadata
    {
        [Display(Name = "Respuesta del empleado")]
        public int ID_Respuesta_QR { get; set; }
        [Display(Name = "Queja")]
        public Nullable<int> Id_Queja { get; set; }
        [Display(Name = "Reclamación")]
        public Nullable<int> Id_Reclamacion { get; set; }
        [Display(Name = "Empleado origen")]
        public Nullable<int> ID_Empleado_Origen { get; set; }
        [Display(Name = "Empleado destino")]
        public Nullable<int> ID_Empleado_Destino { get; set; }
        [Display(Name = "Departamento origen")]
        public Nullable<int> ID_Departamento_Origen { get; set; }
        [Display(Name = "Departamento destino")]
        public Nullable<int> ID_Departamento_Destino { get; set; }
        [Display(Name = "Estado origen")]
        public Nullable<int> ID_Estado_Origen { get; set; }
        [Display(Name = "Estado destino")]
        public Nullable<int> ID_Estado_Destino { get; set; }
        [Display(Name = "Sucursal origen")]
        public Nullable<int> ID_Sucursal_Origen { get; set; }
        [Display(Name = "Sucursal destino")]
        public Nullable<int> ID_Sucursal_Destino { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public Nullable<System.DateTime> Fecha { get; set; }
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        [Display(Name = "Hora")]
        public Nullable<System.TimeSpan> Hora { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Comentario")]
        public string Detalle { get; set; }

        [Display(Name = "Departamento origen")]
        public virtual Departamento Departamento { get; set; }
        [Display(Name = "Departamento destino")]
        public virtual Departamento Departamento1 { get; set; }
        [Display(Name = "Empleado origen")]
        public virtual Empleado Empleado { get; set; }
        [Display(Name = "Empleado destino")]
        public virtual Empleado Empleado1 { get; set; }
        [Display(Name = "Estado origen")]
        public virtual Estado_QR Estado_QR { get; set; }
        [Display(Name = "Estado destino")]
        public virtual Estado_QR Estado_QR1 { get; set; }
        [Display(Name = "Queja")]
        public virtual Queja Queja { get; set; }
        [Display(Name = "Reclamación")]
        public virtual Reclamacion Reclamacion { get; set; }
        [Display(Name = "Sucursal origen")]
        public virtual Sucursal Sucursal { get; set; }
        [Display(Name = "Sucursal destino")]
        public virtual Sucursal Sucursal1 { get; set; }
    }

    [DisplayName("Sucursal")]
    public class SucursalMetadata
    {
        [Display(Name = "Sucursal")]
        public int ID_Sucursal { get; set; }
        [Display(Name = "Sucursal")]
        public string Nombre { get; set; }
        [Display(Name = "Representante")]
        public Nullable<int> Id_Empleado_Representante { get; set; }
        [Display(Name = "Representante")]
        public virtual Empleado Empleado1 { get; set; }
    }

    [DisplayName("Tipo de identificación")]
    public class Tipo_IdentificacionMetadata
    {
        [Display(Name = "Tipo de identificación")]
        public int Id_Tipo_Identificacion { get; set; }
        [Display(Name = "Tipo de identificación")]
        public string Descripcion { get; set; }
    }

    [DisplayName("Tipo de producto")]
    public class Tipo_ProductoMetadata
    {
        [Display(Name = "Tipo de producto")]
        public int ID_Tipo_Producto { get; set; }
        [Display(Name = "Tipo de producto")]
        public string Descripcion { get; set; }
    }

    [DisplayName("Tipo de queja")]
    public class Tipo_QuejaMetadata
    {
        [Display(Name = "Tipo de queja")]
        public int ID_Tipo_Queja { get; set; }
        [Display(Name = "Tipo de queja")]
        public string Descripcion { get; set; }
    }

    [DisplayName("Tipo de reclamación")]
    public class Tipo_ReclamacionMetadata
    {
        [Display(Name = "Tipo de reclamación")]
        public int ID_Tipo_Reclamacion { get; set; }
        [Display(Name = "Tipo de reclamación")]
        public string Descripcion { get; set; }
    }

    [DisplayColumn("ID_Transaccion")]
    [DisplayName("Transacción")]
    public class TransaccionMetadata
    {
        [Display(Name = "Transacción")]
        public int ID_Transaccion { get; set; }
        [Display(Name = "Cliente")]
        public Nullable<int> ID_Cliente { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public Nullable<System.DateTime> Fecha { get; set; }
        [Display(Name = "Estado de transacción")]
        public Nullable<int> ID_Estado_Transaccion { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Monto")]
        public Nullable<decimal> Monto { get; set; }
        [Display(Name = "Vendedor")]
        public Nullable<int> Id_Empleado { get; set; }

        [Display(Name = "Cliente")]
        public virtual Cliente Cliente { get; set; }
        [Display(Name = "Vendedor")]
        public virtual Empleado Empleado { get; set; }
        [Display(Name = "Estado de transacción")]
        public virtual Estado_Transaccion Estado_Transaccion { get; set; }
    }

}