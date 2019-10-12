// Defining angularjs module
var app = angular.module('demoModule', []);

// You will need to use your newly created Web API here
var apiURL = "http://localhost:17249/api/";

app.controller('demoCtrl', function ($scope, $http, UnitService) {

    $scope.showAdd = false;
    $scope.showEdit = false;
    $scope.unitData = "";
    $scope.noResult = false;

    UnitService.GetAllRecords().then(function (d) {
        $scope.unitData = d.data; // Success
        console.log($scope.unitData);
    }, function () {
        $scope.noResult = true;
    });

    $scope.Unit = {
        Id: '',
        UnitName: '',
        UnitCode: ''
    };


    // Clear
    $scope.back = function () {
        $scope.showEdit = false;
        $scope.showAdd = false;
    }

    $scope.addButton = function () {
        $scope.showAdd = true;
        $scope.showEdit = false;
    }

    //Add New Unit
    $scope.save = function () {
        if ($scope.Unit.UnitCode != "" && $scope.Unit.UnitName != "") {
            $scope.Unit.Id = 0;
            $http({
                method: 'POST',
                url: apiURL + "units",
                data: $scope.Unit
            }).then(function successCallback(response) {
                $scope.unitData.push(response.data);
                $scope.addResult = true;
                $scope.clear();
                alert("Unit Added Successfully");
            }, function errorCallback(response) {
                $scope.noResult = true;
            });
        }
        else {
            alert('Please enter both the unit code and unit name.');
        }
    };

    $scope.edit = function (index, data) {

        $scope.updateIndex = index;
        $scope.showAdd = false;
        $scope.showEdit = true;
        $scope.Unit = { Id: data.Id, UnitCode: data.UnitCode, UnitName: data.UnitName }
    }

    // Cancel unit details
    $scope.cancel = function () {
        $scope.showEdit = false;
    }

    // Update product details
    $scope.update = function () {
        if ($scope.Unit.UnitTitle != "" && $scope.Unit.UnitName != "") {

            $http({
                method: 'PUT',
                url: apiURL + "units/" + $scope.Unit.Id,
                data: $scope.Unit
            }).then(function successCallback(response) {
                var id = $scope.Unit.Id;
                //console.log(id);
                //$scope.unitData.splice($scope.updateIndex, 1);
                var unit = $scope.Unit;
                $scope.unitData[$scope.updateIndex] = unit;
                $scope.updateResult = true;
                //$scope.clear();
            }, function errorCallback(response) {
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
        else {
            alert('Please enter the required values.');
        }
    };

    // Delete unit
    $scope.delete = function (index) {
        $http({
            method: 'DELETE',
            url: apiURL + "units/" + $scope.unitData[index].Id

        }).then(function successCallback(response) {
            $scope.deleteResult = true;
        }, function errorCallback(response) {
            alert("Error : " + response.data.ExceptionMessage);
        });
    };

});

app.factory('UnitService', function ($http) {
    var fac = {};
    fac.GetAllRecords = function () {
        return $http.get(apiURL + "units");
    }
    return fac;
});