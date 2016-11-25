CREATE TABLE AGENDAMIENTO
(
FECHA_GESTION DATETIME NOT NULL,
A�O_GESTION NUMERIC NOT NULL,
MES_GESTION NUMERIC NOT NULL,
DIA_GESTION NUMERIC NOT NULL,
HORA_GESTION DATETIME NOT NULL,
USUARIO VARCHAR (50) NOT NULL,
CANAL_INGRESO VARCHAR (20) NOT NULL,
CUENTA NUMERIC (18,0) NOT NULL,
ORDEN NUMERIC (18,0) NOT NULL,
FECHA_CREACION DATETIME NOT NULL,
RANGO_DIAS NUMERIC NOT NULL,
COMUNIDAD VARCHAR (255) NOT NULL,
NODO VARCHAR (50) NOT NULL,
REPORTE_ALIADO VARCHAR (255) NOT NULL,
VECES_PROGRAMADA NUMERIC NOT NULL,
GESTION VARCHAR (255) NOT NULL,
FECHA_AGENDA VARCHAR (255) NOT NULL,
OBSERVACIONES VARCHAR (1000) NOT NULL
)

GO
CREATE TABLE ASIG_AGENDAMIENTO
(
CUENTA NUMERIC (18,0) NOT NULL,
ORDEN NUMERIC (18,0) NOT NULL,
CANAL_INGRESO VARCHAR (50) NOT NULL,
FECHA_CREACION DATETIME NOT NULL,
RANGO_DIAS NUMERIC NOT NULL,
COMUNIDAD VARCHAR (509) NOT NULL,
NODO VARCHAR (50) NOT NULL,
)
GO

CREATE TABLE ASIG_CONGELACIONES
(
CUENTA NUMERIC (18,0) NOT NULL,
CANAL_INGRESO VARCHAR (50) NOT NULL,
FECHA_CREACION DATETIME NOT NULL,
A�O_CREACION NUMERIC NOT NULL,
MES_CREACION NUMERIC NOT NULL,
DIA_CREACION NUMERIC NOT NULL,
USUARIO_CREACION VARCHAR (50) NOT NULL,
)
GO
CREATE TABLE ASIG_DESCONEXIONES
(
CUENTA NUMERIC (18,0) NOT NULL,
CANAL_INGRESO VARCHAR (50)NOT NULL,
MOTIVO_DX VARCHAR (50) NOT NULL,
CODIGO NUMERIC NOT NULL,
NOTA1 VARCHAR (1000) NOT NULL,
NOTA2 VARCHAR (1000) NOT NULL,
NOTA3 VARCHAR (1000) NOT NULL,
NOTA4 VARCHAR (1000) NOT NULL,
NOTA5 NUMERIC (18,0) NOT NULL,
RED VARCHAR (50) NOT NULL,
SERVICIOS VARCHAR (50) NOT NULL,
FECHA_SOLICITUD VARCHAR (50) NOT NULL,
FECHA_CORTE VARCHAR (50) NOT NULL,
FECHA_PREAVISO VARCHAR (50) NOT NULL,
DIA_DX NUMERIC NOT NULL,
TARIFA_ANTERIOR VARCHAR (50) NOT NULL,
)
GO

CREATE TABLE ASIG_POSVENTAS
(
CUENTA NUMERIC (18,0) NOT NULL,
ORDEN NUMERIC (18,0) NOT NULL,
CANAL_INGRESO VARCHAR (50) NOT NULL,
RANGO_DIAS NUMERIC NOT NULL,
TIPO_TRABAJO VARCHAR (255) NOT NULL,
USUARIO_CREACION VARCHAR (50) NOT NULL,
FECHA_CREACION VARCHAR (50) NOT NULL,
A�O_CREACION NUMERIC NOT NULL,
MES_CREACION NUMERIC NOT NULL,
DIA_CREACION NUMERIC NOT NULL,
)
GO

CREATE TABLE ASIG_TARIFA_TRE
(
CUENTA NUMERIC NOT NULL,
CANAL_INGRESO VARCHAR (50) NOT NULL,
)
GO

