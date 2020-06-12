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
        },
        bind: function () {

            // 根据表格搜索异步引擎初始化
            $('#Initializationbufen').on('click', function () {
                // 搜索引擎初始化异步
                $.ajax({
                    url: '/LR_CodeDemo/SearchEngine/EngineInit',    //请求地址和参数    GET请求才把参数写在这里
                    type: 'GET',
                    data: {
                        tname: $('#tablename').val()
                    },
                    dataType: "json",
                    success: function (res) {   //请求成功后执行的函数res是返回的值
                        console.log(res)
                    }
                });
            });

            // 搜索引擎整体初始化异步
            $('#Initialization').on('click', function () {
                $.ajax({
                    type: "GET",    //请求类型 
                    url: top.$.rootUrl + '/LR_CodeDemo/SearchEngine/EngineInitAll',    //请求地址和参数    GET请求才把参数写在这里
                    success: function (res) {   //请求成功后执行的函数res是返回的值
                        console.log(res)
                    }
                });
            });

            // 搜索引擎整体同步初始化
            $('#InitializationAsyn').on('click', function () {
                $("#suModal").modal("show")

                $.ajax({
                    type: "GET",    //请求类型 
                    url: top.$.rootUrl + '/LR_CodeDemo/SearchEngine/EngineInitAllAsyc',    //请求地址和参数    GET请求才把参数写在这里
                    success: function (res) {   //请求成功后执行的函数res是返回的值
                        console.log(res)
                        $("#suModal").modal("hide")
                    }
                });
            });

            //单个标准搜索引擎同步初始化
            $('#iteminit').on('click', function () {
                $("#suModal").modal("show")

                $.ajax({
                    type: "GET",    //请求类型 
                    data: {
                        id: $('#standardidname').val()
                    },
                    url: top.$.rootUrl + '/LR_CodeDemo/SearchEngine/EngineInitItemAsyc',    //请求地址和参数    GET请求才把参数写在这里
                    success: function (res) {   //请求成功后执行的函数res是返回的值
                        console.log(res)
                        $("#suModal").modal("hide")
                    }
                });
            });





            // 搜索引擎清除
            $('#delete').on('click', function () {
                $.ajax({
                    type: "GET",    //请求类型 
                    url: top.$.rootUrl + '/LR_CodeDemo/SearchEngine/DeleteEngine',    //请求地址和参数    GET请求才把参数写在这里
                    success: function (res) {   //请求成功后执行的函数res是返回的值
                        console.log(res)
                    }
                });
            });
            // 搜索
            $('#search').on('click', function () {
                page.render();
            });
        },
        render: function () {
            $.ajax({
                url: top.$.rootUrl + '/LR_CodeDemo/SearchEngine/search',
                type: 'GET',
                data: {
                    pagea: currentPage,
                    keyword: $('#key').val(),
                    pagesizea: pageSize
                },
                dataType: "json",
                success: function (result) {
                    var results = result.data.rows;
                    var htmla = '';
                    for (var i = 0; i < results.length; i++) {  
                        htmla += '<div class="resultitem">';
                        htmla += '<div class="itemtitle">';
                        htmla += '<a href="' + top.$.rootUrl + '/LR_CodeDemo/Standard/Detail?id=' + results[i].Id + '" target="_blank">' + results[i].StandNum + '&nbsp;&nbsp;' + results[i].ChineseName + '</a>';
                        htmla += '</div>';

                        htmla += '<div class="itemcis">';
                        htmla += '国际标准分类号（ICS）  '+ results[i].ICS;
                        htmla += '</div>';

                        htmla += '<div class="itemccs">';
                        htmla += '中国标准分类号（CCS） ' +results[i].BidWinningNo;
                        htmla += '</div>';

                        htmla += '<div class="itemshishi">';
                        htmla += '发布日期  ' + results[i].Isd;
                        htmla += '</div>';

                        htmla += '<div class="itemstatus">';
                        htmla += '实施日期  ' + results[i].Efd;
                        htmla += '</div>';

                        htmla += '<div class="itemstatus">';
                        htmla += '标准状态  ' + results[i].StandStatus;
                        htmla += '</div>';

                        htmla += '</div>';

                    }
                    $('#resultt').html(htmla);
                    page.setPage(currentPage, Math.ceil(result.data.total / pageSize), page.render)
                    $('#totalnum').html('总数为'+result.data.total)
                }
            })
        },
        setPage: function (pageCurrent, pageSum, callback) {
            $(".pagination").bootstrapPaginator({
                //设置版本号
                bootstrapMajorVersion: 3,
                // 显示第几页
                currentPage: pageCurrent,
                // 总页数
                totalPages: pageSum,
                //当单击操作按钮的时候, 执行该函数, 调用ajax渲染页面
                onPageClicked: function (event, originalEvent, type, page) {
                    // 把当前点击的页码赋值给currentPage, 调用ajax,渲染页面
                    currentPage = page
                    callback && callback()
                }
            })
        }
    };
    page.init();
}
bootstrap(jQuery);

