﻿/**
 * DailyWastageCtrl.js
 */


app.controller('DailyWastageCtrl', ['$scope', 'crudService', 'uiGridConstants',
    function ($scope, crudService, uiGridConstants) {

    }]);


function modal_fadeOut() {
    $("#userModal").fadeOut(200, function () {
        $('#userModal').modal('hide');
    });
}