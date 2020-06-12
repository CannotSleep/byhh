/* * 创建人：超级管理员
 * 日  期：2020-04-26 17:30
 * 描  述：标准费用计算
 */
var acceptClick;
var keyValue = request('keyValue');
var bootstrap = function ($, learun) {
    "use strict";
    var selectedRow = learun.frameTab.currentIframe().selectedRow;
    var page = {
        init: function () {
            page.bind();
        },
        bind: function () {
            //获取会员等级
            var htm = '<ul>';
            $.ajax({
                url: '/LR_CodeDemo/VipMemberLevel/GetList',
                data:JSON,
                type: 'Get',
                success: function (data) {
                    var rea = JSON.parse(data).data;
                    for (var i = 0; i < rea.length;i++) {
                        htm += '<li data-value="'+rea[i].id+'">'+rea[i].name+'</li>';
                    }
                    htm += '</ul>';
                    $("#memberRank_id").html(htm);
                    $('#memberRank_id').lrselect();
                    page.initData();
                },
                error: function (response) {
                    console.log(response);
                }
            });
        },
        initData: function () {
            if (!!selectedRow) {
                console.log(selectedRow)
                console.log(selectedRow.memberRank_id)
                $('#form').lrSetFormData(selectedRow);
                $("#memberRank_id").val(selectedRow.memberRank_id);
                $("#memberRank_id").attr("value", selectedRow.memberRank_id);
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('#form').lrValidform()) {
            return false;
        }
        var postData = $('#form').lrGetFormData();
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/StandardCount/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
