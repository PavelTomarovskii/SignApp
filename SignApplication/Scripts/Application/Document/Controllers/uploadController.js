documentModule.config(['$httpProvider', 'fileUploadProvider', function ($httpProvider, fileUploadProvider) {
    delete $httpProvider.defaults.headers.common['X-Requested-With'];
    fileUploadProvider.defaults.redirect = window.location.href.replace(
        /\/[^\/]*$/,
        '/cors/result.html?%s'
    );
}])
    .controller('documentFileUploadController', ['$scope', '$http', '$filter', '$window', function ($scope, $http) {
        console.log($scope.queue);
        $scope.options = {
            url: 'Upload/Upload/'
        };
        $scope.loadingFiles = true;
        $http.get('Upload/Upload/')
            .then(
                function (response) {
                    $scope.loadingFiles = false;
                    $scope.queue = response.data.files || [];
                },
                function () {
                    $scope.loadingFiles = false;
                }
            );

    }])
    .controller('documentFileDestroyController', ['$scope', '$http', function ($scope, $http) {
        var file = $scope.file,
            state;
        if (file.url) {
            file.$state = function() {
                return state;
            };
            file.$destroy = function() {
                state = 'pending';
                return $http({
                    url: file.deleteUrl,
                    method: file.deleteType
                }).then(
                    function() {
                        state = 'resolved';
                        $scope.clear(file);
                    },
                    function() {
                        state = 'rejected';
                    }
                );
            };
        } else if (!file.$cancel && !file._index) {
            file.$cancel = function() {
                $scope.clear(file);
            };
        }
    }]);