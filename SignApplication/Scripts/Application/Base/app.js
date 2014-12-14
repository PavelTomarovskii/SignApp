'use strict';

var signApp = angular.module('signApp', [
    'ngRoute',
    'signApp.infoModule',
    'signApp.menuModule',
    'signApp.documentModule']);

signApp.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
          when('/menu', {
              templateUrl: 'Info/Index',
              controller: 'infoController'
          }).
          when('/documents', {
              templateUrl: 'Documents/List',
              controller: 'documentsController'
          }).
          //when('/documents/:documentId', {
          //    templateUrl: 'Documents/Item',
          //    controller: 'documentController'
          //}).
          otherwise({
              redirectTo: '/menu'
          });
  }]);