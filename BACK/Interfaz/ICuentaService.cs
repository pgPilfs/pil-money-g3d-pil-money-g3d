using PWFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWFinal.Interfaz
{
    public interface ICuentaService
    {
        Task<Cuenta> CrearCuenta(Cuenta cuenta);
    }
}
