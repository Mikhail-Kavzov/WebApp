$(function () {
    var page = 0;
    var _inCallback = false;
    function loadItems() {
        if (page > -1 && !_inCallback) {
            _inCallback = true;
            page++;
            $.ajax({
                type: 'GET',
                url: '/Category/LoadProducts/' + page,
                success: function (data, textstatus) {
                    if (data != '') {
                        $("#scrollWrapper").append(data);
                    }
                    else {
                        page = -1;
                    }
                    _inCallback = false;
                }
            });
        }
    }

    $(window).scroll(function () {
        if ((Math.trunc($(window).scrollTop())) === $(document).height() - $(window).height()) {
            loadItems();           
        }
        
    });
})
