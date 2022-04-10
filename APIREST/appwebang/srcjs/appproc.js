
// Houve mudanças na criação de modulos e controller angular 1.8 segue a for de declarar os modulos
// 
angular.module("siscliproc", []).controller("procedimentocontroller", function($scope){
    

    $scope.message = "Sou o controller dos Procedimentos - procedimentoscontroller";
    $scope.novoprocedimento = {};
    $scope.procedimentoselecionado = {};
    $scope.procedimentos = {}
    
    $scope.procedimentos = [
        {descricao: "Consulta Otorrinolaringologista", valor:"220,00"},
        { descricao: "Consulta Cardiologista", valor:"250,00"},
        { descricao: "Clinico Geral", valor:"210,00"},
        
    ];
    
    //$http.get("https://localhost:44338/api/Procedimentos"); 

    $scope.salvar = function () {
        $scope.procedimentos.push($scope.novoprocedimento);
        $scope.novoprocedimento={}
    };

    function limparFormulario(){
        ("#prodedimentosdescricao").val("") ;
        ("#procedimentovalor").val("");
    }
    
});
