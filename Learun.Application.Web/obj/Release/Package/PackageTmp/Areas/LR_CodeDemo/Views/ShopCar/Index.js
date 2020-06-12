/*
 * 创建人：超级管理员
 * 日  期：2020-04-16 09:18
 * 描  述：购物车
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
                page.search({ keyword: keyword });
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
                    url: top.$.rootUrl + '/LR_CodeDemo/ShopCar/Form',
                    width: 700,
                    height: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('id');
                selectedRow = $('#gridtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/ShopCar/Form?keyValue=' + keyValue,
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
                var keyValue = $('#gridtable').jfGridValue('id');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/ShopCar/DeleteForm', { keyValue: keyValue}, function () {
                            });
                        }
                    });
                }
            });
        },
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/ShopCar/GetPageList',
                headData: [
                        { label: 'id', name: 'id', width: 200, align: "left" },
                        { label: '创建时间', name: 'createDate', width: 200, align: "left" },
                        { label: '修改时间', name: 'modifyDate', width: 200, align: "left" },
                        { label: 'quantity', name: 'quantity', width: 200, align: "left" },
                        { label: 'member_id', name: 'member_id', width: 200, align: "left" },
                        { label: 'product_id', name: 'product_id', width: 200, align: "left" },
                        { label: 'admin_id', name: 'admin_id', width: 200, align: "left" },
                        { label: 'standardId', name: 'standardId', width: 200, align: "left" },
                        { label: 'standardName', name: 'standardName', width: 200, align: "left" },
                        { label: 'standardPages', name: 'standardPages', width: 200, align: "left" },
                        { label: 'cartType', name: 'cartType', width: 200, align: "left" },
                        { label: '价格', name: 'price', width: 200, align: "left" },
                        { label: 'computer', name: 'computer', width: 200, align: "left" },
                        { label: 'startDate', name: 'startDate', width: 200, align: "left" },
                        { label: 'endDate', name: 'endDate', width: 200, align: "left" },
                        { label: 'replaceStandard', name: 'replaceStandard', width: 200, align: "left" },
                        { label: 'depositeDate', name: 'depositeDate', width: 200, align: "left" },
                        { label: 'depositeTime', name: 'depositeTime', width: 200, align: "left" },
                        { label: 'a825', name: 'a825', width: 200, align: "left" },
                        { label: 'a4754', name: 'a4754', width: 200, align: "left" },
                        { label: 'a826', name: 'a826', width: 200, align: "left" },
                        { label: 'copr', name: 'copr', width: 200, align: "left" },
                        { label: 'memberCompany', name: 'memberCompany', width: 200, align: "left" },
                        { label: 'zba001', name: 'zba001', width: 200, align: "left" },
                        { label: 'zba102', name: 'zba102', width: 200, align: "left" },
                        { label: 'paperPrice', name: 'paperPrice', width: 200, align: "left" },
                        { label: 'standorg', name: 'standorg', width: 200, align: "left" },
                        { label: 'standorgbiao', name: 'standorgbiao', width: 200, align: "left" },
                        { label: 'qwprice', name: 'qwprice', width: 200, align: "left" },
                        { label: 'downloadtrue', name: 'downloadtrue', width: 200, align: "left" },
                ],
                mainId:'id',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        page.search();
    };
    page.init();
}
