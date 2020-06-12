/* 
 * 创建人：超级管理员
 * 日  期：2020-02-11 10:59
 * 描  述：搜索引擎管理
 */
var bootstrap = function ($) {
    "use strict";
    let currentPage = 1;
    let pageSize = 10;
    var page = {
        init: function () {
            page.bind();
            page.inittable();
        },
        bind: function () {
            $.ajax({
                type: "GET",    //请求类型 
                url: '/LR_CodeDemo/SearchEngine/GetAllTable',    //请求地址和参数    GET请求才把参数写在这里
                dataType: "json",
                success: function (res) {   //请求成功后执行的函数res是返回的值
                    var result = res.data.rows;
                    var htm = '';
                    for (var i = 0; i < result.length;i++) {
                        htm += '<tr>';
                        htm += '<td>';
                        htm += result[i];
                        htm += '</td>';
                        htm += '<td>';
                        htm += '<button onclick="addenigen(\''+result[i]+'\')">加入搜索引擎</button>';
                        htm += '</td>';
                        htm += '<td>';
                        htm += '</td>';
                        htm += '</tr>';
                    }
                    $("#tbody").html(htm);
                }
            });

            $("#updateall").click(function () {
                //添加搜索引擎
                $.ajax({
                    url: '/LR_CodeDemo/SearchEngine/EngineInitAll',    //请求地址和参数    GET请求才把参数写在这里
                    type: 'GET',
                    dataType: "json",
                    success: function (res) {   //请求成功后执行的函数res是返回的值
                        console.log(res)
                    }
                });

            });
        },
        inittable: function () {

        },
        render: function () {
            
        }
    };
    page.init();
}
bootstrap(jQuery);

function addenigen(te) {
   //添加搜索引擎
    $.ajax({
        url: '/LR_CodeDemo/SearchEngine/EngineInit',    //请求地址和参数    GET请求才把参数写在这里
        type: 'GET',
        data: {
            tname: te
        },
        dataType: "json",
        success: function (res) {   //请求成功后执行的函数res是返回的值
            console.log(res)
        }
    });
}

