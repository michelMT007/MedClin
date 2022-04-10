
var app = angular.module('procedimentoapp', []);
    app.controller('procedimentoCtrl', function($scope, $http) {
    //$http.get("https://www.w3schools.com/angular/customers.php").then(function(response) {
    
    //$http.get("https://www.w3schools.com/angular/customers.php").then(function(response) {
        
        $http.get("https://localhost:44397/api/procedimentos").then(function(response) {
            $scope.procedimentos = response.data;
            $scope.message = "TesteB - MAC 2022";
        });

        /*
        var InserirProcedimentos = $http.post('https://localhost:5001/api/procedimentos', { procedimento})
        .success(function (result){
            
            $scope.proc = result;
            //delete $scope.procedimeto;
        }).error(function (data){
            console.log(data);
        });
        */
    /*  
    $http.get("https://localhost:5001/api/procedimentos").then(function(response) {
        //$scope.procedimentos = response.data;
        $scope.message = "Controller dos Procedimentos";
        
        //$http.get('https://localhost:5001/api/procedimentos').success(function (response) {
        $scope.procedimentos = response;
        }).error(function (data) {
            console.log(data);
        });
        */  
     /*   
    //chama o  método AdicionarLivro do controlador
    $scope.IncluiProcedimento = function (procedimento) {
        $http.post('https://localhost:5001/api/procedimentos', { procedimento })
        .success(function (result) {
            $scope.procedimentos = result;
            delete $scope.procedimeto;
            $scope.TodosProcedimentos();
        }).error(function (data) {
            console.log(data);
        });
    }
    
    //retorna todos os livros
    $scope.TodosProcedimentos = function () {
        $http.get('https://localhost:5001/api/procedimentos')
        .success(function (response) {
            $scope.procedimentos = response;
        }).error(function (data) {
            console.log(data);
        });
    }
    
    /*function Insert(procedimento ) {
        if(procedimento == null){
            console.log('Procedimento esta nulo');
        }
        console.log('TESTE - Insert(procedimento)');
        var proc = $http.post('https://localhost:5001/api/procedimentos', procedimento);
        return proc;
    }*/

});