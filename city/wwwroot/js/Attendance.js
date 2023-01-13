
$(document).ready(
    $('#AddAttendance').click(
        function () {
            $('#AttendanceModal').modal('show')
        }
    ),
    GetAllEmp()
);

function GetAllEmp() {
    var empdata = [];
    var id = $('#empid').val();
    $.ajax({
        url: '/Attendance/GetAttendance/'+id+'',
        type: 'Get',
        dataType: 'json',
        success: OnSuccess
    })

}
function OnSuccess(response) {
    $('#Attendancetable').DataTable({
        bProcessing: true,
        bLenghtChange: true,
        lenghtMenu: [[6, 10, 25, -10], [6, 10, 25, "All"]],
        bfilter: true,
        bSort: true,
        bPaginate: true,
        data: response,
        columns: [
            {
                data: 'التاريخ',
                render: function (data, type, row, meta) {
                    return row.start_day
                }
            },
            {
                data: 'عدد الايام',
                render: function (data, type, row, meta) {
                    return row.days
                }
            },
            {
                data: 'نوع الاجازة',
                render: function (data, type, row, meta) {
                    return row.type
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

    window.location.href = "/Attendance/Delete/" + el;
}
function edit(el) {

    window.location.href = "/Employee/Edit/" + el;
}

$('#SaveAttendance').click(
    function () {

        let emp = $('#empid').val();
        let date = $('#Atdate').val();
        let days = $('#Atdays').val();
        let type = $('#Attype').val();

        $.ajax({
            url: "/Attendance/AddJson",
            type: "POST",
            data: { emp: emp, date: date, days: days, type: type },
            dataType: "json",
            success: function () {
                alert("تم الاضافة بنجاح");
            }
        })
    }
);

