var app = angular.module('atendimentoapp', []);

app.controller('atendimentoCtrl', function ($scope, $http) {
    // Simple Post request example:    
    var url = "https://localhost:44397/api/atendimentos/"
    ,config='contenttype';

    var endpointPaciente = null;
    var endpointMedicolst = null;
    var endpointAtendentelst = null;
    var endpointProcedimentolst = null;

    $scope.atendimentos = null;
    $scope.atendimentoSelecionado = {};
    $scope.message="Atendimento";
   
    $scope.post = function(paciente){     
    $http.post(url, $scope.paciente).then(function (response) {    
      $http.get(url).then(function(response){
        $scope.pacientes = response.data;
          alert('Salvo com sucesso!');
          paciente={};
        }, function (response) {
            $scope.msg = "Service not Exists";
		    $scope.statusval = response.status;
		    $scope.statustext = response.statusText;
		    $scope.headers = response.headers();
        });
      });  
    };

    $http.get(url).then(function(response){
        $scope.atendimentos = response.data;
    });    
    
    $scope.selecionaAtendimento = function (atendimento) {
        $scope.atendimentoSelecionado = atendimento;
    };

    $scope.delete = function(atendimento){
        $http.delete(url+atendimento); 
        atendimento = {};
        alert("Excluido com sucesso!");
        reload();
    };

    function reload()
    {
        location.reload(); 
    }
   
    $scope.update = function() {
    $http({
      method: 'PUT',
      url: url + $scope.pacienteSelecionado.id,
      data: $scope.pacienteSelecionado
    }).then(function successCallback(response) {  
      alert("Atualizado com sucesso!");
      reload();
    }, function errorCallback(response) {
      alert("Houve algum erro de conectividade!");
    });
  };

});