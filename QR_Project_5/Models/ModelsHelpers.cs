using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QR_Project_5.Models
{
    public static class ModelsHelpers
    {
        public static int CompareRespuestas(IRespuesta x, IRespuesta y)
        {
            if(x.Fecha == null && y.Fecha == null)
            {
                return 0;
            }else if(x.Fecha == null && y.Fecha != null)
            {
                return -1;
            }else if(x.Fecha != null && y.Fecha == null)
            {
                return 1;
            }
            if(x.Fecha > y.Fecha)
            {
                return 1;
            }else if(x.Fecha < y.Fecha)
            {
                return -1;
            }else if(x.Hora > y.Hora)
            {
                return 1;
            }else if(x.Hora < y.Hora)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}