
$(document).ready(function () {
    GetAllEmp();

});

function GetAllEmp() {
    var empdata = [];
    $.ajax({
        url: '/Employee/GetAll',
        type: 'Get',
        dataType: 'json',
        success: OnSuccess
    })

}
function OnSuccess(response) {
    $('#TblData').DataTable({
        bProcessing: true,
        bLenghtChange: true,
        lenghtMenu: [[6, 10, 25, -10], [6, 10, 25, "All"]],
        bfilter: true,
        bSort: true,
        bPaginate: true,
        data: response,
        columns: [
            {
                data: 'الكود',
                render: function (data, type, row, meta) {
                    return row.emp_code
                }
            },
            {
                data: 'الاسم',
                render: function (data, type, row, meta) {
                    return row.name
                }
            },
            {
                data: 'الرقم القومي',
                render: function (data, type, row, meta) {
                    return row.nat_id
                }
            },
            {
                data: 'تريخ التعين',
                render: function (data, type, row, meta) {
                    return row.hire_date.split("T")[0];
                }
            },
            {
                data: 'الوظيفة',
                render: function (data, type, row, meta) {
                    return row.job.name
                }
            },
            {
                data: 'العملبات',
                render: function (data, type, row, meta) {
                    return "<a class='btn-danger btn btn-sm' id='delete' onclick='remove(" + row.id + ")' asp-controller='Job' asp-action='Delete'/>مسح<a/>" + "<a  onclick='edit(" + row.id + ")' class='btn-primary btn btn-sm' asp-controller='Job' asp-action='Delete'/>تعديل<a/>" +"<a class='btn-primary btn btn-sm' id='delete' onclick='ViewOne(" + row.id + ")' asp-controller='Job' asp-actio btn-smn='Delete'/>عرض<a/>"
                }
            },
            ]
    })
}
function remove(el) {
   
    window.location.href = "/Employee/Delete/" + el;
}
function edit(el) {

    window.location.href = "/Employee/Edit/" + el;
}
function ViewOne(el) {

    window.location.href = "/Employee/viewOne/" + el;
}


