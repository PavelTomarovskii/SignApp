(function () {
    'use strict';

    angular
        .module('request.module')
        .controller('requestsController', requestsController)
        .filter('startFrom', startFrom);

    requestsController.$inject = ['$http', '$log'];

    function requestsController($http, $log) {

        var vm = this;
        vm.pageSize = 10;
        vm.paginatorPages = 5;
        vm.currentPage = 1;
        vm.colModel = [];
        vm.requests = [];

        vm.getSortOrder = getSortOrder;
        vm.clickOnHeader = clickOnHeader;

        activate();

        function activate() {
            
            vm.colModel.push({ name: '#', predicate: 'id' });
            vm.colModel.push({ name: 'Request Date', predicate: 'requestdate' });
            vm.colModel.push({ name: 'Status', predicate: 'status' });
            vm.colModel.push({ name: 'Sent To', predicate: 'sentto' });
            vm.colModel.push({ name: 'Document', predicate: 'document' });
            vm.colModel.push({ name: 'Type', predicate: 'type' });
            vm.colModel.push({ name: 'Download', predicate: 'download' });
            
            vm.requests.push({
                id: 1,
                date: '2015-02-06',
                status: 'Подписан',
                sentTo: 'Иван Иванович (ivan-ivan@mail.ru)',
                documents: 'Заявление на отпуск',
                download: true
            });

        }
        
        function getSortOrder() {
            return vm.reverse ? "glyphicon-sort-by-attributes-alt" : "glyphicon-sort-by-attributes";
        }
        
        function clickOnHeader(predicate) {
            vm.predicate = predicate;
            vm.reverse = !vm.reverse;
        }

    }
    
    function startFrom() {
        return function (input, start) {
            start = +start;
            return input ? input.slice(start) : input;
        };
    }

})();