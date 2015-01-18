documentModule.controller('documentEditerController', ['$scope', '$routeParams', '$q', 'documentFactory', 'documentElementFactory', 'documentElementService', 
    function ($scope, $routeParams, $q, documentFactory, documentElementFactory, documentElementService) {

        var documentId = $routeParams.documentId;
        $scope.docElements = [];
        $scope.listElements = [];

        documentElementService.waitForLoad().then(function() {
            $scope.listElements = documentElementService.getAllElements();
        });

        $q.all([documentFactory.getDocument(documentId), documentElementFactory.getDocumentElements(documentId)]).then(success, failGet);
    
        function success(res) {
            $scope.document = (res[0])[0];
            $scope.docElements = res[1];
            documentElementService.setDropableElement();
            angular.forEach($scope.docElements, function(value, key) {
                documentElementService.createElement(value);
            });
        };

        function failGet() {
            $scope.error = "Ошибка при загрузке документа!";
        };
        
        function failUpdate() {
            $scope.error = "Ошибка при сохранении документа!";
        };
        
        $scope.$on('dropNewElement', function (event, args) {

            $q.all([documentElementFactory.createDocumentElement(documentId, args.newElement)]).then(function (res) {
                $scope.docElements.push(res[0]);
                documentElementService.createElement(res[0]);
            }, failUpdate);
        });
        


    }]);