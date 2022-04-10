var app = angular.module('experienciaApp', []);

app.controller('experienciaCtrl', function ($scope, $http) {
    // Simple Post request example:    
    var url = 'https://localhost:44397/api/procedimentos'
    ,config='contenttype';
    $scope.codigo = null;
    $scope.descricao = null;
    $scope.valor = null;
    $scope.message = "Experience - Michel";
    $scope.procedimentos=null;

    $scope.procedimentoSelecionado = {};

    $scope.postdata = function(descricao, valor){
        var data ={
            descricao: descricao,
            valor: valor
        };
        console.log("Meu LOG: "+data);
        $http.post(url, data).then(function (response) {    
            $http.get("https://localhost:44397/api/procedimentos").then(function(response){
            $scope.procedimentos = response.data;
            alert('Salvo com sucesso!');
        }, function (response) {
            $scope.msg = "Service not Exists";
		    $scope.statusval = response.status;
		    $scope.statustext = response.statusText;
		    $scope.headers = response.headers();
        });
        });  
    };

    $http.get("https://localhost:44397/api/procedimentos").then(function(response){
        $scope.procedimentos = response.data;
    });    
    
    $scope.selecionaProcedimento = function (procedimento) {
        $scope.procedimentoSelecionado = procedimento;
    };

    $scope.excluirProcedimento = function(procedimento){
        $http.delete("https://localhost:44397/api/procedimentos/"+procedimento); 
        procedimento = {};
        reload();
        alert("Procedimento Excluido com sucesso!"); 
    };

    function reload()
    {
        location.reload(); 
    }
   
    $scope.updateProcedimento = function() {
    $http({
      method: 'PUT',
      url: 'https://localhost:44397/api/procedimentos/' + $scope.procedimentoSelecionado.id,
      data: $scope.procedimentoSelecionado
    }).then(function successCallback(response) {
        reload();
        $scope.procedimentoSelecionado ={};
      alert("Procedimento Atualizado com sucesso!");
    }, function errorCallback(response) {
      alert("Houve algum erro de conectividade!");
    });
  };
});