$(document).ready(function () {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=urf-8",
        dataType: "json",
        url: urlBase + '/DataBarras',
        error: function () {
            alert("Ocurrio un error");
        },
        success: function (data) {
            console.log(data);
            GraficaBarras(data);
        }
    });
});

function GraficaBarras(data) {
    // Build the chart
    Highcharts.chart('container2', {
        chart: {
            type: 'column'
        },
        title: {
            text: 'Servicios por empleado'
        },
        subtitle: {
            text: 'Servicios '
        },
        xAxis: {
            type: 'category',
            labels: {
                rotation: -45,
                style: {
                    fontSize: '13px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        },
        yAxis: {
            min: 0,
            title: {
                text: 'Cantidad'
            }
        },
        legend: {
            enabled: false
        },
        tooltip: {
            pointFormat: 'Realizados: <b>{point.y:.1f} servicios</b>'
        },
        series: [{
            name: 'Datos',
            data: data,
            dataLabels: {
                enabled: true,
                rotation: -90,
                color: '#FFFFFF',
                align: 'right',
                format: '{point.y:.1f}', // one decimal
                y: 10, // 10 pixels down from the top
                style: {
                    fontSize: '13px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        }]
    });

}
