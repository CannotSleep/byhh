/* * 版 本 Learun-ADMS V7.0.0 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2020-04-15 11:32
 * 描  述：订单子项
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
                    url: top.$.rootUrl + '/LR_CodeDemo/OrderItem/Form',
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
                        url: top.$.rootUrl + '/LR_CodeDemo/OrderItem/Form?keyValue=' + keyValue,
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
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/OrderItem/DeleteForm', { keyValue: keyValue}, function () {
                            });
                        }
                    });
                }
            });
        },
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/OrderItem/GetPageList',
                headData: [
                        { label: 'id', name: 'id', width: 200, align: "left" },
                        { label: 'createDate', name: 'createDate', width: 200, align: "left" },
                        { label: 'modifyDate', name: 'modifyDate', width: 200, align: "left" },
                        { label: 'deliveryQuantity', name: 'deliveryQuantity', width: 200, align: "left" },
                        { label: 'productHtmlFilePath', name: 'productHtmlFilePath', width: 200, align: "left" },
                        { label: 'productName', name: 'productName', width: 200, align: "left" },
                        { label: 'productPrice', name: 'productPrice', width: 200, align: "left" },
                        { label: 'productQuantity', name: 'productQuantity', width: 200, align: "left" },
                        { label: 'productSn', name: 'productSn', width: 200, align: "left" },
                        { label: 'totalDeliveryQuantity', name: 'totalDeliveryQuantity', width: 200, align: "left" },
                        { label: 'order_id', name: 'order_id', width: 200, align: "left" },
                        { label: 'standard_id', name: 'standard_id', width: 200, align: "left" },
                        { label: 'memberId', name: 'memberId', width: 200, align: "left" },
                        { label: 'orderId', name: 'orderId', width: 200, align: "left" },
                        { label: 'standardId', name: 'standardId', width: 200, align: "left" },
                        { label: 'orderSn', name: 'orderSn', width: 200, align: "left" },
                        { label: 'product_id', name: 'product_id', width: 200, align: "left" },
                        { label: 'orderItemType', name: 'orderItemType', width: 200, align: "left" },
                        { label: 'emailAttachStatus', name: 'emailAttachStatus', width: 200, align: "left" },
                        { label: 'deleteType', name: 'deleteType', width: 200, align: "left" },
                        { label: 'addtoPrice', name: 'addtoPrice', width: 200, align: "left" },
                        { label: 'identify', name: 'identify', width: 200, align: "left" },
                        { label: 'a825', name: 'a825', width: 200, align: "left" },
                        { label: 'a4754', name: 'a4754', width: 200, align: "left" },
                        { label: 'a826', name: 'a826', width: 200, align: "left" },
                        { label: 'isSuoQu', name: 'isSuoQu', width: 200, align: "left" },
                        { label: 'memberCompany', name: 'memberCompany', width: 200, align: "left" },
                        { label: 'memberName', name: 'memberName', width: 200, align: "left" },
                        { label: 'memberusername', name: 'memberusername', width: 200, align: "left" },
                        { label: 'orderNum', name: 'orderNum', width: 200, align: "left" },
                        { label: 'password', name: 'password', width: 200, align: "left" },
                        { label: 'zba001', name: 'zba001', width: 200, align: "left" },
                        { label: 'zba002', name: 'zba002', width: 200, align: "left" },
                        { label: 'zba102', name: 'zba102', width: 200, align: "left" },
                        { label: 'qwisopen', name: 'qwisopen', width: 200, align: "left" },
                        { label: 'a827', name: 'a827', width: 200, align: "left" },
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
