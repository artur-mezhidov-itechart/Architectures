(function ($) {

    $(document).ready(function () {
        initTable({
            url: '/api/request/active',
            selector: '.kt-datatable.active-requests-table',
            tabSelector: 'a[href="#kt_portlet_tab_1"]'
        });
        initTable({
            url: '/api/request/completed',
            selector: '.kt-datatable.completed-requests-table',
            tabSelector: 'a[href="#kt_portlet_tab_2"]'
        });
    });

    function initTable(options) {
        var datatable = $(options.selector).KTDatatable({
            sortable: true,
            pagination: true,
            data: {
                type: 'remote',
                source: {
                    read: {
                        url: options.url,
                        method: 'GET'
                    }
                },
                pageSize: 10
            },
            columns: [
                {
                    field: 'message',
                    title: 'Message'
                }, {
                    field: 'updatedOn',
                    title: 'Updated Date',
                    type: 'date',
                    format: 'MM/DD/YYYY'
                }, {
                    field: 'equipmentType',
                    title: 'Equipment Type',
                    template: function (row) {
                        var status = {
                            1: { 'title': 'Furniture', 'class': 'kt-badge--brand' },
                            2: { 'title': 'Device', 'class': ' kt-badge--danger' },
                            3: { 'title': 'Accessory', 'class': ' kt-badge--primary' },
                            4: { 'title': 'Tools', 'class': ' kt-badge--success' }
                        };
                        return '<span class="kt-badge ' + status[row.equipmentType].class + ' kt-badge--inline kt-badge--pill">' + status[row.equipmentType].title + '</span>';
                    }
                }, {
                    field: 'status',
                    title: 'Status',
                    template: function (row) {
                        var status = {
                            1: { 'title': 'Pending', 'state': 'warning' },
                            2: { 'title': 'In Progress', 'state': 'info' },
                            3: { 'title': 'Approved', 'state': 'success' },
                            4: { 'title': 'Declined', 'state': 'danger' },
                            5: { 'title': 'Completed', 'state': 'primary' },
                            6: { 'title': 'Canceled', 'state': 'dark' }
                        };
                        return '<span class="kt-badge kt-badge--' + status[row.status].state + ' kt-badge--dot"></span>&nbsp;<span class="kt-font-bold kt-font-' + status[row.status].state +
                            '">' + status[row.status].title + '</span>';
                    }
                }, {
                    field: 'Actions',
                    title: 'Actions',
                    sortable: false,
                    width: 110,
                    autoHide: false,
                    template: function (row) {
                        return '<a href="/Request/Details/' + row.id + '" class="btn btn-sm btn-clean btn-icon btn-icon-sm" title="Details"><i class="flaticon2-paper"></i></a>';
                    }
                }]
        });

        if (options.tabSelector) {
            $(options.tabSelector).on('shown.bs.tab', function () {
                datatable.reload();
            });
        }
    }

})(jQuery);
