var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $("#userTable").DataTable({
        "ajax": {
            "url": "/api/user",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "fullName" },
            { "data": "email" },
            { "data": "phoneNumber" },
            {
                "data": {id:"id",lockoutEnd:"lockoutEnd"},
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();

                    if (lockout > today) {
                        //Current user is locked
                        return `<div class="text-center">
                                       <a class="btn btn-warning btn-sm" onclick=LockUnlock('${data.id}')>
                                           <i class="fas fa-lock-open"></i> Unlock
                                       </a>
                                </div>`
                    }
                    else {
                        //Current user is unlocked
                        return `<div class="text-center">
                                       <a class="btn btn-danger btn-sm" onclick=LockUnlock('${data.id}')>
                                           <i class="fas fa-lock"></i> Lock
                                       </a>
                                </div>`
                    }
                }, "width": "30%"
            }
        ],
    });
};

function LockUnlock(id) {
    $.ajax({
        type: 'POST',
        url: '/api/user',
        data: JSON.stringify(id),
        contentType: "application/json",
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
