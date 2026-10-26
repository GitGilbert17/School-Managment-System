using Microsoft.EntityFrameworkCore;
using School_Managment_system_Backend.DTOs;

// 1. Creamos el constructor de la aplicación web (el "builder") que nos permite 
// configurar los servicios que va a utilizar nuestra API.
var builder = WebApplication.CreateBuilder(args);

// 2. Leemos la cadena de conexión ("DefaultConnection") desde el archivo appsettings.json
// para poder conectarnos a nuestra base de datos SQL Server (EscuelaDB).
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 3. Registramos el contexto de base de datos (Entity Framework Core) en el contenedor de dependencias.
// Aquí le indicamos que usaremos SQL Server y le pasamos nuestra cadena de conexión.
// (Asegúrate de cambiar "AppDbContext" por el nombre real de tu clase DbContext si se llama diferente).
builder.Services.AddDbContext<EscuelaDbContext>(options =>
    options.UseSqlServer(connectionString));

// 4. Agregamos el soporte para controladores de API (Controllers), 
// permitiéndonos crear endpoints (rutas HTTP) para que nuestro frontend en Vue.js los consuma.
builder.Services.AddControllers();

// 5. Configuramos una política de CORS (Cross-Origin Resource Sharing).
// Esto es obligatorio para permitir que tu aplicación de Vue.js (que correrá en otro puerto) 
// pueda hacer peticiones (GET, POST, etc.) a esta API sin que el navegador las bloquee.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", policy =>
    {
        policy.AllowAnyOrigin()      // Permite peticiones desde cualquier origen (puedes cambiarlo luego por la URL exacta de Vue)
              .AllowAnyMethod()      // Permite cualquier método HTTP (GET, POST, PUT, DELETE, etc.)
              .AllowAnyHeader();     // Permite cualquier cabecera HTTP (Headers)
    });
});

// 6. Construimos la aplicación web con todos los servicios que acabamos de registrar.
var app = builder.Build();

// 7. Redirige automáticamente las peticiones HTTP inseguras hacia HTTPS (seguridad web estándar).
app.UseHttpsRedirection();

// 8. Aplicamos la política de CORS que definimos arriba. 
// IMPORTANTE: Debe ir antes de mapear los controladores y de la autenticación.
app.UseCors("AllowVueApp");

// 9. Activa el middleware de autorización (por si en el futuro proteges rutas con tokens o roles).
app.UseAuthorization();

// 10. Mapea automáticamente todos los controladores que crees (ej. AlumnosController, CursosController)
// para que respondan a las peticiones que te mande Postman o tu app de Vue.js.
app.MapControllers();

// 11. Ejecuta y enciende la aplicación web para que empiece a escuchar peticiones.
app.Run();