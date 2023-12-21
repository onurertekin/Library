//$(document).on('shown.bs.modal', '.modal', function () {
//    var firstModalIndex = 1050;
//    $(".modal.show").each(function (index) {
//        $(this).css("z-index", firstModalIndex);
//        firstModalIndex += 20;
//    });
//});


$(".modal").attr("data-bs-backdrop", "static");
$(".modal").attr("data-bs-keyboard", "false");

let modals = []

$(document).keyup(function (e) {
    if ((e.key == 'Escape' || e.key == 'Esc' || e.keyCode == 27) && modals.length) {
        $(".modal[modal='" + modals[modals.length-1] + "']").modal('hide');
    }
})

$(".modal").on("shown.bs.modal", e => {
    const id = modals.length;
    modals.push(id);
    $(e.target).attr("modal", id);
});

$(".modal").on("hidden.bs.modal", e => {
    modals.pop();
});