# .NET Entity Framework Project

Este proyecto fue desarrollado utilizando el marco de trabajo **ASP.NET MVC** con integración a bases de datos **SQL Server** mediante **Entity Framework**.  

## Características principales
- Implementación del patrón **MVC** para una arquitectura organizada y escalable.  
- Gestión de base de datos con principios **ACID**, garantizando la integridad de la información.  
- Uso de métodos **asíncronos** y **síncronos**, aplicados según las necesidades de cada proceso.  
- Manejo de errores con un sistema de **registro en el Visor de Eventos de Windows**, lo que permite almacenar y consultar los errores no controlados para obtener contexto y mejorar la depuración.  
- Implementación de un sistema de **autenticación y autorización** mediante **ASP.NET Identity**, incluyendo:
  - Registro e inicio de sesión de usuarios.  
  - Asignación y administración de **roles** con diferentes niveles de acceso.  

## Tecnologías utilizadas
- **ASP.NET MVC**  
- **Entity Framework**  
- **ASP.NET Identity (con roles)**  
- **SQL Server**  
- **C#**  
- **HTML**  
- **CSS**  


## Aprendizaje obtenido
Este proyecto fortaleció mis conocimientos en:
- Integración de bases de datos con **ORM (Entity Framework)**.  
- Aplicación de principios de **integridad transaccional (ACID)**.  
- Implementación de **autenticación y autorización con ASP.NET Identity** y gestión de roles.  
- Buenas prácticas de **manejo de errores** en entornos productivos.  
- Trabajo con procesos **síncronos y asíncronos**.  

## Instrucciones para ejecutar el proyecto

1. **Clonar el repositorio**  
   ```bash
   git clone [https://github.com/TU_USUARIO/.NET-Entity-Framework.git](https://github.com/Vargas0421/.NET-Entity-Framework)
   cd .NET-Entity-Framework
2. **Configurar la base de datos**

2.1 Abre el archivo Web.config.

2.2 Adapta la cadena de conexión a tu entorno de SQL Server:

connectionString="Data Source={(TU BASE DE DATOS)}; Initial Catalog=ARSCODEX; Integrated Security=True".
         
2.3 Asegúrate de que la base de datos ARSCODEX exista en tu servidor SQL o créala antes de ejecutar el proyecto.

3. **Habilitar registro de errores en el Visor de Eventos**
Ejecuta en PowerShell como administrador el siguiente comando para crear un log personalizado:


*New-EventLog -LogName "ArsCodexLog" -Source "ArsCodexSource"*

Esto permitirá almacenar los errores no controlados del sistema en el Visor de Eventos de Windows, facilitando su monitoreo y diagnóstico.

4. **Agregar roles iniciales a la base de datos**
   
Ejecuta en tu instancia de SQL Server los siguientes comandos para registrar los roles básicos en la tabla AspNetRoles:
sql
Copiar código
INSERT INTO dbo.AspNetRoles (Id, Name) VALUES ('1', 'Administrador');
INSERT INTO dbo.AspNetRoles (Id, Name) VALUES ('2', 'Contador');

**Ejecutar el proyecto**

Abre la solución en Visual Studio.
Compila y ejecuta (F5).

**Posibles problemas comunes**

1. Permisos de PowerShell: si el comando New-EventLog da error, asegúrate de ejecutar PowerShell como administrador.
2. Permisos de SQL Server: si no puedes conectarte, revisa que la autenticación de Windows esté habilitada en tu instancia de SQL Server.
3. Migraciones fallidas: en caso de error con Update-Database, borra la base de datos y vuelve a correr las migraciones.
