/* 
 * 创建人：超级管理员
 * 日  期：2020-04-20 10:39
 * 描  述：合作机构
 */
var acceptClick;
var keyValue = request('keyValue');
var fileob;
var bootstrap = function ($, learun) {
    "use strict";
    var selectedRow = learun.frameTab.currentIframe().selectedRow;
    var page = {
        init: function () {
            page.initData();
            page.bind();
        },
        bind: function () {
            var img1 = new ImgUpload('.imgLog', 310, 155, 155);
            $(document).on('change', ".imgLog input", function (e) {
                //模拟后台返回url
                var url = window.URL.createObjectURL(e.target.files[0]);
                $(this).parent().css('background', 'url(' + url + ')')
                $(this).parent().css('background-repeat', 'no-repeat')
                $(this).parent().css('background-size', '100% 100%')
                fileob = e.target.files[0];
                img1.setSpan(this)
            })		
        },
        initData: function () {
            if (!!selectedRow) {
                $(".upload").css('background', 'url(' +selectedRow.imgPath + ')')
                $(".upload").css('background-repeat', 'no-repeat')
                $(".upload").css('background-size', '100% 100%')
                $('#form').lrSetFormData(selectedRow);
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('#form').lrValidform()) {
            return false;
        }
        var postData = $('#form').lrGetFormData();
        //先保存图片 回调保存表单
        if (fileob != null) {
            var formData = new FormData();
            formData.append('file', fileob);

            $.ajax({
                url: '/LR_CodeDemo/CooperativeOrganization/UploadifyFile',
                type: 'POST',
                async: false,
                data: formData,
                processData: false, // 使数据不做处理
                contentType: false, // 不要设置Content-Type请求头
                success: function (data) {
                    var res = JSON.parse(data);
                    postData.imgPath = res.info;
                    if (res.code === 200) {
                        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/CooperativeOrganization/SaveForm?keyValue=' + keyValue, postData, function (res) {
                            // 保存成功后才回调
                            if (!!callBack) {
                                callBack();
                            }
                        });
                    }
                },
                error: function (response) {
                    console.log(response);
                }
            });
        } else {
            $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/CooperativeOrganization/SaveForm?keyValue=' + keyValue, postData, function (res) {
                // 保存成功后才回调
                if (!!callBack) {
                    callBack();
                }
            });
        }
    };
    page.init();
}
function ImgUpload(node, width, height, linHeight)
{
    var _this = this; this._node = node;
    this.width = width + 'px';
    this.height = height + 'px';
    this.linHeight = linHeight + 'px';
    this.setCss();
    this.createFile();
}
ImgUpload.prototype.createFile = function ()
{ $(this._node).append('<input id="imgPath" type="file"/>') }
ImgUpload.prototype.setCss = function ()
{ $(this._node).css({ "width": this.width, "height": this.height, "line-height": this.linHeight, }) }
ImgUpload.prototype.setSpan = function (_this)
{ $(_this).siblings().css("opacity", 0); }
