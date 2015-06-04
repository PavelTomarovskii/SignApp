(function(){
    "use strict";

    documentModule
        .controller('SignController', SignController);

    SignController.$inject = [
        '$scope',
        '$q',
        '$modal',
        'documentFactory',
        'documentElementFactory'
    ];

    function SignController(
        $scope,
        $q,
        $modal,
        documentFactory,
        documentElementFactory) {

        $scope.documentID = 33;
        $scope.currentPage = 1;

        $scope.open = function (size) {

            var modalInstance = $modal.open({
                animation: true,
                templateUrl: 'myModalContent.html',
                controller: 'ModalInstanceCtrl',
                resolve: {
                    items: function () {
                        return $scope.items;
                    }
                }
            });

            modalInstance.result.then(function (selectedItem) {
                $scope.selected = selectedItem;
            }, function () {

            });
        };

        $q.all([
            documentFactory.getDocument($scope.documentID, $scope.currentPage),
            documentElementFactory.getDocumentElements($scope.documentID, $scope.currentPage)
        ]).then(success, failGet);


        function success(res) {
            console.log(res);
            $scope.document = (res[0])[0];
            $scope.controls = (res[1]);
            $scope.totalPages = $scope.document.PageCount;
        }

        function failGet() {
            $scope.error = "Ошибка при загрузке документа!";
        }

    }

    documentModule.directive("drawing", function(){
        return {
            restrict: "A",
            link: function(scope, element){
                var ctx = element[0].getContext('2d');

                // variable that decides if something should be drawn on mousemove
                var drawing = false;

                // the last coordinates before the current move
                var lastX;
                var lastY;

                element.bind('mousedown', function(event){
                    if(event.offsetX!==undefined){
                        lastX = event.offsetX;
                        lastY = event.offsetY;
                    } else { // Firefox compatibility
                        lastX = event.layerX - event.currentTarget.offsetLeft;
                        lastY = event.layerY - event.currentTarget.offsetTop;
                    }

                    // begins new line
                    ctx.beginPath();

                    drawing = true;
                });
                element.bind('mousemove', function(event){
                    if(drawing){
                        var currentX, currentY;
                        // get current mouse position
                        if(event.offsetX!==undefined){
                            currentX = event.offsetX;
                            currentY = event.offsetY;
                        } else {
                            currentX = event.layerX - event.currentTarget.offsetLeft;
                            currentY = event.layerY - event.currentTarget.offsetTop;
                        }

                        draw(lastX, lastY, currentX, currentY);

                        // set current coordinates to last one
                        lastX = currentX;
                        lastY = currentY;
                    }

                });
                element.bind('mouseup', function(event){
                    // stop drawing
                    drawing = false;
                });

                // canvas reset
                function reset(){
                    element[0].width = element[0].width;
                }

                function draw(lX, lY, cX, cY){
                    // line from
                    ctx.moveTo(lX,lY);
                    // to
                    ctx.lineTo(cX,cY);
                    // color
                    ctx.strokeStyle = "#4bf";
                    // draw it
                    ctx.stroke();
                }
            }
        };
    });

    documentModule.controller('ModalInstanceCtrl', function ($scope, $modalInstance, items) {

        $scope.ok = function () {
            $modalInstance.close();
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    });

})();


