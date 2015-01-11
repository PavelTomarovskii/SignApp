var documentElementFactory = function documentElementFactory($http, $log) {
    var factory = {};

    factory.getDocumentElements = function (id) {

        var req = {
            method: 'GET',
            url: 'documents/getDocumentElements',
            params: { documentID: id }
        };

        return $http(req)
            .then(getComplete)
            .catch(getFailed);
    };
    
    factory.createDocumentElement = function (documentID, element) {

        var req = {
            method: 'POST',
            url: 'documents/updateDocumentElement',
            data: {
                DocumentID: documentID,
                ContentID: element.ID,
                Left: element.Left,
                Top: element.Top,
                Width: element.DefaultWidth,
                Height: element.DefaultHeight
            }
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