myApp.controller('HomeCtrl', function ($scope, $http, $sce) {
    $scope.List = [];
    $scope.listSlide = []; 
    $scope.getSlides = function () {
        try {
            $http.get('/GetSlide')
                .then(function (response) {
                    console.log(response.data);
                    $scope.listSlide = response.data;
                })
                .catch(function (error) {
                    console.error('Error:', error);
                });
        } catch (error) {
            console.error('Error in getSlides:', error);
        }
    };

    $scope.getTinTuc = function () {
        $http.get('/GetTinTuc')
            .then(function (response) {
                angular.forEach(response.data, function (item) {
                    if (item.tieuDe && item.noiDung) {
                        var title = item.tieuDe;
                        var content = item.noiDung;

                        var totalLength = title.length + content.length;
                        var maxLength = 120;

                        if (totalLength > maxLength) {
                            var titleLength = Math.floor(title.length * maxLength / totalLength);
                            var contentLength = maxLength - titleLength;
                            item.noiDung = content.substring(0, contentLength) + "...";
;
                        }
                    }
                });
                $scope.List = response.data;
            })
            .catch(function (error) {
                console.error('Error fetching tin tuc:', error);
            });
    };
    $scope.trustAsHtml = function (html) {
        return $sce.trustAsHtml(html);
    };

   

    $scope.getTinTuc();
    $scope.getSlides();
});