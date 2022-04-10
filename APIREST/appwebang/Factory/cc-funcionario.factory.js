(function () {
    'use strict';

    angular.module($ngSession.ModuleName).factory("funcionarioFactory", funcionarioFactory)

    funcionarioFactory.$inject = ['$http', 'errorRequest'];

    function funcionarioFactory($http, errorRequest) {
        var _funcionarioFactory = {
            Consultarfuncionario: Consultarfuncionario,
            Insert: Insert,
            Update: Update,
            Delete: Delete
        };
        return _funcionarioFactory;

        function ConsultarFuncionario(funcionario) {
            console.log('c.FACTORY.JS FUNCTION: ConsultarGravidade(funcionario)');
            return $http.get('/api/Gravidade/ConsultarFuncionario/', { params: { jsonConsulta: funcionario } });
        }

        function Insert(funcionario) {

            console.log('TESTE - GRAVIDADE.FACTORY.JS FUNCTION: Insert(gravidade)');
            return $http.post('/api/Funcionarios', funcionario);
        }

        function Update(funcionario) {
            console.log('TESTE - funcionario.FACTORY.JS FUNCTION: Update(funcionario)');
            return $http.put('/api/Funcionarios', funcionario);
        }

        function Delete(id) {
            console.log('TESTE -  funcionario.FACTORY.JS FUNCTION: Delete(id)');
            return $http.delete('/api/Funcionarios/Delete/' + id);
        }
    }
}());