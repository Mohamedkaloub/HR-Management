
$(document).ready(
    $('#AddAdvance').click(
        function () {
            $('#AdvanceModal').modal('show')
        }
    ),
    GetAllEmp()
);

function GetAllEmp() {
    var empdata = [];
    var id = $('#empid').val();
    $.ajax({
        url: '/Advance/GetAdvance',
        type: 'Get',
        dataType: 'json',
        success: OnSuccess
    })

}
function OnSuccess(response) {
    $('#Advancetable').DataTable({
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
                    return row.employee.emp_code
                }
            },
            {
                data: 'الاسم',
                render: function (data, type, row, meta) {
                    return row.employee.name
                }
            },
            {
                data: 'المبلغ المطلوب',
                render: function (data, type, row, meta) {
                    return row.need
                }
            },
            {
                data: 'المبلغ المصدق',
                render: function (data, type, row, meta) {
                    return row.accept
                }
            },
            {
                data: 'التاريخ',
                render: function (data, type, row, meta) {
                    return row.date
                }
            },
            {
                data: 'العملبات',
                render: function (data, type, row, meta) {
                    return "<a class='btn-primary btn' onclick='remove(" + row.id + ")' />مسح<a/>"
                }
            },
        ]
    })
}
function remove(el) {

    window.location.href = "/Advance/Delete/" + el;
}
function edit(el) {

    window.location.href = "/Employee/Edit/" + el;
}

$('#SaveAdvance').click(
    function () {

        let emp = $('#Ad_code').val();
        let need = $('#Ad_need').val();
        let accept = $('#Ad_accept').val();
      

        $.ajax({
            url: "/Advance/AddJson",
            type: "POST",
            data: { emp: emp, need: need, accept: accept},
            dataType: "json",
            success: function () {
                alert("تم الاضافة بنجاح");
            }
        })
    }
);
$('#Ad_code').change(
    function () {
        let code = $(this).val();
        let x = code;
        $.ajax({
            url: '/Advance/FindName',
            method: "get",
            type: "json",
            data: { code: code },
            success: function (data) {
                $('#Ad_name').val(data)
            }
        })
    }
)
