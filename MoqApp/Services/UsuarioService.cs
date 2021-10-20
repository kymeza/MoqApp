using Microsoft.EntityFrameworkCore;
using MoqApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoqApp.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly sistemaUsuariosContext _context;
        private readonly ILogService _logger;

        public UsuarioService(sistemaUsuariosContext context, ILogService logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            _logger.LogInformation("Retrieved {Count} Usuarios", usuarios.Count);
            return usuarios;
        }

        public async Task<Usuario> GetByIdAsync(string codigoUsuario)
        {
            //TODO --> Implementar Log
            var usuario = await _context.Usuarios.FindAsync(codigoUsuario);

            if (usuario == null)
            {
                return null;
            }

            return usuario;
        }

        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            //TODO --> Implementar Log
            _context.Usuarios.Add(usuario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsuarioExists(usuario.CodigoUsuario))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return usuario;
        }

        public async Task<bool> DeleteUsuario(string codigoUsuario)
        {
            //TODO --> Implementar Log
            var usuarioToDelete = await _context.Usuarios.FindAsync(codigoUsuario);

            if (usuarioToDelete == null)
            {
                return false;
            }

            _context.Usuarios.Remove(usuarioToDelete);
            await _context.SaveChangesAsync();

            return true;

        }

        private bool UsuarioExists(string id)
        {
            return _context.Usuarios.Any(e => e.CodigoUsuario == id);
        }

        
    }
}
