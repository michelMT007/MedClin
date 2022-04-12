var app = angular.module('consultaatendimentoapp', []);

app.controller('consultaatendimentoCtrl', function ($scope, $http) {
    
    var endpointAtendimentos = "https://localhost:44397/api/Atendimentos/";
        
    $scope.dados = {};
    $scope.messageMed="Médicos";
    $scope.messagePaciente="Paciente";
    $scope.messageAtendente="Atendente";
    
    $scope.postatendimento = function(Atendimento){
        
        console.log("Meu LOG: "+Atendimento.data + " "+Atendimento.idAtendente);
        $http.post(endpointAtendimentos, Atendimento).then(function (response) {    
            $http.get(endpointAtendimentos).then(function(response){
            $scope.procedimentos = response.data;
            alert('1 - Salvo com sucesso!');
        }, function (response) {
            $scope.msg = "Service not Exists";
		    $scope.statusval = response.status;
		    $scope.statustext = response.statusText;
		    $scope.headers = response.headers();
        });
        });  
    };


    $scope.postdata = function(dataatendimento, 
        idmedico, nomemedico, idatendente, nomeatend,idprocedimentomedico, descricaoprocedimento, idpacienteatendido,
        nomepaciente,valorprocedimento ){
        var data ={
            dataAtendimento:dataatendimento,
            idMedico:idmedico,
            nomeMedico:nomemedico,
            idAtendente: idatendente,
            nomeAtend:nomeatend,
            idProcedimentoMedico:idprocedimentomedico,
            descricaoProcedmento: descricaoprocedimento, 
            idPacienteAtendido:idpacienteatendido, 
            nomePaciente: nomepaciente, 
            valorProcedimento: valorprocedimento 
        };
        
        $http.post(endpointAtendimentos, dados).then(function (response) {    
            $http.get(endpointAtendimentos).then(function(response){
            $scope.atendimentos = response.data;
            alert('2 - Salvo com sucesso!');
        }, function (response) {
            $scope.msg = "Service not Exists";
		    $scope.statusval = response.status;
		    $scope.statustext = response.statusText;
		    $scope.headers = response.headers();
        });
        });  
    };
    
    $scope.listamed = $http.get(endpointMedicolst).then(function(response){
        $scope.medicos=response.data;
    });

});