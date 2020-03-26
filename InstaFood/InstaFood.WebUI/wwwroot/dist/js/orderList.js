var dataTable;

$(document).ready(function () {
    var url = window.location.search;

    if (url.includes("Cancelled")) {
        loadList("Cancelled");
    }
    else if (url.includes("Completed")) {
        loadList("Completed");
    }
    else {
        loadList("")
    }
});

function loadList(param) {
    dataTable = $("#orderListTable").DataTable({
        "ajax": {
            "url": "/api/order?status=" + param,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "orderHeader.id" },
            { "data": "orderHeader.pickUpName" },
            { "data": "orderHeader.applicationUser.email" },
            { "data": "orderHeader.orderTotal" },
            {
                "data": "orderHeader.id",
                "render": function (data) {
                    return ` <div class="text-center">
                                        <a href="/Admin/Order/OrderDetails?id=${data}" class="btn btn-info btn-sm">
                                            <i class="fas fa-pencil-alt"></i> Details
                                        </a>                                       
                                     </div>`;
                }, "width": "30%"
            }
        ],
    });
};