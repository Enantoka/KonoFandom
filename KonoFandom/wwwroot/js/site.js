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


// DataTable for CardIndex Page
// ----------------------------
// Define variables
var dt; // DataTable
var character = []; // Character filter
var element = []; // Element filter

$(function () {
    dt = $('#sortableTable').DataTable({
        "paging": false,
        "columnDefs": [
            // Skills column
            {
                "targets": [-4, -3, -2, -1],
                "width": 50,
                "orderable": false
            },
            // Rarity, stats and resistance column
            {
                "targets": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17],
                "width": 50
            },
            // Name column
            {
                "targets": 0,
                "width": 250
            }
        ],
        "dom": 'lrt'
    });

    $.fn.dataTable.ext.search.push(
        function (settings, searchData, dataIndex) {

            var row = dt
                .row(dataIndex)
                .nodes();

            // Show rows of selected character or when none are selected
            if (character.length > 0) {
                for (c of character) {
                    if ($(row).data('chara') == c) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            } else {
                return true;
            }
        });
})

// Filter by character
function characterFilter() {
    character = $('input:checkbox[name="chara_group"]:checked').map(function () {
        return $(this).val();
    }).get();

    //var dt = $('#sortableTable').DataTable();
    dt.draw();
}
$('.character-checkbox-filter').on('change', function () { characterFilter() });

// Filter by element
function elementFilter() {
    element = $('input:checkbox[name="ele_group"]:checked').map(function () {
        return '^' + $(this).val() + '$';
    }).get().join('|'); 

    //var dt = $('#sortableTable').DataTable();
    dt.column(1).search(element, true, false).draw();
}
$('.element-checkbox-filter').on('change', function () { elementFilter() });

// Change opactiy of img to 1
function fadeFilter(label) {

    if ($(label).hasClass('fade-filter')) {
        $(label).removeClass('fade-filter');
    } else {
        $(label).addClass('fade-filter');
    }
}
$('.element-checkbox-filter label').on('click', function () { fadeFilter(this) });

// ----------------------------

// Tooltips
$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})
