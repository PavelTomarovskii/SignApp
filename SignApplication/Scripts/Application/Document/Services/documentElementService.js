documentModule.service('documentElementService', ['$log', '$q', '$http', '$rootScope', function ($log, $q, $http, $rootScope) {

    var elements,
        self = this;
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
                var tempElement = self.getElementByID(id);
                if (tempElement) {
                    var element = self.cloneTemplateElement(tempElement);
                    element = self.offsetPositionByElement(event, element, $('.page'));
                    $rootScope.$broadcast('dropNewElement', { newElement: element });
                } else {
                    console.log(event);
                    console.log(ui);
                }
            }
        });
    };

    self.cloneTemplateElement = function(template) {
        var element = {
            ID: -1,
            ContentID: template.ID,
            Width: template.DefaultWidth,
            Height: template.DefaultHeight,
            Text: template.DefaultValue,
            IsDelete: false,
            IsRequired: true
        };

        return element;
    };

    self.offsetPositionByElement = function(event, element, byElement) {
        var position = byElement.offset();
        element.Left = event.clientX - position.left;
        element.Top = event.clientY - position.top;
        return element;
    };

    self.createElement = function (element) {
        $('.page').append($('<div/>', {
            id: 'elem' + element.ID,
            'class': 'doc-elem',
            'html': '<span class="elem-text">' + element.Text + '</span>',
            'style': 'top: ' + element.Top + 'px; left: ' + element.Left + 'px; z-index:' + element.Zindex + '; width:' + element.Width + 'px; height:' + element.Height + 'px;'
        }));
        var newElem = $('#elem' + element.ID);
        
        newElem.resizable({
            containment: ".page",
            minHeight: 40,
            minWidth: 80,
            stop: function(event, ui) {
                console.log(event);
                console.log(ui);
            }
        });
        newElem.draggable({ revert: "invalid" });
    };

    self.updateElementPosition = function () {
        
    };

}]);