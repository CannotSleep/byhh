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
    let itemoldarray = [];
    var uploader;
    var keyValue = '';
    var layer;
    var lindex;
    var page = {
        init: function () {
            //数据加载弹出层
            layui.use('layer', function () {
                layer  = layui.layer;
                lindex = layer.load(0);
            }); 
            page.bind();
            //初始化数据
        },
        bind: function () {
            //绑定题录类型
            $.ajax({
                url: '/LR_CodeDemo/StandardTitle/GetList',
                type: 'Get',
                data: JSON,
                success: function (data) {
                    var resl = JSON.parse(data).data;
                    //console.log(resl);
                    var htm = '';
                    for (var i = 0; i < resl.length; i++) {
                        htm += '<option value="' + resl[i].OraganId + '">' + resl[i].OraganizationCode + resl[i].OraganizationName + '</option>';
                    }
                    //console.log(htm)
                    $('#TableName').append(htm);
                    //$('#TableName').searchableSelect();
                    page.initdata();

                },
                error: function (response) {
                    console.log(response);
                }
            });
        },
        initdata: function () {
            //编辑
            keyValue = page.GetQueryString("id");
            //获取主体标准数据
            $.ajax({
                url: '/LR_CodeDemo/Standard/GetById',
                type: 'GET',
                data: {
                    queryJson: keyValue,
                },
                dataType: "json",
                success: function (result) {
                    var item = result.data;
                    console.log(result);
                    //标准Id
                    //$("#StandId").val(item.Id);
                    //标准号
                    $("input[name='StandNum']").val(item.StandNum);
                    //发布日期
                    $("input[name='isd']").val(item.Isd);
                    //实施日期
                    $("input[name='efd']").val(item.Efd);
                    //废止日期
                    $("input[name='AbolitionDate']").val(item.AbolitionDate);
                    //确认日期
                    //$("input[name='StandNum']").val(item.ConfirmationDate);
                    //中文名称
                    $("input[name='cn']").val(item.Cn);
                    //英文名称
                    $("input[name='en']").val(item.En);
                    //原文名称
                    //$("input[name='StandNum']").val(item.OriginalName);
                    ////英文主题词
                    //$("input[name='StandNum']").val(item.EnglishSubjectWords);
                    ////中文主题词
                    //$("input[name='StandNum']").val(item.ChineseThemeWords);
                    //发布单位
                    $("input[name='PublishingUnit']").val(item.PublishingUnit);
                    //批准单位
                    $("input[name='ApprovedUnit']").val(item.ApprovedUnit);
                    //提出单位
                    $("input[name='ProposedUnit']").val(item.ProposedUnit);
                    //起草单位
                    $("input[name='DraftingUnit']").val(item.DraftingUnit);
                    //代替标准
                    $("input[name='SubstituteStandard']").val(item.SubstituteStandard);
                    //被代替标准
                    $("input[name='SubstitutedStandard']").val(item.SubstitutedStandard);
                    //起草人
                    $("input[name='zb_a001']").val(item.zb_a001);
                    //归口单位
                    //$("input[name='StandNum']").val(item.TechnicalCommittees);
                    //适用范围
                    $("[name='scope']").val(item.Scope);
                    //CCS
                    $("input[name='ccs']").val(item.Ccs);
                    //ICS
                    $("input[name='ics']").val(item.Ics);
                    //GBN
                    $("input[name='gbn']").val(item.Gbn);
                    //页数
                    $("input[name='Pages']").val(item.Pages);
                    //国民经济分类
                    //$("input[name='RecordNumber']").val(item.ClassificationEconomy);
                    //备案号
                    $("input[name='RecordNumber']").val(item.RecordNumber);
                    //标准类型
                    //$("input[name='StandNum']").val(item.StandardType);
                    //前言
                    //$("[name='preface']").val(item.Preface);
                    //全文光盘
                    //$("input[name='StandNum']").val(item.CdRom);
                    //文本地址
                    //$("input[name='StandNum']").val(item.TextAddress);
                    //引言
                    //$("input[name='StandNum']").val(item.Introduction);
                    //语种
                    //$("input[name='StandNum']").val(item.Languages);
                    //是否有翻译
                    //$("input[name='StandNum']").val(item.IsTranslation);
                    //是否有翻译件
                    //$("input[name='StandNum']").val(item.IsTranslationd);
                    //翻译件语种
                    //$("input[name='StandNum']").val(item.TranslationLanguage);
                    //标准所在合订本名称
                    //$("input[name='StandNum']").val(item.NameTheStandard);
                    //所属标委会
                    //$("input[name='StandNum']").val(item.AffiliatedCommittee);
                    //ISBN
                    //$("input[name='StandNum']").val(item.ISBN);
                    //首次记录时间
                    //$("input[name='StandNum']").val(item.FirstRecordingTime);
                    //最后修改时间
                    //$("input[name='StandNum']").val(item.LastModifyTime);
                    //馆藏标志
                    //$("input[name='StandNum']").val(item.CollectionMark);
                    //单行本
                    //$("input[name='StandNum']").val(item.SingleCopy);
                    //创建日期
                    $("input[name='CreateTime']").val(item.CreateTime);
                    //修改日期
                    $("input[name='ModifyDate']").val(item.ModifyDate);
                    //修改件
                    //$("input[name='StandNum']").val(item.Amendment);
                    //题录类型
                    //$("input[name='StandNum']").val(item.TypesTitles);
                    //加入方式
                    //$("input[name='StandNum']").val(item.WayAdding);
                    //组织号
                    //$("input[name='StandNum']").val(item.OrganizationNumber);
                    //顺序号
                    //$("input[name='StandNum']").val(item.SequenceNumber);
                    //年代号
                    //$("input[name='StandNum']").val(item.AgeNumber);
                    //最后修改
                    //$("input[name='StandNum']").val(item.LastModifiedIP);
                    //表名
                    $("#TableName").val(item.TableName);
                    layui.use(['form'], function () {
                        $ = layui.jquery;
                        var form = layui.form;
                        form.render(); //刷新select选择框渲染
                        $("#TableName").attr("disabled","disabled");

                    });
                    //标准状态
                    //$("input[name='StandStatus']").val(item.StandStatus);
                    $("input[name='StandStatus'][value=" + item.StandStatus+"]").attr("checked", true); 
                    $("input[name='StandStatus']").attr("disabled", "disabled");

                    //代替标准
                    //$("input[name='StandNum']").val(item.SubstituteStandard);
                    //被代替标准
                    //$("input[name='StandNum']").val(item.SubstitutedStandard);
                    //采用关系
                    //$("input[name='StandNum']").val(item.AdoptionRelationship);
                    //补充件
                    //$("input[name='StandNum']").val(item.Supplement);
                    //排序字段
                    //$("input[name='StandNum']").val(item.SortField);
                    //是否作废
                    //$("input[name='StandNum']").val(item.Status);
                    //替代标准
                    //$("input[name='StandNum']").val(item.SubStandard);
                    //是否审核
                    //$("input[name='StandNum']").val(item.IsAudited);
                    //转换数字的排序字符
                    //$("input[name='StandNum']").val(item.ConvertCharacters);
                    //是否免费
                    $("input[name='isfree']").val(item.isfree);
                    //console.log(item.ElectronicSource.substr(1));
                    if (item.ElectronicSource != null) {
                        //电子文本来源
                        var arr = item.ElectronicSource.split("/");
                        var cpdf = '';
                        cpdf += '<a target="_blank" href="' + window.location.origin + item.ElectronicSource.substr(1) + '">';
                        cpdf += arr[2];
                        cpdf += '</a>';
                        $("#filename").html(cpdf);
                    }
                    itemoldarray = item.childList;
                    page.initItem();
                }
            })

        },
        initItem: function () {
            for (var i = 0; i < itemoldarray.length; i++) {
                if (itemoldarray[i].type == "1") {
                    //规范化
                    var htmgui = '';
                    htmgui += '<tr>';
                    htmgui += '<td>';
                    htmgui += '规范性引用文件';
                    htmgui += '</td>';
                    htmgui += '<td>';
                    htmgui += '<input class="ctinput" style="display:none" type="text" value="' + itemoldarray[i].Id + '" name="JID">';
                    htmgui += '<input class="ctinput" readonly type="text" value="' + itemoldarray[i].n_docum + '" name="n_docum">';
                    htmgui += '</td>';
                    htmgui += '</tr>';
                    $("#zguifan").append(htmgui);
                }
                if (itemoldarray[i].type == "2") {
                    //附录
                    var htmflu = '';
                    htmflu += '<tr>';
                    htmflu += '<td>';
                    htmflu += '附录';
                    htmflu += '</td>';
                    htmflu += '<td>';
                    htmflu += '<input class="ctinput" style="display:none" type="text" value="' + itemoldarray[i].Id + '" name="FId">';
                    htmflu += '<input  class="ctinput" readonly type="text" value="' + itemoldarray[i].app_id + '" name="app_id">';
                    htmflu += '</td>';
                    htmflu += '<td>';
                    htmflu += '<input  class="ctinput" readonly type="text" value="' + itemoldarray[i].app_body + '" name="app_body">';
                    htmflu += '</td>';
                    htmflu += '</tr>';
                    $("#zfulu").append(htmflu);
                }
                if (itemoldarray[i].type == "3") {
                    //参考文献
                    var htmcank = '';
                    htmcank += '<tr>';
                    htmcank += '<td>';
                    htmcank += '参考文献';
                    htmcank += '</td>';
                    htmcank += '<td>';
                    htmcank += '<input class="ctinput" style="display:none" type="text" value="' + itemoldarray[i].Id + '" name="CId">';
                    htmcank += '<input id="cankaowenxi" readonly class="ctinput" value="' + itemoldarray[i].ref_item + '" type="text" name="ref_item">';
                    htmcank += '</td>';
                    htmcank += '</tr>';
                    $("#zcankao").append(htmcank);
                }
                if (itemoldarray[i].type == "4") {
                    //术语
                    var htmshyu = '';
                    htmshyu += '<tr>';
                    htmshyu += '<td>';
                    htmshyu += '术语';
                    htmshyu += '</td>';
                    htmshyu += '<td>';
                    htmshyu += '<input class="ctinput" style="display:none" type="text" value="' + itemoldarray[i].Id + '" name="SId">';
                    htmshyu += '<input class="ctinput" readonly type="text" value="' + itemoldarray[i].t_id + '" name="t_id">';
                    htmshyu += '</td>';
                    htmshyu += '<td>';
                    htmshyu += '<input class="ctinput" readonly type="text" value="' + itemoldarray[i].t_cn + '" name="t_cn">';
                    htmshyu += '</td>';
                    htmshyu += '<td>';
                    htmshyu += '<input class="ctinput" readonly type="text" value="' + itemoldarray[i].t_en + '" name="t_en">';
                    htmshyu += '</td>';
                    htmshyu += '<td>';
                    htmshyu += '<input class="ctinput" readonly type="text" value="' + itemoldarray[i].t_def + '" name="t_def">';
                    htmshyu += '</td>';
                    htmshyu += '<td>';
                    htmshyu += '<input class="ctinput" readonly type="text" value="' + itemoldarray[i].t_note + '" name="t_note">';
                    htmshyu += '</td>';
                    htmshyu += '<td>';
                    htmshyu += '<input class="ctinput" readonly type="text" value="' + itemoldarray[i].t_exp + '" name="t_exp">';
                    htmshyu += '</td>';
                    htmshyu += '<td>';
                    if (itemoldarray[i].pic != '') {
                        var arr = itemoldarray[i].pic.split("/");
                        htmshyu += '<a target="_blank" href="' + window.location.origin + itemoldarray[i].pic.substr(1) + '">';
                        htmshyu += arr[2];
                        htmshyu += '</a>';
                    }
                    htmshyu += '</td>';
                    htmshyu += '</tr>';
                    $("#zshuyu").append(htmshyu);
                }
                if (itemoldarray[i].type == "5") {
                    //目次
                    var htmmuci = '';
                    htmmuci += '<tr>';
                    htmmuci += '<td>';
                    htmmuci += '目次';
                    htmmuci += '</td>';
                    htmmuci += '<td>';
                    htmmuci += '<input class="ctinput" style="display:none" type="text" value="' + itemoldarray[i].Id + '" name="MId">';
                    htmmuci += '<input  class="ctinput" readonly type="text" value="' + itemoldarray[i].clg_id + '" name="clg_id">';
                    htmmuci += '</td>';
                    htmmuci += '<td>';
                    htmmuci += '<input class="ctinput" readonly type="text" value="' + itemoldarray[i].clg_name + '" name="clg_name">';
                    htmmuci += '</td>';
                    htmmuci += '</tr>';
                    $("#zmuci").append(htmmuci);
                }
                if (itemoldarray[i].type == "6") {
                    //结构化
                    var htmjiegou = '';
                    htmjiegou += '<tr>';
                    htmjiegou += '<td>';
                    htmjiegou += '结构化内容';
                    htmjiegou += '</td>';
                    htmjiegou += '<td>';
                    htmjiegou += '<select class="form-control" disabled="disabled" name="tech_level">';
                    if (itemoldarray[i].tech_level == "1") {
                        htmjiegou += '<option value="1" selected>';
                    } else {
                        htmjiegou += '<option value="1">';
                    }
                    htmjiegou += '一级标题';
                    htmjiegou += '</option>';
                    if (itemoldarray[i].tech_level == "2") {
                        htmjiegou += '<option value="2" selected>';
                    } else {
                        htmjiegou += '<option value="2">';
                    }
                    htmjiegou += '二级标题';
                    htmjiegou += '</option>';
                    if (itemoldarray[i].tech_level == "3") {
                        htmjiegou += '<option value="3" selected>';
                    } else {
                        htmjiegou += '<option value="3">';
                    }
                    htmjiegou += '三级标题';
                    htmjiegou += '</option>';
                    htmjiegou += '</select>';
                    htmjiegou += '</td>';
                    htmjiegou += '<td>';
                    htmjiegou += '<input class="ctinput" value="' + itemoldarray[i].Id + '" style="display:none" type="text" name="tech_id">';
                    htmjiegou += '<input class="ctinput" readonly value="' + itemoldarray[i].tech_itid + '" type="text" name="tech_itid">';
                    htmjiegou += '</td>';
                    htmjiegou += '<td>';
                    htmjiegou += '<input class="ctinput" readonly value="' + itemoldarray[i].tech_itname + '" type="text" name="tech_itname">';
                    htmjiegou += '</td>';
                    htmjiegou += '<td>';
                    htmjiegou += '<input class="ctinput" readonly value="' + itemoldarray[i].tech_ptbody + '" type="text" name="tech_ptbody">';
                    htmjiegou += '</td>';
                    htmjiegou += '<td>';
                    if (itemoldarray[i].tech_pic != '') {
                        var arra = itemoldarray[i].tech_pic.split("/");
                        htmjiegou += '<a target="_blank" href="' + window.location.origin + itemoldarray[i].tech_pic.substr(1) + '">';
                        htmjiegou += arra[2];
                        htmjiegou += '</a>';
                    }
                    htmjiegou += '</td>';
                    htmjiegou += '</tr>';
                    $("#zjiegou").append(htmjiegou);  
                }
            }
            layer.close(lindex);
        },
        GetQueryString: function (name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }
    };
    page.init();
};
bootstrap(jQuery);

