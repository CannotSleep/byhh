/* * 版 本 Learun-ADMS V7.0.0 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2020-03-26 15:54
 * 描  述：标准子类
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
                    url: top.$.rootUrl + '/LR_CodeDemo/StandardItem/Form',
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
                        url: top.$.rootUrl + '/LR_CodeDemo/StandardItem/Form?keyValue=' + keyValue,
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
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/StandardItem/DeleteForm', { keyValue: keyValue}, function () {
                            });
                        }
                    });
                }
            });
        },
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/StandardItem/GetPageList',
                headData: [
                        { label: 'type', name: 'type', width: 200, align: "left" },
                        { label: 'clg_id', name: 'clg_id', width: 200, align: "left" },
                        { label: 'clg_name', name: 'clg_name', width: 200, align: "left" },
                        { label: 'n_docum', name: 'n_docum', width: 200, align: "left" },
                        { label: 'app_id', name: 'app_id', width: 200, align: "left" },
                        { label: 'app_body', name: 'app_body', width: 200, align: "left" },
                        { label: 'ref_item', name: 'ref_item', width: 200, align: "left" },
                        { label: 't_id', name: 't_id', width: 200, align: "left" },
                        { label: 't_cn', name: 't_cn', width: 200, align: "left" },
                        { label: 't_en', name: 't_en', width: 200, align: "left" },
                        { label: 't_def', name: 't_def', width: 200, align: "left" },
                        { label: 't_note', name: 't_note', width: 200, align: "left" },
                        { label: 't_exp', name: 't_exp', width: 200, align: "left" },
                        { label: 'pic', name: 'pic', width: 200, align: "left" },
                        { label: 'tech_itid', name: 'tech_itid', width: 200, align: "left" },
                        { label: 'tech_itname', name: 'tech_itname', width: 200, align: "left" },
                        { label: 'tech_ptbody', name: 'tech_ptbody', width: 200, align: "left" },
                        { label: 'tech_level', name: 'tech_level', width: 200, align: "left" },
                        { label: 'tech_pic', name: 'tech_pic', width: 200, align: "left" },
                        { label: 'BId', name: 'BId', width: 200, align: "left" },
                        { label: 'Id', name: 'Id', width: 200, align: "left" },
                ],
                mainId:'Id',
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
