angular.module('wechat.controllers', [])


.controller('wsbjCtrl', function ($scope, $state, $ionicPopup, $http) {
    $scope.onSwipeLeft = function() {
        $state.go("tab.friends");
    };

    $scope.title = "网上报建-业务列表";

    $scope.openForm = function (business) {
        $state.go("form", {
            "businessId": business.id
        });
    };

    $http({
        url: 'http://125.70.229.20/Test/wsbj.ashx',
        method: 'get'
        //data: $scope.Filters
        //params: {
        //    nid: $stateParams.nid
        //}
    }).success(function (result, status, header, config) {
        $scope.businesses = result;
    }).error(function () {
        alert('加载业务列表失败！');
    });

    //$scope.$on("$ionicView.beforeEnter", function(){
    //    $http.post("http://111.122.189.55:8888/DY/wsbj.ashx?action=Businesses").then(function (response) {
    //        $scope.businesses = response.data;//.businesses;
    //    });
    //});
})

.controller('formCtrl', ['$scope', '$stateParams', 'messageService', '$ionicScrollDelegate', '$timeout', '$http',
    function ($scope, $stateParams, messageService, $ionicScrollDelegate, $timeout, $http) {
        //var viewScroll = $ionicScrollDelegate.$getByHandle('messageDetailsScroll');




        $scope.doRefresh = function () {
            // console.log("ok");
            $scope.messageNum += 5;
            $timeout(function () {
                $scope.messageDetils = messageService.getAmountMessageById($scope.messageNum,
                    $stateParams.messageId);
                $scope.$broadcast('scroll.refreshComplete');
            }, 200);
        };

        $scope.$on("$ionicView.beforeEnter", function () {
            $http.get("http://125.70.229.20/Test/www/data/json/wsbj.json").then(function (response) {
                var businesses = response.data.businesses;
                var currBusinessId = $stateParams.businessId;
                for (var i = 0; i < businesses.length; i++)
                {
                    if(businesses[i].id == currBusinessId)
                    {
                        $scope.title = businesses[i].name;
                    }
                }
            });
        });

        //window.addEventListener("native.keyboardshow", function (e) {
        //    viewScroll.scrollBottom();
        //});
    }
])

.controller('assessmentsCtrl', function ($scope, $state) {
    $scope.onSwipeLeft = function () {
        $state.go("tab.find");
    };

    $scope.onSwipeRight = function () {
        $state.go("tab.wsbj");
    };

    $scope.title = "网上报建-办事指南";

    $scope.contacts_right_bar_swipe = function (e) {
        console.log(e);
    };
})

.controller('findCtrl', function ($scope, $state) {
    $scope.onSwipeLeft = function () {
        $state.go("tab.setting");
    };
    $scope.onSwipeRight = function () {
        $state.go("tab.assessments");
    };

    $scope.title = "网上报建-进度查询";

    $scope.ItemArr1 = [{ name: "abc" }, { name: "def" }];
    $scope.searchCont = {};//搜索内容  
    $scope.ItemArr2 = []; //搜索后页面遍历显示的数组  
    $scope.search = function () {
        $scope.ItemArr2 = []; //每次搜索先清空数组内容  
        var searchValue = document.getElementById('search').value;
        for (var i = 0; i < $scope.ItemArr1.length; i++) {
            if ($scope.ItemArr1[i].name == searchValue) {
                $scope.ItemArr2.push($scope.ItemArr1[i]); //如果有相同的字，加入数组。  
                //alert($scope.ItemArr1[i].name +" "+ searchValue);
            }
        }
        //if ($scope.ItemArr2 == '') {
        //    alert('未找到匹配的报建编号');
        //}
    }
})

.controller('settingCtrl', function($scope, $state) {
    $scope.onSwipeRight = function() {
        $state.go("tab.find");
    };

    $scope.title = "网上报建-个人信息";

})

