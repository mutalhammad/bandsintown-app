
var showLoader = function (form) {
    $("<div />").css({
        'position': 'fixed',
        'left': 0,
        'right': 0,
        'bottom': 0,
        'top': 0,
        'background': 'grey',
        'z-index': '99',
        'text-align': 'center',
        'opacity':0.5



    }).appendTo($("body"))
        .append(
            $("<img />").attr("src", "/images/loader.gif")
        );
}