CREATE TABLE ASIG_TICKETS
(
CANAL_INGRESO VARCHAR (50) NOT NULL,
CUENTA NUMERIC (18,0) NOT NULL,
NUMERO_TICKET NUMERIC (18,0) NOT NULL,
USUARIO_CREACION VARCHAR (50) NOT NULL,
FECHA_CREACION VARCHAR (50) NOT NULL,
SRCAUS VARCHAR (50) NOT NULL,
SRREAS VARCHAR (50) NOT NULL,
MOTIVO_DX VARCHAR (50) NOT NULL,
CODIGO NUMERIC NOT NULL,
NOTA1 VARCHAR (1000) NOT NULL,
NOTA2 VARCHAR (1000) NOT NULL,
NOTA3 VARCHAR (1000) NOT NULL,
NOTA4 VARCHAR (1000) NOT NULL,
NOTA5 NUMERIC (18,0) NOT NULL,
)
GO
CREATE TABLE ASIG_TRASLADOS
(
CUENTA NUMERIC(18,0) NOT NULL,
ORDEN NUMERIC (18,0) NOT NULL,
CANAL_INGRESO VARCHAR (50) NOT NULL,
DIVISION VARCHAR (50) NOT NULL,
USUARIO_CREACION VARCHAR (50) NOT NULL,
FECHA_CREACION DATETIME NOT NULL,
A�O_CREACION NUMERIC NOT NULL,
MES_CREACION NUMERIC NOT NULL,
DIA_CREACION NUMERIC NOT NULL,
RANGO_ORDEN NUMERIC NOT NULL,
ESTADO VARCHAR (50) NOT NULL,
)

GO

CREATE TABLE CASOS_RETENCION
(
FECHA_GESTION DATETIME NOT NULL,
A�O_GESTION NUMERIC NOT NULL,
MES_GESTION NUMERIC NOT NULL,
DIA_GESTION NUMERIC NOT NULL,
HORA_GESTION DATETIME NOT NULL,
USUARIO VARCHAR(50) NOT NULL,
CANAL_INGRESO VARCHAR (50) NOT NULL,
CUENTA NUMERIC (18,0) NOT NULL,
NUMERO_TICKET NUMERIC (18,0) NOT NULL,
USUARIO_CREA VARCHAR (50) NOT NULL,
FECHA_CREACION DATETIME NOT NULL,
A�O_CREACION NUMERIC NOT NULL,
MES_CREACION NUMERIC NOT NULL,
DIA_CREACION NUMERIC NOT NULL,
SRCAUS VARCHAR (50) NOT NULL,
SRREAS VARCHAR (50)  NOT NULL,
MOTIVO VARCHAR (50) NOT NULL,
CODIGO NUMERIC NOT NULL,
NOTA1 VARCHAR (500) NOT NULL,
NOTA2 VARCHAR (500) NOT NULL,
NOTA3 VARCHAR (500) NOT NULL,
NOTA4 VARCHAR (500) NOT NULL,
NOTA5 NUMERIC (18,0) NOT NULL,
FECHA_ESCALAMIENTO DATETIME NOT NULL,
MARCA VARCHAR (1000) NOT NULL,
MOTIVO_REC VARCHAR (1000) NOT NULL,
USU_RETENCION VARCHAR (50) NOT NULL,
OFREC_RET VARCHAR (1000) NOT NULL,
FECHA_SOL_CAN VARCHAR (50) NOT NULL,
MARCACION VARCHAR (50) NOT NULL,
USUARUIO_CAN VARCHAR (50) NOT NULL,
MOVIE_LETTER NUMERIC (18,0) NOT NULL,
NUMERO_SER NUMERIC NOT NULL,
AJUSTE VARCHAR (50) NOT NULL,
ESTADO_TICKET VARCHAR (50) NOT NULL,
USUARIO_ESCALA VARCHAR (50) NOT NULL,
OBSERVACIONES VARCHAR (1000) NOT NULL,
)
GO
CREATE TABLE TICKETS
(
FECHA_GESTION DATETIME NOT NULL,
A�O_GESTION NUMERIC NOT NULL,
MES_GESTION NUMERIC NOT NULL,
DIA_GESTION NUMERIC NOT NULL,
HORA_GESTION DATETIME NOT NULL,
USUARIO VARCHAR(50) NOT NULL,
CANAL_INGRESO VARCHAR (50) NOT NULL,
CUENTA NUMERIC (18,0) NOT NULL,
NUMERO_TICKET NUMERIC (18,0) NOT NULL,
USUARIO_CREA VARCHAR (50) NOT NULL,
FECHA_CREACION DATETIME NOT NULL,
A�O_CREACION NUMERIC NOT NULL,
MES_CREACION NUMERIC NOT NULL,
DIA_CREACION NUMERIC NOT NULL,
SRCAUS VARCHAR (50) NOT NULL,
SRREAS VARCHAR (50)  NOT NULL,
MOTIVO VARCHAR (50) NOT NULL,
CODIGO NUMERIC NOT NULL,
NOTA1 VARCHAR (500) NOT NULL,
NOTA2 VARCHAR (500) NOT NULL,
NOTA3 VARCHAR (500) NOT NULL,
NOTA4 VARCHAR (500) NOT NULL,
NOTA5 NUMERIC (18,0) NOT NULL,
FECHA_ESCALAMIENTO DATETIME NOT NULL,
MARCA VARCHAR (1000) NOT NULL,
MOTIVO_REC VARCHAR (1000) NOT NULL,
USU_RETENCION VARCHAR (50) NOT NULL,
OFREC_RET VARCHAR (1000) NOT NULL,
FECHA_SOL_CAN VARCHAR (50) NOT NULL,
MARCACION VARCHAR (50) NOT NULL,
USUARUIO_CAN VARCHAR (50) NOT NULL,
MOVIE_LETTER NUMERIC (18,0) NOT NULL,
NUMERO_SER NUMERIC NOT NULL,
AJUSTE VARCHAR (50) NOT NULL,
ESTADO_TICKET VARCHAR (50) NOT NULL,
USUARIO_ESCALA VARCHAR (50) NOT NULL,
OBSERVACIONES VARCHAR (1000) NOT NULL,
)
GO

