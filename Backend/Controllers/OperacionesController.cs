using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Backend.Connection;
using Backend.Models;

namespace Backend.Controllers
{
    public class OperacionesController : ApiController
    {

        #region Cuentas

        /// <summary>
        /// Metodo para obtener las cuentas bancarias de un usuario
        /// </summary>
        /// <param name="id_usuario">Id usuario logueado</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult getCuentas(int id_usuario)
        {
            DBConnection db = new DBConnection();

            var connection = db.OpenConnection();

            string sql = "SELECT " +
                         "  c.id, " +
                         "  c.nombre, " +
                         "  c.saldo, " +
                         "  ba.nombre as banco " +
                         "FROM cuenta c " +
                         "LEFT JOIN banco ba ON ba.id = c.id_banco " +
                         "WHERE c.id_usuario = {0}";

            var cuentas = db.getDataSQL(connection, string.Format(sql, id_usuario));

            db.CloseConnection();

            return Ok(cuentas);
        }

        /// <summary>
        /// Metodo para obtener las transacciones
        /// </summary>
        /// <param name="id_usuario">Id usuario logueado</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult getTransacciones(int id_usuario)
        {
            DBConnection db = new DBConnection();

            var connection = db.OpenConnection();

            string sql = "SELECT " +
                        "	tt.nombre tipo_transaccion, " +
                        "	t.monto, " +
                        "	t.valor_gmf, " +
                        "	c.nombre as cuenta, " +
                        "	t.saldo_operacion, " +
                        "	t.fecha_hora, " +
                        "	c1.nombre as cuenta_destino," +
                        "   convert(varchar, t.fecha_hora, 0) fecha_tra " +
                        "FROM transaccion t " +
                        "LEFT JOIN tipo_transaccion tt ON tt.id = t.id_tipo_transaccion " +
                        "LEFT JOIN cuenta c ON c.id = t.id_cuenta " +
                        "LEFT JOIN cuenta c1 ON c1.id = t.id_cuenta_destino " +
                        "WHERE t.id_usuario = {0} " +
                        "ORDER BY fecha_hora desc ";

            var transacciones = db.getDataSQL(connection, string.Format(sql, id_usuario));

            db.CloseConnection();

            return Ok(transacciones);
        }

        /// <summary>
        /// Metodo para obtener lista de cuentas y tipos de transaccion
        /// </summary>
        /// <param name="id_usuario"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult getCatalogos(int id_usuario, int id_cuenta)
        {
            DBConnection db = new DBConnection();

            var connection = db.OpenConnection();

            string sql = "SELECT " +
                        "	* " +
                        "FROM cuenta " +
                        "WHERE id_usuario = {0} and id <> {1} ";

            var cuentas = db.getDataSQL(connection, string.Format(sql, id_usuario, id_cuenta));


            sql = "SELECT " +
                  "   * " +
                  "FROM tipo_transaccion ";

            var tipo_transaccion = db.getDataSQL(connection, string.Format(sql));

            db.CloseConnection();

            return Ok(new {
                cuentas,
                tipo_transaccion
            });
        }

        /// <summary>
        /// Metodo para guardar una transaaccion
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult guardar_transaccion(int id_cuenta, int? id_cuenta_destino, int id_tipo_transaccion, int id_usuario, decimal monto)
        {
            DBConnection db = new DBConnection();

            var connection = db.OpenConnection();

            string sql = "EXEC	guardar_transaccion " +
                        "		@id_tipo_transaccion = {0}, " +
                        "		@monto = {1}, " +
                        "		@id_cuenta = {2}, " +
                        "		@id_cuenta_destino = {3}, " +
                        "		@id_usuario = {4} ";

            var guardar_tran = db.getDataSQL(connection, string.Format(sql, id_tipo_transaccion, 
                monto, id_cuenta, id_cuenta_destino, id_usuario));


            return Ok(new
            {
                guardar_tran
            });
        }
        #endregion

    }
}
