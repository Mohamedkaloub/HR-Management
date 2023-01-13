
$(document).ready(
    $('#AddSalary').click(
        function () {
            $('#SalaryModal').modal('show')
        }
    ),
    GetAllEmp()
);

function GetAllEmp() {
    var empdata = [];
    var id = $('#empid').val();
    $.ajax({
        url: '/Salary/GetSalary/'+id+'',
        type: 'Get',
        dataType: 'json',
        success: OnSuccess
    })

}
function OnSuccess(response) {
    $('#Salarytable').DataTable({
        bProcessing: true,
        bLenghtChange: true,
        lenghtMenu: [[6, 10, 25, -10], [6, 10, 25, "All"]],
        bfilter: true,
        bSort: true,
        bPaginate: true,
        data: response,
        columns: [
            {
                data: 'المرتب',
                render: function (data, type, row, meta) {
                    return row.total
                }
            },
            {
                data: 'الخصم',
                render: function (data, type, row, meta) {
                    return row.punishment
                }
            },
            {
                data: 'النهائي',
                render: function (data, type, row, meta) {
                    return row.total-row.punishment
                }
            },
            {
                data: 'التاريخ',
                render: function (data, type, row, meta) {
                    
                    return row.time
                }
            },
            {
                data: 'العملبات',
                render: function (data, type, row, meta) {
                    return "<a class='btn-primary btn' onclick='remove(" + row.id + ")' />مسح<a/>" + "<a onclick='edit(" + row.id + ")' class='btn-primary btn' asp-controller='Job'/>تعديل<a/>" 
                }
            },
        ]
    })
}
function remove(el) {

    window.location.href = "/Salary/Delete/" + el;
}
function edit(el) {

    window.location.href = "/Employee/Edit/" + el;
}

$('#SaveSalary').click(
    function () {

        let emp = $('#empid').val();
        let salary = $('#salary').val();
        let p = $('#pun').val();

        $.ajax({
            url: "/Salary/AddJson",
            type: "POST",
            data: { id: emp, p: p, salary: salary },
            dataType: "json",
            success: function () {
                alert("تم الاضافة بنجاح");
            }
        })
    }
);

