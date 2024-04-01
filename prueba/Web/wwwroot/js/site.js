function iniciar() {


    // Realizar la solicitud Ajax para cargar el Partial View
    $.ajax({
        url: '/Home/Iniciar', // Reemplaza "ActionName" y "ControllerName" por el nombre de la acción y controlador que devuelve el Partial View
        type: 'GET',
        success: function (result) {
            $("#partialViewContainer").html(result);
        },
        error: function (xhr, status, error) {
            // Manejar errores si la solicitud falla
            console.error("Error al cargar Partial View:", error);
        }
    });
}
