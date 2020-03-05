var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $("#menuTable").DataTable({
        "ajax": {
            "url": "/api/MenuItem",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name" },
            { "data": "price" },
            { "data": "category.name" },
            { "data": "foodType.name" },
            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                                        <a href="/Admin/MenuItem/Upsert?id=${data}" class="btn btn-info btn-sm">
                                            <i class="fas fa-pencil-alt"></i> Edit
                                        </a>                                       
                                        <a class="btn btn-danger btn-sm" onclick=Delete('/api/MenuItem/'+${data})>
                                            <i class="fas fa-trash"></i> Delete
                                        </a>
                                     </div>`;
                }, "width": "30%"
            }
        ],
        "width": "100%",
        "order": [[2, "asc"]]
    });
};

function Delete(url) {
    Swal.fire({
        title: 'Are you sure you want to Delete?',
        text: "You will not be able to restore the data!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((willDelete) => {
        if (willDelete.value) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}
