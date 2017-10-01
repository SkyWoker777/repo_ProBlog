$(document).ready(function () {
    $("#menu-categories").hide();
    $('#nav-icon').click(function () {
        $(this).toggleClass('open');
        $("#menu-categories").slideToggle("slow");
    });
});

$(document).ready(function () {
    $("#btn-up").click(function up() {
        $("html, body").animate({ scrollTop: 0 }, "slow");
        return false;
    });
    window.onscroll = function myScroll() {
        var toTop = document.querySelector("#btn-up");
        (document.body.scrollTop > 300 || document.documentElement.scrollTop > 300) ?
            toTop.style.display = 'block' : toTop.style.display = 'none';
    }
});