(function () {
    'use strict';

    // Defining angularjs Module
    angular.module($ngSession.ModuleName).controller('FuncionarioController', FuncionarioController);


    FuncionarioController.$inject = ['$scope', '$filter', 'growl', 'funcionarioFactory', /*'ui-iconpicker',*/ 'segurancaFactory', 'commonFactory'];

    function GravidadeController($scope, $filter, growl, funcionarioFactory  /*, segurancaFactory, commonFactory*/) {

        var vm = $scope;

        UserConfig();

        vm.Funcionario = {};
        vm.FuncionarioConsulta = {};
        vm.TabOpen = 0;

        vm.itemsByPage = 25;
        vm.listItemsByPage = [{ Id: 10, Descricao: 10 }, { Id: 25, Descricao: 25 }, { Id: 50, Descricao: 50 }, { Id: 100, Descricao: 100 }];
        vm.rowCollection = undefined;
        vm.predicates = ['Id', 'Nome', 'Rg', 'Cpf', 'Endereco', 'matricula', 'profissao', 'Ativo'];
        vm.selectedPredicate = vm.predicates[0];

        vm.IsAuthorized = IsAuthorized;
        vm.Order = Order;
        vm.AtualizarGrid = AtualizarGrid;

        vm.ConsultarGravidade = ConsultarGravidade;
        vm.SetTabOpen = SetTabOpen;
        vm.IsTabOpen = IsTabOpen;
        vm.ResetConsulta = ResetConsulta;

        /*function IsAuthorized(rf) {
            return segurancaFactory.IsAuthorized(rf);
        }

        function UserConfig() {
            segurancaFactory.GetCurrentUser().success(function (data) {
                vm.Usuario = data;
            });
        }*/

        vm.LoadGrid = LoadGrid;
        function LoadGrid() {
            vm.FuncionarioConsulta.LimitTo = 3;
        }

        function AtualizarGrid() {
            SetTabOpen(1);
            vm.rowCollection = undefined;
            ConsultarFuncionario();
            growl.success('Consulta atualizada com sucesso!', { title: 'Atualizada' })
        }

        function ConfigureModal(idModal, pristine, funcionario, titulo, info) {
            vm.modalInserir = pristine;
            vm.btnInserir = pristine;
            vm.tituloModal = titulo;
            vm.infoModal = info;
            if (pristine) {
                vm.Funcionario = {};
                //vm.ProdutoView = {};
                vm.inserirForm.$setPristine();
                vm.inserirForm.$resetForm();
            }
            vm.modalInserir = true;
            $(idModal).modal();
        }

        function CallbackSuccess(msg, Funcionario, del) {
            $(".modal").modal("hide");

            if (del) {
                var page = angular.element('#pagerId').isolateScope().currentPage;
                vm.FuncionarioConsulta.Nome = funcionario.Nome;
                ConsultarFuncionario();
            } else {
                //LoadGrid(true, 0, page, search);
                vm.FuncionarioConsulta.Nome = funcionario.Nome;
                ConsultarFuncionario();
            }

            delete vm.Funcionario;
            vm.inserirForm.$setPristine();
            growl.success(msg, { title: 'Sucesso' });
        }

        function ConsultarFuncionario() {
            console.log('Funcionario.CONTROLLER.JS FUNCTION  ConsultarFuncionario()' );
            vm.rowCollection = undefined;
            gravidadeFactory.ConsultarFuncionario(vm.Funcionario).success(function (data) {
                vm.rowCollection = data;
                vm.GravidadeConsulta.LimitTo = 100;
            });
        }

        vm.Insert = Insert;
        function Insert() {
            console.log('Funcionario.Funcionario.JS FUNCTION  Insert()');
            funcionarioFactory.Insert(vm.Funcionario).success(function (data, status) {
                CallbackSuccess('Registro gravado com sucesso!', vm.Funcionario);
            });
            AtualizarGrid();
        }

        vm.ModalInsert = ModalInsert;

        function ModalInsert() {
            vm.Funcionario = {};
            vm.tabs = 1;
            ConfigureModal("#modal-inserir-grav", true, {}, "Cadastro de Tipo de Gravidades", "Preencha todos os campos para inserir uma nova Gravidade.");
            
        }

        vm.ModalEdit = ModalEdit;
        function ModalEdit(Funcionario) {
            vm.Funcionario = {};
            vm.Funcionario = funcionario;
            ConfigureModal("#modal-inserir-grav", false, vm.Funcionario, "Cadastro de Tipo de Funcionario", "Preencha todos os campos para alterar o Funcionario selecionado.");
        }

        vm.Update = Update;
        function Update() {
            gravidadeFactory.Update(vm.Funcionario).success(function (data, status) {
                CallbackSuccess('Registro gravado com sucesso!', vm.Funcionario);
            });
        }

        /* ---------------------------------------------------------------------------------------  */
        /* ---------------------------------------------------------------------------------------  */

        vm.ModalDelete = ModalDelete;
        function ModalDelete(funcionario) {
            vm.FuncionarioExcluir = angular.copy(funcionario);
            swal({
                title: "Atenção!",
                text: "Deseja realmente excluir a Gravidade selecionado?",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "DD6B55",
                confirmButtonText: "Sim, Continuar!",
                cancelButtonText: "Cancelar",
                closeOnConfirm: true
            }, function (isConfirm) {
                if (isConfirm) {
                    Delete();
                }
            });
        }

        vm.Delete = Delete;
        function Delete() {
            funcionarioFactory.Delete(vm.Funcionario.Id).success(function (data) {
                growl.success('O responsável foi excluído com sucesso!', { title: 'Confirmado!' });
                AtualizarGrid();
            });
        }
        /* ---------------------------------------------------------------------------------------  */
    }
})();
