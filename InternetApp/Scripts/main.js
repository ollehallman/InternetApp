$(document).ready(function () {
    $("#accountSubmitBtn").on('click', function (e) {
        var r = confirm("Are you sure you want to save?");
        if (r == true) {
            // If ok
        }
        else {
            // If cancel
            e.preventDefault(); // prevents default
            return false; // This too
        }
    });

    $('input[type=submit], input[type=button], button').addClass('btn');
    $('input[type=submit], input[type=button], button').addClass('btn-default');
    $('input[type=text], input[type=number]').addClass('form-control');
    $('input[type=text], input[type=number]').addClass('input-field-size');
    

    $(document).on('change', '#skill-lvl-filter', function (e) {
        console.log("." + this.options[e.target.selectedIndex].text);
        $("#project-table").find("tr:not(.column-names)").hide();
        $('.' + this.options[e.target.selectedIndex].text).show();
    });
});