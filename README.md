
# ApiHexagonalNetV2

Este es un proyecto de API basado en arquitectura hexagonal utilizando .NET y MongoDB Atlas. La API proporciona endpoints para manejar usuarios, tiendas y empleados.

## Clonar el Repositorio

Para clonar este repositorio, asegúrate de tener [Git](https://git-scm.com/) instalado. Ejecuta el siguiente comando en tu terminal:

```bash
git clone https://github.com/AboveAcrobat284/ApiHexagonalNetV2.git
```

## Configuración del Entorno

### Requisitos Previos

Asegúrate de tener instalado:

- [.NET 6 SDK o superior](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MongoDB Atlas](https://www.mongodb.com/cloud/atlas) (o una instancia local de MongoDB)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) o [Visual Studio Code](https://code.visualstudio.com/) con la extensión de C#

### Configurar la Conexión a MongoDB

1. Renombra el archivo `appsettings.Development.json.example` a `appsettings.Development.json`.
2. Edita el archivo `appsettings.Development.json` y configura tu cadena de conexión de MongoDB:

```json
{
  "MongoDBSettings": {
    "ConnectionString": "TU_MONGO_DB_CONNECTION_STRING",
    "DatabaseName": "ApiHexagonalNetV2"
  }
}
```

Reemplaza `"TU_MONGO_DB_CONNECTION_STRING"` con tu cadena de conexión real de MongoDB Atlas.

## Ejecutar la API

Para ejecutar la API, sigue estos pasos:

1. Abre tu terminal o consola en la raíz del proyecto.

2. Restaura las dependencias del proyecto y compílalo:

   ```bash
   dotnet build
   ```

3. Ejecuta la aplicación:

   ```bash
   dotnet run
   ```

La API debería iniciarse y estar disponible en `http://localhost:5020` u otro puerto especificado.

## Realizar Pruebas con Postman

Para realizar pruebas en Postman, sigue estos pasos:

1. **Descarga e instala [Postman](https://www.postman.com/downloads/).**
2. Abre Postman y crea una nueva colección para organizar tus solicitudes.
3. Configura las siguientes solicitudes:

### Consultas para Postman

#### 1. Crear un Usuario

- **Método:** POST
- **URL:** `http://localhost:5020/api/user`
- **Body:**
```json
{
  "name": "John Doe",
  "email": "john.doe@example.com",
  "storeIds": []
}
```

#### 2. Obtener Todos los Usuarios

- **Método:** GET
- **URL:** `http://localhost:5020/api/user`

#### 3. Obtener un Usuario por ID

- **Método:** GET
- **URL:** `http://localhost:5020/api/user/{id}`

#### 4. Obtener Tiendas de un Usuario

- **Método:** GET
- **URL:** `http://localhost:5020/api/user/{id}/stores`

#### 5. Actualizar un Usuario

- **Método:** PUT
- **URL:** `http://localhost:5020/api/user/{id}`
- **Body:**
```json
{
  "id": "66e401da595743eae277dbc9",
  "name": "John Doe Updated",
  "email": "john.doe.updated@example.com",
  "storeIds": ["66e402ca595743eae277dbcf", "66e403ab595743eae277dbd0"]
}
```

#### 6. Eliminar un Usuario

- **Método:** DELETE
- **URL:** `http://localhost:5020/api/user/{id}`

#### 7. Crear una Tienda

- **Método:** POST
- **URL:** `http://localhost:5020/api/store`
- **Body:**
```json
{
  "name": "Flower Shop",
  "location": "123 Garden St, City, Country",
  "userId": "66e401da595743eae277dbc9"
}
```

#### 8. Obtener Todas las Tiendas

- **Método:** GET
- **URL:** `http://localhost:5020/api/store`

#### 9. Obtener una Tienda por ID

- **Método:** GET
- **URL:** `http://localhost:5020/api/store/{id}`

#### 10. Obtener Empleados de una Tienda

- **Método:** GET
- **URL:** `http://localhost:5020/api/employee/store/{storeId}/employees`

#### 11. Actualizar una Tienda

- **Método:** PUT
- **URL:** `http://localhost:5020/api/store/{id}`
- **Body:**
```json
{
  "id": "66e402ca595743eae277dbcf",
  "name": "Updated Flower Shop",
  "location": "456 New Garden St, City, Country",
  "userId": "66e401da595743eae277dbc9"
}
```

#### 12. Eliminar una Tienda

- **Método:** DELETE
- **URL:** `http://localhost:5020/api/store/{id}`

#### 13. Crear un Empleado

- **Método:** POST
- **URL:** `http://localhost:5020/api/employee`
- **Body:**
```json
{
  "name": "Alice Johnson",
  "position": "Sales Associate",
  "storeId": "66e402ca595743eae277dbcf"
}
```

#### 14. Obtener Todos los Empleados

- **Método:** GET
- **URL:** `http://localhost:5020/api/employee`

#### 15. Obtener un Empleado por ID

- **Método:** GET
- **URL:** `http://localhost:5020/api/employee/{id}`

#### 16. Actualizar un Empleado

- **Método:** PUT
- **URL:** `http://localhost:5020/api/employee/{id}`
- **Body:**
```json
{
  "id": "66e403ab595743eae277dbd0",
  "name": "Alice Johnson Updated",
  "position": "Senior Sales Associate",
  "storeId": "66e402ca595743eae277dbcf"
}
```

#### 17. Eliminar un Empleado

- **Método:** DELETE
- **URL:** `http://localhost:5020/api/employee/{id}`

4. **Ejecuta las solicitudes** y verifica las respuestas de la API para asegurarte de que todo funciona correctamente.

## Contribuir

Si deseas contribuir a este proyecto, por favor crea un fork del repositorio, haz tus cambios, y envía un pull request. Agradecemos todas las contribuciones.

## Licencia

Este proyecto está licenciado bajo los términos de la licencia MIT. Consulta el archivo LICENSE para más detalles.
