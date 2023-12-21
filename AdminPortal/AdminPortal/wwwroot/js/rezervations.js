$(document).ready(function () {
    //Sayfa ilk açıldığında yapılması gereken işlemleri buraya yazın
    $(".topnav #rezervations").addClass("active");
    getRezervations();
});

function getRezervations() {

    showPageLoading();

    var $table = $('table#rezervations');

    $table.bootstrapTable('destroy').bootstrapTable({
        silentSort: false,
        locale: currentLanguageCode,
        url: portalApiEndpoint + '/library-api/rezervations',
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
                    field: 'bookName',
                    title: 'Book Name',
                    sortable: true,
                    class: 'left-aligned pl-10',
                    width: '250px',
                },
                {
                    field: 'customerName',
                    title: 'Customer Name',
                    sortable: true,
                    class: 'left-aligned pl-10'
                },
                {
                    field: 'rezervationStartDate',
                    title: 'Rezervation Start Date',
                    sortable: true,
                    class: 'right-aligned pl-10',
                    width: '150px',
                    formatter: dateFormatter
                },
                {
                    field: 'rezervationEndDate',
                    title: 'Rezervation End Date',
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
                    width: '90px',
                    class: 'right-aligned pr-10 row-action',
                    formatter: tableActionFormatter
                }
            ]
        ]
    });
}


function tableActionFormatter(value, row, index) {

    var template = $("template[id=dataTableActionsTemplate]").html();
    template = replaceAll(template, "#id#", row.id);

    var element = jQuery.parseHTML(template);

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
    res = {
        "total": res.totalCount,
        "rows": res.rezervations
    };
    return res;
}