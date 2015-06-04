var documentFactory = function documentFactory($http, $log) {
    var factory = {};

    factory.getDocuments = function() {
        return $http.get('documents/getDocuments')
            .then(getDocumentsComplete)
            .catch(getDocumentFailed);
    };
    
    factory.getDocument = function (id, page) {

        var req = {
            method: 'GET',
            url: 'http://localhost:73/documents/getDocument',
            params: {
                documentID: id,
                page: page
            }
        };

        return $http(req)
            .then(getDocumentsComplete)
            .catch(getDocumentFailed);
    };

    factory.saveDocument = function(document) {
        var req = {
            method: 'POST',
            url: 'documents/updateDocument',
            data: document
        };

        return $http(req)
            .success(updateDocumentSuccess)
            .error(updateDocumentError);
    };

    function getDocumentsComplete(response) {
        return response.data;
    }
    
    function getDocumentFailed(error) {
        $log.error('[documentFactory] getDocument(s) Failed' + error.data);
    }

    function updateDocumentSuccess() {

    }

    function updateDocumentError() {
        $log.error('[documentFactory] updateDocument Failed' + error.data);
    }

    return factory;
};

documentModule.factory('documentFactory', ['$http', '$log', documentFactory]);