CREATE TABLE CONGELACIONES
(
FECHA_GESTION  DATETIME NOT NULL,
A�O_GESTION NUMERIC NOT NULL,
MES_GESTION NUMERIC NOT NULL,
DIA_GESTION NUMERIC NOT NULL,
HORA_GESTION DATETIME NOT NULL,
USUARIO VARCHAR (50) NOT NULL,
CANAL_INGRESO VARCHAR (50) NOT NULL,
FECHA_CREACION  DATETIME NOT NULL,
A�O_CREACION NUMERIC NOT NULL,
MES_CREACION NUMERIC NOT NULL,
DIA_CREACION NUMERIC NOT NULL,
CUENTA NUMERIC (18,0) NOT NULL,
SERVICIOS VARCHAR (50) NOT NULL,
MOTIVO_E4 VARCHAR (50) NOT NULL,
USUARIO_E4 VARCHAR (50) NOT NULL,
MES_CONGELAR VARCHAR (50) NOT NULL,
GESTION VARCHAR (500) NOT NULL,
SUB_RAZON VARCHAR (500) NOT NULL,
ESTADO VARCHAR (50) NOT NULL,
MOTIVO_ESTADO VARCHAR (255) NOT NULL,
USUARIO_APLICO_E4 VARCHAR (50) NOT NULL,
AJUSTE VARCHAR (50) NOT NULL,
SERVICIOS_DX NUMERIC NOT NULL,
OBSERVACIONES VARCHAR (1000) NOT NULL,
)
GO
CREATE TABLE CONSOLIDADO
(
ID_GESTION NUMERIC NOT NULL,
CUENTA NUMERIC (18,0) NOT NULL,
CANAL_INGRESO VARCHAR (50) NOT NULL,
FECHA_CREACION DATETIME NOT NULL,
PROCESO VARCHAR (255) NOT NULL,
GESTION VARCHAR (500) NOT NULL,
SUB_RAZON VARCHAR (500) NOT NULL,
SERVICIOS_DX NUMERIC NOT NULL,
FECHA_GESTION DATETIME NOT NULL,
A�O_GESTION NUMERIC NOT NULL,
MES_GESTION NUMERIC NOT NULL,
DIA_GESTION NUMERIC NOT NULL,
HORA_GESTION DATETIME NOT NULL,
USUARIO VARCHAR (50) NOT NULL,
FOREIGN KEY (ID_GESTION) REFERENCES GESTIONES
)
GO

