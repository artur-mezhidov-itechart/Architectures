$(function () {

    ReportsHelper.activitiesChart(totalEquipmentsOptions);

    for (var userEquipmentCountOption in userEquipmentCountOptions) {
        if (userEquipmentCountOptions.hasOwnProperty(userEquipmentCountOption)) {
            ReportsHelper.bandwidthChart(userEquipmentCountOptions[userEquipmentCountOption]);
        }
    }

    for (var ratioOfEquipmentCountOption in ratioOfEquipmentCountOptions) {
        if (ratioOfEquipmentCountOptions.hasOwnProperty(ratioOfEquipmentCountOption)) {
            ReportsHelper.ratioDetailChart(ratioOfEquipmentCountOptions[ratioOfEquipmentCountOption]);
        }
    }
});
