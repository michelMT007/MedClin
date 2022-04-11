var app = angular.module('pacienteapp', []);

app.controller('pacienteCtrl', function ($scope, $http) {
    // Simple Post request example:    
    var url = 'https://localhost:44397/api/Pacientes/'
    ,config='contenttype';

    $scope.pacientes = null;
    $scope.pacienteSelecionado = {};
    $scope.message="Pacientes";
   
    $scope.post = function(paciente){     
    $http.post(url, $scope.paciente).then(function (response) {    
      //$http.get(url).then(function(response){
        
      //$scope.paciente = response.data;
        reload();  
          paciente={};
        }, function (response) {
            $scope.msg = "Service not Exists";
		    $scope.statusval = response.status;
		    $scope.statustext = response.statusText;
		    $scope.headers = response.headers();
        });
        
    };

    $http.get(url).then(function(response){
        $scope.pacientes = response.data;
    });    
    
    $scope.selecionaPaciente = function (paciente) {
        $scope.pacienteSelecionado = paciente;
    };

    $scope.delete = function(paciente){
        $http.delete("https://localhost:44397/api/Pacientes/"+paciente); 
        paciente = {};
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
      url: "https://localhost:44397/api/Pacientes/" + $scope.pacienteSelecionado.id,
      data: $scope.pacienteSelecionado
    }).then(function successCallback(response) {  
      alert("Atualizado com sucesso!");
      reload();
    }, function errorCallback(response) {
      alert("Houve algum erro de conectividade!");
    });
  };

});