myApp.controller('LienHeCtrl', function ($scope, $http, $sce) {

    $scope.LienHe = function () {
        $http.get('/GetLienHe')
            .then(function (response) {
                $scope.LienHeList = response.data;
                console.log(response);

            }).catch(function (error) {
                console.error('Error searching for sim so:', error);
            });
    };

    $scope.trustAsHtml = function (html) {
        return $sce.trustAsHtml(html);
    };

    $scope.LienHe();
})
