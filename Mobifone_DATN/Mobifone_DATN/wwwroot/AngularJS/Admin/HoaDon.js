myApp.controller('HoaDonCtrl', ['$scope', '$http', '$window', function ($scope, $http, $window) {

    var token = localStorage.getItem('token');
    if (token) {

        // Khai báo base URL cho API
        var baseUrl = "/Admin/HoaDon/";


        $scope.btnText = "Lưu";

        $scope.searchTitle = "";
        $scope.currentPage = 1;
        $scope.pageSize = 10;
        $scope.totalItems = 0;
        $scope.totalPages = 0;

        // Khởi tạo biến cho thông báo thành công và lỗi
        $scope.showSuccessAlert = false;
        $scope.showErrorAlert = false;
        $scope.successMessage = "";
        $scope.errorMessage = "";
        $scope.openSuccessAlert = function (message) {
            $scope.successMessage = message;
            $scope.showSuccessAlert = true;
            setTimeout(function () {
                $scope.$apply(function () {
                    $scope.closeSuccessAlert();
                });
            }, 3000);
        };

        $scope.openErrorAlert = function (message) {
            $scope.errorMessage = message;
            $scope.showErrorAlert = true;
            setTimeout(function () {
                $scope.$apply(function () {
                    $scope.closeErrorAlert();
                });
            }, 3000);
        };

        $scope.closeSuccessAlert = function () {
            $scope.showSuccessAlert = false;
            $scope.successMessage = "";
        };

        $scope.closeErrorAlert = function () {
            $scope.showErrorAlert = false;
            $scope.errorMessage = "";
        };

        // Hàm thực hiện tìm kiếm khi người dùng nhấn nút "Tìm kiếm"
        $scope.search = function () {
            $scope.currentPage = 1;
            $scope.searchHoaDon($scope.searchTitle, $scope.currentPage, $scope.pageSize);
        };
        // Hàm searchHoaDon được định nghĩa ở đoạn mã của bạn
        $scope.searchHoaDon = function (title, page, pageSize) {
            var url = baseUrl + "Search_HoaDon?title=" + title + "&page=" + page + "&pageSize=" + pageSize;
            $http({
                method: 'get',
                headers: { "Authorization": 'Bearer ' + token },
                url: url
            })
                .then(function (response) {
                    $scope.List = response.data.items.result;
                    $scope.totalItems = response.data.totalItems;
                    $scope.totalPages = response.data.totalPages;
                    $scope.pagesArray = [];
                    for (var i = 1; i <= $scope.totalPages; i++) {
                        $scope.pagesArray.push(i);
                    }
                })
                .catch(function (error) {
                    console.log("Lỗi: " + error);
                });
        };

        // Hàm chuyển đến trang được chọn
        $scope.setPage = function (page) {
            if (page >= 1 && page <= $scope.totalPages) {
                $scope.currentPage = page;
                $scope.search();
            }
        };
        $scope.search();

        // Hàm tạo mới quyền
        $scope.CreateUpdate = function () {
            if ($scope.Id) {
                var Data = {
                    Id: $scope.Id,
                    TrangThaiDonHang: $scope.TrangThaiDonHang
                };
                var url = baseUrl + "Update_HoaDon";
                $http({
                    method: 'put',
                    headers: { "Authorization": 'Bearer ' + token },
                    url: url,
                    data: Data
                }).then(function (response) {
                        $scope.openSuccessAlert(response.data.message);
                        $scope.search();
                }).catch(function (error) {
                        $scope.openErrorAlert("Có lỗi xảy ra.");
                    });
            }
        };



        // Hàm lấy thông tin quyền theo ID
        $scope.getById = function (id) {
            var url = baseUrl + "GetById_HoaDon/" + id;
            $http({
                method: 'get',
                headers: { "Authorization": 'Bearer ' + token },
                url: url
            })
                .then(function (response) {
                    $scope.Id = response.data.id;
                    $scope.TrangThaiDonHang = response.data.trangThaiDonHang;
                    $scope.btnText = "Cập nhập";
                })
                .catch(function (error) {
                    { }
                    $scope.openErrorAlert("Có lỗi xảy ra.");
                });
        };

        $scope.Print = function (id) {
            var url = baseUrl + "GetById_HoaDon/" + id;
            $http({
                method: 'get',
                headers: { "Authorization": 'Bearer ' + token },
                url: url
            })
                .then(function (response) {
                    $scope.printBill = response.data;
                })
                .catch(function (error) {
                    $scope.openErrorAlert("Có lỗi xảy ra.");
                });
        };

    } else {
        $window.location.href = '/Login';
    }
}]);
