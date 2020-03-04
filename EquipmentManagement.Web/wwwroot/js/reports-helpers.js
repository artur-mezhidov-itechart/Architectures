window.ReportsHelper = {
    activitiesChart: function (options) {

        if (!$('#' + options.id).length) {
            return;
        }

        var ctx = document.getElementById(options.id).getContext("2d");
        var gradient = ctx.createLinearGradient(0, 0, 0, 240);
        gradient.addColorStop(0, Chart.helpers.color('#e14c86').alpha(1).rgbString());
        gradient.addColorStop(1, Chart.helpers.color('#e14c86').alpha(0.3).rgbString());

        var config = {
            type: 'line',
            data: {
                labels: options.items.map(function (item) { return item.label; }),
                datasets: [
                    {
                        label: "Count",
                        backgroundColor: Chart.helpers.color('#e14c86').alpha(1).rgbString(),
                        borderColor: '#e13a58',
                        pointBackgroundColor: Chart.helpers.color('#000000').alpha(0).rgbString(),
                        pointBorderColor: Chart.helpers.color('#000000').alpha(0).rgbString(),
                        pointHoverBackgroundColor: KTApp.getStateColor('light'),
                        pointHoverBorderColor: Chart.helpers.color('#ffffff').alpha(0.1).rgbString(),
                        data: options.items.map(function (item) { return item.value; })
                    }
                ]
            },
            options: {
                title: {
                    display: false
                },
                tooltips: {
                    mode: 'nearest',
                    intersect: false,
                    position: 'nearest',
                    xPadding: 10,
                    yPadding: 10,
                    caretPadding: 10
                },
                legend: {
                    display: false
                },
                responsive: true,
                maintainAspectRatio: false,
                scales: {
                    xAxes: [
                        {
                            display: false,
                            gridLines: false,
                            scaleLabel: {
                                display: true,
                                labelString: 'Month'
                            }
                        }
                    ],
                    yAxes: [
                        {
                            display: false,
                            gridLines: false,
                            scaleLabel: {
                                display: true,
                                labelString: 'Value'
                            },
                            ticks: {
                                beginAtZero: true
                            }
                        }
                    ]
                },
                elements: {
                    line: {
                        tension: 0.0000001
                    },
                    point: {
                        radius: 4,
                        borderWidth: 12
                    }
                },
                layout: {
                    padding: {
                        left: 0,
                        right: 0,
                        top: 10,
                        bottom: 0
                    }
                }
            }
        };

        var chart = new Chart(ctx, config);
        return chart;
    },

    bandwidthChart: function (options) {

        if (!$('#' + options.id).length) {
            return;
        }

        var states = {
            success: '#d1f1ec',
            brand: '#d2f5f9',
            danger: '#FFCCCC',
            warning: '#ffefce',
            default: '#d1f1ec'
        };

        var ctx = document.getElementById(options.id).getContext("2d");

        var gradient = ctx.createLinearGradient(0, 0, 0, 240);
        gradient.addColorStop(0, Chart.helpers.color(states[options.type] || states.default).alpha(1).rgbString());
        gradient.addColorStop(1, Chart.helpers.color(states[options.type] || states.default).alpha(0.3).rgbString());

        var config = {
            type: 'line',
            data: {
                labels: options.items.map(function (item) { return item.label; }),
                datasets: [{
                    label: "Count",
                    backgroundColor: gradient,
                    borderColor: KTApp.getStateColor(options.type),

                    pointBackgroundColor: Chart.helpers.color('#000000').alpha(0).rgbString(),
                    pointBorderColor: Chart.helpers.color('#000000').alpha(0).rgbString(),
                    pointHoverBackgroundColor: KTApp.getStateColor('danger'),
                    pointHoverBorderColor: Chart.helpers.color('#000000').alpha(0.1).rgbString(),
                    data: options.items.map(function (item) { return item.value; })
                }]
            },
            options: {
                title: {
                    display: false
                },
                tooltips: {
                    mode: 'nearest',
                    intersect: false,
                    position: 'nearest',
                    xPadding: 10,
                    yPadding: 10,
                    caretPadding: 10
                },
                legend: {
                    display: false
                },
                responsive: true,
                maintainAspectRatio: false,
                scales: {
                    xAxes: [{
                        display: false,
                        gridLines: false,
                        scaleLabel: {
                            display: true,
                            labelString: 'Month'
                        }
                    }],
                    yAxes: [{
                        display: false,
                        gridLines: false,
                        scaleLabel: {
                            display: true,
                            labelString: 'Value'
                        },
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                },
                elements: {
                    line: {
                        tension: 0.0000001
                    },
                    point: {
                        radius: 4,
                        borderWidth: 12
                    }
                },
                layout: {
                    padding: {
                        left: 0,
                        right: 0,
                        top: 10,
                        bottom: 0
                    }
                }
            }
        };

        var chart = new Chart(ctx, config);
        return chart;
    },

    ratioDetailChart: function (options) {

        if (!$('#' + options.id).length) {
            return;
        }

        Morris.Donut({
            element: options.id,
            data: options.items,
            labelColor: '#a7a7c2',
            colors: options.items.map(function (item) { return KTApp.getStateColor(item.type);  }),
            formatter: function (x) { return x + "%"}
        });
    },

    lineChart: function (options) {
        var data = new google.visualization.DataTable();
        data.addColumn('string', options.xValues.title);
        for (var i = 0; i < options.columns.length; i++) {
            var column = options.columns[i];
            data.addColumn('number', column.title);
        }

        var rows = [];

        for (var j = 0; j < options.columns.length; j++) {
            var values = options.columns[j].values;
            for (var k = 0; k < values.length; k++) {
                if (j === 0) {
                    rows[k] = [options.xValues.values[k]];
                } 
                rows[k].push(parseInt(values[k]));
            }
        }

        data.addRows(rows);

        var chartOptions = {
            chart: {
                title: options.chartTitle,
                subtitle: options.chartSubTitle
            }
        };

        var chart = new google.charts.Line(document.getElementById(options.chartId));
        chart.draw(data, chartOptions);
    },

    amChart: function (options) {
        console.log(options);
        var currentYear = options.data.first;
        var chart = AmCharts.makeChart(options.chartId, {
            "type": "pie",
            "theme": "light",
            "dataProvider": [],
            "valueField": "size",
            "titleField": "sector",
            "startDuration": 0,
            "innerRadius": 80,
            "pullOutRadius": 20,
            "marginTop": 30,
            "titles": [{
                "text": options.title
            }],
            "allLabels": [{
                "y": "54%",
                "align": "center",
                "size": 25,
                "bold": true,
                "text": currentYear,
                "color": "#555"
            }, {
                "y": "49%",
                "align": "center",
                "size": 15,
                "text": "Year",
                "color": "#555"
            }],
            "listeners": [{
                "event": "init",
                "method": function (e) {
                    var chart = e.chart;

                    function getCurrentData() {
                        var data = options.data.sectors[currentYear];
                        currentYear++;
                        if (currentYear > options.data.last)
                            currentYear = options.data.first;
                        return data;
                    }

                    function loop() {
                        chart.allLabels[0].text = currentYear;
                        var data = getCurrentData();
                        chart.animateData(data, {
                            duration: 1000,
                            complete: function () {
                                setTimeout(loop, 3000);
                            }
                        });
                    }

                    loop();
                }
            }],
            "export": {
                "enabled": true
            }
        });
    }
};
