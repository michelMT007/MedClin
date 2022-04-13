var app = angular.module('dropdownapp', []);

app.controller('dropdownCtrl', function ($scope, $http) {
    
    var endpointAtendimentos = "https://localhost:44397/api/Atendimentos/";
    var endpointPaciente = "https://localhost:44397/api/Pacientes/";
    var endpointMedicolst = "https://localhost:44397/api/Funcionarios/lstmedicos";
    var endpointAtendentelst = "https://localhost:44397/api/Funcionarios/lstatendentes";
    var endpointProcedimentolst = "https://localhost:44397/api/Procedimentos";
    
    $scope.medicoSelecionado = {};
    $scope.pacientes = null;
    $scope.pacienteSelecionado = {};
    $scope.Atendimento = {};

    $scope.atendimentos = {};

    $scope.dados = {};
    $scope.messageMed="Médicos";
    $scope.messagePaciente="Paciente";
    $scope.messageAtendente="Atendente";
    
    $scope.dataAtendimento= null;
    $scope.idMedico= null;
    $scope.nomeMedico=null;
    $scope.idAtendente= null;
    $scope.nomeAtend= null;
    $scope.idProcedimentoMedico= null;
    $scope.descricaoProcedmento= null; 
    $scope.idPacienteAtendido=null; 
    $scope.nomePaciente=null; 
    $scope.valorProcedimento =null;

    $scope.excluirAtendimento = function(atendimento){
        $http.delete(endpointAtendimentos+atendimento); 
        atendimento = {};
        reload();
        alert("Excluido com sucesso!"); 
    };

    function reload()
    {
        location.reload(); 
    }

    $scope.postatendimento = function(Atendimento){
        
        console.log("Meu LOG: "+Atendimento.data + " "+Atendimento.idAtendente);
        $http.post(endpointAtendimentos, Atendimento).then(function (response) {    
            $http.get(endpointAtendimentos).then(function(response){
            $scope.procedimentos = response.data;
            
        }, function (response) {
            $scope.msg = "Service not Exists";
		    $scope.statusval = response.status;
		    $scope.statustext = response.statusText;
		    $scope.headers = response.headers();
        });
        });  
    };

    $scope.atendimentoSelecionado={};
    $scope.selecionaAtendimento =function (atendimento){
        atendimentoSelecionado = atendimento;
    }

    $scope.postdata = function(dataatendimento, idmedico, nomemedico, idatendente, nomeatend,idprocedimentomedico, 
        descricaoprocedimento, idpacienteatendido, nomepaciente,valorprocedimento ){
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
            reload();
        }, function (response) {
                $scope.msg = "Service not Exists";
                $scope.statusval = response.status;
                $scope.statustext = response.statusText;
                $scope.headers = response.headers();
            });
        });  
    };

    $http.get(endpointAtendimentos).then(function(response){
        $scope.atendimentos =response.data;
    });
    
    $http.get(endpointAtendentelst).then(function(response){
        $scope.atendenteslst =response.data;
    });


    $http.get(endpointProcedimentolst).then(function(response){
        $scope.procedimentos = response.data;
    });

    $http.get(endpointPaciente).then(function(response){
        $scope.pacientes = response.data;
    });

    $scope.listamed = $http.get(endpointMedicolst).then(function(response){
        $scope.medicos=response.data;
    });
    
    $scope.CriaAtendimento = function (medico, atendente, procedimento, paciente) {
        dados ={
            idMedico:medico.id,
            nomeMedico:medico.nome,
            idAtendente: atendente.id,
            nomeAtend:atendente.nome,
            idProcedimentoMedico:procedimento.id,
            descricaoProcedmento: procedimento.descricao, 
            idPacienteAtendido:paciente.id, 
            nomePaciente: paciente.nome, 
            valorProcedimento: procedimento.valor 
        };
        console.log(dados);
        $scope.dadosatendimento = dados;
        return dados;
    };


});