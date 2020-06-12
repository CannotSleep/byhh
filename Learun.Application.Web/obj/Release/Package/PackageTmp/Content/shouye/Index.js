


function LoadPublishingUnitData() {
    var url = "/Home/LoadPublishingUnit";
    $.ajax({
        type: "get",
        dataType: 'json',
       
        url: url,
        success: function (data) {
            //data = JSON.parse(data);
            var categories_str = "[";
            var data_str = "[";
            for (var i = 0; i < data.length; i++) {
                var name = data[i].PublishingUnit;
                var value = data[i].Num;
                if (categories_str != "[") { categories_str += ","; }
                categories_str += "'" + name + "'";
                if (data_str != "[") { data_str += ","; }
                data_str += "" + value + "";
            }
            categories_str += "]";
            data_str += "]";
            LoadPublishingUnit(categories_str, data_str);
        }
    });
}
function LoadPublishingUnit(categories_str, data_str) {
    var chart = Highcharts.chart('container', {
        chart: {
            type: 'bar'
        },
        title: {
            text: '标准发布数量--发布单位'
        },

        xAxis: {
            categories: eval(categories_str),
            title: {
                text: null
            }
        },
        yAxis: {
            min: 0,
            title: {
                text: '标准发布数量',
                align: 'high'
            },
            labels: {
                overflow: 'justify'
            }
        },
        tooltip: {
            valueSuffix: ' 篇'
        },
        plotOptions: {
            bar: {
                dataLabels: {
                    enabled: true,
                    allowOverlap: true // 允许数据标签重叠
                }
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'top',
            x: -40,
            y: 100,
            floating: true,
            borderWidth: 1,
            backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
            shadow: true
        },
        series: [{
            name: '标准发布数量',
            data: eval(data_str)
        }]
    });
}
function LoadOraganizationTypeData() {
    var url = "/Home/LoadOraganizationType";
    $.ajax({
        type: "get",
        dataType: 'json',
       
        url: url,
        success: function (data) {
            //data = JSON.parse(data);
            var categories_str = "[";
            var data_str = "[";
            for (var i = 0; i < data.length; i++) {
                var name = data[i].Describe;
                var value = data[i].Num;
                if (categories_str != "[") { categories_str += ","; }
                categories_str += "'" + name + "'";
                if (data_str != "[") { data_str += ","; }
                data_str += "" + value + "";
            }
            categories_str += "]";
            data_str += "]";
            LoadOraganizationType(categories_str, data_str);
        }
    });
}
function LoadOraganizationType(categories_str, data_str) {
    var chart = Highcharts.chart('container_type', {
        chart: {
            type: 'bar'
        },
        title: {
            text: '标准发布数量--标准类型'
        },

        xAxis: {
            categories: eval(categories_str),
            title: {
                text: null
            }
        },
        yAxis: {
            min: 0,
            title: {
                text: '标准发布数量',
                align: 'high'
            },
            labels: {
                overflow: 'justify'
            }
        },
        tooltip: {
            valueSuffix: ' 篇'
        },
        plotOptions: {
            bar: {
                dataLabels: {
                    enabled: true,
                    allowOverlap: true // 允许数据标签重叠
                }
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'top',
            x: -40,
            y: 100,
            floating: true,
            borderWidth: 1,
            backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
            shadow: true
        },
        series: [{
            name: '标准发布数量',
            data: eval(data_str)
        }]
    });
}
function LoadPublishingUnitYearData() {
    var url = "/Home/LoadPublishingUnitYear";
    $.ajax({
        type: "get",
        dataType: 'json',
     
        url: url,
        success: function (data) {
            //data = JSON.parse(data);
            var categories_str = "[";
            var data_str = "[";
            for (var i = 0; i < data.length; i++) {
                var name = data[i].Year;
                var value = data[i].Num;
                if (categories_str != "[") { categories_str += ","; }
                categories_str += "'" + name + "'";
                if (data_str != "[") { data_str += ","; }
                data_str += "" + value + "";
            }
            categories_str += "]";
            data_str += "]";
            LoadPublishingUnitYear(categories_str, data_str);
        }
    });
}
function LoadPublishingUnitYear(categories_str, data_str) {
    var chart = Highcharts.chart('container_u_year', {
        chart: {
            type: 'column'
        },
        title: {
            text: '标准年发布数量--内蒙古自治区质量技术监督局'
        },

        xAxis: {
            categories: eval(categories_str),
            crosshair: true
        },
        yAxis: {
            min: 0,
            title: {
                text: '发布数量 (篇)'
            }
        },
        plotOptions: {
            bar: {
                dataLabels: {
                    enabled: true,
                    allowOverlap: true // 允许数据标签重叠
                }
            }
        },
        tooltip: {
            // head + 每个 point + footer 拼接成完整的 table
            headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                '<td style="padding:0"><b>{point.y:.1f} 篇</b></td></tr>',
            footerFormat: '</table>',
            shared: true,
            useHTML: true
        },
        plotOptions: {
            column: {
                borderWidth: 0
            }
        },
        dataLabels: {
            enabled: true,
            rotation: -90,
            color: '#FFFFFF',
            align: 'right',
            format: '{point.y:.1f}', // :.1f 为保留 1 位小数
            y: 10
        },
        series: [{
            name: '发布数量',
            data: eval(data_str)
        }]
    });
}
function LoadOraganizationTypeYearData() {
    var url = "/Home/LoadOraganizationTypeYear";
    $.ajax({
        type: "get",
        dataType: 'json',
      
        url: url,
        success: function (data) {
            LoadOYearData();
            var data_str = "";
            var data_str1 = "[";
            var data_str2 = "[";
            var data_str3 = "[";
            var data_str4 = "[";
            for (var m = 0; m < year_data.length; m++) {
                var year = year_data[m].year;
                var val1 = null;
                var val2 = null;
                var val3 = null;
                var val4 = null;
                for (var i = 0; i < data.length; i++) {
                    var name = data[i].Describe;
                    var value = data[i].Num;
                    var yearVal = data[i].YearVal;
                    if (year == yearVal) {
                        if (name == '地方标准') {
                            val1 = value;
                        }
                        if (name == '行业标准') {
                            val2 = value;
                        }
                        if (name == '中华人民共和国国家标准') {
                            val3 = value;
                        }
                        if (name == '国外标准') {
                            val4 = value;
                        }
                    }
                }
                if (data_str1 != "[") { data_str1 += ","; }
                data_str1 += "" + val1 + "";
                if (data_str2 != "[") { data_str2 += ","; }
                data_str2 += "" + val2 + "";
                if (data_str3 != "[") { data_str3 += ","; }
                data_str3 += "" + val3 + "";
                if (data_str4 != "[") { data_str4 += ","; }
                data_str4 += "" + val4 + "";
            }
            data_str1 += "]";
            data_str2 += "]";
            data_str3 += "]";
            data_str4 += "]";
            data_str += "[{name:'地方标准',data:" + data_str1 + "},{name:'行业标准',data:" + data_str2 + "},{name:'中华人民共和国国家标准',data:" + data_str3 + "},{name:'国外标准',data:" + data_str4 + "}]";
            LoadOraganizationTypeYear(categories_year_str, data_str);
        }
    });
}
var categories_year_str = "[";
var year_data;
function LoadOYearData() {
    var url = "/Home/LoadOraganizationTypeYearData";
    $.ajax({
        type: "get",
        dataType: 'json',
        async: false,
        url: url,
        success: function (data) {
            year_data = data;
            for (var i = 0; i < data.length; i++) {
                var year = data[i].year;
                if (categories_year_str != "[") { categories_year_str += ","; }
                categories_year_str += "'" + year + "'";
            }
            categories_year_str += "]";
        }
    });
}
function LoadOraganizationTypeYear(categories_str, data_str) {
    var chart = Highcharts.chart('container_t_year', {
        chart: {
            type: 'column'
        },
        title: {
            text: '标准年发布数量--标准类型'
        },

        xAxis: {
            categories: eval(categories_str),
            crosshair: true
        },
        yAxis: {
            min: 0,
            title: {
                text: '发布数量 (篇)'
            }
        },
        plotOptions: {
            bar: {
                dataLabels: {
                    enabled: true,
                    allowOverlap: true // 允许数据标签重叠
                }
            }
        },
        tooltip: {
            // head + 每个 point + footer 拼接成完整的 table
            headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                '<td style="padding:0"><b>{point.y:.1f} 篇</b></td></tr>',
            footerFormat: '</table>',
            shared: true,
            useHTML: true
        },
        plotOptions: {
            column: {
                borderWidth: 0
            }
        },
        series: eval(data_str)
    });
}
function LoadLoadStatusData() {
    var url = "/Home/LoadStatusData";
    $.ajax({
        type: "get",
        dataType: 'json',
        url: url,
        success: function (data) {
            //data = JSON.parse(data);
            
            var data_str = "[";
            for (var i = 0; i < data.length; i++) {
                var status = data[i].Status;
                var value = data[i].Num;
                if (status == "0") {
                    status = "作废";
                } else {
                    status = "现行";
                }
                if (data_str != "[") { data_str += ","; }
                data_str += "['" + status+"'," + value + "]";
            }
          
            data_str += "]";
            LoadLoadStatus(data_str);
        }
    });
}
function LoadLoadStatus(data_str) {
    // 创建渐变色
    Highcharts.getOptions().colors = Highcharts.map(Highcharts.getOptions().colors, function (color) {
        return {
            radialGradient: { cx: 0.5, cy: 0.3, r: 0.7 },
            stops: [
                [0, color],
                [1, Highcharts.Color(color).brighten(-0.3).get('rgb')] // darken
            ]
        };
    });
    // 构建图表
    var chart = Highcharts.chart('container_status', {
        title: {
            text: '标准废止/现行占比'
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    },
                    connectorColor: 'silver'
                }
            }
        },
        series: [{
            type: 'pie',
            name: '标准占比',
            data: eval(data_str)
        }]
    });
}
function LoadLoadStatusData_C() {
    var url = "/Home/LoadStatusData";
    $.ajax({
        type: "get",
        dataType: 'json',
        url: url,
        success: function (data) {
            //data = JSON.parse(data);

            var data_str = "[";
            var categories_str = "[";
            for (var i = 0; i < data.length; i++) {
                var status = data[i].Status;
                var value = data[i].Num;
                if (status == "0") {
                    status = "作废";
                } else {
                    status = "现行";
                }
                if (categories_str != "[") { categories_str += ","; }
                categories_str += "'" + status + "'";
                if (data_str != "[") { data_str += ","; }
                data_str += "" + value + "";
            }

            categories_str += "]";
            data_str += "]";
            LoadLoadStatus_C(categories_str,data_str);
        }
    });
}
function LoadLoadStatus_C(categories_str,data_str) {
    var chart = Highcharts.chart('container_c_status', {
        chart: {
            type: 'column'
        },
        title: {
            text: '标准废止/现行数量'
        },
       
        xAxis: {
            categories: eval(categories_str),
            crosshair: true
        },
        yAxis: {
            min: 0,
            title: {
                text: '数量 (篇)'
            }
        },
        tooltip: {
            // head + 每个 point + footer 拼接成完整的 table
            headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                '<td style="padding:0"><b>{point.y:.1f} 篇</b></td></tr>',
            footerFormat: '</table>',
            shared: true,
            useHTML: true
        },
        plotOptions: {
            column: {
                borderWidth: 0
            }
        },
        series: [{
            name: '数量',
            data: eval(data_str)
        }]
    });
}
function LoadMaxOrderData() {
    var url = "/Home/LoadMaxOrderData";
    $.ajax({
        type: "get",
        dataType: 'json',

        url: url,
        success: function (data) {
            //data = JSON.parse(data);
            var categories_str = "[";
            var data_str = "[";
            for (var i = 0; i < data.length; i++) {
                var name = data[i].productName.split(' ')[0];
                var value = data[i].Num;
                if (categories_str != "[") { categories_str += ","; }
                categories_str += "'" + name + "'";
                if (data_str != "[") { data_str += ","; }
                data_str += "" + value + "";
            }
            categories_str += "]";
            data_str += "]";
            LoadMaxOrder(categories_str, data_str);
        }
    });
}
function LoadMaxOrder(categories_str, data_str) {
    var chart = Highcharts.chart('container_m_n', {
        chart: {
            type: 'bar'
        },
        title: {
            text: '标准购买订单数量--前十'
        },

        xAxis: {
            categories: eval(categories_str),
            title: {
                text: null
            }
        },
        yAxis: {
            min: 0,
            title: {
                text: '标准订单数量',
                align: 'high'
            },
            labels: {
                overflow: 'justify'
            }
        },
        tooltip: {
            valueSuffix: ' 篇'
        },
        plotOptions: {
            bar: {
                dataLabels: {
                    enabled: true,
                    allowOverlap: true // 允许数据标签重叠
                }
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'top',
            x: -40,
            y: 100,
            floating: true,
            borderWidth: 1,
            backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
            shadow: true
        },
        series: [{
            name: '标准订单数量',
            data: eval(data_str)
        }]
    });
}
function LoadMaxAmountOrderData() {
    var url = "/Home/LoadMaxAmountOrderData";
    $.ajax({
        type: "get",
        dataType: 'json',
        url: url,
        success: function (data) {
            //data = JSON.parse(data);
            var categories_str = "[";
            var data_str = "[";
            for (var i = 0; i < data.length; i++) {
                var name = data[i].standardName.split(' ')[0];
                var value = data[i].totalAmount;
                if (categories_str != "[") { categories_str += ","; }
                categories_str += "'" + name + "'";
                if (data_str != "[") { data_str += ","; }
                data_str += "" + value + "";
            }
            categories_str += "]";
            data_str += "]";
            LoadMaxAmountOrder(categories_str, data_str);
        }
    });
}
function LoadMaxAmountOrder(categories_str, data_str) {
    var chart = Highcharts.chart('container_a_n', {
        chart: {
            type: 'bar'
        },
        title: {
            text: '标准购买订单金额--前十'
        },

        xAxis: {
            categories: eval(categories_str),
            title: {
                text: null
            }
        },
        yAxis: {
            min: 0,
            title: {
                text: '标准订单金额',
                align: 'high'
            },
            labels: {
                overflow: 'justify'
            }
        },
        tooltip: {
            valueSuffix: ' 元'
        },
        plotOptions: {
            bar: {
                dataLabels: {
                    enabled: true,
                    allowOverlap: true // 允许数据标签重叠
                }
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'top',
            x: -40,
            y: 100,
            floating: true,
            borderWidth: 1,
            backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
            shadow: true
        },
        series: [{
            name: '标准订单金额',
            data: eval(data_str)
        }]
    });
}
function LoadYearOrderData() {
    var url = "/Home/LoadYearOrderData";
    $.ajax({
        type: "get",
        dataType: 'json',
        url: url,
        success: function (data) {
        
            var categories_str = "[";
            var data_str = "[";
            for (var i = 0; i < data.length; i++) {
                var name = data[i].year;
                var value = data[i].Num;
                if (categories_str != "[") { categories_str += ","; }
                categories_str += "'" + name + "'";
                if (data_str != "[") { data_str += ","; }
                data_str += "" + value + "";
            }
            categories_str += "]";
            data_str += "]";
            LoadYearOrder(categories_str, data_str);
        }
    });
}
function LoadYearOrder(categories_str, data_str) {
    var chart = Highcharts.chart('container_y_o', {
        chart: {
            type: 'line'
        },
        title: {
            text: '年--标准订单数量'
        },
        
        xAxis: {
            categories: eval(categories_str)
        },
        yAxis: {
            title: {
                text: '数量 (个)'
            }
        },
        plotOptions: {
            line: {
                dataLabels: {
                    // 开启数据标签
                    enabled: true
                },
                // 关闭鼠标跟踪，对应的提示框、点击事件会失效
                enableMouseTracking: false
            }
        },
        series: [{
            name: '订单数量',
            data: eval(data_str)
        }]
    });
}
function LoadYearAmountOrderData() {
    var url = "/Home/LoadYearAmountOrderData";
    $.ajax({
        type: "get",
        dataType: 'json',
        url: url,
        success: function (data) {

            var categories_str = "[";
            var data_str = "[";
            for (var i = 0; i < data.length; i++) {
                var name = data[i].year;
                var value = data[i].totalAmount;
                if (categories_str != "[") { categories_str += ","; }
                categories_str += "'" + name + "'";
                if (data_str != "[") { data_str += ","; }
                data_str += "" + value + "";
            }
            categories_str += "]";
            data_str += "]";
            LoadYearAmountOrder(categories_str, data_str);
        }
    });
}
function LoadYearAmountOrder(categories_str, data_str) {
    var chart = Highcharts.chart('container_a_o', {
        chart: {
            type: 'line'
        },
        title: {
            text: '年--标准订单金额'
        },

        xAxis: {
            categories: eval(categories_str)
        },
        yAxis: {
            title: {
                text: '金额 (元)'
            }
        },
        plotOptions: {
            line: {
                dataLabels: {
                    // 开启数据标签
                    enabled: true
                },
                // 关闭鼠标跟踪，对应的提示框、点击事件会失效
                enableMouseTracking: false
            }
        },
        series: [{
            name: '订单金额',
            data: eval(data_str)
        }]
    });
}
$(function () {
    LoadPublishingUnitData();
    LoadOraganizationTypeData();
    LoadPublishingUnitYearData();
    LoadOraganizationTypeYearData();
    LoadLoadStatusData();
    LoadLoadStatusData_C();
    LoadMaxOrderData();
    LoadMaxAmountOrderData();
    LoadYearOrderData();
    LoadYearAmountOrderData();
});