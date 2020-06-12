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
                layer = layui.layer;
                lindex = layer.load(0);
            }); 
            page.bind();
            //初始化上传组件
            //page.initup();
            //初始化数据
            
        },
        initform: function () {
            layui.use(['form', 'layedit', 'upload', 'laydate'], function () {
                var form = layui.form
                    , layer = layui.layer
                    , layedit = layui.layedit
                    , upload = layui.upload
                    , $ = layui.jquery
                    , laydate = layui.laydate;
                //日期
                laydate.render({
                    elem: '#date'
                });
                laydate.render({
                    elem: '#date1'
                });
                laydate.render({
                    elem: '#date2'
                });
                laydate.render({
                    elem: '#date3'
                });
                laydate.render({
                    elem: '#date4'
                });
                //拖拽上传
                upload.render({
                    elem: '#test8'
                    , auto: false
                    , url: '/LR_CodeDemo/Standard/UploadifyFile' //改成您自己的上传接口
                    , bindAction: '#test9'
                    , accept: 'file' //普通文件
                    , exts: 'pdf' //只允许上传压缩文件
                    , done: function (res) {
                        layer.msg('文件上传成功');
                        console.log(res)
                        //文件上传成功 上传表单内容
                        page.uploadformMain(res.info);
                    }, error: function () {
                        //请求异常回调
                    }, choose: function (obj) {
                        //选择文件后的回调函数
                        judge = true;
                        //将每次选择的文件追加到文件队列
                        var files = obj.pushFile();
                        //console.log(obj)
                        //预读本地文件，如果是多文件，则会遍历。(不支持ie8/9)
                        obj.preview(function (index, file, result) {
                            //console.log(index); //得到文件索引
                            console.log(file); //得到文件对象
                            $("#filename").html(file.name)
                            //console.log(result); //得到文件base64编码，比如图片

                            //obj.resetFile(index, file, '123.jpg'); //重命名文件名，layui 2.3.0 开始新增

                            //这里还可以做一些 append 文件列表 DOM 的操作

                            //obj.upload(index, file); //对上传失败的单个文件重新上传，一般在某个事件中使用
                            //delete files[index]; //删除列表中对应的文件，一般在某个事件中使用
                        });
                    }
                });
                //表单监听
                form.on('submit(demo1)', function (data) {
                    if (judge) {
                        //如果有图片 先上传图片
                        $("#test9").click();
                    } else {
                        //如果没有图片 直接上传内容
                        page.uploadformMain();
                    }
                    return false;
                });

            });
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
                    page.initform();
                    page.initdata();

                },
                error: function (response) {
                    console.log(response);
                }
            });


            //标准主体提交
            //$("#standard").submit(function (e) {
            //    e.preventDefault();
            //    //表单验证后提交 先上传文件
            //    //judge为true 有文件
            //    if (judge) {
            //        uploader.upload();
            //    } else {
            //        page.uploadformMain();
            //    }
            //});

            //模态框隐藏 关闭窗口
            $('#myModal').on('hide.bs.modal', function () {
                // 执行一些动作...
                window.close();
            })

            //规范性引用文件
            $("#addguifan").click(function () {
                var htm = '';
                htm += '<tr>';
                htm += '<td>';
                htm += '规范性引用文件';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="ctinput" style="display:none" type="text" name="GId">';
                htm += '<input class="ctinput" type="text" name="n_docum">';
                htm += '</td>';
                htm += '</tr>';
                $("#zguifan").append(htm);
            });

            //附录
            $("#addfulu").click(function () {
                var htm = '';
                htm += '<tr>';
                htm += '<td>';
                htm += '附录';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="ctinput" style="display:none" type="text" name="FId">';
                htm += '<input  class="ctinput" type="text" name="app_id">';
                htm += '</td>';
                htm += '<td>';
                htm += '<input  class="ctinput" type="text" name="app_body">';
                htm += '</td>';
                htm += '</tr>';
                $("#zfulu").append(htm);
            });

            //参考文献
            $("#addcankao").click(function () {
                var htm = '';
                htm += '<tr>';
                htm += '<td>';
                htm += '参考文献';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="ctinput" style="display:none" type="text" name="CId">';
                htm += '<input id="cankaowenxi" class="ctinput" type="text" name="ref_item">';
                htm += '</td>';
                htm += '</tr>';
                $("#zcankao").append(htm);
            });

            //术语
            $("#addshuyu").click(function () {
                var htm = '';

                htm += '<tr>';
                htm += '<td>';
                htm += '术语';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="ctinput" style="display:none" type="text" name="SId">';
                htm += '<input class="ctinput" type="text" name="t_id">';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="ctinput" type="text" name="t_cn">';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="ctinput" type="text" name="t_en">';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="ctinput" type="text" name="t_def">';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="ctinput" type="text" name="t_note">';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="ctinput" type="text" name="t_exp">';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="ctinput" type="file"  name="pic">';
                htm += '</td>';
                htm += '</tr>';
                $("#zshuyu").append(htm);
            });

            //目次
            $("#addmuci").click(function () {
                var htm = '';
                htm += '<tr>';
                htm += '<td>';
                htm += '目次';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="ctinput" style="display:none" type="text" name="MId">';
                htm += '<input  class="ctinput" type="text" name="clg_id">';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="ctinput" type="text" name="clg_name">';
                htm += '</td>';
                htm += '</tr>';
                $("#zmuci").append(htm);
            });

            //结构化内容
            $("#addjishu").click(function () {

                var htm = '';
                htm += '<tr>';
                htm += '<td>';
                htm += '结构化内容';
                htm += '</td>';
                htm += '<td>';
                htm += '<select class="form-control" name="tech_level">';
                htm += '<option value="1">';
                htm += '一级标题';
                htm += '</option>';
                htm += '<option value="2">';
                htm += '二级标题';
                htm += '</option>';
                htm += '<option value="3">';
                htm += '三级标题';
                htm += '</option>';
                htm += '</select>';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="ctinput" style="display:none" type="text" name="tech_id">';
                htm += '<input class="ctinput" type="text" name="tech_itid">';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="ctinput" type="text" name="tech_itname">';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="ctinput" type="text" name="tech_ptbody">';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="ctinput" type="file"  name="tech_pic">';
                htm += '</td>';
                htm += '</tr>';

                $("#zjiegou").append(htm);
            });

        },
        getItem: function () {
            var guifan = [];
            var itemid = [];
            //获取规范性引用文件
            $("input[name='GId']").each(function () {
                itemid.push($(this).val());
            })
            $("input[name='n_docum']").each(function () {
                guifan.push($(this).val());
            })
            for (var i = 0; i < guifan.length; i++) {
                var objfulu = { Id: itemid[i], n_docum: guifan[i], "type": 1 }
                itemarray.push(objfulu);
            }

            //附录
            var fuluid = [];
            var fulubody = [];
            var fid = []
            $("input[name='FId']").each(function () {
                fid.push($(this).val());
            })
            $("input[name='app_id']").each(function () {
                fuluid.push($(this).val());
            })
            $("input[name='app_body']").each(function () {
                fulubody.push($(this).val());
            })
            for (var i = 0; i < fuluid.length; i++) {
                var objfulu = { app_id: fuluid[i], app_body: fulubody[i], "type": 2, Id: fid[i] }
                itemarray.push(objfulu);
            }
            //获取参考性文件
            var cank = [];
            var cid = [];
            $("input[name='ref_item']").each(function () {
                cank.push($(this).val());
            })
            $("input[name='CId']").each(function () {
                cid.push($(this).val());
            })
            for (var i = 0; i < cank.length; i++) {
                var objfulu = { ref_item: cank[i], "type": 3, Id: cid[i] }
                itemarray.push(objfulu);
            }
            //术语
            var shuyut_id = [];
            var shuyut_cn = [];
            var shuyut_en = [];
            var shuyut_def = [];
            var shuyut_note = [];
            var shuyut_exp = [];
            var shuyupic = [];
            var sid = [];
            $("input[name='SId']").each(function () {
                sid.push($(this).val());
            })
            $("input[name='t_id']").each(function () {
                shuyut_id.push($(this).val());
            })
            $("input[name='t_cn']").each(function () {
                shuyut_cn.push($(this).val());
            })
            $("input[name='t_en']").each(function () {
                shuyut_en.push($(this).val());
            })
            $("input[name='t_def']").each(function () {
                shuyut_def.push($(this).val());
            })
            $("input[name='t_note']").each(function () {
                shuyut_note.push($(this).val());
            })
            $("input[name='t_exp']").each(function () {
                shuyut_exp.push($(this).val());
            })
            $("input[name='pic']").each(function (e) {
                shuyupic.push($(this)[0].files);
            })
            for (var a = 0; a < shuyut_id.length; a++) {
                var objshuyu = {
                    Id: sid[a],
                    t_id: shuyut_id[a],
                    t_cn: shuyut_cn[a],
                    t_en: shuyut_en[a],
                    t_def: shuyut_def[a],
                    t_note: shuyut_note[a],
                    t_exp: shuyut_exp[a],
                    type: 4,
                    pic: ''
                }
                //术语文件上传
                if (shuyupic[a].length != 0) {
                    objshuyu.pic = shuyupic[a][0].name;

                    var formData = new FormData();
                    formData.append('file', shuyupic[a][0]);

                    $.ajax({
                        url: '/LR_CodeDemo/Standard/UploadifyFileItem',
                        type: 'POST',
                        async: false,
                        data: formData,
                        processData: false, // 使数据不做处理
                        contentType: false, // 不要设置Content-Type请求头
                        success: function (data) {
                            //console.log(data);
                        },
                        error: function (response) {
                            console.log(response);
                            $("#myModalz").modal("show")
                        }
                    });
                }
                itemarray.push(objshuyu);
            }
            //目次
            var clg_id = [];
            var clg_name = [];
            var mid = [];
            $("input[name='MId']").each(function () {
                mid.push($(this).val());
            })
            $("input[name='clg_id']").each(function () {
                clg_id.push($(this).val());
            })
            $("input[name='clg_name']").each(function () {
                clg_name.push($(this).val());
            })
            for (var b = 0; b < clg_id.length; b++) {
                var objmuci = { clg_id: clg_id[b], clg_name: clg_name[b], "type": 5, Id: mid[b] }
                itemarray.push(objmuci);
            }
            //结构文件
            var tech_itid = [];
            var tech_itname = [];
            var tech_ptbody = [];
            var tech_level = [];
            var tech_pic = [];
            var tec_id = [];
            $("input[name='tech_id']").each(function () {
                tec_id.push($(this).val());
            })
            $("select[name='tech_level']").each(function () {
                tech_level.push($(this).val());
            })
            $("input[name='tech_itid']").each(function () {
                tech_itid.push($(this).val());
            })
            $("input[name='tech_itname']").each(function () {
                tech_itname.push($(this).val());
            })
            $("input[name='tech_ptbody']").each(function () {
                tech_ptbody.push($(this).val());
            })
            $("input[name='tech_pic']").each(function (e) {
                tech_pic.push($(this)[0].files);
            })
            for (var c = 0; c < tech_itid.length; c++) {
                var objjiegou = {
                    Id: tec_id[c],
                    tech_level: tech_level[c],
                    tech_itid: tech_itid[c],
                    tech_itname: tech_itname[c],
                    tech_ptbody: tech_ptbody[c],
                    tech_pic: '',
                    type: 6
                }
                if (tech_pic[c].length != 0) {
                    objjiegou.tech_pic = tech_pic[c][0].name;

                    var formDataj = new FormData();
                    formDataj.append('file', tech_pic[c][0]);

                    $.ajax({
                        url: '/LR_CodeDemo/Standard/UploadifyFileItem',
                        type: 'POST',
                        async: false,
                        data: formDataj,
                        processData: false, // 使数据不做处理
                        contentType: false, // 不要设置Content-Type请求头
                        success: function (data) {
                            //console.log(data);
                        },
                        error: function (response) {
                            console.log(response);
                            $("#myModalz").modal("show");
                        }
                    });
                }
                itemarray.push(objjiegou);
            }
        },
        uploadformMain: function (filepath) {
            var t = $("#standard").serializeArray();
            var obj = { name: "__RequestVerificationToken", value: $.lrToken };
            var fileobj = { name: "ElectronicSource", value: filepath };
            var keyobj = { name: "keyValue", value: keyValue };
            t.push(obj);
            t.push(fileobj);
            t.push(keyobj);
            //更新子项及上传子项文件
            page.getItem();
            for (var p = 0; p < itemarray.length; p++) {
                //上传子项文件
                var itemobj = [
                    { name: 'childList[' + p + '].Id', value: itemarray[p].Id },
                    { name: 'childList[' + p + '].type', value: itemarray[p].type },
                    { name: 'childList[' + p + '].clg_id', value: itemarray[p].clg_id },
                    { name: 'childList[' + p + '].clg_name', value: itemarray[p].clg_name },
                    { name: 'childList[' + p + '].n_docum', value: itemarray[p].n_docum },
                    { name: 'childList[' + p + '].app_id', value: itemarray[p].app_id },
                    { name: 'childList[' + p + '].app_body', value: itemarray[p].app_body },
                    { name: 'childList[' + p + '].ref_item', value: itemarray[p].ref_item },
                    { name: 'childList[' + p + '].t_id', value: itemarray[p].t_id },
                    { name: 'childList[' + p + '].t_cn', value: itemarray[p].t_cn },
                    { name: 'childList[' + p + '].t_en', value: itemarray[p].t_en },
                    { name: 'childList[' + p + '].t_def', value: itemarray[p].t_def },
                    { name: 'childList[' + p + '].t_note', value: itemarray[p].t_note },
                    { name: 'childList[' + p + '].t_exp', value: itemarray[p].t_exp },
                    { name: 'childList[' + p + '].pic', value: itemarray[p].pic },
                    { name: 'childList[' + p + '].sfile', value: itemarray[p].pic },
                    { name: 'childList[' + p + '].tech_itid', value: itemarray[p].tech_itid },
                    { name: 'childList[' + p + '].tech_itname', value: itemarray[p].tech_itname },
                    { name: 'childList[' + p + '].tech_ptbody', value: itemarray[p].tech_ptbody },
                    { name: 'childList[' + p + '].tech_level', value: itemarray[p].tech_level },
                    { name: 'childList[' + p + '].tech_pic', value: itemarray[p].tech_pic }];
                for (var y = 0; y < itemobj.length; y++) {
                    t.push(itemobj[y]);
                }
            }
            console.log(t);
            $.ajax({
                url: '/LR_CodeDemo/Standard/SaveForm',
                type: 'POST',
                data: t,
                dataType: "json",
                success: function (result) {
                    console.log(result);
                    if (result.code == 200) {
                        //提交成功
                        $("#myModal").modal("show")
                    } else {
                        $("#myModals").modal("show")
                    }
                }
            });
        },
        setPage: function (pageCurrent, pageSum, callback) {

        },
        initup: function () {
            uploader = WebUploader.create({
                // swf文件路径
                swf: '../Content/webuploader/Uploader.swf',
                // 文件接收服务端。
                server: '/LR_CodeDemo/Standard/UploadifyFile',
                // 选择文件的按钮。可选。
                // 内部根据当前运行是创建，可能是input元素，也可能是flash.
                pick: {
                    id: '#picker',
                    multiple: false,
                    label: '点击选择PDF'
                },
                auto: false,
                // 不压缩image, 默认如果是jpeg，文件上传前会压缩一把再上传！
                resize: false,
                accept: {
                    title: 'PDF',
                    extensions: 'pdf',
                    mimeTypes: 'application/pdf'
                }
            });

            uploader.on('fileQueued', function (file) {
                var $list = $('#thelist');
                $list.append('<div id="' + file.id + '" class="item">' +
                    '<h4 class="info">' + file.name + '</h4>' +
                    '<p class="state">等待上传...</p>' +
                    '</div>');
            });

            // 文件上传过程中创建进度条实时显示。
            uploader.on('uploadProgress', function (file, percentage) {
                var $li = $('#' + file.id),
                    $percent = $li.find('.progress .progress-bar');

                // 避免重复创建
                if (!$percent.length) {
                    $percent = $('<div class="progress progress-striped active">' +
                        '<div class="progress-bar" role="progressbar" style="width: 0%">' +
                        '</div>' +
                        '</div>').appendTo($li).find('.progress-bar');
                }

                $li.find('p.state').text('上传中');
                $percent.css('width', percentage * 100 + '%');
            });

            // 当有文件被添加进队列的时候
            uploader.on('beforeFileQueued', function (file) {
                if (file.size != 0) {
                    judge = true;
                }
            });


            uploader.on('uploadSuccess', function (file, response) {
                $('#' + file.id).find('p.state').text('已上传');
                //console.log(response);
                //pdf上传完成后上传数据
                if (response.code == 200) {
                    //console.log(response)
                    page.uploadformMain(response.info);
                }
            });

            uploader.on('uploadError', function (file, reason) {
                $('#' + file.id).find('p.state').text('上传出错');
            });

            uploader.on('uploadComplete', function (file) {
                $('#' + file.id).find('.progress').fadeOut();
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
                    console.log(result)
                    var item = result.data;
                    //标准Id
                    $("#Id").val(item.Id);
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
                    //$("input[name='AbolitionDate']").val(item.OriginalName);
                    //英文主题词
                    //$("input[name='AbolitionDate']").val(item.EnglishSubjectWords);
                    //中文主题词
                    //$("input[name='AbolitionDate']").val(item.ChineseThemeWords);
                    //发布单位
                    $("input[name='PublishingUnit']").val(item.PublishingUnit);
                    //批准单位
                    $("input[name='ApprovedUnit']").val(item.ApprovedUnit);
                    //提出单位
                    $("input[name='ProposedUnit']").val(item.ProposedUnit);
                    //起草单位
                    $("input[name='DraftingUnit']").val(item.DraftingUnit);
                    //替代标准
                    $("input[name='SubstituteStandard']").val(item.SubstituteStandard);
                    //被替代标准
                    $("input[name='SubstitutedStandard']").val(item.SubstitutedStandard);
                    //归口单位
                    //$("#TechnicalCommittees").val(item.TechnicalCommittees);
                    //适用范围
                    $("input[name='scope']").val(item.Scope);
                    //CCS
                    $("input[name='ccs']").val(item.Ccs);
                    //ICS
                    $("input[name='ics']").val(item.Ics);
                    //GBN
                    $("input[name='gbn']").val(item.Gbn);
                    //页数
                    $("input[name='Pages']").val(item.Pages);
                    //国民经济分类
                    //$("#input[name='SubstitutedStandard']").val(item.ClassificationEconomy);
                    //备案号
                    $("input[name='RecordNumber']").val(item.RecordNumber);
                    //标准类型
                    //$("#StandardType").val(item.StandardType);
                    //前言
                    $("input[name='preface']").val(item.Preface);
                    //全文光盘
                    //$("#CdRom").val(item.CdRom);
                    //文本地址
                    //$("#TextAddress").val(item.TextAddress);
                    //引言
                    //$("#introduction").val(item.Introduction);
                    //语种
                    //$("#Languages").val(item.Languages);
                    //是否有翻译
                    //$("#IsTranslation").val(item.IsTranslation);
                    //是否有翻译件
                    //$("#IsTranslationd").val(item.IsTranslationd);
                    //翻译件语种
                    //$("#TranslationLanguage").val(item.TranslationLanguage);
                    //标准所在合订本名称
                    //$("#NameTheStandard").val(item.NameTheStandard);
                    //所属标委会
                    //$("#AffiliatedCommittee").val(item.AffiliatedCommittee);
                    //ISBN
                    //$("#ISBN").val(item.ISBN);
                    //首次记录时间
                    //$("#FirstRecordingTime").val(item.FirstRecordingTime);
                    //最后修改时间
                    //$("#LastModifyTime").val(item.LastModifyTime);
                    //馆藏标志
                    //$("#CollectionMark").val(item.CollectionMark);
                    //单行本
                    //$("#SingleCopy").val(item.SingleCopy);
                    //创建日期
                    $("input[name='ModifyDate']").val(item.CreateTime);
                    //修改日期
                    $("input[name='CreateTime']").val(item.ModifyDate);
                    //修改件
                    //$("#Amendment").val(item.Amendment);
                    //题录类型
                    //$("#TypesTitles").val(item.TypesTitles);
                    //加入方式
                    //$("#WayAdding").val(item.WayAdding);
                    //组织号
                    //$("#OrganizationNumber").val(item.OrganizationNumber);
                    //顺序号
                    //$("#SequenceNumber").val(item.SequenceNumber);
                    //年代号
                    //$("#AgeNumber").val(item.AgeNumber);
                    //最后修改
                    //$("#LastModifiedIP").val(item.LastModifiedIP);
                    //表名 题录
                    $("#TableName").val(item.TableName);
                    layui.use(['form'], function () {
                        $ = layui.jquery;
                        var form = layui.form;
                        form.render(); //刷新select选择框渲染
                    });
                    //标准状态
                    $("input[name='StandStatus']").val(item.StandStatus);
                    //代替标准
                    //$("#SubstituteStandard").val(item.SubstituteStandard);
                    //被代替标准
                    //$("#SubstitutedStandard").val(item.SubstitutedStandard);
                    //采用关系
                    //$("#AdoptionRelationship").val(item.AdoptionRelationship);
                    //补充件
                    //$("#Supplement").val(item.Supplement);
                    //排序字段
                    //$("#SortField").val(item.SortField);
                    //是否作废
                    //$("#Status").val(item.Status);
                    //替代标准
                    //$("#SubStandard").val(item.SubStandard);
                    //是否审核
                    //$("#IsAudited").val(item.IsAudited);
                    //转换数字的排序字符
                    //$("#ConvertCharacters").val(item.ConvertCharacters);
                    //是否免费
                    $("input[name='isfree']").val(item.isfree);
                    //电子文本来源
                    
                    //console.log(item.ElectronicSource.substr(1));
                    if (item.ElectronicSource != null) {
                        var arr = item.ElectronicSource.split("/");
                        var cpdf = '';
                        cpdf += '<a target="_blank" href="' + window.location.origin + item.ElectronicSource.substr(1) + '">';
                        cpdf += arr[2];
                        cpdf += '</a>';
                        $("#ElectronicSource").html(cpdf);
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
                    htmgui += '<input class="ctinput" type="text" value="' + itemoldarray[i].n_docum + '" name="n_docum">';
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
                    htmflu += '<input  class="ctinput" type="text" value="' + itemoldarray[i].app_id + '" name="app_id">';
                    htmflu += '</td>';
                    htmflu += '<td>';
                    htmflu += '<input  class="ctinput" type="text" value="' + itemoldarray[i].app_body+'" name="app_body">';
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
                    htmcank += '<input id="cankaowenxi" class="ctinput" value="' + itemoldarray[i].ref_item + '" type="text" name="ref_item">';
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
                    htmshyu += '<input class="ctinput" type="text" value="' + itemoldarray[i].t_id + '" name="t_id">';
                    htmshyu += '</td>';
                    htmshyu += '<td>';
                    htmshyu += '<input class="ctinput" type="text" value="' + itemoldarray[i].t_cn + '" name="t_cn">';
                    htmshyu += '</td>';
                    htmshyu += '<td>';
                    htmshyu += '<input class="ctinput" type="text" value="' + itemoldarray[i].t_en + '" name="t_en">';
                    htmshyu += '</td>';
                    htmshyu += '<td>';
                    htmshyu += '<input class="ctinput" type="text" value="' + itemoldarray[i].t_def + '" name="t_def">';
                    htmshyu += '</td>';
                    htmshyu += '<td>';
                    htmshyu += '<input class="ctinput" type="text" value="' + itemoldarray[i].t_note + '" name="t_note">';
                    htmshyu += '</td>';
                    htmshyu += '<td>';
                    htmshyu += '<input class="ctinput" type="text" value="' + itemoldarray[i].t_exp + '" name="t_exp">';
                    htmshyu += '</td>';
                    htmshyu += '<td>';
                    htmshyu += '<input class="ctinput" type="file"  name="pic">';
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
                    htmmuci += '<input  class="ctinput" type="text" value="' + itemoldarray[i].clg_id + '" name="clg_id">';
                    htmmuci += '</td>';
                    htmmuci += '<td>';
                    htmmuci += '<input class="ctinput" type="text" value="' + itemoldarray[i].clg_name + '" name="clg_name">';
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
                    htmjiegou += '<select class="form-control" name="tech_level">';
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
                    htmjiegou += '<input class="ctinput" value="' + itemoldarray[i].tech_itid + '" type="text" name="tech_itid">';
                    htmjiegou += '</td>';
                    htmjiegou += '<td>';
                    htmjiegou += '<input class="ctinput" value="' + itemoldarray[i].tech_itname + '" type="text" name="tech_itname">';
                    htmjiegou += '</td>';
                    htmjiegou += '<td>';
                    htmjiegou += '<input class="ctinput" value="' + itemoldarray[i].tech_ptbody + '" type="text" name="tech_ptbody">';
                    htmjiegou += '</td>';
                    htmjiegou += '<td>';
                    htmjiegou += '<input class="ctinput"  type="file"  name="tech_pic">';
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

