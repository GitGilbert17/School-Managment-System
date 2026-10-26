-- 1. Tabla Grados
CREATE TABLE Grados (
 Id int identity(1,1) primary key,
 Nombre varchar(50) not null,
 Nivel varchar(20) not null check (Nivel IN ('Primaria', 'Secundaria')),
 Activo BIT not null default 1
);

-- 1. Tabla Docentes

CREATE TABLE Docentes (
 Id int identity(1,1) primary key,
 Nombre varchar (50) not null,
 Apellido varchar (50) not null,
 Cedula varchar (15) not null UNIQUE,
 Email varchar (100) not null UNIQUE,
 Telefono varchar (15) not null,
 Especialidad  varchar (50) not null,
 FechaContratacion date not null,
 Activo BIT not null default 1
);

-- 3. Tabla Estudiantes 

create table Estudiantes (
 Id int identity (1,1) primary key,
 Nombre varchar (50) not null,
 Apellido varchar (50) not null,
 Cedula varchar (15) null UNIQUE,
 FechaNacimiento date not null,
 Email varchar(100) null unique,
 Telefono varchar (15) null,
 GradoId int not null,
 FechaInscripcion Date not null default getdate(),
 Activo bit not null default 1,

 Constraint FK_estudiantes_Grados Foreign key (GradoID) references Grados (Id)
 -- Relaciona GradoId con Id de Grados.
-- Evita registrar grados inexistentes y eliminar grados con estudiantes.

);

create table Materias (
 Id int identity(1,1) primary key,
 Nombre varchar(50) not null,
 CodigoMateria varchar(15) not null unique,
 Creditos int not null check (Creditos > 0),
 DocenteId int not null,
 GradoId int not null,
 Activo BIT not null default 1,

 -- Relaciona cada materia con el docente que la imparte.
-- Impide asignar un DocenteId que no exista en la tabla Docentes.
 constraint FK_Materias_Docentes Foreign key (DocenteId) references Docentes (Id),

 -- Relaciona cada materia con el grado al que pertenece.
-- Impide asignar un GradoId que no exista en la tabla Grados.
 CONSTRAINT FK_Materias_Grados FOREIGN KEY (GradoId) REFERENCES Grados(Id)
);

-- 5. Tabla Periodos
CREATE TABLE Periodos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(20) NOT NULL, -- Ej: '2024-1'
    FechaInicio DATE NOT NULL,
    FechaFin DATE NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,

    -- Verifica que la fecha de finalización sea posterior a la fecha de inicio.
-- Evita crear períodos con fechas inválidas o invertidas.
    CONSTRAINT CHK_Fechas_Periodo CHECK (FechaFin > FechaInicio)
);

-- 6. Tabla Calificaciones
CREATE TABLE Calificaciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EstudianteId INT NOT NULL,
    MateriaId INT NOT NULL,
    PeriodoId INT NOT NULL,
    Nota1 DECIMAL(5,2) NOT NULL,
    Nota2 DECIMAL(5,2) NOT NULL,
    Nota3 DECIMAL(5,2) NOT NULL,
    NotaFinal DECIMAL(5,2) NOT NULL,
    Observaciones VARCHAR(255) NULL,
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),

    -- Claves Foráneas

    -- Relaciona la calificación con el estudiante correspondiente.
-- Impide registrar una calificación para un estudiante que no exista.
    CONSTRAINT FK_Calificaciones_Estudiantes FOREIGN KEY (EstudianteId) REFERENCES Estudiantes(Id),

    -- Relaciona la calificación con la materia correspondiente.
-- Impide registrar una calificación para una materia que no exista.
    CONSTRAINT FK_Calificaciones_Materias FOREIGN KEY (MateriaId) REFERENCES Materias(Id),

    -- Relaciona la calificación con el período escolar correspondiente.
-- Impide registrar una calificación para un período que no exista.
    CONSTRAINT FK_Calificaciones_Periodos FOREIGN KEY (PeriodoId) REFERENCES Periodos(Id),

    -- Requisito: CHECK CONSTRAINTS para notas entre 0 y 100
    CONSTRAINT CHK_Nota1 CHECK (Nota1 BETWEEN 0 AND 100),
    CONSTRAINT CHK_Nota2 CHECK (Nota2 BETWEEN 0 AND 100),
    CONSTRAINT CHK_Nota3 CHECK (Nota3 BETWEEN 0 AND 100),
    CONSTRAINT CHK_NotaFinal CHECK (NotaFinal BETWEEN 0 AND 100),

    -- Requisito: UNIQUE CONSTRAINT para evitar duplicados en la combinación (EstudianteId, MateriaId, PeriodoId)
    CONSTRAINT UQ_Estudiante_Materia_Periodo UNIQUE (EstudianteId, MateriaId, PeriodoId)
);
GO

-- Requisito: Índices en columnas de búsqueda frecuente
CREATE INDEX IX_Estudiantes_GradoId ON Estudiantes(GradoId);
CREATE INDEX IX_Estudiantes_Apellido ON Estudiantes(Apellido);
CREATE INDEX IX_Materias_DocenteId ON Materias(DocenteId);
CREATE INDEX IX_Calificaciones_EstudianteId ON Calificaciones(EstudianteId);
GO

);

