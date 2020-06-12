/* * 创建人：超级管理员
 * 日  期：2020-04-26 17:30
 * 描  述：标准费用计算
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
                    url: top.$.rootUrl + '/LR_CodeDemo/StandardCount/Form',
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
                        url: top.$.rootUrl + '/LR_CodeDemo/StandardCount/Form?keyValue=' + keyValue,
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
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/StandardCount/DeleteForm', { keyValue: keyValue}, function () {
                            });
                        }
                    });
                }
            });
        },
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/StandardCount/GetPageList',
                headData: [
                        //{ label: 'id', name: 'id', width: 200, align: "left" },
                        { label: '会员等级', name: 'name', width: 200, align: "left" },
                        //{ label: 'pageSize', name: 'pageSize', width: 200, align: "left" },
                        { label: '国内标准每页单价', name: 'unit', width: 200, align: "left" },
                        { label: '国内基本费用', name: 'basicCost', width: 200, align: "left" },
                        { label: '国内过期标准费用', name: 'overdueCost', width: 200, align: "left" },
                        //{ label: 'isDefault', name: 'isDefault', width: 200, align: "left" },
                        { label: '国外标准每页单价', name: 'funit', width: 200, align: "left" },
                        { label: '国外基本标准费用', name: 'fbasicCost', width: 200, align: "left" },
                        { label: '国外过期标准费用', name: 'foverdueCost', width: 200, align: "left" },
                        { label: '托管单价', name: 'depositePrice', width: 200, align: "left" },
                        { label: '创建日期', name: 'createDate', width: 200, align: "left" },
                        { label: '修改日期', name: 'modifyDate', width: 200, align: "left" }
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
