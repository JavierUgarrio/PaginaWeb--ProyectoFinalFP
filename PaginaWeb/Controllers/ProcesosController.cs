using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaginaWeb.Modelos;
using PaginaWeb.Modelos.ViewModels;
using System.Text;

namespace PaginaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcesosController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public ProcesosController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult DameProcesos()
        {

            Resultado res = new Resultado();
            try
            {
                using (FPAngularNetContext basedatos = new FPAngularNetContext())
                {
                    var lista = basedatos.Procesos.ToList();
                    res.ObjetoGenerico = lista;
                }
            }
            catch (Exception ex)
            {
                res.Error = "Hay un error al obtener los procesos" + ex.Message;
            }
            return Ok(res);
        }


        [HttpPost]
        public IActionResult AgregarProceso(ProcesoViewModel pro)
        {
            Resultado res = new Resultado();
            try
            {
                if (pro.email =="javier@gmail.com" && pro.pass=="12345")
                {
                    using (FPAngularNetContext basedatos = new FPAngularNetContext())
                    {
                        Proceso proceso = new Proceso();
                        //proceso.IdProceso = pro.id;
                        proceso.Nombre = pro.nombre;
                        proceso.Descripcion = pro.descripcion;
                        proceso.Cliente = pro.cliente;
                        proceso.FechaAlta = DateTime.Now;
                        basedatos.Procesos.Add(proceso);
                        basedatos.SaveChanges();
                    }

                }
                else
                {
                    Console.WriteLine("Usuario Incorrecto");
                }
                
            }
            catch (Exception ex)
            {
                res.Error = "Hay un error al añadir el proceso" + ex.Message;
            }
            return Ok(res);
        }









    }
}
