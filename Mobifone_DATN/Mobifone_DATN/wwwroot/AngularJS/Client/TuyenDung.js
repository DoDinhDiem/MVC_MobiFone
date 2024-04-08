myApp.controller('TuyenDungCtrl', function ($scope, $http, $window, $sce) {
    $scope.searchResults = [];
    $scope.totalPages = 0;
    $scope.currentPage = 1;
    $scope.pageSize = 2;

    $scope.search = function () {
        $http.get('/GetTuyenDung', {
            params: {
                page: $scope.currentPage,
                pageSize: $scope.pageSize
            }
        }).then(function (response) {
            console.log(response)
            $scope.searchResults = response.data.items.result;
            $scope.totalPages = response.data.totalPages;
            $scope.currentPage = response.data.pageNumber;
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
