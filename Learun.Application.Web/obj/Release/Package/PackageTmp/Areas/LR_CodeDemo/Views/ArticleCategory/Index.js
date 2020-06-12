/* 
 * 创建人：超级管理员
 * 日  期：2020-02-11 10:59
 * 描  述：标准管理
 */
var bootstrap = function ($) {
    "use strict";
    var layer;
    var lindex;
    var table;
    var page = {
        init: function () {
            //数据加载弹出层
            //加载数据表格
            page.bind();
        },
        bind: function () {


            layui.use(['form', 'layedit', 'upload', 'laydate'], function () {
                var form = layui.form
                    , layedit = layui.layedit
                    , $ = layui.jquery
                    layer = layui.layer
            });

            ////绑定题录类型
            //$.ajax({
            //    url: '/LR_CodeDemo/StandardTitle/GetList',
            //    type: 'Get',
            //    data: JSON,
            //    success: function (data) {
            //        var resl = JSON.parse(data).data;
            //        //console.log(resl);
            //        var htm = '';
            //        for (var i = 0; i < resl.length; i++) {
            //            htm += '<option value="' + resl[i].OraganId + '">' + resl[i].OraganizationCode + resl[i].OraganizationName + '</option>';
            //        }
            //        //console.log(htm)
            //        $('#TableName').append(htm);
            //        //$('#TableName').searchableSelect();
            //        page.initform();
            //    },
            //    error: function (response) {
            //        console.log(response);
            //    }
            //});
            //layui.use('layer', function () {
            //    layer.close(lindex);
            //});
            layui.use('table', function () {
                table = layui.table;

                table.render({
                    elem: '#test'
                    , url: '/LR_CodeDemo/ArticleCategory/GetPageList'
                    , parseData: function (res) { //res 即为原始返回的数据
                        //console.log(res)
                        //console.log(res.data.rows)
                        return {
                            "code": 0, //解析接口状态
                            "msg": "", //解析提示文本
                            "count": res.data.records, //解析数据长度
                            "data": res.data.rows //解析数据列表
                        };
                    }
                    //, toolbar: '#toolbarDemo' //开启头部工具栏，并为其绑定左侧模板
                    , defaultToolbar: ['filter', 'exports', 'print', { //自定义头部工具栏右侧图标。如无需自定义，去除该参数即可
                        title: '提示'
                        , layEvent: 'LAYTABLE_TIPS'
                        , icon: 'layui-icon-tips'
                    }]
                    , title: '用户数据表'
                    , cols: [[
                        { field: 'name', title: '分类名称'}
                        , { fixed: 'right', title: '操作', toolbar: '#barDemo', width: 150 }
                    ]]
                    ,page: true
                });

                //监听行工具事件
                table.on('tool(test)', function (obj) {
                    var data = obj.data;
                    //console.log(data)
                    if (obj.event === 'del') {
                        var deldat = { keyValue:data.id}
                        layer.confirm('真的删除行么', function (index) {
                            obj.del();
                            $.ajax({
                                url: '/LR_CodeDemo/ArticleCategory/DeleteForm',
                                type: 'Post',
                                data: deldat,
                                success: function (result) {
                                    console.log(result)
                                    table.reload("test");
                                },
                                error: function (response) {
                                    console.log(response);
                                }
                            });


                            layer.close(index);
                        });
                    } else if (obj.event === 'edit') {
                        var edata = obj.data;
                        console.log(edata)

                        //编辑
                        layer.open({
                            title: '文章分类编辑'
                            , area: ['400px', '200px']
                            , btn: ['确定']
                            , content: '<label class="layui-form-label">分类名称</label><div class="layui-input-inline"><input type="text" style="display:none" id="eid" name="id" lay-verify="required"  autocomplete="off" value="' + edata.id + '" class="layui-input"><input type="text" id="ceid" name="name" value="' + edata.name+'" lay-verify="required" lay-reqtext="必填" placeholder="请输入" autocomplete="off" class="layui-input"></div>'
                            , yes: function (index, layero) {
                                var obj = { name: "__RequestVerificationToken", value: $.lrToken };
                                var obj1 = { name: "keyValue", value: $("#eid").val() };
                                var obj2 = { name: "name", value: $("#ceid").val() };

                                var ob = []
                                ob.push(obj);
                                ob.push(obj1);
                                ob.push(obj2);

                                $.ajax({
                                    url: '/LR_CodeDemo/ArticleCategory/SaveForm',
                                    type: 'POST',
                                    data: ob,
                                    dataType: "json",
                                    success: function (result) {
                                        console.log(result);
                                        layer.msg(result.info);
                                        layer.close(index);
                                        table.reload("test");
                                    }
                                });

                            }
                        });  


                    }
                });
            });
        },
        uploadformMain: function (filepath) {
            var t = $("#standard").serializeArray();
            var obj = { name: "__RequestVerificationToken", value: $.lrToken };
            var fileobj = { name: "ElectronicSource", value: filepath };
            t.push(obj);
            t.push(fileobj);
            
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

function addCategory() {
    layer.open({
        title: '文章分类新增'
        , area: ['400px', '200px']
        , btn: ['确定']
        , content: '<label class="layui-form-label">分类名称</label><div class="layui-input-inline"><input type="text" id="cid" name="name" lay-verify="required" lay-reqtext="必填" placeholder="请输入" autocomplete="off" class="layui-input"></div>'
        , yes: function (index, layero) {
            var obj = { name: "__RequestVerificationToken", value: $.lrToken };
            var obj1 = { name: "name", value: $("#cid").val() };
            var ob = []
            ob.push(obj);
            ob.push(obj1);

            $.ajax({
                url: '/LR_CodeDemo/ArticleCategory/SaveForm',
                type: 'POST',
                data: ob,
                dataType: "json",
                success: function (result) {
                    console.log(result);
                    layer.msg(result.info);
                    layer.close(index);
                }
            });

        }
    });  
}
