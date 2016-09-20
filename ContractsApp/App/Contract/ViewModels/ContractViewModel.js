contractModule.controller("contractViewModel", function ($scope, contractService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

	$scope.viewModelHelper = viewModelHelper;
	$scope.contractService = contractService;

	var initialize = function () {
		$scope.refreshContract($routeParams.contractId);
	}

	$scope.refreshContract = function (contractId) {
		viewModelHelper.apiGet('api/contract/' + contractId, null,
            function (result) {
            	contractService.contractId = contractId;
            	$scope.contract = result.data;
            });
	}

	initialize();
});
