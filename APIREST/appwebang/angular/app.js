
// Houve mudanças na criação de modulos e controller angular 1.8 segue a for de declarar os modulos
// 
angular.module("siscli", []).controller("testecontroller", function($scope){
    $scope.app = "Lista telefonica";
    $scope.funcionario = [];
    $scope.funcionarioselecionado = [];
    $scope.fucionarios = [];
   
    $scope.message = "Sou o controller App - para testes";

    function carregaProcedimentos(){
        $http.get("https://localhost:44338/api/Procedimentos").success(function (data){
            $scope.funcionarios = data;
            console.log("Metodo -> carregaProcedimentos()"+data);
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
