using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Backend.Connection;

namespace Backend.Controllers
{
    public class login
    {
        public string usuario { get; set; }
        public string clave { get; set; }
    }

    public class LoginEstado
    {
        public bool result { get; set; }
        public string error { get; set; }
    }

    public class LoginController : ApiController
    {

        [HttpGet]
        public IHttpActionResult login(string usuario, string clave)
        {
            login login = new login
            {
                usuario = usuario,
                clave = clave
            };


            DBConnection db = new DBConnection();
            var connection = db.OpenConnection();

            SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 1 * FROM usuario WHERE usuario='" + login.usuario + "' AND clave='" + login.clave + "'", connection.connection);
            /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
            DataTable dt = new DataTable(); //this is creating a virtual table  
            sda.Fill(dt);

            string ret = "0|0";

            if (dt.Rows.Count > 0)
            {
                return Ok(dt.Rows[0][0].ToString() + "|" + dt.Rows[0][1].ToString());
            }
            else
            {
                return Ok(ret);
            }


        }
    }
}
