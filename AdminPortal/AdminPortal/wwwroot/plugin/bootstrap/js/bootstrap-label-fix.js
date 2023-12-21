//id kullanmadığımız için label click'lerini customize ediyoruz
$("label").on("click", function (e) {

    var target = $(e.target);

    var dataFor = $(e.target).attr("data-for");

    var input = target.parent().find("input[name=" + dataFor + "]");

    var type = $(input).attr("type");

    if (type == "text")
        $(input).focus();
    else if (type == "checkbox")
        $(input).click();
});