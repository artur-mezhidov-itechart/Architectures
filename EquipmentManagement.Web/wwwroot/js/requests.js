(function ($) {

    $(document).ready(function () {
        initTable({
            url: '/api/request/assigned',
            selector: '.kt-datatable#my-requests-table'
        });
        initTable({
            url: '/api/request',
            selector: '.kt-datatable#all-requests-table'
        });
    });

    function initTable(options) {
        var datatable = $(options.selector).KTDatatable({
            sortable: true,
            filterable: false,
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
                    field: 'requestId',
                    title: '#',
                    width: 50,
                    autoHide: false
                }, {
                    field: 'userName',
                    title: 'User',
                    width: 230,
                    template: function (data) {
                        var state = getState();
                        return '<div class="kt-user-card-v2">\
							<div class="kt-user-card-v2__pic">\
								<div class="kt-badge kt-badge--xl kt-badge--' + state + '">' + data.userName.substring(0, 1) + '</div>\
							</div>\
							<div class="kt-user-card-v2__details">\
								<a href="#" class="kt-user-card-v2__name">' + data.userName + '</a>\
								<span class="kt-user-card-v2__desc">' + data.userEmail + '</span>\
							</div>\
						</div>';
                    }
                }, {
                    field: 'equipmentType',
                    title: 'Equipment',
                    width: 100,
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
                    field: 'createdOn',
                    title: 'Created On',
                    width: 120
                }, {
                    field: 'assignedUserName',
                    title: 'Assigned',
                    width: 230,
                    template: function (data) {
                        var state = getState();
                        return '<div class="kt-user-card-v2">\
							<div class="kt-user-card-v2__pic">\
								<div class="kt-badge kt-badge--xl kt-badge--' + state + '">' + data.assignedUserName.substring(0, 1) + '</div>\
							</div>\
							<div class="kt-user-card-v2__details">\
								<a href="#" class="kt-user-card-v2__name">' + data.assignedUserName + '</a>\
								<span class="kt-user-card-v2__desc">' + data.assignedUserEmail + '</span>\
							</div>\
						</div>';
                    }
                }, {
                    field: 'currentStatus',
                    title: 'Status',
                    width: 100,
                    template: function (row) {
                        var status = {
                            1: { 'title': 'Pending', 'state': 'warning' },
                            2: { 'title': 'In Progress', 'state': 'info' },
                            3: { 'title': 'Approved', 'state': 'success' },
                            4: { 'title': 'Declined', 'state': 'danger' },
                            5: { 'title': 'Completed', 'state': 'primary' },
                            6: { 'title': 'Canceled', 'state': 'dark' }
                        };
                        return '<span class="btn btn-bold btn-sm btn-font-sm  btn-label-' + status[row.currentStatus].state +'">' + status[row.currentStatus].title + '</span>';
                    }
                }, {
                    field: 'updatedOn',
                    title: 'Updated On',
                    width: 120
                }, {
                    field: 'Actions',
                    title: 'Actions',
                    sortable: false,
                    width: 50,
                    autoHide: false,
                    template: function (row) {
                        return '<a href="/Request/Details/' + row.requestId + '" class="btn btn-sm btn-clean btn-icon btn-icon-sm" title="Details"><i class="flaticon2-paper"></i></a>';
                    }
                }]
        });

        function getState() {
            var stateNo = KTUtil.getRandomInt(0, 6);
            var states = [
                'success',
                'brand',
                'danger',
                'success',
                'warning',
                'primary',
                'info'];
            return states[stateNo];
        }
    }

})(jQuery);
