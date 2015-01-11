documentModule.directive('documentElement', function () {
    return {
        restrict: 'E',
        replace: true,
        controller: 'documentElementController',
        scope: {
            options: '=options'
        },
        templateUrl: 'Html/Document/DocumentElement.html',
        link: function (scope, element, attrs, ngModelCtrl) {
            $(function() {
                element.draggable({
                    revert: "invalid",
                    helper: 'clone'
                });
            });
        }
    };
});

documentModule.value('documentElementConfig', {
    ReadOnly: true
});

documentModule.controller('documentElementController', ['$scope', 'documentElementConfig', function ($scope, documentElementConfig) {

    //console.log($scope.options);

}]);
