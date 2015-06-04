documentModule.service('documentElementService', ['$log', '$q', '$http', '$rootScope', function ($log, $q, $http, $rootScope) {

    var elements,
        docElements,
        isHasSign = false,
        self = this;
    var loading = $q.defer();
    
    function cloneTemplateElement (template) {
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

    function offsetPositionByElement (event, element, byElement) {
        var position = byElement.offset();
        console.log(position);
        console.log(event);
        element.Left = event.clientX - position.left;
        element.Top = event.clientY - position.top;
        return element;
    };
    
    $http.get('http://localhost:73/documents/getTemplateElements').then(function (response) {
        elements = response.data;
        loading.resolve();
    });

    self.waitForLoad = function () {
        return loading.promise;
    };

    self.getAllTemplateElements = function () {
        return elements;
    };

    self.getTemplateElementByID = function (id) {
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
    
    self.getAllElements = function () {
        return docElements;
    };

    self.isHasSignElement = function() {
        return isHasSign;
    };

    self.getElementByID = function (id) {
        if (id) {
            var ret;
            function findElement(element, index, array) {
                if (element.ID == id) {
                    ret = element;
                }
            }
            docElements.forEach(findElement);
            return ret;
        }
    };

    self.setAllElements = function(elems) {
        docElements = elems;
        angular.forEach(docElements, function (value, key) {
            self.createElement(value);
        });
    };

    self.AddElement = function(elem) {
        docElements.push(elem);
        self.createElement(elem);
    };

    self.setDropableElement = function () {
        $("#droppable").droppable({
            drop: function (event, ui) {
                
                var id = ui.draggable[0].attributes["id"].value.replace(/temp_elem_/g, "");
                var tempElement = self.getTemplateElementByID(id);
                if (tempElement) {
                    var element = cloneTemplateElement(tempElement);
                    element = offsetPositionByElement(event, element, $('.page'));
                    console.log(element);

                    $rootScope.$broadcast('dropNewElement', { newElement: element });
                } else {
                    var id = ui.draggable[0].attributes["id"].value.replace(/elem_/g, "");
                    var docElement = self.getElementByID(id);
                    if (docElement) {
                        self.updateElement(docElement, event);
                    }
                }
            }
        });
    };

    self.createElement = function (element) {
        if (element.ContentID === 1) {
            isHasSign = true;
        }

        $('.page')
            .append($('<div/>', {
                id: 'elem_' + element.ID,
                'class': 'doc-elem',
                //'html': '<span class="elem-text">' + element.Text + '</span>',
                'style': 'top: ' + element.Top + 'px; left: ' + element.Left + 'px; z-index:' + element.Zindex + '; width:' + element.Width + 'px; height:' + element.Height + 'px;'
            })
            .append($('<span/>', {
                'class': 'elem-text',
                'html': element.Text
            }))
            .append($('<div/>', {
                'class': 'ui-icon ui-icon-close elem-del',
                'ng-click': 'deleteElement(' + element.ID + ')'
            }))

            );
        var newElem = $('#elem_' + element.ID);
        
        newElem.resizable({
            containment: ".page",
            minHeight: 40,
            minWidth: 80,
            stop: function(event, ui) {
                var id = ui.element[0].attributes["id"].value.replace(/elem_/g, "");
                var docElement = self.getElementByID(id);
                if (docElement) {
                    self.updateElement(docElement, event);
                }
            }
        });
        newElem.draggable({ revert: "invalid" });
    };

    self.clearAllElements = function() {
        $('[id^=elem_]').remove();
    };

    self.updateElement = function (element, event) {
        var jqElem = $('#elem_' + element.ID);
        element.Width = jqElem.width();
        element.Height = jqElem.height();
        element = offsetPositionByElement(event, element, $('.page'));
        $rootScope.$broadcast('dropResizeElement', { newElement: element });
    };

}]);