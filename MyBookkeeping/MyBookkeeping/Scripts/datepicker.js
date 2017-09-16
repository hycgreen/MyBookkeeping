$(function () {
    $("[data-datetimepicker]").pickadate({
        formatSubmit: $(this).attr("data_date_format"),
        hiddenName: true
    });
});
