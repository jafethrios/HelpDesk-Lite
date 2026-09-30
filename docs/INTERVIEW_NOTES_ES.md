# Cómo explicar HelpDesk Lite en una entrevista

## Respuesta de 30 segundos

“HelpDesk Lite es una aplicación web que desarrollé para practicar el flujo básico de soporte técnico. Permite registrar incidencias, asignarles prioridad y estado, buscar tickets y dar seguimiento a las fechas de creación, actualización y resolución. La construí con C#, ASP.NET Core MVC, Entity Framework Core y SQL Server.”

## Problema que resuelve

Evita que las incidencias queden dispersas en mensajes o notas. Centraliza la información y permite saber qué casos están abiertos, en progreso o resueltos.

## Decisiones técnicas

- MVC separa la interfaz, la lógica de control y los datos.
- Entity Framework Core permite trabajar con SQL Server mediante entidades de C#.
- Los `enum` representan las prioridades y los estados disponibles; la validación de valores recibidos también debe comprobarse en el servidor.
- La validación evita guardar tickets incompletos.
- `RowVersion` ayuda a detectar ediciones simultáneas.

## Lo que aprendí

- Diseñar un alcance pequeño antes de programar.
- Modelar una entidad y sus reglas.
- Implementar CRUD con validación.
- Filtrar y consultar datos con LINQ.
- Documentar un proyecto para que otra persona pueda ejecutarlo.

## Próximo paso

Agregar autenticación, roles, asignación de técnicos, comentarios e historial de cambios.
