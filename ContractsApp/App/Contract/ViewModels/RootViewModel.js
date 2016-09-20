contractModule.controller("rootViewModel", function ($scope, contractService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

	// This is the parent controller/viewmodel for 'contractModule' and its $scope is accesible
	// down controllers set by the routing engine. This controller is bound to the Contract.cshtml in the
	// Home view-folder.

	$scope.viewModelHelper = viewModelHelper;
	$scope.contractService = contractService;

	$scope.flags = { shownFromList: false };

	var initialize = function () {
		$scope.pageHeading = "Contract Section";
	}

	$scope.contractList = function () {
		viewModelHelper.navigateTo('contract/list');
	}

	$scope.showContract = function () {
		if (contractService.contractId != 0) {
			$scope.flags.shownFromList = false;
			viewModelHelper.navigateTo('contract/show/' + contractService.contractId);
		}
	}

	$scope.createContract = function () {
			viewModelHelper.navigateTo('contract/create');
	}

	initialize();
});
