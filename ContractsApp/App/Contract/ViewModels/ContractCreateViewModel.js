contractModule.controller("contractCreateViewModel", function ($scope, contractService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

	$scope.viewModelHelper = viewModelHelper;
	$scope.contractService = contractService;
	
	$scope.createContract = function () {
		viewModelHelper.apiPost('api/contract/create',
			$scope.contract,
            function (result) {
            	viewModelHelper.navigateTo("contract/show/"+result.data.newContractId);
            },
            function (error) {
                _showValidationErrors($scope, error);
            });
	}

	$scope.calculateSalary = function () {
		viewModelHelper.apiPost('api/contract/calculateSalary',
			$scope.contract,
            function (result) {
            	$scope.contract.Salary = result.data.salary
            });
	}

	function _showValidationErrors($scope, error) {
	    $scope.validationErrors = [];
	    if (error.data && angular.isObject(error.data)) {
	        for (var key in error.data) {
	            $scope.validationErrors.push(error.data[key][0]);
	        }
	    } else {
	        $scope.validationErrors.push('Could not add movie.');
	    };
	}

	var initialize = function () {
		$scope.positions = ["Programmer", "Tester"];
	}

	initialize();
});
