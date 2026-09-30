# Guía de instalación de HelpDesk Lite

Aplicación local de portafolio para gestionar tickets de soporte.

## Requisitos

.NET 10 SDK y SQL Server Express con autenticación de Windows. Abrí HelpDeskLite.sln en Visual Studio o usá la terminal.

## Primera ejecución

La configuración de ejemplo usa SQL Server Express local y la base HelpDeskLitePortfolioDb. Podés definir otra conexión desde la terminal:

```powershell
$env:ConnectionStrings__DefaultConnection='Server=.\SQLEXPRESS;Database=HelpDeskLitePortfolioDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true'
dotnet restore
dotnet build --no-restore
dotnet run --project HelpDeskLite --launch-profile https
```

Confirmá primero que tu instancia de SQL Server sea .\SQLEXPRESS. Si usás otra, cambiá el servidor de la conexión. La variable de entorno debe establecerse en la misma terminal donde ejecutás el proyecto.

Al iniciar, el programa aplica la migración incluida. No ejecutés Add-Migration InitialCreate: esa migración ya está en el proyecto. La cuenta de Windows debe tener permisos para crear la base y sus tablas.

Si la conexión falla, revisá el nombre de la instancia, que el servicio esté iniciado y que puedas conectarte desde SQL Server Management Studio. Si aparece un problema con el certificado HTTPS local, revisá su configuración en Visual Studio.

## Comprobación manual pendiente

Con datos ficticios: crear un ticket, buscarlo, filtrar por estado y prioridad, editarlo, resolverlo y comprobar el dashboard. Abrir un mismo ticket en dos pestañas y comprobar el aviso de edición simultánea. Finalmente, eliminar un ticket de prueba.

El programa todavía no tiene autenticación ni roles. Esta copia es para pruebas locales y preparación del portafolio.
