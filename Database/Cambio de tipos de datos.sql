USE EscuelaDB;
GO

-- ==========================================
-- 1. Actualizar tabla Grados
-- ==========================================
ALTER TABLE Grados ALTER COLUMN Nombre NVARCHAR(50) NOT NULL;
ALTER TABLE Grados ALTER COLUMN Nivel NVARCHAR(20) NOT NULL;

-- ==========================================
-- 2. Actualizar tabla Docentes
-- ==========================================
ALTER TABLE Docentes ALTER COLUMN Nombre NVARCHAR(50) NOT NULL;
ALTER TABLE Docentes ALTER COLUMN Apellido NVARCHAR(50) NOT NULL;
ALTER TABLE Docentes ALTER COLUMN Especialidad NVARCHAR(50) NOT NULL;
-- (Cédula, Email, Teléfono se quedan en VARCHAR ya que no llevan tildes y son códigos/correos estándar)

-- ==========================================
-- 3. Actualizar tabla Estudiantes
-- ==========================================
ALTER TABLE Estudiantes ALTER COLUMN Nombre NVARCHAR(50) NOT NULL;
ALTER TABLE Estudiantes ALTER COLUMN Apellido NVARCHAR(50) NOT NULL;

-- ==========================================
-- 4. Actualizar tabla Materias
-- ==========================================
ALTER TABLE Materias ALTER COLUMN Nombre NVARCHAR(50) NOT NULL;
-- Permitir que DocenteId sea NULL (por si se crea una materia sin profesor asignado inicialmente)
ALTER TABLE Materias ALTER COLUMN DocenteId INT NULL;

-- ==========================================
-- 5. Actualizar tabla Periodos
-- ==========================================
ALTER TABLE Periodos ALTER COLUMN Nombre NVARCHAR(20) NOT NULL;

-- Actualizar Observaciones a NVARCHAR
ALTER TABLE Calificaciones ALTER COLUMN Observaciones NVARCHAR(255) NULL;

GO

USE EscuelaDB;
GO

-- 1. Eliminamos la restricción CHECK vieja que está bloqueando la columna
ALTER TABLE Grados DROP CONSTRAINT CK__Grados__Nivel__60A75C0F;
GO

-- 2. Cambiamos el tipo de dato a NVARCHAR(20) para que acepte tildes y caracteres especiales
ALTER TABLE Grados ALTER COLUMN Nivel NVARCHAR(20) NOT NULL;
GO

-- 3. Volvemos a crear la regla CHECK con un nombre limpio
ALTER TABLE Grados ADD CONSTRAINT CHK_Grados_Nivel CHECK (Nivel IN ('Primaria', 'Secundaria'));
GO

DROP INDEX IX_Estudiantes_Apellido ON Estudiantes;
GO

-- 2. Cambiar el tipo de dato de la columna Apellido a NVARCHAR(50)
ALTER TABLE Estudiantes ALTER COLUMN Apellido NVARCHAR(50) NOT NULL;
GO

-- 3. Volver a crear el índice en la columna Apellido para no perder el rendimiento
CREATE INDEX IX_Estudiantes_Apellido ON Estudiantes(Apellido);
GO