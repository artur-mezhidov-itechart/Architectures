(function ($) {

    $(document).ready(function () {
        initTable({
            url: '/api/equipment/users',
            selector: '#user-equipments'
        });
        initTable({
            url: '/api/equipment/my',
            selector: '#my-equipments'
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
                    field: 'equipmentName',
                    title: 'Name'
                }, {
                    field: 'equipmentType',
                    title: 'Type',
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
                    field: 'isReturned',
                    title: 'Is Returned',
                    template: function (row) {
                        var status = {
                            true: { 'title': 'Yes', 'state': 'dark' },
                            false: { 'title': 'No', 'state': 'brand' }
                        };
                        return '<span class="btn btn-bold btn-sm btn-font-sm  btn-label-' + status[row.isReturned].state + '">'
                            + (!row.isReturned && row.isExpired
                                ? '<i class="flaticon-warning text-danger"></i> '
                                : '')
                            + status[row.isReturned].title
                            + '</span>';
                    }
                }, {
                    field: 'isExpired',
                    title: 'Status',
                    template: function (row) {
                        var status = {
                            true: { 'title': 'Expired', 'class': ' kt-badge--danger' },
                            false: { 'title': 'Active', 'class': ' kt-badge--success' }
                        };
                        return '<span class="kt-badge ' + status[row.isExpired].class + ' kt-badge--inline kt-badge--pill">' + status[row.isExpired].title + '</span>';
                    }
                }, {
                    field: 'receivedDate',
                    title: 'Received Date'
                }, {
                    field: 'expirationDate',
                    title: 'Expiration Date'
                }, {
                    field: 'Actions',
                    title: 'Actions',
                    sortable: false,
                    width: 110,
                    autoHide: false,
                    template: function (row) {
                        return '<a href="/Request/Details/' + row.requestId + '" class="btn btn-sm btn-clean btn-icon btn-icon-sm" title="Details"><i class="flaticon2-paper"></i></a>';
                    }
                }]
        });

        if (datatable) {
            $('.kt-search-input').on('change', function () {
                datatable.search($(this).val(), 'equipmentType');
            });
        }
    }

})(jQuery);
