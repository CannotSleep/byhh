/*
 * 创建人：超级管理员
 * 日  期：2020-02-11 10:42
 * 描  述：标准查新
 */
var bootstrap = function ($, learun) {
    "use strict";
    var layer;
    var lindex;
    var tabl;
    //输入的标准号数组
    //var standardnumarr = [];
    //解析word得到的数组
    var itemarry = [];
    //查证后数组
    var carry = [];
    var layer;
    var lindex;
    var page = {
        init: function () {
            page.bindupload();
            page.bind();
            page.initData();
        },
        bindupload: function () {
            //绑定上传文件
            layui.use('upload', function () {
                var $ = layui.jquery
                    , upload = layui.upload;
                //指定允许上传的文件类型
                upload.render({
                    elem: '#testyy'
                    , url: '/LR_CodeDemo/Standard/GetWord' //改成您自己的上传接口
                    , accept: 'file' //普通文件
                    , done: function (res) {
                        layer.msg('上传成功');
                        layer.close(lindex);

                        var resu = JSON.parse(res.data.rows);

                        for (var i = 0; i < resu.length; i++) {
                            var it = {
                                XNum: i + 1,
                                StandNum: resu[i],
                                Cn: '',
                                StandStatus: '',
                                SubstituteStandard: '',
                                AbolitionDate: '',
                            }
                            itemarry.push(it);
                        }

                        tabl.render({
                            elem: '#demo'
                            , cols: [[ //标题栏
                               // { type: 'checkbox', fixed: 'left' }
                                { field: 'XNum', title: '序号', width: 60, edit: 'text' }
                                , { field: 'StandNum', title: '标准号', width: 200, edit: 'text' }
                                , { field: 'Cn', title: '标准名称', width: 240, edit: 'text' }
                                , { field: 'StandStatus', title: '标准状态', minWidth: 160, edit: 'text' }
                                , { field: 'SubstituteStandard', title: '被替代标准', minWidth: 160, edit: 'text' }
                                , { field: 'AbolitionDate', title: '废止时间', minWidth: 160, edit: 'text' }
                            ]]
                            , data: itemarry
                            //, toolbar: '#toolbarDemo' //开启头部工具栏，并为其绑定左侧模板
                            //,skin: 'line' //表格风格
                            //, even: true
                            , page: true //是否显示分页
                            //,limits: [5, 7, 10]
                            , limit: 100 //每页默认显示的数量
                        });


                        //头工具栏事件
                        tabl.on('toolbar(demo)', function (obj) {
                            var checkStatus = tabl.checkStatus(obj.config.id);
                            switch (obj.event) {
                                case 'getCheckData':
                                    var data = checkStatus.data;
                                    //layer.alert(JSON.stringify(data));

                                    var objda = { "objdata": JSON.stringify(data) };
                                    console.log(objda)
                                    $.ajax({
                                        url: '/LR_CodeDemo/Standard/ExportWord',
                                        type: 'POST',
                                        data: objda,
                                        dataType: "json",
                                        success: function (result) {
                                            console.log(result)
                                            layer.msg('生成成功');
                                            layer.close(lindex);
                                            var rdata = result.info
                                            if (result.code == 200) {
                                                //转换成功
                                                $("#res").html('<a id="tdoc" style="display:none"  href="/Template/' + rdata + '">111111</a>')
                                                document.getElementById("tdoc").click();
                                            }
                                        }
                                    });
                                    break;
                            };
                        });

                        //监听行工具事件
                        tabl.on('tool(demo)', function (obj) {
                            var data = obj.data;
                            //console.log(obj)
                            if (obj.event === 'del') {
                                layer.confirm('真的删除行么', function (index) {
                                    obj.del();
                                    layer.close(index);
                                });
                            }
                           
                        });

                    }, choose: function (obj) {
                        layui.use('layer', function () {
                            layer = layui.layer;
                            lindex = layer.load(0);
                        }); 
                    }
                });
            })
        },
        bind: function () {

            //生成word
            $("#exportword").click(function () {
                var obj = { "standardArray": '111' };
                $.ajax({
                    url: '/LR_CodeDemo/Standard/ExportWord',
                    type: 'POST',
                    data: obj,
                    dataType: "json",
                    success: function (result) {
                        console.log(result)
                    }
                });
            })

            //开始查证
            $("#track").click(function () {
                layui.use('layer', function () {
                    layer = layui.layer;
                    lindex = layer.load(0);
                }); 

                var numarr = "";
                for (var i = 0; i < itemarry.length; i++) {
                    if (i === itemarry.length-1) {
                        numarr += "'" + itemarry[i].StandNum + "'";
                    } else {
                        numarr += "'" + itemarry[i].StandNum + "'" + ",";
                    }
                }
                var obj = { "standardArray": numarr };
                $.ajax({
                    url: '/LR_CodeDemo/Standard/TrackStandard',
                    type: 'POST',
                    data: obj,
                    dataType: "json",
                    success: function (result) {
                        console.log(result);
                        if (result.code == 200) {
                            //提交成功
                            layer.close(lindex);
                            layer.msg("查证成功");
                            ////获取回的标准数据
                            var resu = result.data;
                            //判断标准是否都有查询结果
                            //首先循环输入标准号
                            for (var m = 0; m < itemarry.length; m++) {
                                var isexit = false;
                                //循环结果
                                for (var n = 0; n < resu.length;n++) {
                                    //获取标准号
                                    if (itemarry[m].StandNum === resu[n].StandNum) {
                                        isexit = true;
                                        var itt = {
                                            XNum: m + 1,
                                            Csta:1,
                                            StandNum: resu[n].StandNum,
                                            Cn: resu[n].Cn,
                                            StandStatus: resu[n].StandStatus,
                                            SubstituteStandard: resu[n].SubstitutedStandard,
                                            AbolitionDate: resu[n].AbolitionDate,
                                            TableName: resu[n].TableName
                                        }
                                        carry.push(itt)
                                    }
                                }
                                if (!isexit) {
                                    var wobj = {
                                        XNum: m + 1,
                                        Csta: 0,
                                        StandNum: itemarry[m].StandNum,
                                        Cn: '',
                                        StandStatus: '',
                                        SubstituteStandard: '',
                                        AbolitionDate: '',
                                        TableName:''
                                    }
                                    carry.push(wobj)
                                }
                            }
                            //console.log(resu);
                            //展示已知数据
                            page.inittable();
                        } else {
                            layer.close(lindex);
                            上传失败
                            layer.open({
                                title: '错误'
                                , content: '追踪失败'
                            });
                        }
                    }
                });
            })
        },
        initData: function () {
            layui.use('table', function () {
                tabl = layui.table;

                
            });
        },
        inittable: function () {
            tabl.render({
                elem: '#demo'
                , cols: [[ //标题栏
                    { type: 'checkbox', fixed: 'left' }
                    , { field: 'XNum', title: '序号', width: 60, edit: 'text' }
                    , { field: 'Csta', title: '查证状态', width: 100, templet: '#usernameTpl' }
                    , { field: 'StandNum', title: '标准号', width: 200, edit: 'text' }
                    , { field: 'Cn', title: '标准名称', width: 240, edit: 'text' }
                    , { field: 'StandStatus', title: '标准状态', minWidth: 160, edit: 'text' }
                    , { field: 'SubstituteStandard', title: '被替代标准', minWidth: 160, edit: 'text' }
                    , { field: 'AbolitionDate', title: '废止时间', minWidth: 160, edit: 'text' }
                    , { field: 'TableName', title: '标准分类', minWidth: 0, edit: 'text' }
                    , { fixed: 'right', title: '操作', toolbar: '#barDemo', width: 150 }
                ]]
                , data: carry
                , toolbar: '#toolbarDemo' //开启头部工具栏，并为其绑定左侧模板
                //,skin: 'line' //表格风格
                //, even: true
                , page: true //是否显示分页
                //,limits: [5, 7, 10]
                , limit: 100 //每页默认显示的数量
            });


            //头工具栏事件
            tabl.on('toolbar(demo)', function (obj) {
                var checkStatus = tabl.checkStatus(obj.config.id);
                switch (obj.event) {
                    case 'getCheckData':
                        layui.use('layer', function () {
                            layer = layui.layer;
                            lindex = layer.load(0);
                        });
                        var data = checkStatus.data;
                        //layer.alert(JSON.stringify(data));

                        var objda = { "objdata": JSON.stringify(data) };
                        console.log(objda)
                        $.ajax({
                            url: '/LR_CodeDemo/Standard/ExportWord',
                            type: 'POST',
                            data: objda,
                            dataType: "json",
                            success: function (result) {
                                console.log(result)
                                layer.msg('生成成功');
                                layer.close(lindex);
                                var rdata = result.info
                                if (result.code == 200) {
                                    //转换成功
                                    $("#res").html('<a id="tdoc" style="display:none"  href="/Template/' + rdata + '">111111</a>')
                                    document.getElementById("tdoc").click();
                                }
                            }
                        });
                        break;
                };
            });

            //监听行工具事件
            tabl.on('tool(demo)', function (obj) {
                var dataaa = obj.data;
                //console.log(obj)
                if (obj.event === 'del') {
                    layer.confirm('真的删除行么', function (index) {
                        obj.del();
                        layer.close(index);
                    });
                }
                if (obj.event === 'edit') {
                    console.log(dataaa)
                    var xxnum = dataaa.XNum;
                    layer.open({
                        type: 1
                        //, offset: type //具体配置参考：http://www.layui.com/doc/modules/layer.html#offset
                        //, id: 'layerDemo' + type //防止重复弹出
                        , content: '<table class="layui-hide" id="mohudemo" lay-filter="mohudemo"></table>'
                        , btn: '关闭'
                        //, btnAlign: 'c' //按钮居中
                        , shade: 0 //不显示遮罩
                        , yes: function () {
                            layer.closeAll();
                        }
                        , success: function (layero, index) {
                            lindex = layer.load(0);
                            //弹出层打开成功 进行标准模糊查询
                            var objda = { "standnum": dataaa.StandNum };
                            $.ajax({
                                url: '/LR_CodeDemo/Standard/TrackMohuStandard',
                                type: 'POST',
                                data: objda,
                                dataType: "json",
                                success: function (result) {
                                    console.log(result)
                                    layer.msg('查询成功');
                                    layer.close(lindex);
                                    //初始化表格
                                    tabl.render({
                                        elem: '#mohudemo'
                                        , cols: [[ //标题栏
                                            { type: 'checkbox', fixed: 'left' }
                                            , { field: 'StandNum', title: '标准号', width: 200, edit: 'text' }
                                            , { field: 'Cn', title: '标准名称', width: 240, edit: 'text' }
                                            , { field: 'StandStatus', title: '标准状态', minWidth: 160, edit: 'text' }
                                            , { field: 'SubstituteStandard', title: '被替代标准', minWidth: 160, edit: 'text' }
                                            , { field: 'AbolitionDate', title: '废止时间', minWidth: 160, edit: 'text' }
                                            , { field: 'TableName', title: '标准分类', minWidth: 0, edit: 'text' }
                                            , { fixed: 'right', title: '操作', toolbar: '#mbarDemo', width: 150 }
                                        ]]
                                        , data: result.data
                                        //, toolbar: '#mbarDemo' //开启头部工具栏，并为其绑定左侧模板
                                        //,skin: 'line' //表格风格
                                        //, even: true
                                        , page: true //是否显示分页
                                        //,limits: [5, 7, 10]
                                        , limit: 100 //每页默认显示的数量
                                    });

                                    //监听行工具事件
                                    tabl.on('tool(mohudemo)', function (objj) {
                                        var datac = objj.data;
                                        //console.log(obj)
                                        if (objj.event === 'confirm') {
                                            //获取模糊查询获得的数据
                                            console.log(datac)
                                            //更新上级表格数据
                                            for (var n = 0; n < carry.length; n++) {
                                                if (xxnum === carry[n].XNum) {
                                                    carry[n].StandNum = datac.StandNum;
                                                    carry[n].Cn = datac.Cn;
                                                    carry[n].StandStatus = datac.StandStatus;
                                                    carry[n].SubstituteStandard = datac.SubstituteStandard;
                                                    carry[n].AbolitionDate = datac.AbolitionDate;
                                                    carry[n].TableName = datac.TableName;
                                                }
                                            }
                                            layer.closeAll();                                        }
                                    });
                                }
                            });
                        }
                        , end: function () {
                            //层销毁
                            page.inittable();
                        }
                    });
                }
            });
        }
    };
    page.init();
}
bootstrap(jQuery);
//删除行
function delN(obj) {
    var oParent = obj.parentNode.parentNode;
    oParent.remove();
    //document.getElementById('table').removeChild(oParent);
}
