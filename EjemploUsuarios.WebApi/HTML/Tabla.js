// Función para llenar la tabla de usuarios
function llenarTablaUsuarios() {
    fetch('http://localhost:5133/usuarios') // Reemplaza con la URL de tu API
        .then(response => response.json())
        .then(data => {
            var tablaUsuarios = document.getElementById("tablaUsuarios");
            data.forEach(usuario => {
                var fila = document.createElement("tr");
                fila.innerHTML = `
                    <td>${usuario.id}</td>
                    <td>${usuario.nombre}</td>
                    <td>${usuario.apellido}</td>
                    <td>${usuario.correoElectronico}</td>
                    <td>${usuario.fechaRegistro}</td>
                    <td>${usuario.activo ? "Sí" : "No"}</td>
                `;
                tablaUsuarios.appendChild(fila);
            });
        })
        .catch(error => {
            console.error('Error al obtener datos:', error);
        });
}

// Llama a la función para llenar la tabla cuando el DOM esté listo
document.addEventListener("DOMContentLoaded", llenarTablaUsuarios);