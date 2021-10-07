using PILpw.Models;
using AutoMapper;
using PILpw.Entitis;
using PWFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PILpw.Interfaz
{
    public interface IContactoService
    {
        Task<ContactoModel> Guardar(ContactoModel contacto);
        //Task<ContactoModel> CrearContacto(ContactoModel contacto);

        Task<ContactoModel> Eliminar(ContactoModel contacto, int id);
    }
}
