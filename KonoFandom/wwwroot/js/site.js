// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/******************* 
    Navigation Bar
********************/
// Indicate selected link from menu
$(function () {
    var url = window.location.href;
    var links = ["Characters", "Cards"];

    links.forEach(function (link) {
        if (url.includes(link)) {
            $('.navbar .navbar-nav .nav-item .' + link.toLowerCase() + "-link").addClass('active');
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

// Drag and Drop
$(function () {
    // Let skill-gallery and passive-skill items be draggable
    $("#passive-skill-gallery img, #passive-skill img, " +
        "#basic-skill-gallery img, #basic-one img").draggable({
        revert: "invalid",
        helper: "clone",
        cursor: "move"
    });

    // Let passive-skill-gallery be droppable accepting passive-skill items
    $("#passive-skill-gallery").droppable({
        accept: "#passive-skill > img",
        drop: function (event, ui) {
            var item = $(ui.draggable),
                droppable = $(this);

            // Sort the item dropped
            sortReturnedSkill(droppable,item);

            // Clear the input value in passive-skill
            var inputElement = item.parent().parent().children("input");
            if (inputElement !== undefined) {
                inputElement.val("");
            }
        }
    });

    // Let passive skill be droppable accepting skill gallery items
    $("#passive-skill").droppable({
        accept: "#passive-skill-gallery > img",
        drop: function (event, ui) {
            var item = $(ui.draggable),
                droppable = $(this);

            addSkill(droppable, item);
            sortReplacedSkill(droppable, item);

            // Update the input value in passive-skill
            var inputElement = droppable.parent().children("input");
            if (inputElement !== undefined) {
                inputElement.val(item.attr("id"));
            }
        }
    });

    // Let basic-skill-gallery be droppable accepting basic-skill items
    $("#basic-skill-gallery").droppable({
        accept: "#basic-one > img, " +
            "#basic-two > img, " +
            "#basic-three > img",
        drop: function (event, ui) {
            var item = $(ui.draggable),
                droppable = $(this);

            // Sort the item dropped
            sortReturnedSkill(droppable, item);

            // Clear the input value in passive-skill
            var inputElement = item.parent().parent().children("input");
            if (inputElement !== undefined) {
                inputElement.val("");
            }
        }
    });

    // Let basic-skill be droppable accepting basic-skill-gallery items
    $("#basic-one, #basic-two, #basic-three").droppable({
        accept: "#basic-skill-gallery > img, " +
            "#basic-one > img, " +
            "#basic-two > img, " + 
            "#basic-three > img",
        drop: function (event, ui) {
            var item = $(ui.draggable),
                droppable = $(this),
                inputElement,
                basicAttributeId;

            addSkill(droppable, item);

            // Swap the input value when switching between basic skills 
            inputElement = item.parent().parent().children("input");
            basicAttributeId = droppable.children("img").attr("id");
            if (inputElement !== undefined) {
                inputElement.val(basicAttributeId);
            }

            sortReplacedSkill(droppable, item);

            // Update the input value in basic-skill
            inputElement = droppable.parent().children("input");
            basicAttributeId = item.attr("id");
            if (inputElement !== undefined) {
                inputElement.val(basicAttributeId);
            }
        }
    });

    // Add skill to the droppable
    function addSkill(droppable, item) {
        item.fadeOut(function () {
            item.appendTo(droppable).fadeIn(function () {
                item.find("img");
            });
        });
    }

    // Sort the item replaced in the droppable
    function sortReplacedSkill(droppable, item) {
        if (droppable.children().length > 0) {

            // Replace item in the droppable with dropped item
            var replace = droppable.children().detach();
            item.parent().append(replace);

            // Sort the items
            var list = item.parent().children("img");
            item.parent().append(list.sort(sortByNameThenTitle));
        }
    }

    // Sort the skill returned to the droppable
    function sortReturnedSkill(droppable, item) {
        item.fadeOut(function () {

            // Append the returned item to the droppable
            item.appendTo(droppable).fadeIn(function () {
                item.find("img");
            });

            // Sort the items
            var list = item.parent().children();
            droppable.append(list.sort(sortByNameThenTitle));
        });
    }

    function sortByNameThenTitle(a, b) {
        if ($(a).data("name") === $(b).data("name")) {
            a = $(a).attr("title");
            b = $(b).attr("title");
            return (a > b ? 1 : -1);
        }

        a = $(a).data("name");
        b = $(b).data("name");
        return (a > b ? 1 : -1);
    }
});