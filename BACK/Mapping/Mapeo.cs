using AutoMapper;
using PILpw.Entitis;
using PipayWalletFinal.Models;
using PWFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWFinal.Mapping
{
    public class Mapeo:Profile
    {
        public Mapeo()
        {

            CreateMap<CuentaModel, Cuenta>()
                .ForMember(destination => destination.IdCuenta, options => options.Ignore());

            CreateMap<Cuenta, CuentaModel>(); 

            CreateMap<UsuarioModel, Usuario>();
            CreateMap<Usuario, UsuarioModel>();
        }



    }
}
