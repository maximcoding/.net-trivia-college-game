$(document).ready(function () {

    $('.pic').click(function () {
        $(this).toggleClass("animated rotateOut", function () {
            $(this).remove();
        });
    });

    // LEFT RIGHT scrolling
    $('div.section').first();
    $('a.display').on('click', function (e) {
        e.preventDefault();

        var t = $(this).text(),
            that = $(this);

        if (t === 'next' && $('.current').next('div.section').length > 0) {
            var $next = $('.current').next('.section');
            var top = $next.offset().top;

            $('.current').removeClass('current');

            $('body').animate({
                scrollTop: top
            }, function () {
                $next.addClass('current');
            });
        } else if (t === 'prev' && $('.current').prev('div.section').length > 0) {
            var $prev = $('.current').prev('.section');
            var top = $prev.offset().top;

            $('.current').removeClass('current');

            $('body').animate({
                scrollTop: top
            }, function () {
                $prev.addClass('current');
            });
        }
    });
    $('#picDD').change(function () {
        var val = parseInt($('#picDD').val());
        $('img').attr("src", pictureList[val]);
    });

});

















