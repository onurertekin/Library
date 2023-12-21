$(document).ready(function () {
    //Sayfa ilk açıldığında yapılması gereken işlemleri buraya yazın
    $(".topnav #books").addClass("active");
    getBooks();
});

function getBooks() {

    showPageLoading();

    var $table = $('table#books');

    $table.bootstrapTable('destroy').bootstrapTable({
        silentSort: false,
        locale: currentLanguageCode,
        url: portalApiEndpoint + '/library-api/books',
        ajaxOptions: {
            headers: {
                'Token': localStorage.getItem('token'),
                'X-Correlation-Id': generateUUID(),
                'Accept-Language': currentLanguageCode
            }
        },
        onLoadSuccess: function (data) {
            hidePageLoading();
        },
        onLoadError: function (status, xhr) {
            //notify('Error', errorMessagesBeautifier(xhr.status, xhr.responseText), 'error');
        },
        formatLoadingMessage: function () {
            return '<div class="spinner-border"></div>';
        },
        columns: [
            [
                {
                    field: 'name',
                    title: 'Name',
                    sortable: true,
                    class: 'left-aligned pl-10',
                    formatter: firstNameFormatter
                },
                {
                    field: 'createdOn',
                    title: 'Created On',
                    sortable: true,
                    class: 'right-aligned pl-10',
                    width: '150px',
                    formatter: dateFormatter
                },
                {
                    field: 'updatedOn',
                    title: 'Updated On',
                    sortable: true,
                    class: 'right-aligned pl-10',
                    width: '150px',
                    formatter: dateFormatter
                },
                {
                    field: 'status',
                    title: 'Status',
                    sortable: true,
                    class: 'right-aligned pl-10',
                    width: '100px',
                    formatter: statusFormatter
                },
                {
                    field: "id",
                    title: "",
                    width: '75px',
                    class: 'right-aligned pr-10 row-action',
                    formatter: tableActionFormatter
                }
            ]
        ]
    });
}

function firstNameFormatter(value, row, index) {
    return "<div class='fw500'>" + row.name + "</div><div> <span>ISBN : </span>" + row.isbn + "</div><div> <span>Page Count : </span>" + row.pageCount + "</div>";
}

function tableActionFormatter(value, row, index) {

    var template = $("template[id=dataTableActionsTemplate]").html();
    template = replaceAll(template, "#id#", row.id);

    var element = jQuery.parseHTML(template);
    //console.log(row.status);
    if (row.status === 2) {
        $(element).find(".dropdown-menu li a[tag=deactivate]").addClass("disabled");
    }
    else {
        $(element).find(".dropdown-menu li a[tag=activate]").addClass("disabled");
    }
    //console.log(element[1].outerHTML);
    return element[1].outerHTML;
}

function queryParams(params) {

    return {
        pageSize: params.limit,
        pageNumber: (parseInt(params.offset) / params.limit) + 1,
        sortBy: params.sort,
        sortDirection: params.order
    };
}

function responseHandler(res) {
    //console.log(res.totalCount);
    res = {
        "total": res.totalCount,
        "rows": res.books
    };
    return res;
}
