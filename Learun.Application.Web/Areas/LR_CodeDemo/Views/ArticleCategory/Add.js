/* 
 * 创建人：超级管理员
 * 日  期：2020-02-11 10:59
 * 描  述：标准管理
 */
var bootstrap = function ($) {
    "use strict";
    let currentPage = 1;
    let pageSize = 10;
    let judge = false;
    let mainid;
    let itemarray = [];
    var uploader;
    var layer;
    var lindex;
    var page = {
        init: function () {

            page.bind();
            page.initup();
        },
        initpart: function () {

        },
        initform: function () {
            layui.use(['form', 'layedit', 'upload', 'laydate'], function () {
                var form = layui.form
                    , layer = layui.layer
                    , layedit = layui.layedit
                    , upload = layui.upload
                    , $ = layui.jquery
                    , laydate = layui.laydate;

            });
        },
        bind: function () {
            

        },
        uploadformMain: function (filepath) {
            var t = $("#standard").serializeArray();
            var obj = { name: "__RequestVerificationToken", value: $.lrToken };
            var fileobj = { name: "ElectronicSource", value: filepath };
            t.push(obj);
            t.push(fileobj);
            //获取子项及上传子项文件
            page.getItem();
            for (var p = 0; p < itemarray.length; p++) {
                //上传子项文件
                var itemobj = [
                    { name: 'childList[' + p + '].type', value: itemarray[p].type },
                    { name: 'childList[' + p + '].clg_id', value: itemarray[p].clg_id },
                    { name: 'childList[' + p + '].clg_name', value: itemarray[p].clg_name },
                    { name: 'childList[' + p + '].n_docum', value: itemarray[p].n_docum },
                    { name: 'childList[' + p + '].app_id', value: itemarray[p].app_id },
                    { name: 'childList[' + p + '].app_body', value: itemarray[p].app_body },
                    { name: 'childList[' + p + '].ref_item', value: itemarray[p].ref_item },
                    { name: 'childList[' + p + '].t_id', value: itemarray[p].t_id },
                    { name: 'childList[' + p + '].t_cn', value: itemarray[p].t_cn },
                    { name: 'childList[' + p + '].t_en', value: itemarray[p].t_en },
                    { name: 'childList[' + p + '].t_def', value: itemarray[p].t_def },
                    { name: 'childList[' + p + '].t_note', value: itemarray[p].t_note },
                    { name: 'childList[' + p + '].t_exp', value: itemarray[p].t_exp },
                    { name: 'childList[' + p + '].pic', value: itemarray[p].pic },
                    { name: 'childList[' + p + '].sfile', value: itemarray[p].pic },
                    { name: 'childList[' + p + '].tech_itid', value: itemarray[p].tech_itid },
                    { name: 'childList[' + p + '].tech_itname', value: itemarray[p].tech_itname },
                    { name: 'childList[' + p + '].tech_ptbody', value: itemarray[p].tech_ptbody },
                    { name: 'childList[' + p + '].tech_level', value: itemarray[p].tech_level },
                    { name: 'childList[' + p + '].tech_pic', value: itemarray[p].tech_pic }];
                for (var y = 0; y < itemobj.length; y++) {
                    t.push(itemobj[y]);
                }
            }
            //t.push(itemobj);
            var keyValue = '';
            console.log(t);
            $.ajax({
                url: '/LR_CodeDemo/Standard/SaveForm',
                type: 'POST',
                data: t,
                dataType: "json",
                success: function (result) {
                    console.log(result);
                    if (result.code == 200) {
                        //提交成功
                        layer.close(lindex);
                        layer.msg("上传成功");
                    } else {
                        layer.close(lindex);
                        //上传失败
                        layer.open({
                            title: '错误'
                            , content: '上传失败，请联系管理员'
                        });
                    }
                }
            });
        },
        setPage: function (pageCurrent, pageSum, callback) {

        },
        initup: function () {

        }
    };
    page.init();
};
bootstrap(jQuery);
