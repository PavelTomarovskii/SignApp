documentModule.controller('documentEditerController', ['$scope', '$routeParams', '$q', 'documentFactory', 'documentElementFactory', 'documentElementService', 
    function ($scope, $routeParams, $q, documentFactory, documentElementFactory, documentElementService) {

        var documentId = $routeParams.documentId;
        $scope.listElements = [];

        documentElementService.waitForLoad().then(function() {
            $scope.listElements = documentElementService.getAllTemplateElements();
        });

        $q.all([documentFactory.getDocument(documentId), documentElementFactory.getDocumentElements(documentId)]).then(success, failGet);
    
        function success(res) {
            $scope.document = (res[0])[0];
            documentElementService.setDropableElement();
            documentElementService.setAllElements(res[1]);
        };

        function failGet() {
            $scope.error = "Ошибка при загрузке документа!";
        };
        
        function failUpdate() {
            $scope.error = "Ошибка при сохранении документа!";
        };
        
        $scope.$on('dropNewElement', function (event, args) {
            $q.all([documentElementFactory.updateDocumentElement(documentId, args.newElement)]).then(function (res) {
                documentElementService.AddElement(res[0]);
            }, failUpdate);
        });
        
        $scope.$on('dropResizeElement', function (event, args) {
            documentElementFactory.updateDocumentElement(documentId, args.newElement);
        });

        $scope.deleteElement = function(id) {
            console.log(id);
        };


    }]);