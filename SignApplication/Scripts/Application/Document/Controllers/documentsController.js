documentModule.controller('documentsController', ['$scope', 'documentFactory', '$q', function ($scope, documentFactory, $q) {

    $scope.isDeleteQuestion = false;

    $q.all([documentFactory.getDocuments()]).then(success, fail);

    function success(res) {
        $scope.documents = res[0];
        console.log($scope.documents);
    };
    
    function fail() {
        $scope.error = "Ошибка при загрузке документов!";
    };

    $scope.sendRequest = function(document) {
        console.log(document);
    };

}]);