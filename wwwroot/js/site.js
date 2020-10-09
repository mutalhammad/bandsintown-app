// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// updated 2019
//const input = document.getElementById("search-input");
//const searchBtn = document.getElementById("search-btn");

//const expand = () => {
//    searchBtn.classList.toggle("close");
//    input.classList.toggle("square");
//};

//searchBtn.addEventListener("click", expand);


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





//  old version / jquery
//
// function expand() {
//   $(".search").toggleClass("close");
//   $(".input").toggleClass("square");
//   if ($('.search').hasClass('close')) {
//     $('input').focus();
//   } else {
//     $('input').blur();
//   }
// }
// $('button').on('click', expand);
//
