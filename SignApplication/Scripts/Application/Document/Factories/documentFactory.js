var documentFactory = function documentFactory($http, $log) {
    var factory = {};

    factory.getDocuments = function() {
        return $http.get('documents/getDocuments')
            .then(getDocumentsComplete)
            .catch(getDocumentFailed);
    };
    
    factory.getDocument = function (id) {

        var req = {
            method: 'GET',
            url: 'documents/getDocument',
            params: { documentID: id }
        };

        return $http(req)
            .then(getDocumentsComplete)
            .catch(getDocumentFailed);
    };

    function getDocumentsComplete(response) {
        return response.data;
    }
    
    function getDocumentFailed(error) {
        $log.error('[documentFactory] getDocument(s) Failed' + error.data);
    }

    return factory;
};

documentModule.factory('documentFactory', ['$http', '$log', documentFactory]);