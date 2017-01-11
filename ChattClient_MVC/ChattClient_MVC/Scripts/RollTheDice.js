$(document).ready(function () {
    $("#btn").click(function () {
        $.ajax({
            type: "GET",
            url: "/Home/RollTheDice",
            success: function (numberOnDice) {
                document.getElementById("diceResult").innerHTML = "Result: " + numberOnDice;
            },
        });
    });
});