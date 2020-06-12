/* * 创建人：超级管理员
 * 日  期：2020-04-26 16:25
 * 描  述：会员等级
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
                    url: top.$.rootUrl + '/LR_CodeDemo/VipMemberLevel/Form',
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
                        url: top.$.rootUrl + '/LR_CodeDemo/VipMemberLevel/Form?keyValue=' + keyValue,
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
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/VipMemberLevel/DeleteForm', { keyValue: keyValue}, function () {
                            });
                        }
                    });
                }
            });
        },
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/VipMemberLevel/GetPageList',
                headData: [
                        //{ label: 'id', name: 'id', width: 200, align: "left" },
                        { label: '创建日期', name: 'createDate', width: 200, align: "left" },
                        { label: '修改日期', name: 'modifyDate', width: 200, align: "left" },
                        {
                            label: '是否默认', name: 'isDefault', width: 200, align: "left",
                            formatter: function (cellvalue) {
                                return cellvalue == true ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
                            }
                        },
                        { label: '名称', name: 'name', width: 200, align: "left" }
                        //{ label: 'point', name: 'point', width: 200, align: "left" },
                        //{ label: 'preferentialScale', name: 'preferentialScale', width: 200, align: "left" },
                        //{ label: 'ouid_id', name: 'ouid_id', width: 200, align: "left" },
                        //{ label: 'organname', name: 'organname', width: 200, align: "left" },
                        //{ label: 'parent_id', name: 'parent_id', width: 200, align: "left" },
                        //{ label: 'uploadSpacepaceSize', name: 'uploadSpacepaceSize', width: 200, align: "left" },
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
