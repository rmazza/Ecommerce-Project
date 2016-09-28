var app = angular.module("myApp", []);

app.controller("myCont", ['$scope',"$http", function ($scope,$http) {
    
    $http.get("http://localhost:53222/List/Data")
        .then(function (response) {
            $scope.products = response.data;
        }, function (response) {
            //Second function handles error
            $scope.content = "Something went wrong";
        });
    
}]);