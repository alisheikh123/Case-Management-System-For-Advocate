var app = angular.module("resApp", []);
app.controller("ReservationCtrl", function ($http, $scope) {
    //$http.get('/Reservation/getCity').then(function (rec)
    //{
    //    $scope.citylist = rec.data;
    //});
    $http.get('/Reservation/getCountry').then(function (rec) {
        $scope.countrylist = rec.data;
    });

    $scope.state = function () {
        $http.get('/Reservation/getState?countryid=' + $scope.CountryIdloc).then(function (rec)
        {
            $scope.statelist = rec.data;
        });

    };
    $scope.cit = function () {
        $http.get('/Reservation/getCity?stateId=' + $scope.statIdsloc).then(function (rec) {
            $scope.citylist = rec.data;
        });

    };
});