(function ($) {

    $(document).ready(function () {
        initTable({
            url: '/api/equipment',
            selector: '.kt-datatable#equipments'
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
                    field: 'name',
                    title: 'Name'
                }, {
                    field: 'price',
                    title: 'Price'
                }, {
                    field: 'type',
                    title: 'Type',
                    template: function (row) {
                        var status = {
                            1: { 'title': 'Furniture', 'class': 'kt-badge--brand' },
                            2: { 'title': 'Device', 'class': ' kt-badge--danger' },
                            3: { 'title': 'Accessory', 'class': ' kt-badge--primary' },
                            4: { 'title': 'Tools', 'class': ' kt-badge--success' }
                        };
                        return '<span class="kt-badge ' + status[row.type].class + ' kt-badge--inline kt-badge--pill">' + status[row.type].title + '</span>';
                    }
                }, {
                    field: 'Actions',
                    title: 'Actions',
                    sortable: false,
                    width: 110,
                    autoHide: false,
                    template: function (row) {
                        return '<a href="/Equipment/Edit/' + row.id + '" class="btn btn-sm btn-clean btn-icon btn-icon-sm" title="Edit details"><i class="flaticon2-paper"></i></a>\
                                <a href="/Equipment/Delete/' + row.id + '" class="btn btn-sm btn-clean btn-icon btn-icon-sm" title="Delete"><i class="flaticon2-trash"></i></a>';
                    }
                }]
        });

        if (datatable) {
            $('.kt-search-input').on('change', function () {
                datatable.search($(this).val(), 'type');
            });
        }
    }

})(jQuery);
