var app = angular.module('pacientesapp', []);
app.controller('pacientesCtrl', function($scope, $http) {
    $http.get("https://www.w3schools.com/angular/customers.php").then(function(response) {
    //$http.get("https://localhost:5001/api/pacientes").then(function(response) {
        $scope.pacientes = response.data; 
        $scope.message= "Controller paciente";
    });
});