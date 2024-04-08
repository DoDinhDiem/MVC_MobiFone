myApp.controller('SimSoCtrl', function ($scope, $http, $window) {
    $scope.searchResults = [];
    $scope.totalPages = 0;
    $scope.currentPage = 1;
    $scope.pageSize = 10;
    $scope.searchText = '';

    $scope.searchSimSo = function () {
        $http.get('/Search_SimSo', {
            params: {
                title: $scope.searchText,
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

    $scope.selectSimSo = function (simSo) {
        // Lưu đối tượng simSo vào local storage
        localStorage.setItem('selectedSimSo', JSON.stringify(simSo));

        // Chuyển hướng sang trang ThanhToan
        $window.location.href = '/ThanhToan'; // Đổi đường dẫn nếu cần thiết
    };

    $scope.checkInput = function (event) {
        var charCode = event.keyCode;
        if (charCode < 48 || charCode > 57) {
            event.preventDefault();
        }
    };
    // Gọi hàm searchSimSo khi trang được tải
    $scope.searchSimSo();
});