CREATE TABLE DESCONEXIONES
(
USUARIO VARCHAR (50) NOT NULL,
FECHA_GESTION DATETIME NOT NULL,
A�O_GESTION NUMERIC NOT NULL,
MES_GESTION NUMERIC NOT NULL,
DIA_GESTION NUMERIC NOT NULL,
HORA_GESTION DATETIME NOT NULL,
CANAL_INGRESO VARCHAR (50) NOT NULL,
CUENTA NUMERIC (18,0) NOT NULL,
MOTIVO_DX VARCHAR (50) NOT NULL,
CODIGO NUMERIC NOT NULL,
NOTA1 VARCHAR (500) NOT NULL,
NOTA2 VARCHAR (500) NOT NULL,
NOTA3 VARCHAR (500) NOT NULL,
NOTA4 VARCHAR (500) NOT NULL,
NOTA5 NUMERIC (18,0) NOT NULL,
RED VARCHAR (50) NOT NULL,
SERVICIOS VARCHAR (50) NOT NULL,
FECHA_SOLICITUD VARCHAR (50) NOT NULL,
FECHA_CORTE VARCHAR (50) NOT NULL,
FECHA_PREAVISO VARCHAR (50) NOT NULL,
DIA_DX NUMERIC NOT NULL,
TARIFA_ANTERIOR VARCHAR (50) NOT NULL,
GESTION VARCHAR (500) NOT NULL,
RAZON VARCHAR (500) NOT NULL,
MOVIE_LETTER NUMERIC (18,0) NOT NULL,
AJUSTE VARCHAR (50) NOT NULL,
CANTIDAD_SERVICIOS NUMERIC NOT NULL,
OBSERVACIONES VARCHAR (500) NOT NULL,
PROCESO_RETENCION VARCHAR (50) NOT NULL,
)
GO

CREATE TABLE LIBERACIONES 
(
REGISTRO NUMERIC (18,0) NOT NULL,
CUENTA NUMERIC (18,0) NOT NULL,
CANAL_INGRESO VARCHAR (50) NOT NULL,
PER_ENVIA VARCHAR (100) NOT NULL,
NUM_SERVICIOS NUMERIC NOT NULL,
FECHA_SOLICITUD DATETIME NOT NULL,
A�O_SOLICITUD NUMERIC NOT NULL,
MES_SOLICITUD NUMERIC NOT NULL,
DIA_SOLICITUD NUMERIC NOT NULL,
FECHA_GESTION DATETIME NOT NULL,
A�O_GESTION NUMERIC NOT NULL,
MES_GESTION NUMERIC NOT NULL,
DIA_GESTION NUMERIC NOT NULL,
HORA_GESTION DATETIME NOT NULL,
USUARIO VARCHAR (50) NOT NULL,
REGISTRO_MODULO  VARCHAR (50) NOT NULL,
SOLICITUD_CANCELACION VARCHAR (50) NOT NULL,
MOTIVO_DX VARCHAR (50) NOT NULL,
VENDEDOR VARCHAR (50) NOT NULL,
GRUPO VARCHAR (500) NOT NULL,
GESTION VARCHAR (500) NOT NULL,
RAZON VARCHAR (500) NOT NULL,
MOTIVO_LIBERACION VARCHAR (500) NOT NULL,
USUARIO_LIBERO VARCHAR (50) NOT NULL,
OBSERVACIONES VARCHAR (500) NOT NULL,
)
GO

CREATE TABLE POSVENTAS
(
FECHA_GESTION DATETIME NOT NULL,
A�O_GESTION NUMERIC NOT NULL,
MES_GESTION NUMERIC NOT NULL,
DIA_GESTION NUMERIC NOT NULL,
HORA_GESTION DATETIME NOT NULL,
USUARIO VARCHAR (50) NOT NULL,
CUENTA NUMERIC (18,0) NOT NULL,
ORDEN NUMERIC (18,0) NOT NULL,
CANAL_INGRESO VARCHAR (50) NOT NULL,
RANGO_DIAS NUMERIC (18,0) NOT NULL,
TIPO_TRABAJO VARCHAR (100) NOT NULL,
USU_CREACION VARCHAR (50) NOT NULL,
FECHA_CREACION VARCHAR (50) NOT NULL,
A�O_CREACION NUMERIC NOT NULL,
MES_CREACION NUMERIC NOT NULL,
DIA_CREACION NUMERIC NOT NULL,
ESTADO_ORDEN VARCHAR (100) NOT NULL,
TIPO_ORDEN VARCHAR (100) NOT NULL,
MOTIVO_ORDEN VARCHAR (255) NOT NULL,
NUM_SERVICIOS NUMERIC NOT NULL,
OBSERVACIONES VARCHAR (500) NOT NULL,
)
GO

CREATE TABLE TARIFA_TRE
(
USUARIO VARCHAR (50) NOT NULL,
FECHA_GESTION DATETIME NOT NULL,
A�O_GESTION NUMERIC NOT NULL,
MES_GESTION NUMERIC NOT NULL,
DIA_GESTION NUMERIC NOT NULL,
HORA_GESTION DATETIME NOT NULL,
CUENTA NUMERIC (18,0) NOT NULL,
FECHA_CREACION  DATETIME NOT NULL,
CANAL_INGRESO VARCHAR (50) NOT NULL,
GESTION VARCHAR (255) NOT NULL,
RAZON VARCHAR (255) NOT NULL,
MOVIE_LETTER NUMERIC (18,0) NOT NULL,
AJUSTE VARCHAR (50) NOT NULL,
CANT_SERVICIOS NUMERIC NOT NULL,
OBSERVACIONES VARCHAR (1000) NOT NULL,
)
GO


