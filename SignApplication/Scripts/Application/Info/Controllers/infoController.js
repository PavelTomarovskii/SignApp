infoModule.controller('infoController', ['$scope', function ($scope) {
    $scope.text = 'История запросов';
    
    /*chart*/
    var json = {
        "series": ["SeriesA"],
        "data": [["90", "99", "80", "91", "76", "75", "60", "67", "59", "55"]],
        "labels": ["01", "02", "03", "04", "05", "06", "07", "08", "09", "10"],
        "colours": [{ // default
            "fillColor": "rgba(224, 108, 112, 1)",
            "strokeColor": "rgba(207,100,103,1)",
            "pointColor": "rgba(220,220,220,1)",
            "pointStrokeColor": "#fff",
            "pointHighlightFill": "#fff",
            "pointHighlightStroke": "rgba(151,187,205,0.8)"
        }]
    };
    $scope.ocw = json;
    
}]);