$(document).ready(function () {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=urf-8",
        dataType: "json",
        url: urlBase + '/DataPastel',
        error: function () {
            alert("Ocurrio un error");
        },
        success: function (data) {
            console.log(data);
            GraficaPastel(data);
        }
    });
});



function GraficaPastel(data) {
    // Build the chart
    Highcharts.chart('container', {
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            type: 'pie'
        },
        title: {
            text: 'Total servicios por empleado'
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        accessibility: {
            point: {
                valueSuffix: '%'
            }
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: false
                },
                showInLegend: true
            }
        },
        series: [{
            name: 'Porcentaje servicios realizados ',
            colorByPoint: true,
            data: data
            //data: [{
            //    name: 'Chrome',
            //    y: 61.41,
            //    sliced: true,
            //    selected: true
            //}, {
            //    name: 'Internet Explorer',
            //    y: 11.84
            //}, {
            //    name: 'Firefox', 
            //    y: 10.85
            //}, {
            //    name: 'Edge',
            //    y: 4.67
            //}, {
            //    name: 'Safari',
            //    y: 4.18
            //}, {
            //    name: 'Other',
            //    y: 7.05
            //}]
        }]
    });
}

