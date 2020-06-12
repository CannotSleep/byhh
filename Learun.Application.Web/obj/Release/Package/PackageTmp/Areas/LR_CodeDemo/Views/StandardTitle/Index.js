/* * 版 本 Learun-ADMS V7.0.0 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2020-01-16 16:23
 * 描  述：标准题录
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
                    url: top.$.rootUrl + '/LR_CodeDemo/StandardTitle/Form',
                    width: 700,
                    height: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('ID');
                selectedRow = $('#gridtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/StandardTitle/Form?keyValue=' + keyValue,
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
                var keyValue = $('#gridtable').jfGridValue('ID');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/StandardTitle/DeleteForm', { keyValue: keyValue}, function () {
                            });
                        }
                    });
                }
            });
        },
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/StandardTitle/GetPageList',
                headData: [
                        //{ label: 'ID', name: 'ID', width: 200, align: "left" },
                        { label: '组织ID', name: 'OraganId', width: 200, align: "left" },
                        { label: '组织编码', name: 'OraganizationCode', width: 200, align: "left" },
                        { label: '组织名称', name: 'OraganizationName', width: 200, align: "left" },
                        { label: '分类码', name: 'CategoryCode', width: 200, align: "left" },
                        { label: 'Bz', name: 'Bz', width: 200, align: "left" },
                        { label: '创建日期', name: 'CreateDate', width: 200, align: "left" },
                        { label: '修改日期', name: 'ModifyDate', width: 200, align: "left" },
                        { label: '组织order', name: 'OraganizationOrder', width: 200, align: "left" },
                        { label: 'Copr', name: 'Copr', width: 200, align: "left" },
                        { label: 'Synchronous', name: 'Synchronous', width: 200, align: "left" },
                        { label: 'Discount', name: 'Discount', width: 200, align: "left" },
                        { label: '1启用0禁用', name: 'IsUsed', width: 200, align: "left" },
                        { label: 'OrderCode', name: 'OrderCode', width: 200, align: "left" },
                ],
                mainId:'ID',
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
