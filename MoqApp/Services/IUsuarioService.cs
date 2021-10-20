using MoqApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoqApp.Services
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> GetAllAsync();

        Task<Usuario> CreateAsync(Usuario usuario);

        Task<Usuario> GetByIdAsync(string codigoUsuario);

        Task<bool> DeleteUsuario(string codigoUsuario);

    }
}
