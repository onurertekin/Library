function readFromUrl(key) {
    var urlParams = new URLSearchParams(window.location.search);
    return urlParams.get(key);
}

function goToUrl(url) {
    window.location.href = url;
}

function fillCustomers(selector) {
    $.get('http://localhost:5000/library-api/customers', function (response) {
        $(response.customers).each(function (i, customer) {
            $(selector).append("<option value='" + customer.id + "'>" + customer.name + "</option>");
        });
    });
}

function escapeRegExp(str) {
    return str.replace(/[.*+?^${}()|[\]\\]/g, "\\$&"); // $& means the whole matched string
}

function replaceAll(str, find, replace) {
    return str.replace(new RegExp(escapeRegExp(find), 'g'), replace);
}

function fillBooks(selector) {
    $.get('http://localhost:5000/library-api/books', function (response) {
        $(response.books).each(function (i, book) {
            $(selector).append("<option value='" + book.id + "'>" + book.name + "</option>");
        });
    });
}

function logout() {
    localStorage.removeItem("Token"); //LocalStorage'den Token'ý siliyoruz ki çýkýþ yaptýðýnda tekrardan giriþ istesin.
    window.location.href = "/login";
}


function showPageLoading() {
    $(".page").hide();
    $(".page-loading").show();
}

function hidePageLoading() {
    $(".page-loading").hide();
    $(".page").fadeIn(300);
}

function showModalLoading(modalId) {
    $("#" + modalId + " .modal-body").hide();
    $("#" + modalId + " .modal-footer").hide();
    $("#" + modalId + " .modal-content").append("<div class='modalLoading spinner-border'></div>");
}

function hideModalLoading(modalId) {
    $("#" + modalId + " .modal-body").show();
    $("#" + modalId + " .modal-footer").show();
    $("#" + modalId + " .modalLoading").remove();
}

function generateUUID() { // Public Domain/MIT
    var d = new Date().getTime();//Timestamp
    var d2 = (performance && performance.now && (performance.now() * 1000)) || 0;//Time in microseconds since page-load or 0 if unsupported
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16;//random number between 0 and 16
        if (d > 0) {//Use timestamp until depleted
            r = (d + r) % 16 | 0;
            d = Math.floor(d / 16);
        } else {//Use microseconds since page-load if supported
            r = (d2 + r) % 16 | 0;
            d2 = Math.floor(d2 / 16);
        }
        return (c === 'x' ? r : (r & 0x3 | 0x8)).toString(16);
    });
}

function statusFormatter(value, row, index) {
    //console.log(value);
    //console.log(row);
    //console.log("-----------");
    if (value === 1)
        return '<div class="table-row-status-active">Active</div>';
    else if (value === 2)
        return '<div class="table-row-status-passive">Passive</div>';
}

function dateFormatter(value, row, index) {

    if (value === null)
        return "-";
    else {
        var date = moment(value).locale(currentLanguageCode);
        return "<div class='table-row-date'>" + date.format('Do MMM YYYY') + "</div><div class='table-row-time'>" + date.format('HH:mm') + "</div>";
    }
}
