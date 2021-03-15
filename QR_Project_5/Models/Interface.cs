using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_Project_5.Models
{
    public interface IQR
    {
        string Id_UserName { get; set; }
        Nullable<int> Id_Empleado { get; set; }
        Nullable<int> ID_Departamento { get; set; }
        Nullable<System.DateTime> Fecha { get; set; }
        Nullable<System.TimeSpan> Hora { get; set; }
        Nullable<int> ID_Estado_QR { get; set; }
        string Comentario { get; set; }
        Nullable<int> ID_Sucursal { get; set; }
    }
    public interface IRespuesta
    {
        Nullable<System.DateTime> Fecha { get; set; }
        string Detalle { get; set; }
        Nullable<System.TimeSpan> Hora { get; set; }
    }
}
