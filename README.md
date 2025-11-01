Este trabajo es para evaluar la aplicacion correcta de los contenidos vistos sobre arquitectura de 3 capas en una aplicacion Windows Form. Las temáticas fueron sugeridas por los alumnos.  
A tener en cuenta:  
1-No vamos a usar Entity Framework, por lo que les pido que me envien los comandos para sql server de los create de las tablas. Por defecto si son varchar comunes (no esta comentado en la clase varchar max) los varchar seran de 120 caracteres.  
2-Debe funcionar completo el CRUD - SOLO DEBEN TOCAR LOS ARCHIVOS DE LAS CLASES QUE LES FUERON DADAS - NO TOCAR ARCHIVO DE LOS OTROS.  
3-Como implica que varios alumnos van a necesitar funciones y metodos de otras clases que le corresponde a otro compañero, vamos a simplificar y van a poder hacer JOIN y crear los objetos que necesite el modelo elegido. Esto, si bien no es lo optimo, en terminos prácticos va a simplificar los posibles conflictos en la cooperacion.  
4-Deben presentar un reporte en RDLC. Los dejo a criterio de ustedes. Ese tema lo vamos a ver la clase del 01/11.  
5-Cada alumno debe pasarme su link de cuenta de github para que yo lo agregue como colaborador.  
6-Tema manejo de ramas que no pudimos ver en clase. Antes de comenzar a editar deben crear una rama haciendo click en donde dice master en la esquina inferior derecha del visual studio. Ahi les saldra estas opciones:  
<img width="625" height="436" alt="image" src="https://github.com/user-attachments/assets/ca2281f5-bc50-45e2-8b81-d1a298d7e701" />
Ponen nueva rama y le colocan su nombre.  
Siempre que esten desarrollando asegurense tener su rama seleccionada. Cualquier duda la vemos en clase  

//Tablas

-- Base
CREATE TABLE dbo.Clientes (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    nombreCompleto NVARCHAR(200) NULL,
    identificacionTributaria NVARCHAR(50) NULL
);
GO

CREATE TABLE dbo.TipoComprobante (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    descripcion NVARCHAR(200) NULL
);
GO

CREATE TABLE dbo.Usuarios (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    nombre NVARCHAR(100) NULL,
    apellido NVARCHAR(100) NULL,
    nombreUsuario NVARCHAR(100) NULL,
    contrasena NVARCHAR(200) NULL,
    mail NVARCHAR(254) NULL,
    fechaAlta DATETIME2(0) NOT NULL
);
GO

CREATE TABLE dbo.Proveedores (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    nombreCompleto NVARCHAR(200) NULL,
    identificacionTributaria NVARCHAR(50) NULL
);
GO

CREATE TABLE dbo.Productos (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    descripcion NVARCHAR(200) NULL
);
GO

CREATE TABLE dbo.Insumos (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    descripcion NVARCHAR(200) NULL
);
GO

-- Movimientos principales
CREATE TABLE dbo.Compras (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    fecha DATETIME2(0) NOT NULL,
    proveedorId INT NOT NULL,
    tipoComprobanteId INT NOT NULL,
    puntoVenta NVARCHAR(10) NULL,
    numero NVARCHAR(20) NULL,
    netoTotal DECIMAL(18,2) NOT NULL,
    ivaTotal DECIMAL(18,2) NOT NULL,
    noGravado DECIMAL(18,2) NOT NULL,
    otrosTributos DECIMAL(18,2) NOT NULL,
    usuarioId INT NOT NULL,
    CONSTRAINT FK_Compras_Proveedores FOREIGN KEY (proveedorId) REFERENCES dbo.Proveedores(id),
    CONSTRAINT FK_Compras_TipoComprobante FOREIGN KEY (tipoComprobanteId) REFERENCES dbo.TipoComprobante(id),
    CONSTRAINT FK_Compras_Usuarios FOREIGN KEY (usuarioId) REFERENCES dbo.Usuarios(id)
);
GO

