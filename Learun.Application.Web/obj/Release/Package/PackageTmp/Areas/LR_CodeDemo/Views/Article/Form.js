/* *
 * 创建人：超级管理员
 * 日  期：2020-04-13 16:52
 * 描  述：文章信息
 */
var acceptClick;
var keyValue = request('keyValue');
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#lr_form_tabs').lrFormTab();
            $('#lr_form_tabs ul li').eq(0).trigger('click');
            $('#articleCategory_id').lrDataItemSelect({ code: 'NewsCategory' });
            $('#imagePath').lrUploader();
            $('#isTop').lrRadioCheckbox({
                type: 'radio',
                code: 'YesOrNo',
            });
            $('#isRecommend').lrRadioCheckbox({
                type: 'radio',
                code: 'YesOrNo',
            });
            $('#isPublication').lrRadioCheckbox({
                type: 'radio',
                code: 'YesOrNo',
            });
            var contentUE =  UE.getEditor('content');
            $('#content')[0].ue =  contentUE;        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/Article/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id ).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            $('[data-table="' + id + '"]').lrSetFormData(data[id]);
                        }
                    }
                });
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('body').lrValidform()) {
            return false;
        }
        var postData = {
            strEntity: JSON.stringify($('body').lrGetFormData())
        };
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/Article/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
