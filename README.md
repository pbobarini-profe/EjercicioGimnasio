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

-- Tablas base


CREATE TABLE dbo.Clientes (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    dni VARCHAR(20) NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    telefono VARCHAR(30) NOT NULL,
    genero INT NOT NULL, -- 1-hombre | 2-mujer
    fechaNacimiento DATETIME2(0) NOT NULL
);

CREATE TABLE dbo.Entrenadores (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    dni VARCHAR(20) NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    telefono VARCHAR(30) NOT NULL,
    genero INT NOT NULL, -- 1-hombre | 2-mujer
    fechaNacimiento DATETIME2(0) NOT NULL
);

CREATE TABLE dbo.TipoActividades (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    descripcion INT NOT NULL -- según modelo
);

CREATE TABLE dbo.Periodos (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    descripcion INT NOT NULL -- yyyyMM
);

CREATE TABLE dbo.Ejercicios (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    descripcion VARCHAR(MAX) NULL
);

CREATE TABLE dbo.Especializaciones (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    descripcion VARCHAR(200) NOT NULL
);

-- Dependientes


CREATE TABLE dbo.Actividades (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    descripcion VARCHAR(200) NOT NULL,
    tipoActividadId INT NOT NULL,
    monto DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_Actividades_TipoActividades
        FOREIGN KEY (tipoActividadId) REFERENCES dbo.TipoActividades(id)
);

CREATE TABLE dbo.Planes (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    clienteId INT NOT NULL,
    periodoId INT NOT NULL,
    entrenadorId INT NOT NULL,
    CONSTRAINT FK_Planes_Clientes
        FOREIGN KEY (clienteId) REFERENCES dbo.Clientes(id),
    CONSTRAINT FK_Planes_Periodos
        FOREIGN KEY (periodoId) REFERENCES dbo.Periodos(id),
    CONSTRAINT FK_Planes_Entrenadores
        FOREIGN KEY (entrenadorId) REFERENCES dbo.Entrenadores(id)
);

CREATE TABLE dbo.DetallePlanes (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    planId INT NOT NULL,
    ejercicioId INT NOT NULL,
    CONSTRAINT FK_DetallePlanes_Planes
        FOREIGN KEY (planId) REFERENCES dbo.Planes(id),
    CONSTRAINT FK_DetallePlanes_Ejercicios
        FOREIGN KEY (ejercicioId) REFERENCES dbo.Ejercicios(id)
);

CREATE TABLE dbo.ActividadesClientes (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    actividadId INT NOT NULL,
    clienteId INT NOT NULL,
    fechaInicio DATETIME2(0) NOT NULL,
    vigente INT NOT NULL, -- 1-Vigente | 2-Caducado
    CONSTRAINT FK_ActCli_Actividades
        FOREIGN KEY (actividadId) REFERENCES dbo.Actividades(id),
    CONSTRAINT FK_ActCli_Clientes
        FOREIGN KEY (clienteId) REFERENCES dbo.Clientes(id)
);

CREATE TABLE dbo.ActividadesEntrenadores (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    actividadId INT NOT NULL,
    entrenadorId INT NOT NULL,
    fechaInicio DATETIME2(0) NOT NULL,
    vigente INT NOT NULL, -- 1-Vigente | 2-Caducado
    CONSTRAINT FK_ActEnt_Actividades
        FOREIGN KEY (actividadId) REFERENCES dbo.Actividades(id),
    CONSTRAINT FK_ActEnt_Entrenadores
        FOREIGN KEY (entrenadorId) REFERENCES dbo.Entrenadores(id)
);

-- Nota: en el modelo la propiedad se llama "entrengador" (con 'g'). Se respeta en el nombre de columna.


CREATE TABLE dbo.EspecializacionesEntrenadores (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    entrengadorId INT NOT NULL,
    especializacionId INT NOT NULL,
    CONSTRAINT FK_EspEnt_Entrenadores
        FOREIGN KEY (entrengadorId) REFERENCES dbo.Entrenadores(id),
    CONSTRAINT FK_EspEnt_Especializaciones
        FOREIGN KEY (especializacionId) REFERENCES dbo.Especializaciones(id)
);

CREATE TABLE dbo.PagosClientes (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    fechaPago DATETIME2(0) NOT NULL,
    clienteId INT NOT NULL,
    planClienteId INT NOT NULL,
    descripcion VARCHAR(200) NULL,
    periodoId INT NOT NULL,
    CONSTRAINT FK_Pagos_Clientes
        FOREIGN KEY (clienteId) REFERENCES dbo.Clientes(id),
    CONSTRAINT FK_Pagos_ActClientes
        FOREIGN KEY (planClienteId) REFERENCES dbo.ActividadesClientes(id),
    CONSTRAINT FK_Pagos_Periodos
        FOREIGN KEY (periodoId) REFERENCES dbo.Periodos(id)
);
