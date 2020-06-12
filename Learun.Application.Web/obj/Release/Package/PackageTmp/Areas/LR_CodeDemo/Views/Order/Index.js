/*
 * 创建人：超级管理员
 * 日  期：2020-04-09 16:25
 * 描  述：订单管理
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
                    url: top.$.rootUrl + '/LR_CodeDemo/Order/Form',
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
                        url: top.$.rootUrl + '/LR_CodeDemo/Order/Form?keyValue=' + keyValue,
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
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/Order/DeleteForm', { keyValue: keyValue}, function () {
                            });
                        }
                    });
                }
            });
        },
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/Order/GetPageList',
                headData: [
                        { label: 'id', name: 'id', width: 200, align: "left" },
                        { label: '创建日期', name: 'createDate', width: 200, align: "left" },
                        { label: '修改日期', name: 'modifyDate', width: 200, align: "left" },
                        { label: '配送费', name: 'deliveryFee', width: 200, align: "left" },
                        { label: '交货类型', name: 'deliveryTypeName', width: 200, align: "left" },
                        { label: 'memo', name: 'memo', width: 200, align: "left" },
                        { label: '订单编号', name: 'orderSn', width: 200, align: "left" },
                        { label: '订单状态', name: 'orderStatus', width: 200, align: "left" },
                        { label: '订单金额', name: 'paidAmount', width: 200, align: "left" },
                        { label: 'paymentConfigName', name: 'paymentConfigName', width: 200, align: "left" },
                        { label: 'paymentFee', name: 'paymentFee', width: 200, align: "left" },
                        { label: 'paymentStatus', name: 'paymentStatus', width: 200, align: "left" },
                        { label: '订单总金额', name: 'productTotalPrice', width: 200, align: "left" },
                        { label: 'productTotalQuantity', name: 'productTotalQuantity', width: 200, align: "left" },
                        { label: 'productWeight', name: 'productWeight', width: 200, align: "left" },
                        { label: 'productWeightUnit', name: 'productWeightUnit', width: 200, align: "left" },
                        { label: 'shipAddress', name: 'shipAddress', width: 200, align: "left" },
                        { label: 'shipArea', name: 'shipArea', width: 200, align: "left" },
                        { label: 'shipAreaPath', name: 'shipAreaPath', width: 200, align: "left" },
                        { label: '商店电话', name: 'shipMobile', width: 200, align: "left" },
                        { label: 'shipName', name: 'shipName', width: 200, align: "left" },
                        { label: '商店手机', name: 'shipPhone', width: 200, align: "left" },
                        { label: 'shipZipCode', name: 'shipZipCode', width: 200, align: "left" },
                        { label: 'shippingStatus', name: 'shippingStatus', width: 200, align: "left" },
                        { label: 'totalAmount', name: 'totalAmount', width: 200, align: "left" },
                        { label: 'deliveryType_id', name: 'deliveryType_id', width: 200, align: "left" },
                        { label: 'member_id', name: 'member_id', width: 200, align: "left" },
                        { label: 'paymentConfig_id', name: 'paymentConfig_id', width: 200, align: "left" },
                        { label: '标准号', name: 'standardId', width: 200, align: "left" },
                        { label: '标准名称', name: 'standardName', width: 200, align: "left" },
                        { label: 'standardPages', name: 'standardPages', width: 200, align: "left" },
                        { label: 'shipType', name: 'shipType', width: 200, align: "left" },
                        { label: '商城email', name: 'shipEmail', width: 200, align: "left" },
                        { label: 'shipFox', name: 'shipFox', width: 200, align: "left" },
                        { label: 'memberName', name: 'memberName', width: 200, align: "left" },
                        { label: 'memberId', name: 'memberId', width: 200, align: "left" },
                        { label: 'orderType', name: 'orderType', width: 200, align: "left" },
                        { label: 'admin_id', name: 'admin_id', width: 200, align: "left" },
                        { label: 'uploadstatu', name: 'uploadstatu', width: 200, align: "left" },
                        { label: 'addtoPrice', name: 'addtoPrice', width: 200, align: "left" },
                        { label: 'ip', name: 'ip', width: 200, align: "left" },
                        { label: 'receiver_id', name: 'receiver_id', width: 200, align: "left" },
                        { label: 'expressid', name: 'expressid', width: 200, align: "left" },
                        { label: 'expressname', name: 'expressname', width: 200, align: "left" },
                        { label: 'deleteType', name: 'deleteType', width: 200, align: "left" },
                        { label: 'filepath', name: 'filepath', width: 200, align: "left" },
                        { label: 'excelpath', name: 'excelpath', width: 200, align: "left" },
                        { label: 'op', name: 'op', width: 200, align: "left" },
                        { label: 'memberusername', name: 'memberusername', width: 200, align: "left" },
                        { label: 'addtoPricebei', name: 'addtoPricebei', width: 200, align: "left" },
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
