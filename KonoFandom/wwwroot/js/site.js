// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function viewDetails(element) {
    var dataAttribute = $(element).data('action');

    if (dataAttribute == null) {
        var url = $(element).parent().data('url');
        window.location = url;
    }
}
$('#index tbody tr td').click( function () {viewDetails(this) });


// DataTable
var otable;

$(function () {

    otable = $('#sortableTable').DataTable({
        "paging": false,
        "columnDefs": [
            {
                "targets": [-2, -1],
                "orderable": false
            }
        ]
    });
})

function myFilter() {
    var element = $('input:checkbox[name="ele_group"]:checked').map(function () {
        return '^' + $(this).val() + '$';
    }).get().join('|');

    otable.column(1).search(element, true, false).draw();
    
    
}
$('div.element-checkbox-filter').on('click', function () { myFilter() });