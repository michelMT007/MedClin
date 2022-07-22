var app = angular.module('funcionarioapp', []);

app.controller('funcionarioCtrl', function ($scope, $http) {
    // Simple Post request example:    
    var url = 'https://localhost:44397/api/Funcionarios/';

    $scope.funcionarios = null;
    $scope.funcionarioSelecionado = {};
    /*
            "id": 0, "nome": "string","rg": "string","cpf": "string",
            "endereco": "string","matricula": 0, "profissao": "string", "ativo": true*/
    
    $scope.postdata = function(funcionario){
        $http.post(url, $scope.funcionario).then(function (response) {  
            console.log("ERRO Funcionarios - postdata()  1 ------> "+response);  
            $http.get(url).then(function(response){
            $scope.procedimentos = response.data;
            console.log("ERRO Funcionarios - postdata()  2 ------> "+response);
            alert('Salvo com sucesso!');
            reload();
        }, function (response) {
            console.log("ERRO Funcionarios - postdata()  3 ------> "+response.data);
            $scope.msg = "Service not Exists";
            $scope.statusval = response.status;
            $scope.statustext = response.statusText;
            $scope.headers = response.headers();
            });
        });  
    };

    $http.get(url).then(function(response){
        $scope.funcionarios = response.data;
    });    
    
    $scope.selecionaFuncionario = function (funcionario) {
        $scope.funcionarioSelecionado = funcionario;
    };

    $scope.excluirFuncionario = function(funcionario){
        $http.delete("https://localhost:44397/api/funcionarios/"+funcionario); 
        funcionario = {};
        reload();
        
    };

    function reload()
    {
        location.reload(); 
    }
   
    $scope.update = function() {
      $http({
        method: 'PUT',
        url: url + $scope.funcionarioSelecionado.id,
        data: $scope.funcionarioSelecionado
    }).then(function successCallback(response) {
        reload();
        $scope.procedimentoSelecionado ={};
      alert("Atualizado com sucesso!");
    }, function errorCallback(response) {
      alert("Houve algum erro de conectividade!");
    });
  };
});