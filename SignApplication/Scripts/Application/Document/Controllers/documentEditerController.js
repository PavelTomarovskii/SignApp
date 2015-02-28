documentModule.controller('documentEditerController', ['$scope', '$routeParams', '$q', 'documentFactory', 'documentElementFactory', 'documentElementService', 
    function ($scope, $routeParams, $q, documentFactory, documentElementFactory, documentElementService) {

        var documentId = $routeParams.documentId;
        $scope.listElements = [];
        $scope.currentPage = 1;
        $scope.maxSize = 5;
        $scope.totalPages = 10;

        documentElementService.waitForLoad().then(function() {
            $scope.listElements = documentElementService.getAllTemplateElements();
        });

        documentElementService.setDropableElement();
        $q.all([documentFactory.getDocument(documentId, $scope.currentPage), documentElementFactory.getDocumentElements(documentId, $scope.currentPage)]).then(success, failGet);
    
        function success(res) {
            $scope.document = (res[0])[0];
            $scope.totalPages = $scope.document.PageCount;
            documentElementService.setAllElements(res[1]);
        };

        function failGet() {
            $scope.error = "Ошибка при загрузке документа!";
        };
        
        function failUpdate() {
            $scope.error = "Ошибка при сохранении документа!";
        };
        
        $scope.$on('dropNewElement', function (event, args) {
            args.newElement.Page = $scope.currentPage;
            $q.all([documentElementFactory.updateDocumentElement(documentId, args.newElement)]).then(function (res) {
                documentElementService.AddElement(res[0]);
            }, failUpdate);
        });
        
        $scope.$on('dropResizeElement', function (event, args) {
            args.newElement.Page = $scope.currentPage;
            documentElementFactory.updateDocumentElement(documentId, args.newElement);
        });

        $scope.deleteElement = function(id) {
            console.log(id);
        };

        $scope.pageChanged = function() {
            $q.all([documentFactory.getDocument(documentId, $scope.currentPage),
                documentElementFactory.getDocumentElements(documentId, $scope.currentPage)])
            .then(function (res) {
                documentElementService.clearAllElements();
                success(res);
            }, failGet);
        };

        $scope.saveDocument = function() {
            documentFactory.saveDocument($scope.document);
        };

        $scope.isHasSignElement = function() {
            return documentElementService.isHasSignElement();
        };


    }]);