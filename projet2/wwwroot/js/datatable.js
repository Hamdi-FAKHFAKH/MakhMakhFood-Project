var dataTable;
$(document).ready(function () {
    dataTable = $('#myTable').DataTable({
        "ajax": {
            "url": "/api/menuitem",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name" },
            { "data": "description" },
            { "data": "image" },
            { "data": "price" },
            { "data": "food.name" },
            { "data": "categorie.name" },
            {
                "data": "id","width":"20%",
                "render": function (data) {
                    return `<div class="mx-auto">
                                <a href="/menuitem/Upsert?id=${data}" class="btn btn-primary px-4"> <i class="bi bi-pencil-square"></i> </a>
                                <a class="btn btn-danger px-4" onclick="Delete('/api/menuitem?id=${data}')"> <i class="bi bi-trash-fill"></i> </a>
                            </div>`
                }
            },
            
        ],   
    }
    );
});
function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax(
                {
                    url: url,
                    type:"DELETE",
                    success: function (data) {
                        if (data.success) {
                            // succes delete
                            dataTable.ajax.reload();
                            Swal.fire(
                                'Deleted!',
                                'Your file has been deleted.',
                                'success'
                            )
                        }
                        else {
                            toastr.error('delet cancelled')

                        }
                    }
                }

            )




            
        }
    })
}