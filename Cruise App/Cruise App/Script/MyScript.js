$(function () {
    $('#play').click(function () { $('#slider').cycle('resume'); return false });

    $('#pause').click(function () { $('#slider').cycle('pause'); return false });

    $('#slider').cycle({

        fx: 'scrollHorz',
        prev: '#prev',
        next: '#next',
        pager: '#pager',
        timeout: 3000,
        speed: 900
    });
});
