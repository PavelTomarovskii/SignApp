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
            
            vm.predicate = "id";
            vm.reverse = false;
            
            vm.colModel.push({ name: '#', predicate: 'id' });
            vm.colModel.push({ name: 'Request Date', predicate: 'date' });
            vm.colModel.push({ name: 'Status', predicate: 'status' });
            vm.colModel.push({ name: 'Sent To', predicate: 'sentTo' });
            vm.colModel.push({ name: 'Document', predicate: 'documents' });
            vm.colModel.push({ name: 'Download', predicate: 'download' });
            
            vm.requests.push({
                id: 1,
                date: '2015-02-06',
                status: 'Документ подписан',
                sentTo: 'Николай Евгеньевич (volobaev.nikolay.evgen@mail.ru)',
                documents: 'Дополнительное соглашение',
                download: true
                },
                {
                    id: 2,
                    date: '2015-01-16',
                    status: 'Документ просмотрен',
                    sentTo: 'Эдуард Сергеевич (kozachuk.eduard.serg@yandex.ru)',
                    documents: 'Должностные инструкции',
                    download: false
                },
                {
                    id: 3,
                    date: '2015-05-13',
                    status: 'Запрос отправлен',
                    sentTo: 'Илья Борисович (bilyk.ilya.boris@gmail.com)',
                    documents: 'Должностные инструкции',
                    download: false
                },
                {
                    id: 4,
                    date: '2015-03-04',
                    status: 'Запрос отменен',
                    sentTo: 'Евгения Владимировна (bezberdaya.evgeniya.vladim@gmail.com)',
                    documents: 'Приказ',
                    download: false
                },
                {
                    id: 5,
                    date: '2015-05-05',
                    status: 'Документ просмотрен',
                    sentTo: 'Олег Викторович (lobanov.oleg.vict@bk.ru)',
                    documents: 'Приказ',
                    download: false
                },
                {
                    id: 6,
                    date: '2015-04-24',
                    status: 'Документ подписан',
                    sentTo: 'Олег Викторович (ryzhov.oleg.vict@bk.ru)',
                    documents: 'Дополнительное соглашение',
                    download: true
                },
                {
                    id: 7,
                    date: '2015-05-16',
                    status: 'Запрос отправлен',
                    sentTo: 'Людмила Альбертовна (kapustina.ludmila.alber@yandex.ru)',
                    documents: 'Приказ №120',
                    download: false
                },
                {
                    id: 8,
                    date: '2015-03-24',
                    status: 'Запрос отменен',
                    sentTo: 'Нина Владимировна (malceva.nina.vladim@list.ru)',
                    documents: 'Приказ №37',
                    download: false
                },
                {
                    id: 9,
                    date: '2015-04-06',
                    status: 'Документ подписан',
                    sentTo: 'Денис Геннадьевич (vasilchuk.denis.gennad@mail.ru)',
                    documents: 'Дополнительное соглашение',
                    download: true
                },
                {
                    id: 10,
                    date: '2015-05-25',
                    status: 'Документ просмотрен',
                    sentTo: 'Вероника Сергеевна (papkina.veronika.serg@gmail.com)',
                    documents: 'Должностные инструкции',
                    download: false
                },
                {
                    id: 11,
                    date: '2015-05-21',
                    status: 'Запрос отправлен',
                    sentTo: 'Татьяна Алексеевна (mixajlova.tatjana.aleks@yahoo.com)',
                    documents: 'Дополнительное соглашение',
                    download: false
                },
                {
                    id: 12,
                    date: '2015-05-18',
                    status: 'Запрос отменен',
                    sentTo: 'Александр Валерьевич (korlyakov.aleksandr.valer@rambler.ru)',
                    documents: 'Приказ №150',
                    download: false
                },
                {
                    id: 13,
                    date: '2015-05-07',
                    status: 'Документ просмотрен',
                    sentTo: 'Артем Сергеевич (kostin.artem.serg@mail.ru)',
                    documents: 'Приказ №143',
                    download: false
                },
                {
                    id: 14,
                    date: '2015-05-22',
                    status: 'Запрос отправлен',
                    sentTo: 'Петр Дмитриевич (gavrilov.petr.dmitr@bk.ru)',
                    documents: 'Уведомление',
                    download: false
                },
                {
                    id: 15,
                    date: '2015-05-05',
                    status: 'Запрос отменен',
                    sentTo: 'Оксана Романовна kiseleva.(oksana.romanov@gmail.com)',
                    documents: 'Должностные инструкции',
                    download: false
                },
                {
                    id: 16,
                    date: '2015-02-17',
                    status: 'Документ подписан',
                    sentTo: 'Сергей Олегович (sorokin.sergei.olegov@yandex.ru)',
                    documents: 'Дополнительное соглашение',
                    download: true
                },
                {
                    id: 17,
                    date: '2015-04-08',
                    status: 'Документ подписан',
                    sentTo: 'Виталий Русланович (kislyakov.vitalii.rusl@list.ru)',
                    documents: 'Уведомление',
                    download: true
                },
                {
                    id: 18,
                    date: '2015-01-14',
                    status: 'Запрос отменен',
                    sentTo: 'Кристина Игоревна (vasiullina.kristina.igorevna@mail.ru)',
                    documents: 'Уведомление',
                    download: false
                },
                {
                    id: 19,
                    date: '2015-01-12',
                    status: 'Запрос отменен',
                    sentTo: 'Александр Александрович (fomenkov.aleksandr.aleksandr@gmail.com)',
                    documents: 'Уведомление',
                    download: false
                },
                {
                    id: 20,
                    date: '2015-02-27',
                    status: 'Документ подписан',
                    sentTo: 'Константин Дмитриевич (bragin.konstantin.dmitr@yahoo.com)',
                    documents: 'Уведомление',
                    download: true
                },
                {
                    id: 21,
                    date: '2015-05-20',
                    status: 'Документ просмотрен',
                    sentTo: 'Данияр Давлетович (vlasov.daniyar.davlet@mail.ru)',
                    documents: 'Уведомлениек',
                    download: false
                },
                {
                    id: 22,
                    date: '2015-04-30',
                    status: 'Запрос отправлен',
                    sentTo: 'Камила Александровна (kurbanova.kamila.aleks@mail.ru)',
                    documents: 'Уведомление',
                    download: false
                },
                {
                    id: 23,
                    date: '2015-02-11',
                    status: 'Запрос отменен',
                    sentTo: 'Дмитрий Петрович (kalenichenko.dmitrii.petrov@bk.ru)',
                    documents: 'Должностные инструкции',
                    download: false
                },
                {
                    id: 24,
                    date: '2015-05-27',
                    status: 'Документ подписан',
                    sentTo: 'Анна Владимировна (shumkova.anna.vladim@yahoo.com)',
                    documents: 'Уведомление',
                    download: true
                },
                {
                    id: 25,
                    date: '2015-05-06',
                    status: 'Документ просмотрен',
                    sentTo: 'Валентина Владимировна (shumkova.valentina.vladim@rambler.ru)',
                    documents: 'Штатное расписание',
                    download: false
                },
                {
                    id: 26,
                    date: '2015-05-07',
                    status: 'Запрос отправлен',
                    sentTo: 'Олег Вячеславович (gabdulin.oleg.vyachesl@yandex.ru)',
                    documents: 'Дополнительное соглашение',
                    download: false
                },
                {
                    id: 27,
                    date: '2015-01-20',
                    status: 'Запрос отменен',
                    sentTo: 'Кирилл Юрьевич (lopatin.kirill.yurev@mail.ru)',
                    documents: 'Штатное расписание',
                    download: false
                },
                {
                    id: 27,
                    date: '2015-01-21',
                    status: 'Запрос отменен',
                    sentTo: 'Лилия Александровна (kiseleva.liliya.aleks@list.ru)',
                    documents: 'График отпусков',
                    download: false
                },
                {
                    id: 28,
                    date: '2015-01-22',
                    status: 'Документ подписан',
                    sentTo: 'Артем Александрович (palnikov.artem.aleks@mail.ru)',
                    documents: 'Приказ (распоряжение) о поощрении работника',
                    download: true
                },
                {
                    id: 29,
                    date: '2015-05-21',
                    status: 'Документ просмотрен',
                    sentTo: 'Ирина Сергеевна (perepelica.irina.serg@yandex.ru)',
                    documents: 'Штатное расписание',
                    download: false
                },
                {
                    id: 30,
                    date: '2015-05-14',
                    status: 'Запрос отправлен',
                    sentTo: 'Мария Никитична (mixajlova.mariya.nikit@gmail.com)',
                    documents: 'График отпусков',
                    download: false
                },
                {
                    id: 31,
                    date: '2015-04-28',
                    status: 'Запрос отменен',
                    sentTo: 'Полина Игоревна (vustovalova.polina.igorev@gmail.com)',
                    documents: 'Приказ (распоряжение) о поощрении работника',
                    download: false
                },
                {
                    id: 32,
                    date: '2015-03-31',
                    status: 'Документ подписан',
                    sentTo: 'Алена Эдуардовна (dergacheva.alena.eduard@yahoo.com)',
                    documents: 'Приказ (распоряжение) о поощрении работника',
                    download: true
                },
                {
                    id: 33,
                    date: '2015-05-08',
                    status: 'Документ просмотрен',
                    sentTo: 'Александр Владимирович (kostyuk.aleksandr.vladim@gmail.com)',
                    documents: 'Приказ (распоряжение) о поощрении работника',
                    download: false
                },
                {
                    id: 34,
                    date: '2015-05-14',
                    status: 'Запрос отправлен',
                    sentTo: 'Ксения Витальевна (nikitina.kseniya.vital@yandex.ru)',
                    documents: 'Табель учета рабочего времени и расчета оплаты труда',
                    download: false
                },
                {
                    id: 34,
                    date: '2015-01-23',
                    status: 'Запрос отменен',
                    sentTo: 'Валентина Игоревна (navrodskaya.valentina.igorevna@gmail.com)',
                    documents: 'Табель учета рабочего времени и расчета оплаты труда',
                    download: false
                },
                {
                    id: 35,
                    date: '2015-02-25',
                    status: 'Документ подписан',
                    sentTo: 'Илья Дмитриевич (koshovskij.ilya.dmitr@bk.ru)',
                    documents: 'Табель учета рабочего времени и расчета оплаты труда',
                    download: true
                },
                {
                    id: 36,
                    date: '2015-05-18',
                    status: 'Документ просмотрен',
                    sentTo: 'Владислав Олегович (semenkov.vladislav.olegov@list.ru)',
                    documents: 'Командировочное удостоверение',
                    download: false
                },
                {
                    id: 37,
                    date: '2015-05-19',
                    status: 'Запрос отправлен',
                    sentTo: 'Мария Валерьевна (mariya.valer@mail.ru)',
                    documents: 'Записка-расчет о предоставлении отпуска работнику',
                    download: false
                },
                {
                    id: 38,
                    date: '2015-03-10',
                    status: 'Запрос отменен',
                    sentTo: 'Виктория Валерьевна (shinkareva.viktoriya.valer@bk.ru)',
                    documents: 'Командировочное удостоверение',
                    download: false
                },
                {
                    id: 39,
                    date: '2015-03-12',
                    status: 'Документ подписан',
                    sentTo: 'Тимур Сергеевич (timofeev.timur.serg@gmail.com)',
                    documents: 'Записка-расчет о предоставлении отпуска работнику',
                    download: true
                },
                {
                    id: 40,
                    date: '2015-05-14',
                    status: 'Документ просмотрен',
                    sentTo: 'Галина Леонидовна (usacheva.galina.leonid@yahoo.com)',
                    documents: 'Записка-расчет о предоставлении отпуска работнику',
                    download: false
                }
            );

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