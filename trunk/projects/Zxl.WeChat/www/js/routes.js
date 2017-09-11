angular.module('wechat.routes', [])

.config(function($stateProvider, $urlRouterProvider) {

    $stateProvider
        .state("tab", {
            url: "/tab",
            abstract: true,
            templateUrl: "templates/tabs.html",
        })

        .state('tab.wsbj', {
            url: '/wsbj',
            views: {
                'tab-wsbj': {
                    templateUrl: 'templates/tab-wsbj.html',
                    controller: "wsbjCtrl"
                }
            }
        })

        .state('form', {
            url: '/form/:businessId',
            templateUrl: "templates/form.html",
            controller: "formCtrl"
        })

        .state('tab.assessments', {
            url: '/assessments',
            views: {
                'tab-assessments': {
                    templateUrl: 'templates/tab-assessments.html',
                    controller: "assessmentsCtrl"
                }
            }
        })

        .state('tab.find', {
            url: '/find',
            views: {
                'tab-find': {
                    templateUrl: 'templates/tab-find.html',
                    controller: "findCtrl"
                }
            },
        })

        .state('tab.setting', {
            url: '/setting',
            views: {
                'tab-setting': {
                    templateUrl: 'templates/tab-setting.html',
                    controller: "settingCtrl"
                }
            }
        });

    $urlRouterProvider.otherwise("/tab/wsbj");
});