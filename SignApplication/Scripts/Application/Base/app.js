'use strict';

var signApp = angular.module('signApp', [
    'ngRoute',
    'signApp.infoModule',
    'signApp.menuModule',
    'signApp.documentModule',
    'request.module',
    'chart.js']);

signApp.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider
          .when('/info', {
              templateUrl: 'Info/Index',
              controller: 'infoController'
          })
          .when('/documents', {
              templateUrl: 'Documents/List',
              controller: 'documentsController'
          })
          .when('/document/:documentId', {
               templateUrl: 'Documents/Edit',
               controller: 'documentEditerController'
          })
          .when('/upload', {
              templateUrl: 'Upload/Index',
              controller: 'documentFileUploadController'
          })
          .when('/setup', {
              templateUrl: 'Setup/Index',
              controller: 'SetupController'
          })
          .when('/requests', {
              templateUrl: 'Request/Index',
              controller: 'requestsController',
              controllerAs: 'vm'
          })
          .otherwise({
              redirectTo: '/info'
          });
  }]);