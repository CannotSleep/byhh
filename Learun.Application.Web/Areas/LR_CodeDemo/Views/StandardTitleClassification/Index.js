/* * 
 * 创建人：超级管理员
 * 日  期：2020-01-16 11:46
 * 描  述：题录分类管理
 */
var selectedRow;
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            // 查询
            $('#btn_Search').on('click', function () {
                var keyword = $('#txt_Keyword').val();
                page.search(keyword);
            });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                selectedRow = null;
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/LR_CodeDemo/StandardTitleClassification/Form',
                    width: 700,
                    height: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('Id');
                selectedRow = $('#gridtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/StandardTitleClassification/Form?keyValue=' + keyValue,
                        width: 700,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('Id');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/StandardTitleClassification/DeleteForm', { keyValue: keyValue}, function () {
                            });
                        }
                    });
                }
            });
        },
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/StandardTitleClassification/GetPageList',
                headData: [
                        //{ label: 'Id', name: 'Id', width: 200, align: "left" },
                        { label: '分类代码', name: 'CategoryCode', width: 200, align: "left" },
                        { label: '分类描述', name: 'Describe', width: 200, align: "left" },
                        { label: '分类地址', name: 'Address', width: 200, align: "left" },
                        { label: '分类地址码', name: 'AddressCode', width: 200, align: "left" },
                        { label: '创建时间', name: 'CreateDate', width: 200, align: "left" },
                        { label: '修改时间', name: 'ModifyDate', width: 200, align: "left" },
                        { label: '备注', name: 'Remark', width: 200, align: "left" },
                ],
                mainId:'Id',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || '';
            $('#gridtable').jfGridSet('reload', { queryJson:param });
        }
    };
    refreshGirdData = function () {
        page.search();
    };
    page.init();
}
