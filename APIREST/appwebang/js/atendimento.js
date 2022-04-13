var app = angular.module('atendimentoapp', []);

app.controller('atendimentoCtrl', function ($scope, $http) {
    // Simple Post request example:    
    var url = "https://localhost:44397/api/Atendimentos/";

    var endpointPaciente = "https://localhost:44397/api/Pacientes/pacientenome/";
    var endpointMedicolst = "https://localhost:44397/api/Funcionarios/lstmedicos";
    var endpointAtendentelst = "https://localhost:44397/api/Funcionarios/lstatendentes";
    var endpointProcedimentolst = "https://localhost:44397/api/Procedimentos";
    
    $scope.medicos = null;
    $scope.pacientesnome = null;
    $scope.atendenteslst = null;
    $scope.procedimentos = null;
    $scope.atendimentos = null;
  
    $scope.medicoSelecionado = {};
    $scope.pacientes = null;
    $scope.pacienteSelecionado = {};

    $scope.messageMed="Médicos";
    $scope.messagePaciente="Paciente";
    $scope.messageAtendente="Atendente";

    $scope.atendimentoSelecionado = {};
    $scope.message="Atendimento";
    
    /**
      $scope.listamed = $http.get(endpointMedicolst).then(function(response){
      $scope.medicos=response.data;
    });*/


  
    $http.get(endpointProcedimentolst).then(function(response){
        $scope.procedimento = response.data;
    });
    
     
    $scope.GetPacienteNome = function(nome){
            $http.get(endpointPaciente+nome).then(function(response){
            $scope.pacientesnome = response.data;
        });
    };
    
    $http.get(endpointAtendentelst).then(function(response){
        $scope.atendenteslst =response.data;
    });
    
    
    $http.get(endpointMedicolst).then(function(response){
        $scope.medicos=response.data;
    });
    
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

    $scope.excluirAtendimento = function(atendimento){
        $http.delete(url+atendimento.id); 
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