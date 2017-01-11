$(document).ready(function () {
    $("#quoteBtn").click(function () {
        $.ajax({
            type: "GET",
            url: "/Home/GetQuote",
            success: function (quote) {
                document.getElementById("quote").innerHTML = quote;
            },
        });
    });
});