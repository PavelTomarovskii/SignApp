documentModule.service('documentElementService', ['$log', '$q', '$http', '$rootScope', function ($log, $q, $http, $rootScope) {

    var elements,
        docElements,
        self = this,
        dropElement = $('.page');
    var loading = $q.defer();
    
    $http.get('documents/getTemplateElements').then(function (response) {
        elements = response.data;
        loading.resolve();
    });

    self.waitForLoad = function () {
        return loading.promise;
    };

    self.getAllElements = function () {
        return elements;
    };

    self.getElementByID = function (id) {
        if (id) {
            var ret;
            function findElement(element, index, array) {
                if (element.ID == id) {
                    ret = element;
                }
            }
            elements.forEach(findElement);
            
            return ret;
        }
    };

    self.setDropableElement = function () {
        $("#droppable").droppable({
            drop: function (event, ui) {
                
                var id = ui.draggable[0].attributes["id"].value.replace(/temp_elem_/g, "");
                var element = self.getElementByID(id);
                if (element) {
                    element = self.offsetPositionByElement(event, element, dropElement);
                    $rootScope.$broadcast('dropNewElement', { newElement: element });
                } else {
                    
                }
            }
        });
    };

    self.offsetPositionByElement = function(event, element, byElement) {
        var position = byElement.offset();
        element.Left = event.clientX - position.left;
        element.Top = event.clientY - position.top;
        return element;
    };

    self.createElement = function (element, id) {
        element.Zindex = 100 + id;
        dropElement.append($('<div/>', {
            id: 'elem' + id,
            'class': 'doc-elem',
            'html': '<span class="elem-text">' + element.DefaultValue + '</span>',
            'style': 'top: ' + element.Top + 'px; left: ' + element.Left + 'px; z-index:' + element.Zindex + '; width:' + element.DefaultWidth + 'px; height:' + element.DefaultHeight + 'px;'
        }));
        var newElem = $('#elem' + id);
        
        newElem.resizable({ containment: ".page", minHeight: 40, minWidth: 80 });
        newElem.draggable({ revert: "invalid" });
    };

    self.updateElementPosition = function () {
        
    };

}]);