CREATE TABLE dbo.Ventas (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    fecha DATETIME2(0) NOT NULL,
    clienteId INT NOT NULL,
    tipoComprobanteId INT NOT NULL,
    puntoVenta NVARCHAR(10) NULL,
    numero NVARCHAR(20) NULL,
    netoTotal DECIMAL(18,2) NOT NULL,
    ivaTotal DECIMAL(18,2) NOT NULL,
    noGravado DECIMAL(18,2) NOT NULL,
    otrosTributos DECIMAL(18,2) NOT NULL,
    usuarioId INT NOT NULL,
    CONSTRAINT FK_Ventas_Clientes FOREIGN KEY (clienteId) REFERENCES dbo.Clientes(id),
    CONSTRAINT FK_Ventas_TipoComprobante FOREIGN KEY (tipoComprobanteId) REFERENCES dbo.TipoComprobante(id),
    CONSTRAINT FK_Ventas_Usuarios FOREIGN KEY (usuarioId) REFERENCES dbo.Usuarios(id)
);
GO

-- Detalles
CREATE TABLE dbo.DetalleCompras (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    compraId INT NOT NULL,
    cantidad DECIMAL(18,3) NOT NULL,
    insumoId INT NOT NULL,
    precioUnitario DECIMAL(18,2) NOT NULL,
    usuarioId INT NOT NULL,
    CONSTRAINT FK_DetalleCompras_Compras FOREIGN KEY (compraId) REFERENCES dbo.Compras(id),
    CONSTRAINT FK_DetalleCompras_Insumos FOREIGN KEY (insumoId) REFERENCES dbo.Insumos(id),
    CONSTRAINT FK_DetalleCompras_Usuarios FOREIGN KEY (usuarioId) REFERENCES dbo.Usuarios(id)
);
GO

CREATE TABLE dbo.DetalleVentas (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ventaId INT NOT NULL,
    cantidad DECIMAL(18,3) NOT NULL,
    productoId INT NOT NULL,
    precioUnitario DECIMAL(18,2) NOT NULL,
    usuarioId INT NOT NULL,
    CONSTRAINT FK_DetalleVentas_Ventas FOREIGN KEY (ventaId) REFERENCES dbo.Ventas(id),
    CONSTRAINT FK_DetalleVentas_Productos FOREIGN KEY (productoId) REFERENCES dbo.Productos(id),
    CONSTRAINT FK_DetalleVentas_Usuarios FOREIGN KEY (usuarioId) REFERENCES dbo.Usuarios(id)
);
GO

-- Producción y consumos
CREATE TABLE dbo.ProduccionProductos (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    fecha DATETIME2(0) NOT NULL,
    productoId INT NOT NULL,
    cantidad DECIMAL(18,3) NOT NULL,
    CONSTRAINT FK_ProduccionProductos_Productos FOREIGN KEY (productoId) REFERENCES dbo.Productos(id)
);
GO

CREATE TABLE dbo.ConsumosInsumos (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    fecha DATETIME2(0) NOT NULL,
    cantidad DECIMAL(18,3) NOT NULL,
    insumoId INT NOT NULL,
    CONSTRAINT FK_ConsumosInsumos_Insumos FOREIGN KEY (insumoId) REFERENCES dbo.Insumos(id)
);
GO

CREATE TABLE dbo.ConsumoProduccion (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    consumoInsumoId INT NOT NULL,
    produccionProductoId INT NOT NULL,
    observaciones NVARCHAR(MAX) NULL,
    CONSTRAINT FK_ConsumoProduccion_ConsumosInsumos FOREIGN KEY (consumoInsumoId) REFERENCES dbo.ConsumosInsumos(id),
    CONSTRAINT FK_ConsumoProduccion_ProduccionProductos FOREIGN KEY (produccionProductoId) REFERENCES dbo.ProduccionProductos(id)
);
GO
