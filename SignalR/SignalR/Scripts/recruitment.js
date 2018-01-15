$(document).ready(function () {

    $('#paging_recruitment a').mousedown(function (event) {
        if (event.which === 1) {
            //event.preventDefault();
            var url = $(this).attr('href');
            //alert(url);
            //ChangeUrl(url);
            history.pushState({}, null, url);
        }
    });

    // cache scroll to top button
    var b = $('#back_top_recruitment');
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

    // Animated smooth go to top
    b.on('click', function () {
        $('html,body').animate({
            scrollTop: 0
        }, 500);
        return false;
    });

    $('#UserFilterFormLeft').submit(function (event) {
        var submitdataleft = "/tuyen-dung?" + $('#UserFilterFormLeft').serialize();
        ChangeUrl(submitdataleft);

    });
  
    function ShowFilterLeft() {
        $('.filter_recruitment_check').slideToggle();
    }



    $('.search_recruitment_bt').click(function (event) {

        var submitData = { searchString: $('#searchString').val(), filterCity: $('#cityFilter').val(), filterFieldWork: $('#fieldWorkFilter').val() };
        ChangeUrlWithObject(submitData);
    });

    var $filterSelect = $('#fieldWorkFilter').select2({
        language: '@Request.Cookies["lang"].Value.Substring(0, 2)'
    });

    $filterSelect.data('select2').$selection.addClass("filter-input");
    $filterSelect.data('select2').$dropdown.addClass("filter-dropdown_container");

    var $filterCity = $('#cityFilter').select2({
        language: '@Request.Cookies["lang"].Value.Substring(0, 2)'
    });
    $filterCity.data('select2').$selection.addClass("filter-input");
    $filterCity.data('select2').$dropdown.addClass("filter-dropdown_container");

    //set height of menu recruitment
    if ($(window).width() > 769) {
        var result = $(".form_recruitment").height();
        var height_of_left_filter = $("#title_recruitment_height").height();
        var height_of_order_recruitment = $("#live_order_recruitment_height").height();

        if (height_of_left_filter < result) {
            document.getElementById("title_recruitment_height").setAttribute("style", "height:" + result + "px");
        }

        if (height_of_order_recruitment < result) {
            document.getElementById("order_recruitment_height").setAttribute("style", "height:" + result + "px");
        }
    }

    //change width left + right menu recruitment when resize screen
    $(window).resize(function () {
        if ($(window).width() > 769) {
            var result = $(".form_recruitment").height();
            var height_of_left_filter = $("#title_recruitment_height").height();
            var height_of_order_recruitment = $("#live_order_recruitment_height").height();

            if (height_of_left_filter < result) {
                document.getElementById("title_recruitment_height").setAttribute("style", "height:" + result + "px");
            }

            if (height_of_order_recruitment < result) {
                document.getElementById("order_recruitment_height").setAttribute("style", "height:" + result + "px");
            }
        }
        else {
            document.getElementById("title_recruitment_height").setAttribute("style", "height:auto");
            document.getElementById("order_recruitment_height").setAttribute("style", "height:auto");
        }


    });


});


$("#FilterFieldWork").on("select2:open", function () {
    $(".select2-search__field").attr("placeholder", '@Html.Raw(string.Format("{0} {1}",Resource.Search, Resource.FieldWork))');
});

$("#FilterCity").on("select2:open", function () {
    $(".select2-search__field").attr("placeholder", '@Html.Raw(string.Format("{0} {1}", Resource.Search, Resource.City))');
});