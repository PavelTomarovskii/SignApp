documentModule.controller('documentsController', ['$scope', 'documentFactory', '$q', 'requestService', function ($scope, documentFactory, $q, requestService) {

    $scope.isDeleteQuestion = false;

    $q.all([documentFactory.getDocuments()]).then(success, fail);

    function success(res) {
        $scope.documents = res[0];

        angular.forEach($scope.documents, function(doc) {
            $scope.resetPersons(doc);
        });

        console.log($scope.documents);
    }
    
    function fail() {
        $scope.error = "Ошибка при загрузке документов!";
    }

    $scope.sendRequest = function(document) {
        requestService.createRequest(document);
    };

    $scope.addPerson = function (document) {
        document.persons.push({ id: document.persons.length + 1, email: '', name: '' });
    };
    
    $scope.removePerson = function (document, id) {
        document.persons.splice(id - 1, 1);
        for (var i = 0; i < document.persons.length; i++) {
            document.persons[i].id = i + 1;
        }
    };

    $scope.resetPersons = function(document) {
        document.persons = [];
        $scope.addPerson(document);
    };

}]);