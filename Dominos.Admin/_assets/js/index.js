$(document).ready(function () {


  $(".promo .owl-carousel").owlCarousel({

    loop: true,
    nav: false,
    items: 1,
    smartSpeed: 1000,
    responsiveClass: true,
    autoplay: true,
    autoplayTimeout: 1000,
    autoplayHoverPause: true,
    dots: true


  });


  $(".slider .owl-carousel").owlCarousel({

    animateOut: 'fadeOut',
    animateIn: 'fadeIn',
    loop: true,
    nav: false,
    items: 1,
    smartSpeed: 450,
    responsiveClass: true,
    autoplay: true,
    autoplayTimeout: 1000,
    autoplayHoverPause: true,
    dots: true


  });

});


