var app = angular.module("myApp", []);

app.controller("myCont", ['$scope',"$http","currentProduct", function ($scope,$http,currentProduct) {
    
    $http.get("/api/values", {
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(function (response) {
            $scope.products = response.data;
        }, function (response) {
            $scope.content = "Something went wrong";
        });

    $setCurrentProduct = function (obj) {
        currentProduct.setObj(obj);
    }
    
}]);

app.controller("testCont", ["$scope","currentProduct", function($scope,currentProduct){
    $scope.prod = currentProduct.currentObj;
}]);


app.service("currentProduct", function () {

    var currentObj = {};

    var setObj = function (prod) {
        currentObj = prod;
    };

    return currentObj;
});