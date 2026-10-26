-- Procedimiento para obtener los estudiantes activos.
-- Permite consultar todos los estudiantes o filtrarlos por un grado específico.
CREATE PROCEDURE SP_ObtenerEstudiantesPorGrado
    @GradoId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Obtiene los datos principales del estudiante y el nombre de su grado.
    SELECT 
        E.Id,
        E.Nombre,
        E.Apellido,
        E.Cedula,
        E.Email,
        E.Telefono,
        G.Nombre AS Grado
    FROM Estudiantes E

    -- Relaciona cada estudiante con su grado correspondiente.
    INNER JOIN Grados G ON E.GradoId = G.Id

    -- Solo muestra estudiantes activos.
    -- Si @GradoId es NULL, muestra estudiantes de todos los grados.
    -- Si recibe un valor, muestra únicamente los estudiantes de ese grado.
    WHERE E.Activo = 1
      AND (@GradoId IS NULL OR E.GradoId = @GradoId)

    -- Ordena los estudiantes alfabéticamente por apellido.
    ORDER BY E.Apellido ASC;
END;
GO



-- Procedimiento para registrar una calificación.
-- Si ya existe una calificación para el mismo estudiante, materia y período,
-- la actualiza en lugar de crear un registro duplicado.
CREATE PROCEDURE SP_RegistrarCalificacion
    @EstudianteId INT,
    @MateriaId INT,
    @PeriodoId INT,
    @Nota1 DECIMAL(5,2),
    @Nota2 DECIMAL(5,2),
    @Nota3 DECIMAL(5,2),
    @Observaciones VARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Valida que todas las notas estén dentro del rango permitido de 0 a 100.
    IF (@Nota1 < 0 OR @Nota1 > 100 OR 
        @Nota2 < 0 OR @Nota2 > 100 OR 
        @Nota3 < 0 OR @Nota3 > 100)
    BEGIN
        RAISERROR(
            'Error: Las calificaciones deben estar comprendidas dentro del rango de 0 a 100.',
            16,
            1
        );
        RETURN;
    END

    -- Calcula automáticamente la nota final como el promedio de las tres notas.
    DECLARE @NotaFinal DECIMAL(5,2);
    SET @NotaFinal = (@Nota1 + @Nota2 + @Nota3) / 3.0;

    -- Verifica si ya existe una calificación para el estudiante,
    -- la materia y el período indicados.
    IF EXISTS (
        SELECT 1 
        FROM Calificaciones 
        WHERE EstudianteId = @EstudianteId 
          AND MateriaId = @MateriaId 
          AND PeriodoId = @PeriodoId
    )
    BEGIN
        -- Si existe, actualiza las notas, la nota final,
        -- las observaciones y la fecha de registro.
        UPDATE Calificaciones
        SET Nota1 = @Nota1,
            Nota2 = @Nota2,
            Nota3 = @Nota3,
            NotaFinal = @NotaFinal,
            Observaciones = @Observaciones,
            FechaRegistro = GETDATE()
        WHERE EstudianteId = @EstudianteId 
          AND MateriaId = @MateriaId 
          AND PeriodoId = @PeriodoId;
    END
    ELSE
    BEGIN
        -- Si no existe, crea una nueva calificación.
        INSERT INTO Calificaciones (
            EstudianteId,
            MateriaId,
            PeriodoId,
            Nota1,
            Nota2,
            Nota3,
            NotaFinal,
            Observaciones,
            FechaRegistro
        )
        VALUES (
            @EstudianteId,
            @MateriaId,
            @PeriodoId,
            @Nota1,
            @Nota2,
            @Nota3,
            @NotaFinal,
            @Observaciones,
            GETDATE()
        );
    END
END;
GO



-- Procedimiento para obtener la boleta de un estudiante
-- correspondiente a un período escolar específico.
CREATE PROCEDURE SP_BoletaEstudiante
    @EstudianteId INT,
    @PeriodoId INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Obtiene los datos del estudiante, grado, período,
    -- materias y sus respectivas calificaciones.
    SELECT 
        E.Id AS EstudianteId,
        CONCAT(E.Nombre, ' ', E.Apellido) AS NombreEstudiante,
        G.Nombre AS Grado,
        P.Nombre AS Periodo,
        M.Nombre AS Materia,
        C.Nota1,
        C.Nota2,
        C.Nota3,
        C.NotaFinal,
        C.Observaciones
    FROM Calificaciones C

    -- Relaciona la calificación con el estudiante.
    INNER JOIN Estudiantes E ON C.EstudianteId = E.Id

    -- Relaciona la calificación con la materia.
    INNER JOIN Materias M ON C.MateriaId = M.Id

    -- Relaciona la calificación con el período escolar.
    INNER JOIN Periodos P ON C.PeriodoId = P.Id

    -- Obtiene el grado al que pertenece el estudiante.
    INNER JOIN Grados G ON E.GradoId = G.Id

    -- Filtra la información para mostrar únicamente
    -- la boleta del estudiante y período solicitados.
    WHERE C.EstudianteId = @EstudianteId 
      AND C.PeriodoId = @PeriodoId;
END;
GO