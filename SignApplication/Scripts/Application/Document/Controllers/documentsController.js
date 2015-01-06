documentModule.controller('documentsController', ['$scope', 'documentFactory', '$q', function ($scope, documentFactory, $q) {

    $q.all([documentFactory.getDocuments()]).then(success, fail);

    function success(res) {
        $scope.documents = res[0];
    };
    
    function fail() {
        $scope.error = "Ошибка при загрузке документов!";
    };
    
}]);