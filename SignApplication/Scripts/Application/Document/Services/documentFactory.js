var documentFactory = function documentFactory($http, $q, $log) {
    //var loading = $q.defer();

    var factory = {};

    factory.getDocuments = function() {
        return $http.get('documents/getDocuments')
            .then(getDocumentsListComplete)
            .catch(getWeatherListFailed);
    };

    function getDocumentsListComplete(response) {
        //loading.resolve();
        return response.data;
    }

    function getWeatherListFailed(error) {
        $log.error('[weatherFactory] getWeatherList Failed' + error.data);
    }

    return factory;
};

documentModule.factory('documentFactory', ['$http', '$q', '$log', documentFactory]);