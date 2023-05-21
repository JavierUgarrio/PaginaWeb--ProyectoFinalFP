using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaginaWeb.Modelos;
using PaginaWeb.Modelos.ViewModels;
using System.Text;

namespace PaginaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public UsuariosController(IConfiguration configuration) 
        {
            this.configuration = configuration;
        }
        [HttpGet]
        public IActionResult DameUsuarios()
        {   
            Resultado res = new Resultado();
            try
            {
                using (FPAngularNetContext basedatos = new FPAngularNetContext())
                {
                    var lista = basedatos.Usuarios.ToList();
                    res.ObjetoGenerico = lista;
                }
            }
            catch (Exception ex) 
            {
                res.Error ="Hay un error al obtener los usuarios"+ ex.Message;
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult AgregarUsuario(UsuarioViewModel u)
        {
            Resultado res = new Resultado();
            try
            {
                byte[] keyBbyte = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                Util util = new Util(keyBbyte);
                using (FPAngularNetContext basedatos = new FPAngularNetContext())
                {
                    Usuario usuario = new Usuario();
                    usuario.Nombre = u.nombre;
                    usuario.Apellidos = u.apellidos;
                    usuario.Telefono = u.telefono;
                    usuario.Email = u.email;
                    usuario.Password = Encoding.ASCII.GetBytes(util.cifrar(u.pass,configuration["ClaveCifrado"]));
                    usuario.FechaAlta = DateTime.Now;
                    basedatos.Usuarios.Add(usuario);
                    basedatos.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                res.Error = "Hay un error al añadir al usuario" + ex.Message;
            }
            return Ok(res);
        }


        [HttpPut]
        public IActionResult EditarUsuario(UsuarioViewModel u)
        {
            Resultado res = new Resultado();
            try
            {
                byte[] keyBbyte = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                Util util = new Util(keyBbyte);
                using (FPAngularNetContext basedatos = new FPAngularNetContext())
                {
                    Usuario usuario = basedatos.Usuarios.Single(usu => usu.Email == u.email);
                    usuario.Nombre = u.nombre;
                    usuario.Apellidos = u.apellidos;
                    usuario.Telefono = u.telefono;
                    usuario.Email = u.email;
                    usuario.Password = Encoding.ASCII.GetBytes(util.cifrar(u.pass, configuration["ClaveCifrado"]));
                    basedatos.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    basedatos.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                res.Error = "Hay un error al modificar el usuario" + ex.Message;
            }
            return Ok(res);
        }

        [HttpPut("{Email}")]
        public IActionResult BorrarUsuario(string email)
        {
            Resultado res = new Resultado();
            try
            {
                
                using (FPAngularNetContext basedatos = new FPAngularNetContext())
                {
                    Usuario usuario = basedatos.Usuarios.Single(usu => usu.Email == email);
                    basedatos.Remove(usuario);
                    basedatos.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                res.Error = "Hay un error al eliminar un usuario" + ex.Message;
            }
            return Ok(res);
        }

    }
}

