-- Insertar Grados (Mínimo 2)
INSERT INTO Grados (Nombre, Nivel) VALUES 
('1er Año de Secundaria', 'Secundaria'),
('2do Año de Secundaria', 'Secundaria');

-- Insertar Docentes (Mínimo 4)
INSERT INTO Docentes (Nombre, Apellido, Cedula, Email, Telefono, Especialidad, FechaContratacion) VALUES
('Carlos', 'Mendoza', '001-0000001-1', 'carlos.mendoza@escuela.edu', '809-555-0101', 'Matemáticas', '2020-01-15'),
('Ana', 'Gómez', '001-0000002-2', 'ana.gomez@escuela.edu', '809-555-0102', 'Español', '2019-08-20'),
('Luis', 'Martínez', '001-0000003-3', 'luis.martinez@escuela.edu', '809-555-0103', 'Ciencias', '2021-02-10'),
('María', 'Rodríguez', '001-0000004-4', 'maria.rodriguez@escuela.edu', '809-555-0104', 'Historia', '2018-05-12');

-- Insertar Materias (Mínimo 6)
INSERT INTO Materias (Nombre, CodigoMateria, Creditos, DocenteId, GradoId) VALUES
('Álgebra I', 'MAT-101', 4, 1, 1),
('Lengua Española I', 'ESP-101', 3, 2, 1),
('Biología General', 'CIE-101', 4, 3, 1),
('Historia Universal', 'HIS-101', 3, 4, 1),
('Geometría Analítica', 'MAT-201', 4, 1, 2),
('Literatura Hispana', 'ESP-201', 3, 2, 2);

-- Insertar Estudiantes (Mínimo 10 distribuidos en los dos grados)
INSERT INTO Estudiantes (Nombre, Apellido, Cedula, FechaNacimiento, Email, Telefono, GradoId) VALUES
('Juan', 'Pérez', '402-1111111-1', '2008-05-14', 'juan.perez@student.edu', '809-555-0201', 1),
('Laura', 'Sánchez', '402-1111112-2', '2008-08-22', 'laura.sanchez@student.edu', '809-555-0202', 1),
('Pedro', 'Díaz', '402-1111113-3', '2008-01-10', 'pedro.diaz@student.edu', '809-555-0203', 1),
('Sofia', 'López', '402-1111114-4', '2008-11-30', 'sofia.lopez@student.edu', '809-555-0204', 1),
('Diego', 'Torres', '402-1111115-5', '2008-03-18', 'diego.torres@student.edu', '809-555-0205', 1),
('Gabriel', 'García', '402-1111116-6', '2007-06-12', 'gabriel.garcia@student.edu', '809-555-0206', 2),
('Elena', 'Ramírez', '402-1111117-7', '2007-09-05', 'elena.ramirez@student.edu', '809-555-0207', 2),
('Mateo', 'Castro', '402-1111118-8', '2007-02-25', 'mateo.castro@student.edu', '809-555-0208', 2),
('Camila', 'Vargas', '402-1111119-9', '2007-12-01', 'camila.vargas@student.edu', '809-555-0209', 2),
('Lucas', 'Morales', '402-1111120-0', '2007-04-14', 'lucas.morales@student.edu', '809-555-0210', 2);

-- Insertar Periodos Académicos (2 periodos)
INSERT INTO Periodos (Nombre, FechaInicio, FechaFin) VALUES
('2024-1', '2024-01-10', '2024-05-30'),
('2024-2', '2024-08-20', '2024-12-20');

-- Insertar Calificaciones para al menos 5 estudiantes en el período más reciente (Periodo 2)
INSERT INTO Calificaciones (EstudianteId, MateriaId, PeriodoId, Nota1, Nota2, Nota3, NotaFinal) VALUES
(1, 1, 2, 85.00, 90.00, 88.00, 87.67),
(2, 1, 2, 95.00, 92.00, 98.00, 95.00),
(3, 2, 2, 70.00, 75.00, 80.00, 75.00),
(4, 3, 2, 88.00, 84.00, 90.00, 87.33),
(5, 4, 2, 100.00, 98.00, 95.00, 97.67);
GO

select * from Estudiantes