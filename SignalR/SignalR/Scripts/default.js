$(function () {
    $('.main-menu').smartmenus({
        popupHide: true,
        markCurrentItem: true,
        showTimeout: 0,
        hideTimeout: 0
    });

    $('#up-menu').smartmenus({
        showTimeout: 0,
        hideTimeout: 0
    });
});

$('#mobile-menu').click(function () {
    $('#nav-mobile').slideToggle();

    if( $('#mobile-menu .fa-reorder').hasClass('active_menu_mobile'))
    {
        $('#mobile-menu .fa-reorder').removeClass('active_menu_mobile');

        $('#mobile-menu .fa-close').addClass('active_menu_mobile');
    }
    else 
    {
        $('#mobile-menu .fa-reorder').addClass('active_menu_mobile');

        $('#mobile-menu .fa-close').removeClass('active_menu_mobile');
    }
});

$('.hts').click(function () {
    $("#popup-nav").toggle("slide");
});

function CheckMenu(url) {
    // Will also work for relative and absolute hrefs
    $('ul.main-menu a').filter(function () {
        return this.href === url;
    }).addClass('current').parent('a').addClass('current');
}

// intial for menumobile
$(document).ready(function () {

    // make select menu item
    var pathname = window.location.pathname;
    $(".pushmenu li a[href='" + pathname + "']").addClass('selected'); // menu mobile

    // fix footer overlay menumobile
    $('div.xMMenu-wrap-left').appendTo('body');
    // end

    $menuLeft = $('.pushmenu-right');
    $nav_list = $('#nav_list');
    $menu_item = $('.pushmenu li a');

    // Click on | > | Mobile Icon => Body push to left a space to show Menu Mobile
    $nav_list.click(function () {
        $('.xMMenu-wrap-left').toggleClass('xMMenu-wrap-left-toogle');
        $(this).toggleClass('active');
    });

    // Click on menu item
    $menu_item.click(function () {
        $(this).parent().toggleClass('active');
    });

    $('.main-menu > li').mouseenter(function () {
        if (!$(this).children('a').hasClass('current')) {
            $('.main-menu > li > a.current').addClass('inactive-highlight');
        }
        
    }).mouseleave(function () {
        $('.main-menu > li > a.inactive-highlight').removeClass('inactive-highlight');
    });

});

// custom paging of PagedList
$(function () {
    $(".PagedList-skipToPrevious > a").html('<i class="fa fa-caret-left"></i>');
    $(".PagedList-skipToNext > a").html('<i class="fa fa-caret-right"></i>');
});

// intial content Menu in Department page
$(function () {

    $('.maincontent .content-menu ul > li').mouseenter(function () {
        if (!$(this).children('a').hasClass('current')) {
            $('.maincontent .content-menu ul > li.selected').addClass('inactive-highlight');
        }
    }).mouseleave(function () {
        $('.maincontent .content-menu ul > li.inactive-highlight').removeClass('inactive-highlight');
    });
});

function rightpostcontent()
{
    $('.mobile-htvp').click(function () {
        if ($(".right-content").hasClass("active-post"))
        {
                 $(".right-content").removeClass("active-post");    
        }
        else
        {
            $(".right-content").addClass("active-post");
        }
        if ($(".mobile-htvp").hasClass("active-htvp")) {
            $(".mobile-htvp").removeClass("active-htvp");
        }
        else {
            $(".mobile-htvp").addClass("active-htvp");
        }


        });
    
}
rightpostcontent();
$('.dropbtn').click(function () {
    if ($(this).hasClass("active")) {
        $(this).parent().removeClass("show-home");
        $(this).removeClass("active");
        // $(this).parent().addClass("show-home");
    }
    else {
        $('.dropbtn').removeClass("active");
        $('.dropbtn').parent().removeClass("show-home");
        $(this).parent().addClass("show-home");
        $(this).addClass("active");
    }

});

// cache scroll to top button
            var b = $('#back-top');
            // Hide scroll top button
            b.hide();
            // FadeIn or FadeOut scroll to top button on scroll
            $(window).on('scroll', function () {
                // if you scroll more then 500px then fadein goto top button
                if ($(this).scrollTop() > 500) {
                    b.fadeIn();
                    // otherwise fadeout button
                } else {
                    b.fadeOut();
                }

            });

//show hotline scroll

            $('#back-top').click(function () {
                if ($(this).hasClass("active_hotline")) {
                    $(this).removeClass("active_hotline");
                    // $(this).parent().addClass("show-home");
                }
                else {
                    $(this).addClass("active_hotline");
                }

            });


            function ChangeUrl(url) {
                if (typeof (history.pushState) != "undefined") {
                    var url1, index = document.URL.indexOf('?');
                    if (index > 0) {
                        url1 = document.URL.substr(0, document.URL.indexOf('/tuyen-dung'));
                    }
                    else
                        url1 = document.URL.substr(0, document.URL.indexOf('/tuyen-dung'));
                    var isFirstAtt = true;
                    url1 += url;

                    history.pushState({}, null, url1);
                }
            }
