/* 
 * 创建人：超级管理员
 * 日  期：2020-02-11 10:59
 * 描  述：搜索引擎管理
 */
var sid = '';
var bootstrap = function ($) {
    "use strict";
    let currentPage = 1;
    let pageSize = 10;
    var page = {
        init: function () {
            page.bind();
        },
        bind: function () {
            // 搜索
            $('#search').on('click', function () {
                page.render();
            });
            $('#myModal').on('hide.bs.modal', function () {
                // 执行一些动作...
                $("#suModal").modal("show")
            })
            $('#suModal').on('hide.bs.modal', function () {
                window.location.reload()
            })
        },
        render: function () {
            $.ajax({
                url:  '/LR_CodeDemo/SearchEngine/search',
                type: 'GET',
                data: {
                    pagea: currentPage,
                    keyword: $('#key').val(),
                    pagesizea: pageSize
                },
                dataType: "json",
                success: function (result) {
                    console.log(result)
                    var results = result.data.rows;
                    var htmla = '';
                    for (var i = 0; i < results.length; i++) {
                        htmla += '<div class="resultitem">';
                        htmla += '<div class="itemtitle">';
                        htmla += '<a href="/LR_CodeDemo/Standard/Detail?id=' + results[i].Id + '" target="_blank">' + results[i].StandNum + '&nbsp;&nbsp;' + results[i].Cn + '</a>';
                        htmla += '<button onclick=deleteStandard("' + results[i].Id + '") target="_blank" style="float:right;margin-left:10px;" class="btn btn-danger">删除</button>';
                        htmla += '<a href="/LR_CodeDemo/Standard/Edit?id=' + results[i].Id + '" target="_blank" style="float:right;margin-left:20px;" class="btn btn-success">编辑</a>';
                        htmla += '</div>';
                        htmla += '<div class="itemcis">';
                        htmla += '国际标准分类号（ICS）' + results[i].ICS;
                        htmla += '</div>';

                        htmla += '<div class="itemccs">';
                        htmla += '中国标准分类号（CCS） ' + results[i].CCS;
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
                    if (result.data.total!=0) {
                        page.setPage(currentPage, Math.ceil(result.data.total / pageSize), page.render)
                    }
                    $('#totalnum').html('总数为' + result.data.total)
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

function deleteStandard(id, tn) {
    sid = id;
    $("#myModal").modal("show")
}

function confirm() {
    $.ajax({
        url: '/LR_CodeDemo/Standard/DeleteForm',
        type: 'POST',
        dataType: 'json',
        data: { keyValue: sid},
        success: function (data) {
            console.log(data);
            $("#myModal").modal("hide")
        },
        error: function (response) {
            console.log(response);
            $("#myModal").modal("hide")
        }
    });
}
