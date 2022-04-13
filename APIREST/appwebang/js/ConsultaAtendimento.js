var app = angular.module("consultaatendimentoapp", []);

app.controller("consultaatendimentoCtrl", function ($scope, $http) {
    
    var endpointAtendimentos = "https://localhost:44397/api/Atendimentos/atendimentos/";

    $scope.dados = {};
    $scope.messageMed="Médicos";
    $scope.messagePaciente="Paciente";
    $scope.messageAtendente="Atendente";
    $scope.busapormedico = {};

    $scope.consultaNomeMedico = function ConsultaNomeMedico(nome){
        console.log(nome);
    };

    $scope.getMedico = function(nome) {
        $http({
          method: 'GET',
          url: endpointAtendimentos+nome,
          //data: 
      }).then(function successCallback(response) {
          //reload();
          $scope.busapormedico = response.data;
        //alert("Atualizado com sucesso! "+nome);
      }, function errorCallback(response) {
        alert("Houve algum erro de conectividade!");
      });
    };

    function reload()
    {
        location.reload(); 
    }
});