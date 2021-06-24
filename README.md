# Backend1

c# Web Api, VS2017 con conexion a base de datos SQLServer 2019.

En el web.config se encuentran las appkeys de conexion a la base de datos llamada PRUEBADB:

    <add key="server" value="localhost" />
    <add key="db" value="PRUEBADB" />
    <add key="user" value="sa" />
    <add key="password" value="Test2021*" />
    

Dentro de este repositrio se encuentra una carpeta llamada scripts DB, la cual contiene todos los scripts ddl de la base de datos PRUEBADB.

Su contenido son las tablas:

1-usuario: tiene un solo registro, nombre, usuario, clave, exento.
2-banco: tiene un listado de bancos.
3-cuenta: tiene un listado de cuenta asignadas a un banco y a un usuario, su saldo.
4-configuracion: tiene un solo registro base para el gmf, divisor para el gmf, porc para el gmf.
5-tipo_transaccion: tiene 2 registros uno RE para retiros y otro TR  para transferencias. el registro TR tiene activo un campo pide_cuenta_destino.
6-transaccion: guarda todos los movimientos de retiros y transferencias.
7-auditria: guarda registro de auditoria por usuario de las transacciones.

Tambien se encuentra dentro de la carpeta el script ddl de un procedimiento almacenado, el cual guarda la transaccion, solo acepta 5 parametos y el proceso valida y calcula, valores gmf, pide cuenta destino, saldo por transaccion y proceso de actualizar saldo en cada cuenta alterada.

dentro de esta carpeta se encuentra un backup PRUEBADB.bak, la cual contiene la configuracion inicial de la base de datos para su funcionamiento.
