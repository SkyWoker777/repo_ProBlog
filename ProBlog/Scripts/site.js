$(document).ready(function () {
    $(".menu-categories").hide();
    $('#nav-icon').click(function () {
        $(this).toggleClass('open');
        $(".menu-categories").slideToggle("slow");
    });
});