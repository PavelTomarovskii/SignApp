(function() {
    'use strict';

    angular
        .module('request.module')
        .factory('requestService', requestService);

    requestService.$inject = ['$http', '$log'];

    function requestService($http, $log) {

        return {            
            createRequest: createRequest
        };

        function createRequest(document) {
            console.log(document);
            var req = {
                method: 'POST',
                url: 'request/createRequest',
                data: {
                    DocumentID: document.ID,
                    UserID: document.UserID,
                    Persons : document.persons
                }
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