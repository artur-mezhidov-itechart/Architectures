$(function () {

    for (var lineChartOption in lineChartOptions) {
        if (lineChartOptions.hasOwnProperty(lineChartOption)) {
            ReportsHelper.lineChart(lineChartOptions[lineChartOption]);
        }
    }

    for (var amChartOption in amChartOptions) {
        if (amChartOptions.hasOwnProperty(amChartOption)) {
            ReportsHelper.amChart(amChartOptions[amChartOption]);
        }
    }

});
