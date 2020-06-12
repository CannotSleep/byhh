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
            layui.use(['form', 'layedit', 'laydate', 'upload'], function () {
                var form = layui.form
                    , layer = layui.layer
                    , layedit = layui.layedit
                    , upload = layui.upload
                    , $ = layui.jquery
                    , laydate = layui.laydate;
                var edindex = layedit.build('demo'); //建立编辑器
                //绑定文章分类数据
                $.ajax({
                    url: '/LR_CodeDemo/ArticleCategory/GetList',
                    type: 'Get',
                    //data: deldat,
                    success: function (result) {
                        var res = JSON.parse(result)
                        //console.log(res)
                        var htm = '<select name="modules" id="scategory" lay-verify="required"  lay-search=""><option value="">直接选择或搜索选择</option>';
                        var darry = res.data.rows;
                        for (var i = 0; i < darry.length; i++) {
                            htm += '<option value="' + darry[i].id + '">' + darry[i].name + '</option>';
                        }
                        htm += '</select>';
                        $("#articlecategory").html(htm)
                        form.render();
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });

                //多文件列表示例
                var demoListView = $('#demoList')
                    , uploadListIns = upload.render({
                        elem: '#testList'
                        , url: 'https://httpbin.org/post' //改成您自己的上传接口
                        , accept: 'file'
                        , multiple: true
                        , auto: false
                        , bindAction: '#testListAction'
                        , choose: function (obj) {
                            var files = this.files = obj.pushFile(); //将每次选择的文件追加到文件队列
                            //读取本地文件
                            obj.preview(function (index, file, result) {
                                var tr = $(['<tr id="upload-' + index + '">'
                                    , '<td>' + file.name + '</td>'
                                    , '<td>' + (file.size / 1024).toFixed(1) + 'kb</td>'
                                    , '<td>等待上传</td>'
                                    , '<td>'
                                    , '<button class="layui-btn layui-btn-xs demo-reload layui-hide">重传</button>'
                                    , '<button class="layui-btn layui-btn-xs layui-btn-danger demo-delete">删除</button>'
                                    , '</td>'
                                    , '</tr>'].join(''));

                                //单个重传
                                tr.find('.demo-reload').on('click', function () {
                                    obj.upload(index, file);
                                });

                                //删除
                                tr.find('.demo-delete').on('click', function () {
                                    delete files[index]; //删除对应的文件
                                    tr.remove();
                                    uploadListIns.config.elem.next()[0].value = ''; //清空 input file 值，以免删除后出现同名文件不可选
                                });

                                demoListView.append(tr);
                            });
                        }
                        , done: function (res, index, upload) {
                            if (res.files.file) { //上传成功
                                var tr = demoListView.find('tr#upload-' + index)
                                    , tds = tr.children();
                                tds.eq(2).html('<span style="color: #5FB878;">上传成功</span>');
                                tds.eq(3).html(''); //清空操作
                                return delete this.files[index]; //删除文件队列已经上传成功的文件
                            }
                            this.error(index, upload);
                        }
                        , error: function (index, upload) {
                            var tr = demoListView.find('tr#upload-' + index)
                                , tds = tr.children();
                            tds.eq(2).html('<span style="color: #FF5722;">上传失败</span>');
                            tds.eq(3).find('.demo-reload').removeClass('layui-hide'); //显示重传
                        }
                    });

                $("#uparticle").click(function () {
                    var fenlei = $("#scategory").val();
                    if (fenlei === '' || fenlei === undefined) {
                        layer.msg('请选择分类');
                        return;
                    }
                    var obj = { name: "__RequestVerificationToken", value: $.lrToken };
                    var obj1 = { name: "title", value: $("#title").val() };
                    var obj2 = { name: "articleCategory_id", value: fenlei };
                    var obj3 = { name: "content", value: layedit.getContent(edindex) };


                    var ob = []
                    ob.push(obj);
                    ob.push(obj1);
                    ob.push(obj2);
                    ob.push(obj3);

                    $.ajax({
                        url: '/LR_CodeDemo/Article/SaveForm',
                        type: 'POST',
                        data: ob,
                        dataType: "json",
                        success: function (result) {
                            console.log(result);
                            layer.msg(result.info);
                        }
                    });

                })

            })

            

           
        },
        setPage: function (pageCurrent, pageSum, callback) {

        },
        initup: function () {

        }
    };
    page.init();
};
bootstrap(jQuery);


