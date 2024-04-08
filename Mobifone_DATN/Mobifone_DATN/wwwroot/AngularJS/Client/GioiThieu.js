myApp.controller('GioiThieuCtrl', function ($scope, $http, $sce) {

    $scope.GioiThieu = function () {
        $http.get('/GetGioiThieu')
            .then(function (response) {
                console.log(response);
            $scope.GioiThieuList = response.data;
    

        }).catch(function (error) {
            console.error('Error searching for sim so:', error);
        });
    };

    $scope.trustAsHtml = function (html) {
        return $sce.trustAsHtml(html);
    };

    $scope.GioiThieu();
})
