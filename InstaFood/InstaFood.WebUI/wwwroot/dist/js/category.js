var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $("#categoryTable").DataTable({
        "ajax": {
            "url": "/api/category",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name" },
            { "data": "displayOrder" },
            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                                        <a href="/Admin/Category/Upsert?id=${data}" class="btn btn-info btn-sm">
                                            <i class="fas fa-pencil-alt"></i> Edit
                                        </a>                                       
                                        <a class="btn btn-danger btn-sm" onclick=Delete('/api/category/'+${data})>
                                            <i class="fas fa-trash"></i> Delete
                                        </a>
                                     </div>`;
                }, "width": "30%"
            }
        ],
    });
};

function Delete(url) {

}