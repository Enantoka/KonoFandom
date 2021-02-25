// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/******************* 
    Navigation Bar
********************/

// Indicate selected link from menu
$(function () {
    var url = window.location.href;
    $(".navbar .navbar-nav .nav-item .nav-link").each(function () {
        if (url == this.href) {
            $(this).closest(".nav-link").addClass("active");
        }
    });
})

/****************
    Admin Page
****************/
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
var rarity = []; // Rarity filter

$(function () {
    dt = $('#sortableTable').DataTable({
        "paging": false,
        "autoWidth" : false,
        "dom": 'lrt',
        "columnDefs": [
            // Skills column
            {
                "targets": [-4, -3, -2, -1],
                "orderable": false
            }
        ]
    });

    $.fn.dataTable.ext.search.push(
        function (settings, searchData, dataIndex) {

            var row = dt
                .row(dataIndex)
                .nodes();

            // Filter rows with selected character and rarity
            if (character.length > 0 && rarity.length > 0) {
                if (character.indexOf($(row).data('chara').toString()) > -1 && rarity.indexOf($(row).data('rarity').toString()) > -1) {
                    return true;
                }
            }
            // Filter rows with selected character
            else if (character.length > 0) {
                if (character.indexOf($(row).data('chara').toString()) > -1) {
                    return true;
                }
            }
            // Filter rows with selected rarity
            else if (rarity.length > 0) {
                if (rarity.indexOf($(row).data('rarity').toString()) > -1) {
                    return true;
                }
            }

            // No filter, show all rows
            if (character.length == 0 && rarity.length == 0) {
                return true;
            }
        });
})

// Create array with selected characters
function characterFilter() {
    character = $('input:checkbox[name="chara_group"]:checked').map(function () {
        return $(this).val();
    }).get();

    dt.draw();
}
$('.character-checkbox-filter').on('change', function () { characterFilter() });

// Create array and filter by element
function elementFilter() {
    element = $('input:checkbox[name="ele_group"]:checked').map(function () {
        return '^' + $(this).val() + '$';
    }).get().join('|'); 

    dt.column(1).search(element, true, false).draw();
}
$('.element-checkbox-filter').on('change', function () { elementFilter() });

// Create array with selected rarity
function rarityFilter() {
    rarity = $('input:checkbox[name="rarity_group"]:checked').map(function () {
        return $(this).val();
    }).get();

    dt.draw();
}
$('.rarity-checkbox-filter').on('change', function () { rarityFilter() });

// Change opactiy of img to 1
function fadeFilter(label) {

    if ($(label).hasClass('fade-filter')) {
        $(label).removeClass('fade-filter');
    } else {
        $(label).addClass('fade-filter');
    }
}
$('.character-checkbox-filter label').on('click', function () { fadeFilter(this) });
$('.element-checkbox-filter label').on('click', function () { fadeFilter(this) });
$('.rarity-checkbox-filter label').on('click', function () { fadeFilter(this) });

// ----------------------------

// Tooltips
$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})
