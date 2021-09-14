
using PWFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWFinal.Interfaz
{
    public interface ICuentaService
    {
        Task<CuentaModel> CrearCuenta(CuentaModel cuenta);
    }
}
