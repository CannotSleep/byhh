/*
 * 日  期：2020-02-11 10:42
 * 描  述：功能搜索和添加
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
                //location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                //selectedRow = null;
                //learun.layerForm({
                //    id: 'form',
                //    title: '新增',
                //    url: top.$.rootUrl + '/LR_CodeDemo/Standard/Form',
                //    width: 1400,
                //    height: 800,
                //    callBack: function (id) {
                //        return top[id].acceptClick(refreshGirdData);
                //    }
                //});
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('Id');
                selectedRow = $('#gridtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/Standard/Form?keyValue=' + keyValue,
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
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/Standard/DeleteForm', { keyValue: keyValue }, function () {
                            });
                        }
                    });
                }
            });
        },
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/Standard/GetPageList',
                headData: [
                    { label: '标准号', name: 'StandNum', width: 200, align: "left" },
                    { label: '发布日期', name: 'Isd', width: 200, align: "left" },
                    { label: '实施日期', name: 'Efd', width: 200, align: "left" },
                    { label: '废止日期', name: 'AbolitionDate', width: 200, align: "left" },
                    { label: '中文名称', name: 'Cn', width: 200, align: "left" },
                    { label: '英文名称', name: 'En', width: 200, align: "left" },
                    { label: '页数', name: 'Pages', width: 200, align: "left" },
                    { label: '代替标准', name: 'SubstituteStandard', width: 200, align: "left" },
                    { label: '被代替标准', name: 'SubstitutedStandard', width: 200, align: "left" },
                    { label: '采用关系', name: 'AdoptionRelationship', width: 200, align: "left" },
                    { label: '英文主题词', name: 'EnglishSubjectWords', width: 200, align: "left" },
                    { label: '中标分类号', name: 'Ccs', width: 200, align: "left" },
                    { label: '国标号', name: 'Gbn', width: 200, align: "left" },
                    { label: 'ICS', name: 'Ics', width: 200, align: "left" },
                    { label: '最后修改时间', name: 'LastModifyTime', width: 200, align: "left" },
                    { label: '馆藏标志', name: 'CollectionMark', width: 200, align: "left" },
                    { label: '单行本', name: 'SingleCopy', width: 200, align: "left" },
                    { label: '全文光盘', name: 'CdRom', width: 200, align: "left" },
                    { label: '文本地址', name: 'TextAddress', width: 200, align: "left" },
                    { label: '修改件', name: 'Amendment', width: 200, align: "left" },
                    { label: '首次记录时间', name: 'FirstRecordingTime', width: 200, align: "left" },
                    { label: '题录类型', name: 'TypesTitles', width: 200, align: "left" },
                    { label: '加入方式', name: 'WayAdding', width: 200, align: "left" },
                    { label: '组织号', name: 'OrganizationNumber', width: 200, align: "left" },
                    { label: '顺序号', name: 'SequenceNumber', width: 200, align: "left" },
                    { label: '年代号', name: 'AgeNumber', width: 200, align: "left" },
                    { label: '最后修改IP', name: 'LastModifiedIP', width: 200, align: "left" },
                    { label: '适用范围', name: 'scope', width: 200, align: "left" },
                    { label: '表名', name: 'TableName', width: 200, align: "left" },
                    { label: '前言', name: 'preface', width: 200, align: "left" },
                    { label: '引言', name: 'Introduction', width: 200, align: "left" },
                    { label: '发布单位', name: 'PublishingUnit', width: 200, align: "left" },
                    { label: '批准单位', name: 'ApprovedUnit', width: 200, align: "left" },
                    { label: '确认日期', name: 'ConfirmationDate', width: 200, align: "left" },
                    { label: '起草单位', name: 'DraftingUnit', width: 200, align: "left" },
                    { label: '备案号', name: 'RecordNumber', width: 200, align: "left" },
                    { label: '补充件', name: 'Supplement', width: 200, align: "left" },
                    { label: '中文主题词', name: 'ChineseThemeWords', width: 200, align: "left" },
                    { label: '标准类型', name: 'StandardType', width: 200, align: "left" },
                    { label: '提出单位', name: 'ProposedUnit', width: 200, align: "left" },
                    { label: '国民经济分类', name: 'ClassificationEconomy', width: 200, align: "left" },
                    { label: '原文名称', name: 'OriginalName', width: 200, align: "left" },
                    { label: '标准状态', name: 'StandStatus', width: 200, align: "left" },
                    { label: '排序字段', name: 'SortField', width: 200, align: "left" },
                    { label: '创建日期', name: 'CreateTime', width: 200, align: "left" },
                    { label: '修改日期', name: 'ModifyDate', width: 200, align: "left" },
                    { label: '是否作废', name: 'Status', width: 200, align: "left" },
                    { label: '替代标准', name: 'SubStandard', width: 200, align: "left" },
                    { label: '电子文本来源', name: 'ElectronicSource', width: 200, align: "left" },
                    { label: '语种', name: 'Languages', width: 200, align: "left" },
                    { label: '是否有翻译', name: 'IsTranslation', width: 200, align: "left" },
                    { label: '归口单位', name: 'TechnicalCommittees', width: 200, align: "left" },
                    { label: '是否有翻译件', name: 'IsTranslationd', width: 200, align: "left" },
                    { label: '翻译件语种', name: 'TranslationLanguage', width: 200, align: "left" },
                    { label: '所属标委会', name: 'AffiliatedCommittee', width: 200, align: "left" },
                    { label: '标准所在合订本名称', name: 'NameTheStandard', width: 200, align: "left" },
                    { label: '准所在合订本ISBN号', name: 'ISBN', width: 200, align: "left" },
                    { label: '是否审核', name: 'IsAudited', width: 200, align: "left" },
                    { label: '转换数字的排序字符', name: 'ConvertCharacters', width: 200, align: "left" },
                    { label: '是否免费', name: 'isfree', width: 200, align: "left" }
                ],
                mainId: 'Id',
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
};
