contractModule.controller("contractListViewModel", function ($scope, contractService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

	$scope.viewModelHelper = viewModelHelper;
	$scope.contractService = contractService;

	var initialize = function () {
		$scope.refreshContracts();
	}

	$scope.refreshContracts = function () {
		viewModelHelper.apiGet('api/contracts', null,
            function (result) {
            	$scope.contracts = result.data;
            });
	}

	$scope.showContract = function (contract) {
		$scope.flags.shownFromList = true;
		viewModelHelper.navigateTo('contract/show/' + contract.ContractId);
	}

	initialize();
});
