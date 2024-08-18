using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using GamepageAPI.Models;

namespace GamepageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolsController : Controller
    {
        private readonly string cadenaSQL;
        public RolsController(IConfiguration config) {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }
        [HttpGet]
        [Route("Listar")]
        public IActionResult Lista()
        {
            List<Rols> lista = new List<Rols>();

            try {
            
                using (var conexion  = new SqlConnection(cadenaSQL)) {
                    conexion.Open();
                    var cmd = new SqlCommand("GetAllRols", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Rols
                            {
                                IdRol = Convert.ToInt32(reader["IdRol"]),
                                RolName = reader["RolName"].ToString(),
                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Roles adquiridos con exito", response = lista });
            }catch(Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = lista });
            }
        }

    }
}
