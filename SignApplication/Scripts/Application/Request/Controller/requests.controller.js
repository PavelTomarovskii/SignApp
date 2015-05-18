(function () {
    'use strict';

    angular
        .module('request.module')
        .factory('requestsController', requestsController);

    requestsController.$inject = ['$http', '$log'];

    function requestsController($http, $log) {

        var vm = this;
        vm.pageSize = 10;
        vm.paginatorPages = 5;
        vm.colModel = [];

        vm.getSortOrder = getSortOrder;
        vm.clickOnHeader = clickOnHeader;

        activate();

        function activate() {
            
            vm.colModel.push({ name: '#', predicate: 'id' });
            vm.colModel.push({ name: 'Name', predicate: 'name' });
            vm.colModel.push({ name: 'Grade', predicate: 'grade' });
            vm.colModel.push({ name: 'Job', predicate: 'job' });
            vm.colModel.push({ name: 'Age', predicate: 'age' });
            
        }
        
        function getSortOrder() {
            return vm.reverse ? "glyphicon-sort-by-attributes-alt" : "glyphicon-sort-by-attributes";
        }
        
        function clickOnHeader(predicate) {
            vm.predicate = predicate;
            vm.reverse = !vm.reverse;
        }

    }

})();