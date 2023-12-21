////Horizontal scroll çıktığı an mobile mode'a dönüştürüyorum.
////Sabit bir ekran boyutu yok. Sadece sığmadığı an mobile mode'a dönüşüyor.

//$(window).resize(function () {

//    bootstrapTableMobileCheck();
//});

//function bootstrapTableMobileCheck() {

//    var mobileMode = $(".fixed-table-container").hasClass("has-card-view");
//    var mobileModeMaxWidth = $('.fixed-table-body').attr("mobile-mode-max-width");

//    if ($('.fixed-table-body').hasScrollBarX() === true && mobileMode === false) {
//        $('.fixed-table-body').attr("mobile-mode-max-width", $(window).width());
//        $table.bootstrapTable('toggleView');
//    }
//    else if ($(window).width() > mobileModeMaxWidth && mobileMode === true) {
//        $table.bootstrapTable('toggleView');
//    }
//}



$(document).ready(function () {

    $.extend($.fn.bootstrapTable.defaults, {
        onPostHeader: function (elem, arg1) {

            var tblId = $(this)[0].itemid;
            var queryp = $(this)[0].queryParams;

            $(this)[0].queryParams = function (params) {

                if ($(this).data("queryParams") == null)
                    $(this).data("queryParams", queryp);

                var execResult = window[$(this).data("queryParams")](params);

                var options = $(this).bootstrapTable('getOptions')

                if (!options[0].pagination) {
                    execResult.pageSize = 100;
                    execResult.pageNumber = 1;
                }

                execResult.pagination = options[0].pagination;

                return execResult;
            };

            var modal = $("#" + tblId).closest(".modal");
            if (modal.length) {
                $(modal).on('show.bs.modal', function (event) {
                    if (tblId != null) {
                        PrepareToolbar(tblId);
                    }
                });
            }
            else {
                $(document).ready(function () {
                    if (tblId != null) {
                        PrepareToolbar(tblId);
                    }
                });
            }
        }
    });
});

function PrepareToolbar(tblId) {
    var pageToolbar = SearchParentsForElement("#" + tblId, ".page-toolbar").first();
    var toolbar = SearchParentsForElement("#" + tblId, ".fixed-table-toolbar").first();

    if (pageToolbar.find(".fixed-table-toolbar").length == 0) {
        toolbar.appendTo(pageToolbar);
        toolbar.show();
    }

    pageToolbar.find(".fixed-table-toolbar .btn").removeAttr("disabled")
}

function SearchParentsForElement(elem, searchElem) {
    var parentelems = $(elem).parents();

    var parentCount = parentelems.length;

    for (var k = 0; k < parentCount - 1; k++) {
        var findElem = parentelems.eq(k).find(searchElem);
        if (findElem.length > 0) {
            return findElem;
        }
    }

    return null;
}