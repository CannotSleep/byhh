﻿/*
 * 日 期：2017.03.16
 * 描 述：权限验证模块
 */
(function ($, learun) {
    "use strict";

    $.fn.lrAuthorizeJfGrid = function (op) {
        var _headData = [];
        $.each(op.headData, function (id, item) {
            console.log(lrModuleColumnList[item.name.toLowerCase()]);
            //if (!!lrModuleColumnList[item.name.toLowerCase()]) {
                _headData.push(item);
            //}
        });
        op.headData = _headData;
        $(this).jfGrid(op);
    }

    $(function () {
        function btnAuthorize() {
            if (!!lrModuleButtonList) {
                var $container = $('[learun-authorize="yes"]');
                $container.find('[id]').each(function () {
                    var $this = $(this);
                    var id = $this.attr('id');
                    if (!lrModuleButtonList[id]) {
                        $this.remove();
                    }
                });
                $container.find('.dropdown-menu').each(function () {
                    var $this = $(this);
                    if ($this.find('li').length == 0) {
                        $this.remove();
                    }
                });
                $container.css({ 'display': 'inline-block' });
            }
            else {
                setTimeout(btnAuthorize,100);
            }
        }
        btnAuthorize();
    });

})(window.jQuery, top.learun);