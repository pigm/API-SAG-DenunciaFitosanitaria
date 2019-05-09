$("sidebar-wrapper").click(function(){
    $("p").hide(1000);
});
$(".chat").mouseover(function(e) {
        e.preventDefault();
        $("#wrapper").show();
});

$(".chat").Mouseout(function(e) {
        e.preventDefault();
        $("#wrapper").hide();
});