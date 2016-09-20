
var contractModule = angular.module('contractModule', ['common'])
    .config(function ($routeProvider, $locationProvider) {
    	$routeProvider.when('/contract', { templateUrl: '/App/Contract/Views/ContractHomeView.html', controller: 'contractHomeViewModel' });
    	$routeProvider.when('/contract/list', { templateUrl: '/App/Contract/Views/ContractListView.html', controller: 'contractListViewModel' });
    	$routeProvider.when('/contract/create', { templateUrl: '/App/Contract/Views/ContractCreate.html', controller: 'contractCreateViewModel' });
    	$routeProvider.when('/contract/show/:contractId', { templateUrl: '/App/Contract/Views/ContractDetails.html', controller: 'contractViewModel' });
    	$routeProvider.otherwise({ redirectTo: '/contract' });
    	$locationProvider.html5Mode({ enabled: true, requireBase: false });
    });

contractModule.factory('contractService', function ($rootScope, $http, $q, $location, viewModelHelper) { return MyApp.contractService($rootScope, $http, $q, $location, viewModelHelper); });
contractModule.factory('validationService', function (viewModelHelper, $q) {
    return {
        validateContractName: function (contractName) {
            // the $http API is based on the deferred/promise APIs exposed by the $q service
            // so it returns a promise for us by default
            return viewModelHelper.apiPost('api/contract/validateName',
			       typeof(contractName) === undefined || contractName == null ? contractName : '"' + contractName + '"',
                    function (response) {
                        if (typeof response.data === 'object') {
                            return response.data;
                        } else {
                            // invalid response
                            return $q.reject(response.data);
                        }
                    },
                    function (response) {
                        // something went wrong
                        return $q.reject(response.data);
                    }, null, true);
        }
    };
});

contractModule.directive('uniqueNameServerValidator', [ 'validationService', function (validationService) {
    return {
        require: 'ngModel',
        link: function (scope, elem, attrs, ctrl) {
            ctrl.$asyncValidators.asyncValidator = validationService.validateContractName;
        }
    };
}]);

contractModule.directive('usernameValidator', function($q, $timeout) {
    return {
        require: 'ngModel',
        link: function(scope, element, attrs, ngModel) {
            ngModel.$asyncValidators.contractName = function(modelValue, viewValue) {
                if (!viewValue) {
                    return $q.when(true);
                }
                var deferred = $q.defer();
                $timeout(function() {
                    // Faking actual server-side validity check with $http.
                    // Let's pretend our service is so popular all short username are already taken
                    if (viewValue && viewValue.length < 5) {
                        deferred.reject();
                    }

                    deferred.resolve();
                }, 2000);
                return deferred.promise;
            };
        }
    };
});

(function (myApp) {
	var contractService = function ($rootScope, $http, $q, $location, viewModelHelper) {

		var self = this;

		self.contractId = 0;

		return this;
	};
	myApp.contractService = contractService;
}(window.MyApp));
