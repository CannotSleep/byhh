﻿/* 
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
            
            layui.use('table', function () {
                table = layui.table;

                table.render({
                    elem: '#test'
                    , url: '/LR_CodeDemo/Article/GetPageList'
                    , parseData: function (res) { //res 即为原始返回的数据
                        console.log(res)
                        //console.log(res.data.rows) v
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
                        { field: 'title', title: '文章名称' }
                        , { field: 'createDate', title: '创建时间' }
                        , { fixed: 'right', title: '操作', toolbar: '#barDemo', width: 150 }
                    ]]
                    , page: true
                    , id:'articletable'
                });

                var $ = layui.$, active = {
                    reload: function () {
                        var demoReload = $('#demoReload');
                        //执行重载
                        table.reload('articletable', {
                            page: {
                                curr: 1 //重新从第 1 页开始
                            }
                            , where: {
                                articlename: demoReload.val()
                            }
                        }, 'data');
                    }
                };

                $('.demoTable .layui-btn').on('click', function () {
                    var type = $(this).data('type');
                    active[type] ? active[type].call(this) : '';
                });

                //监听行工具事件
                table.on('tool(test)', function (obj) {
                    var data = obj.data;
                    //console.log(data)
                    if (obj.event === 'del') {
                        var deldat = { keyValue: data.id }
                        layer.confirm('真的删除行么', function (index) {
                            obj.del();
                            $.ajax({
                                url: '/LR_CodeDemo/Article/DeleteForm',
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


                    }
                });
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


