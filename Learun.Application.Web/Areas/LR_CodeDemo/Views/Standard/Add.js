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
    let itemarray=[];
    var uploader;
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
            page.initup();
        },
        initpart: function () {
            layui.use('form', function () {
                var form = layui.form; //只有执行了这一步，部分表单元素才会自动修饰成功
                form.render();
            });
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
                        layer.close(lindex);
                        //文件上传失败
                        layer.open({
                            title: '错误'
                            ,content: '文件上传失败，请联系管理员'
                        });
                        return;
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
                layer.close(lindex);
                //表单监听
                form.on('submit(demo1)', function (data) {
                    lindex = layer.load(2);
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
                        htm += '<option value="' + resl[i].OraganId + ',' + resl[i].OraganizationCode + '">' + resl[i].OraganizationCode + resl[i].OraganizationName + '</option>';
                    }
                    //console.log(htm)
                    $('#TableName').append(htm);
                    //$('#TableName').searchableSelect();
                    page.initform();
                },
                error: function (response) {
                    console.log(response);
                }
            });

            //标准主体提交
            //$("#standard").submit(function (e) {
            //    e.preventDefault();
            //    //表单验证成功  提交 先上传文件
            //    //judge为true 有文件
            //    if (judge) {
            //        //如果有图片 先上传图片
            //        $("#test9").click();
            //    } else {
            //        //如果没有图片 直接上传内容
            //        page.uploadformMain();
            //    }
            //}); 

            //规范性引用文件
            $("#addguifan").click(function () {
                var htm = '';
                htm += '<tr>';
                htm += '<td>';
                htm += '规范性引用文件';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="layui-input" type="text" name="n_docum">';
                htm += '</td>';
                htm += '<td>';
                htm += '<button type="button" onclick="delJGH(this)" class="layui-btn layui-btn-danger">删除</button>';
                htm += '</td>';
                htm += '</tr>';
                $("#zguifan").append(htm);
                page.initpart();
            });

            //附录
            $("#addfulu").click(function () {
                var htm = '';
                htm += '<tr>';
                htm += '<td>';
                htm += '附录';
                htm += '</td>';
                htm += '<td>';
                htm += '<input  class="layui-input" type="text" name="app_id">';
                htm += '</td>';
                htm += '<td>';
                htm += '<input  class="layui-input" type="text" name="app_body">';
                htm += '</td>';
                htm += '<td>';
                htm += '<button type="button" onclick="delJGH(this)" class="layui-btn layui-btn-danger">删除</button>';
                htm += '</td>';
                htm += '</tr>';
                $("#zfulu").append(htm);
                page.initpart();
            });

            //参考文献
            $("#addcankao").click(function () {
                var htm = '';
                htm += '<tr>';
                htm += '<td>';
                htm += '参考文献';
                htm += '</td>';
                htm += '<td>';
                htm += '<input id="cankaowenxi" class="layui-input" type="text" name="cankaowenxi">';
                htm += '</td>';
                htm += '<td>';
                htm += '<button type="button" onclick="delJGH(this)" class="layui-btn layui-btn-danger">删除</button>';
                htm += '</td>';
                htm += '</tr>';
                $("#zcankao").append(htm);
                page.initpart();
            });

            //术语
            $("#addshuyu").click(function () {
                var htm = '';

                htm += '<tr>';
                htm += '<td>';
                htm += '术语';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="layui-input" type="text" name="t_id">';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="layui-input" type="text" name="t_cn">';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="layui-input" type="text" name="t_en">';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="layui-input" type="text" name="t_def">';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="layui-input" type="text" name="t_note">';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="layui-input" type="text" name="t_exp">';
                htm += '</td>';
                htm += '<td>';
                htm += '<input  type="file"  name="pic">';
                htm += '</td>';
                htm += '<td>';
                htm += '<button type="button" onclick="delJGH(this)" class="layui-btn layui-btn-danger">删除</button>';
                htm += '</td>';
                htm += '</tr>';
                $("#zshuyu").append(htm);
                page.initpart();
            });

            //目次
            $("#addmuci").click(function () {
                var htm = '';
                htm += '<tr>';
                htm += '<td>';
                htm += '目次';
                htm += '</td>';
                htm += '<td>';
                htm += '<input  class="layui-input" type="text" name="clg_id">';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="layui-input" type="text" name="clg_name">';
                htm += '</td>';
                htm += '<td>';
                htm += '<button type="button" onclick="delJGH(this)" class="layui-btn layui-btn-danger">删除</button>';
                htm += '</td>';
                htm += '</tr>';
                $("#zmuci").append(htm);
                page.initpart();
            });

            //结构化内容
            $("#addjishu").click(function () {

                var htm = '';
                htm += '<tr>';
                htm += '<td>';
                htm += '结构化内容';
                htm += '</td>';
                htm += '<td>';
                htm += '<select name="tech_level" >';
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
                htm += '<input class="layui-input" type="text" name="tech_itid">';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="layui-input" type="text" name="tech_itname">';
                htm += '</td>';
                htm += '<td>';
                htm += '<input class="layui-input" type="text" name="tech_ptbody">';
                htm += '</td>';
                htm += '<td>';
                htm += '<input  type="file"  name="tech_pic">';
                htm += '</td>';
                htm += '<td>';
                htm += '<button type="button" onclick="delJGH(this)" class="layui-btn layui-btn-danger">删除</button>';
                htm += '</td>';
                htm += '</tr>';
                $("#zjiegou").append(htm);
                page.initpart();
            });

        },
        getItem: function () {
            //获取规范性引用文件
            $("input[name='n_docum']").each(function () {
                var obj = { "n_docum": $(this).val(),"type":1 };
                itemarray.push(obj);
            })
            //附录
            var fuluid = [];
            var fulubody = [];
            $("input[name='app_id']").each(function () {
                fuluid.push($(this).val());
            })
            $("input[name='app_body']").each(function () {
                fulubody.push($(this).val());
            })
            for (var i = 0; i < fuluid.length; i++) {
                var objfulu = { app_id: fuluid[i], app_body: fulubody[i], "type": 2 }
                itemarray.push(objfulu);
            }
            //获取参考性文件
            $("input[name='cankaowenxi']").each(function () {
                var obj = { "ref_item": $(this).val(), "type": 3 };
                itemarray.push(obj);
            })
            //术语
            var shuyut_id = [];
            var shuyut_cn = [];
            var shuyut_en = [];
            var shuyut_def = [];
            var shuyut_note = [];
            var shuyut_exp = [];
            var shuyupic = [];

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
                    t_id: shuyut_id[a],
                    t_cn: shuyut_cn[a],
                    t_en: shuyut_en[a],
                    t_def: shuyut_def[a],
                    t_note: shuyut_note[a],
                    t_exp: shuyut_exp[a],
                    type:4,
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
                            //术语文件上传失败
                            //请求异常回调
                            layer.close(lindex);
                            //文件上传失败
                            layer.open({
                                title: '错误'
                                , content: '文件上传失败，请联系管理员'
                            });
                            return;

                        }
                    });
                }
                itemarray.push(objshuyu);
            }
            //目次
            var clg_id = [];
            var clg_name = [];
            $("input[name='clg_id']").each(function () {
                clg_id.push($(this).val());
            })
            $("input[name='clg_name']").each(function () {
                clg_name.push($(this).val());
            })
            for (var b = 0; b < clg_id.length; b++) {
                var objmuci = { clg_id: clg_id[b], clg_name: clg_name[b], "type": 5 }
                itemarray.push(objmuci);
            }
            //结构文件
            var tech_itid = [];
            var tech_itname = [];
            var tech_ptbody = [];
            var tech_level = [];
            var tech_pic = [];

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

            for (var c = 0; c < tech_level.length; c++) {
                var objjiegou = {
                    tech_level: tech_level[c],
                    tech_itid: tech_itid[c],
                    tech_itname: tech_itname[c],
                    tech_ptbody: tech_ptbody[c],
                    tech_pic: '',
                    type:6
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
                            //结构化文件上传失败
                            layer.close(lindex);
                            //文件上传失败
                            layer.open({
                                title: '错误'
                                , content: '文件上传失败，请联系管理员'
                            });
                            return;

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
            t.push(obj);
            t.push(fileobj);
            //获取子项及上传子项文件
            page.getItem();
            for (var p = 0; p < itemarray.length; p++) {
                //上传子项文件
                var itemobj = [
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
                for (var y = 0; y < itemobj.length;y++) {
                    t.push(itemobj[y]);
                }
            }
            //t.push(itemobj);
            var keyValue = '';
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
                        layer.close(lindex);
                        layer.msg("上传成功");
                    } else {
                        layer.close(lindex);
                        //上传失败
                        layer.open({
                            title: '错误'
                            , content: '上传失败，请联系管理员'
                        });
                    }
                }
            });
        },
        setPage: function (pageCurrent, pageSum, callback) {

        },
        initup: function () {
            
        }
    };
    page.init();
};
bootstrap(jQuery);

//删除行
function delJGH(obj) {
    var oParent = obj.parentNode.parentNode;
    oParent.remove();
    //document.getElementById('table').removeChild(oParent);
}
