using NUnit.Framework;
using Moq;
using MoqApp.Services;
using MoqApp.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    [TestFixture]
    public class UsuarioServiceTests
    {


        private readonly UsuarioService _usuarioService;
        private readonly Mock<ILogService> _loggerMock = new Mock<ILogService>();

        private DbContextOptions<sistemaUsuariosContext> options = new DbContextOptionsBuilder<sistemaUsuariosContext>()
            .UseInMemoryDatabase(databaseName: "sistemaUsuarios_MEM_01")
            .Options;

        public UsuarioServiceTests()
        {
            var _context = new sistemaUsuariosContext(options);
            
            _context.Usuarios.Add(new Usuario { CodigoUsuario = "11222333-4", Email = "asd@asd.com", Password = "asdf1", Nombre = "Kyron", Apellido = "Meza" });
            _context.SaveChanges();

            _usuarioService = new UsuarioService(_context, _loggerMock.Object);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnCustomer_WhenCustomerExists()
        {
            var expectedUsuario = new Usuario
            {
                CodigoUsuario = "11222333-4",
                Email = "asd@asd.com",
                Password = "asdf1",
                Nombre = "Kyron",
                Apellido = "Meza"
            };

            var resultUsuario = await _usuarioService.GetByIdAsync("11222333-4");

            Assert.AreEqual(expectedUsuario.ToString(), resultUsuario.ToString());
        }
    }
}