# PlayTrakRest
Servicio web REST que proporcione datos para ser consumidos desde cualquier aplicación u otro servicio, además de permitir la creación de nuevos registros. Los datos pueden consultarse en su totalidad, paginados y / o agrupados bajo algunos criterios. Esta información debe almacenarse en Bases de datos (en las que hay al menos dos tablas relacionadas) para que el servicio interactúe a través de un ORM. También se requiere hacer un registro de los eventos que ocurrieron en los métodos, para rastrear todo tipo de anomalías (recomendamos Apache Log4Net). Finalmente, es necesario documentar las clases, los métodos y los atributos recibidos o el tipo de datos devueltos (se recomienda el Resumen del IDE, por ejemplo); Como la propia aplicación, rutas públicas y ejemplos de uso.

Uso del API

Metodo: GET api/Dispositivos
Llamada: http://playtrackrest.azurewebsites.net/api/Dispositivos
Parametros recibidos: Ninguno.
Respuesta: Json de la clase RespuestaBase, para mas informacion http://playtrackrest.azurewebsites.net/Help.
    {
        "Mensaje": "OK",
        "Datos": [
            {
                "id": 1,
                "nombre": "Television",
                "registro": "2019-04-11T03:09:30",
                "componentes": null,
                "registro_usos": null
            }
        ],
        "Estatus": true
    }
