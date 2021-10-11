using PILpw.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PILpw.Interfaz
{
   public interface ITipoOperacionService
    {
        Task<TipoOperacionModel> Guardar(TipoOperacionModel usuario);
    }
}
