var documentElementFactory = function documentElementFactory($http, $log) {
    var factory = {};

    factory.getDocumentElements = function (id, page) {

        var req = {
            method: 'GET',
            url: 'http://localhost:73/documents/getDocumentElements',
            params: {
                documentID: id,
                page: page
            }
        };

        return $http(req)
            .then(getComplete)
            .catch(getFailed);
    };
    
    factory.updateDocumentElement = function (documentID, element) {
        element.DocumentID = documentID;
        
        var req = {
            method: 'POST',
            url: 'documents/updateDocumentElement',
            data: element
        };

        return $http(req)
            .then(getComplete)
            .catch(getFailed);
    };

    //factory.updateDocumentElement = function(element) {

    //    var req = {
    //        method: 'POST',
    //        url: 'documents/updateDocumentElement',
    //        data: { element }
    //    };

    //    return $http(req)
    //        .then(getComplete)
    //        .catch(getFailed);
    //};

    function getComplete(response) {
        return response.data;
    }

    function getFailed(error) {
        $log.error('[documentFactory] getDocumentElements Failed' + error.data);
    }

    return factory;
};

documentModule.factory('documentElementFactory', ['$http', '$log', documentElementFactory]);