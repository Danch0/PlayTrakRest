# PlayTrakRest

Servicio web REST para guardar dispositivos y consultarlos todos o por tipo.
La aplicación contempla una base de datos SQL de cuatro tablas:

```
CREATE TABLE [COMPONENTES] (
	[id] int NOT NULL IDENTITY(1,1) ,
	[nombre] varchar(100) NULL ,
	[descripcion] varchar(255) NULL ,
	[registro] datetime NULL ,
	[dispositivo_id] int NULL ,
PRIMARY KEY ([id])
)
GO
CREATE TABLE [DISPOSITIVOS] (
	[id] int NOT NULL IDENTITY(1,1) ,
	[nombre] varchar(100) NULL ,
	[registro] datetime NULL ,
	[tipo_id] int NULL ,
PRIMARY KEY ([id])
)
GO
CREATE TABLE [REGISROS_USOS] (
	[id] int NOT NULL IDENTITY(1,1) ,
	[dt_inicio] datetime NULL ,
	[dt_fin] datetime NULL ,
	[dispositivo_id] int NULL ,
PRIMARY KEY ([id])
)
GO
CREATE TABLE [TIPOS_DISPOSITIVO] (
[id] int NOT NULL IDENTITY(1,1) ,
[tipo] varchar(100) NULL ,
PRIMARY KEY ([id])
)
GO
-- ----------------------------
-- Foreign Key structure for table [COMPONENTES]
-- ----------------------------
ALTER TABLE [COMPONENTES] ADD FOREIGN KEY ([dispositivo_id]) REFERENCES [DISPOSITIVOS] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [DISPOSITIVOS]
-- ----------------------------
ALTER TABLE [DISPOSITIVOS] ADD FOREIGN KEY ([tipo_id]) REFERENCES [TIPOS_DISPOSITIVO] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [REGISROS_USOS]
-- ----------------------------
ALTER TABLE [REGISROS_USOS] ADD FOREIGN KEY ([dispositivo_id]) REFERENCES [DISPOSITIVOS] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
```

## Tabla de rutas para el API:

| Verbo| URL| Descripción|

| ----- | ---- | ---- |

| GET | api/Dispositivos | Obtiene todos los dispositivo |
| POST | api/Dispositivos | Agreg nuevo dispositivo |
| GET | api/Tragamonedas | Obtiene los dispositivos tipo tragamonedas |
| GET | api/Blackjack | Obtiene los dispositivos tipo mesa de blackjack |

## Uso del API

 Para información detallada de cada clase y/o ruta consultar http://playtrackrest.azurewebsites.net/Help.

### Metodo: GET api/Dispositivos
* Ruta: http://playtrackrest.azurewebsites.net/api/Dispositivos
* Parametros recibidos: Ninguno.
* Descripción: Retorna un JSON de la clase RespuestaBase como se muestra a continuación, en el campo Datos contendra el arreglo de dispositivos de la clase DispositivosModel.
```
{
	"Mensaje": "",
	"Datos": [ // Arreglo con 
        {
            "id": 1,
            "nombre": "Tragamonedas-1",
            "registro": "2019-04-11T03:09:30",
            "Componentes": [ // Arreglo de los componenetes del dispositivo.
                {
                    "id": 1,
                    "nombre": "Wifi",
                    "descripcion": "Adaptador red inalambrico",
                    "registro": "2019-04-12T17:31:43",
                    "dispositivo_id": 1
                },
                {
                    "id": 2,
                    "nombre": "Display",
                    "descripcion": "Pantalla tipo led fullHD",
                    "registro": "2019-04-12T17:32:25",
                    "dispositivo_id": 1
                }
            ],
            "tipo_id": 1,
            "Tipo": "TRAGAMONEDAS",
            "RegistroUsos": [ // Arreglo de los resistros de uso del dispositivo.
                {
                    "id": 1,
                    "dt_inicio": "2019-04-12T17:32:42",
                    "dt_fin": "2019-04-12T17:32:50",
                    "dispositivo_id": 1
                },
                {
                    "id": 2,
                    "dt_inicio": "2019-04-13T00:35:27",
                    "dt_fin": "2019-04-13T00:50:40",
                    "dispositivo_id": 1
                }
            ]
        },...
	],
	"Estatus": true
}
```

### Metodo: POST api/Dispositivos
* Ruta: http://playtrackrest.azurewebsites.net/api/Dispositivos
* Parametros recibidos: JSON de la clase DispositivosModel, solo acepta arreglo de componenetes de la clase ComponentesModel.
```
{
    "nombre": "Tragamonedas-4",
    "Componentes": [
        {
            "nombre": "Wifi",
            "descripcion": "Adaptador red inalambrico"
        },
        {
            "nombre": "Display",
            "descripcion": "Pantalla tipo led fullHD"
        }
    ],
    "tipo_id": 1
}
```
* Descripción: Retorna un JSON de la clase RespuestaBase, en el campo Datos contendra el nuevo dispositivos de la clase DispositivosModel. 
```
{
    "Mensaje": "",
    "Datos": {
        "id": 7,
        "nombre": "Tragamonedas-4",
        "registro": "2019-04-16T18:24:13.5082251-05:00",
        "Componentes": [
            {
                "id": 12,
                "nombre": "Wifi",
                "descripcion": "Adaptador red inalambrico",
                "registro": "2019-04-16T18:24:24.2547412-05:00",
                "dispositivo_id": null
            },
            {
                "id": 13,
                "nombre": "Display",
                "descripcion": "Pantalla tipo led fullHD",
                "registro": "2019-04-16T18:24:24.5544109-05:00",
                "dispositivo_id": null
            }
        ],
        "tipo_id": 1,
        "Tipo": "TRAGAMONEDAS",
        "RegistroUsos": []
    },
    "Estatus": true
}
```

### Metodo: GET api/Tragamonedas
* Ruta: http://playtrackrest.azurewebsites.net/api/Tragamonedas
* Parametros recibidos: Ninguno.
* Descripción: Retorna un JSON con la misma estructura que el metodo api/Dispositivos.

### Metodo: GET api/Blackjack
* Ruta: http://playtrackrest.azurewebsites.net/api/Blackjack
* Parametros recibidos: Ninguno.
* Descripción: Retorna un JSON con la misma estructura que el metodo api/Dispositivos.
