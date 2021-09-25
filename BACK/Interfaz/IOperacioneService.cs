using PILpw.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PILpw.Interfaz
{
    public interface IOperacioneService
    {
        Task<object> Guardar(OperacioneModel operacione);
    }
}
