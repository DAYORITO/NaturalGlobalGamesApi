using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using GamepageAPI.Models;
using System.Text;
using System.Collections.Generic;
using System;

namespace GamepageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly string cadenaSQL;

        public UsersController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Users> lista = new List<Users>();

            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("GetAllUsers", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = cmd.ExecuteReader())
                    {
                        string userPassword = "********";
                        while (reader.Read())
                        {
                            lista.Add(new Users()
                            {
                                IdUser = Convert.ToInt32(reader["IdGame"]),
                                UserName = reader["UserName"].ToString(),
                                UserPassword = Encoding.UTF8.GetBytes(userPassword),
                                IdRol = Convert.ToInt32(reader["IdRol"])
                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Usuarios adquiridos con exito", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = lista });
            }
        }
    }
}

