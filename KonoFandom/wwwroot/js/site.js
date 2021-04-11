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

// Drag and Drop Test
/*$(function () {
    $("#div1").on("dragover", function (e) {
        e.preventDefault();
    });
    $(".drag1").on("dragstart", function (e) {
        e.dataTransfer.setData("text", e.target.id);
    });
    $("#div1").on("drop", function (e) {
        e.preventDefault();
        var data = e.dataTransfer.getData("text");
        e.target.appendChild(document.getElementById(data));
    });
})*/

/*function dragover(e) {
        e.preventDefault();
}
$('#div1, #skill-box').on('dragover', function () { dragover(event) });

function dragstart(e) {
    e.dataTransfer.setData("text", e.target.id);
    //console.log($(this).attr("id"));
}
$('#skill-box').find("img").on('dragstart', function () { dragstart(event) });
$('#div1').find("img").on('dragstart', function () { dragstart(event) });

function drop(e) {
    e.preventDefault();
    var data = e.dataTransfer.getData("text");
    var tgt = document.getElementById("div1");

    console.log(">: " + data);
    console.log(">>: " + e.currentTarget.firstElementChild);
    console.log(">>>: " + document.getElementById(data));
    if (e.target.hasChildNodes()) {
       tgt.replaceChild(document.getElementById(data), tgt.firstElementChild);
    } else {
        tgt.appendChild(document.getElementById(data));
    }

    
    //e.target.appendChild(document.getElementById(data));
}
$('#div1, #skill-box').on('drop', function () { drop(event) });*/

/*$(function () {
    $("#div1").on("dragover", function (e) {
        e.preventDefault();
    });

    $("#skill-box").find("img").on("dragstart", function (e) {
        e.originalEvent.dataTransfer.setData("text", e.target.id);
        console.log($(this).attr("id"));
    });

    $("#div1").on("drop", function (e) {
        e.preventDefault();
*//*        var data = e.originalEvent.dataTransfer.getData("text");

        var test = document.getElementById(e.originalEvent.dataTransfer.getData("text"))

        console.log(">>: " + e.currentTarget.firstElementChild);
        if (e.target.hasChildNodes()) {
            e.currentTarget.replaceChild(test, e.currentTarget.firstElementChild);
        }
        
        e.target.appendChild(document.getElementById(data));*//*

        var data = e.originalEvent.dataTransfer.getData("text");

        console.log(">>: " + data);
        console.log(">>: " + e.currentTarget.firstElementChild);
        if (e.target.hasChildNodes()) {
            e.currentTarget.removeChild(e.currentTarget.firstElementChild)
            //e.currentTarget.replaceChild(document.getElementById(data), e.currentTarget.child);
        }

        e.target.appendChild(document.getElementById(data));
   
    });
})*/

$(function () {
    var $skillGallery = $("#skill-gallery"),
        $div1 = $("#div1");

    // Let skill gallery and div1 items be draggable
    $("#skill-gallery img, #div1 img").draggable({
        revert: "invalid",
        helper: "clone",
        cursor: "move"
    });

    // Let div1 be droppable accepting skill gallery items
    $div1.droppable({
        accept: "#skill-gallery > img",
        drop: function (event, ui) {
            //addSkill(ui.draggable);
            var $item = ui.draggable;

            if ($(this).children().length > 0) {
                var move = $(this).children().detach();
                $item.parent().append(move);
            }

            $item.fadeOut(function () {
                $item.appendTo($div1).fadeIn(function () {
                    $item.find("img");
                });
            });

            console.log($(this));
            console.log($item);

        }
    });

    // Let skill gallery be droppable accepting added skills from div1
    $skillGallery.droppable({
        accept: "#div1 > img",
        drop: function (event, ui) {
            removeSkill(ui.draggable);
        }
    });

    // Add skill to div1
    function addSkill($item) {

        if ($(this).children().length > 0) {
            var move = $(this).children().detach();
            $item.parent().append(move);
        }

        $item.fadeOut(function () {
            $item.appendTo($div1).fadeIn(function () {
                $item.find("img");
            });
        });

        console.log($(this));
        console.log($item);
    }

    // Add skill to skill gallery
    function removeSkill($item) {
        $item.fadeOut(function () {
            $item.appendTo($skillGallery).fadeIn(function () {
                $item.find("img");
            });
        });
    }
    //console.log($(this).attr("id"));
});