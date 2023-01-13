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
                    return row.hire_date
                }
            },
            {
                data: 'الوظيفة',
                render: function (data, type, row, meta) {
                    return row.job
                }
            },
            {
                data: 'العملبات',
                render: function (data, type, row, meta) {
                    return "123"
                }
            },
    })
}


