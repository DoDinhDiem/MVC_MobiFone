myApp.controller('TinTucCtrl', function ($scope, $http, $window, $sce) {
    $scope.searchResults = [];
    $scope.totalPages = 0;
    $scope.currentPage = 1;
    $scope.pageSize = 6;

    $scope.search = function () {
        $http.get('/TinTuc/GetTinTuc', {
            params: {
                page: $scope.currentPage,
                pageSize: $scope.pageSize
            }
        }).then(function (response) {
            angular.forEach(response.data.items, function (item) {
                if (item.tieuDe && item.noiDung) {
                    var title = item.tieuDe;
                    var content = item.noiDung;

                    var totalLength = title.length + content.length;
                    var maxLength = 280;

                    if (totalLength > maxLength) {
                        var titleLength = Math.floor(title.length * maxLength / totalLength);
                        var contentLength = maxLength - titleLength;
                        item.noiDung = content.substring(0, contentLength) + "...";
                    }
                }
            });
            $scope.searchResults = response.data.items;
            $scope.totalPages = response.data.totalPages;
            $scope.currentPage = response.data.pageNumber;
            console.log($scope.searchResults);

        }).catch(function (error) {
            console.error('Error searching for sim so:', error);
        });
    };

    $scope.getPages = function () {
        return new Array($scope.totalPages).fill().map((_, index) => index + 1);
    };

    // Hàm cập nhật trang hiện tại
    $scope.setCurrentPage = function (page) {
        if (page >= 1 && page <= $scope.totalPages) {
            $scope.currentPage = page;
            $scope.searchSimSo(); // Gọi lại API khi chuyển trang
        }
    };
    $scope.trustAsHtml = function (html) {
        return $sce.trustAsHtml(html);
    };
    $scope.search();
});