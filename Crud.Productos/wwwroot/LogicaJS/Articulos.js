var dataTable;
$(document).ready(function () {
    cargarDatatable();
});


function cargarDatatable() {
    debugger;
    dataTable = $("#tblArticulos").DataTable({
        "ajax": {
            "url": "Articulos/GetList",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "nombre", "width": "15%" },
            { "data": "descripcion", "width": "20%" },
            { "data": "fechaCreacion", "width": "20%" },
            { "data": "nombreCategoria", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href='/Articulos/Edit/${data}' class='btn btn-primary text-white'  width:30px;'>
                                <i class='bx bxs-edit'></i>
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Articulos/Delete/${data}") class='btn btn-danger text-white'  width:50px;'>
                                <i class='bx bxs-trash'></i>
                                </a>
                                `;
                }, "width": "10%"
            }
        ],
        "language": {
            "emptyTable": "No hay registros"
        },
        "width": "100%"
    });
}
function Delete(url) {
    Swal.fire({
        title: 'Esta seguro de eliminar este registro?',
        text: "este contenido no se podra recuperar!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, Eliminar!'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (Response) {
                    var JsonString = JSON.stringify(Response);
                    var objetoJosn = JSON.parse(JsonString);
                    if (objetoJosn.isSuccess) {
                        toastr.success(objetoJosn.mensaje);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(objetoJosn.mensaje);
                    }
                }
            });
        } else {
        }
    })
}




//Inicio cargando Imagen en contenerdor
var FileImege = document.getElementById("UrlImagen");

var contenedorFoto = document.getElementById("ContenedorImagen");

  FileImege.onchange = function () {
    var Files = FileImege.files[0];
    var reader = new FileReader();
    reader.onloadend = function () {
        contenedorFoto.src = reader.result;
    }
    reader.readAsDataURL(Files);
   
}
        // Fin cargando Imagen en contenerdor
