
var siscli = angular.module("siscli", []);

siscli.module("siscli").controller("funcionariocontroller", function($scope){
    $scope.app = "Lista telefonica";
    $scope.funcionario = [];
    $scope.funcionarioselecionado = [];
    $scope.fucionarios = [];
   
    $scope.message = "Sou o controller dos Funcionarios - funcionarioController";

    var carregaFuncionarios = function(){
        $http.get("https://localhost:44338/api/Funcionarios").success(function (data){
            $scope.funcionario = data;
            console.log("Metodo -> carregaFuncionarios()"+data);
        }).error(function(data, status){
            $scope.message = "Aconteceu um problema com comunicação com WEB API"+data;
        });
    }

    $scope.adicionarfuncionario = function(){
        $http.post("https://localhost:44338/api/Funcionarios", funcionario).success(function(data)
        {
            {
                delete $scope.funcionario;
                carregaFuncionarios();
            }
        });
    }

    
});