var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $("#foodTypeTable").DataTable({
        "ajax": {
            "url": "/api/foodtype",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name" },
            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                                        <a href="/Admin/FoodType/Upsert?id=${data}" class="btn btn-info btn-sm">
                                            <i class="fas fa-pencil-alt"></i> Edit
                                        </a>                                       
                                        <a class="btn btn-danger btn-sm" onclick=Delete('/api/foodtype/'+${data})>
                                            <i class="fas fa-trash"></i> Delete
                                        </a>
                                     </div>`;
                }, "width": "30%"
            }
        ],
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