CREATE TABLE TRASLADOS
(
FECHA_GESTION DATETIME NOT NULL,
A�O_GESTION NUMERIC NOT NULL,
MES_GESTION NUMERIC NOT NULL,
DIA_GESTION NUMERIC NOT NULL,
HORA_GESTION DATETIME NOT NULL,
USUARIO VARCHAR (50) NOT NULL,
CUENTA NUMERIC (18,0) NOT NULL,
ORDEN NUMERIC (18,0) NOT NULL,
CANAL_INGRESO VARCHAR (50) NOT NULL,
DIVISION VARCHAR (50) NOT NULL,
USU_CREACION VARCHAR (50) NOT NULL,
FECHA_CREACION DATETIME NOT NULL,
A�O_CREACION NUMERIC NOT NULL,
MES_CREACION NUMERIC NOT NULL,
DIA_CREACION NUMERIC NOT NULL,
RANGO_OT NUMERIC NOT NULL,
ESTADO VARCHAR (50) NOT NULL,
FECHA_MARCACION DATETIME NOT NULL,
A�O_MARCACION NUMERIC NOT NULL,
MES_MARCACION NUMERIC NOT NULL,
DIA_MARCACION NUMERIC NOT NULL,
USU_MODIFICACION VARCHAR (50) NOT NULL,
FECHA_MODIFIC DATETIME NOT NULL,
A�O_MODIFICACION NUMERIC NOT NULL,
MES_MODIFICACION NUMERIC NOT NULL,
DIA_MODIFICACION NUMERIC NOT NULL,
CONTACTO VARCHAR (50) NOT NULL,
TIPO_CONTACTO VARCHAR (50) NOT NULL,
GESTION VARCHAR (500) NOT NULL,
SUB_RAZON VARCHAR (500) NOT NULL,
RAZON_IPOSIBILIDAD VARCHAR (255) NOT NULL,
ESTADO_ORDEN VARCHAR (50) NOT NULL,
PREAVISO VARCHAR (50) NOT NULL,
ETADO_CUENTA VARCHAR (50) NOT NULL,
LLAMADA_SERICIO VARCHAR (50) NOT NULL,
OBSERVACIONES VARCHAR (500) NOT NULL,
INTENTOS_CONTATO NUMERIC NOT NULL,
)
GO
CREATE TABLE ASIG_VENCIDOS
(
CANAL_INGRESO VARCHAR (50) NOT NULL,
CUENTA NUMERIC (18,0) NOT NULL,
NUMERO_TICKET NUMERIC (18,0) NOT NULL,
USUARIO_CREACION VARCHAR (50) NOT NULL,
FECHA_CREACION VARCHAR (50) NOT NULL,
SRCAUS VARCHAR (50) NOT NULL,
SRREAS VARCHAR (50) NOT NULL,
MOTIVO_DX VARCHAR (50) NOT NULL,
CODIGO NUMERIC NOT NULL,
NOTA1 VARCHAR (1000) NOT NULL,
NOTA2 VARCHAR (1000) NOT NULL,
NOTA3 VARCHAR (1000) NOT NULL,
NOTA4 VARCHAR (1000) NOT NULL,
NOTA5 NUMERIC (18,0) NOT NULL,
)
GO

CREATE TABLE ADHERENCIA
(
USUARIO VARCHAR (50) NOT NULL,
FECHA DATETIME NOT NULL,
A�O NUMERIC NOT NULL,
MES NUMERIC NOT NULL,
DIA NUMERIC NOT NULL,
HORA_INICIO DATETIME NOT NULL,
HORA_FIN DATETIME NOT NULL,
) 
CREATE TABLE PRODUCTIVIDAD
(
USUARIO VARCHAR (50) NOT NULL,
ID_GESTION NUMERIC NOT NULL,
FECHA DATETIME NOT NULL,
A�O NUMERIC NOT NULL,
MES NUMERIC NOT NULL,
DIA NUMERIC NOT NULL,
HORA_GESTION DATETIME NOT NULL,
CUETNA NUMERIC (18,0) NOT NULL,
PROCESO VARCHAR (100) NOT NULL,
PORCENTAJE NUMERIC (18,0) NOT NULL,
FOREIGN KEY (ID_GESTION) REFERENCES GESTIONES
)

