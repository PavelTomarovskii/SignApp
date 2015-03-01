(function() {
    'use strict';

    angular
        .documentModule('request.module')
        .factory('requestService', requestService);

    requestService.$inject = ['$http'];

    function requestService($http) {

        return {            
            createRequest: createRequest
        };

        function createRequest(document) {
            var req = {
                method: 'POST',
                url: 'request/createRequest',
                data: document
            };

            return $http(req)
                .success(createRequestComplete)
                .error(createRequestFailed);
        }
        
        function createRequestComplete(response) {

        }

        function createRequestFailed(error) {
            $log.error('[requestService] createRequest Failed' + error.data);
        }
    }

})();