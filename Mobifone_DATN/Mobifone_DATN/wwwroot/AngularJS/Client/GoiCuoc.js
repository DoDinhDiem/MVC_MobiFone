myApp.controller('GoiCuocCtrl', function ($scope, $http, $window) {
    $scope.searchResults = [];
    $scope.totalPages = 0;
    $scope.currentPage = 1;
    $scope.pageSize = 6;

    $scope.searchSimSo = function () {
        $http.get('/GetGoiCuoc', {
            params: {
                page: $scope.currentPage,
                pageSize: $scope.pageSize
            }
        }).then(function (response) {
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
    $scope.searchSimSo();
});