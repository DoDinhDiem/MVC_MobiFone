myApp.controller('SinSoCtrl', ['$scope', '$http', function ($scope, $http) {

    var token = localStorage.getItem('token');
    if (token) {

        // Khai báo base URL cho API
        var baseUrl = "/Admin/SimSo/";

        // Hàm tìm kiếm giới thiệu
        $scope.TaoMoi = function () {
            $scope.btnText = "Lưu";
            $scope.Id = "";
            $scope.SoThueBao = "";
            $scope.LoaiThueBao = "";
            $scope.LoaiSo = "";
            $scope.GiaBan = "";
            $scope.TrangThai = true;
        }

        $scope.btnText = "Lưu";
        $scope.Id = "";
        $scope.SoThueBao = "";
        $scope.LoaiThueBao = "";
        $scope.LoaiSo = "";
        $scope.GiaBan = 0;
        $scope.TrangThai = true;

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
            $scope.searchItem($scope.searchTitle, $scope.currentPage, $scope.pageSize);
        };
        // Hàm search được định nghĩa ở đoạn mã của bạn
        $scope.searchItem = function (title, page, pageSize) {
            var url = baseUrl + "Search_SimSo?title=" + title + "&page=" + page + "&pageSize=" + pageSize;
            $http({
                method: 'get',
                headers: { "Authorization": 'Bearer ' + token },
                url: url
            }).then(function (response) {
                    $scope.List = response.data.items.result;
                    $scope.totalItems = response.data.totalItems;
                    $scope.totalPages = response.data.totalPages;
                    $scope.pagesArray = [];
                    for (var i = 1; i <= $scope.totalPages; i++) {
                        $scope.pagesArray.push(i);
                    }
                })
                .catch(function (error) {
                    $scope.openErrorAlert("Có lỗi xảy ra.");
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

        // Hàm tạo mới giới thiệu
        $scope.CreateUpdate = function () {


            if ($scope.Id) {
                var data = {
                    Id: $scope.Id,
                    SoThueBao: $scope.SoThueBao,
                    LoaiThueBao: $scope.LoaiThueBao,
                    LoaiSo: $scope.LoaiSo,
                    GiaBan: $scope.GiaBan,
                    TrangThai: $scope.TrangThai,
                };
                console.log(data)
                var url = baseUrl + "Update_SimSo";
                $http({
                    method: 'post',
                    headers: { "Authorization": 'Bearer ' + token },
                    url: url,
                    data: data
                })
                    .then(function (response) {
                        $scope.openSuccessAlert(response.data.message);
                        $scope.search();
                        $scope.TaoMoi(); // Đặt lại trường dữ liệu
                    })
                    .catch(function (error) {
                        $scope.openErrorAlert("Có lỗi xảy ra.");
                    });
            } else {
                var data = {
                    SoThueBao: $scope.SoThueBao,
                    LoaiThueBao: $scope.LoaiThueBao,
                    LoaiSo: $scope.LoaiSo,
                    GiaBan: $scope.GiaBan,
                    TrangThai: $scope.TrangThai,
                };
                var url = baseUrl + "Creat_SimSo";
                $http({
                    method: 'post',
                    headers: { "Authorization": 'Bearer ' + token },
                    url: url,
                    data: data
                })
                    .then(function (response) {
                        $scope.openSuccessAlert(response.data.message);
                        $scope.search();
                        $scope.TaoMoi();
                    })
                    .catch(function (error) {
                        $scope.openErrorAlert("Có lỗi xảy ra.");
                    });
            }
        };

        // Hàm lấy thông tin giới thiệu theo ID
        $scope.getById = function (id) {
            var url = baseUrl + "GetById_SimSo?id=" + id;
            $http({
                method: 'get',
                headers: { "Authorization": 'Bearer ' + token },
                url: url
            })
                .then(function (response) {
                    $scope.Id = response.data.id;
                    $scope.SoThueBao = response.data.soThueBao,
                        $scope.LoaiThueBao = response.data.loaiThueBao,
                        $scope.LoaiSo = response.data.loaiSo,
                        $scope.GiaBan = response.data.giaBan,
                        $scope.TrangThai = response.data.trangThai,
                        $scope.btnText = "Cập nhập";
                })
                .catch(function (error) {
                    $scope.openErrorAlert("Có lỗi xảy ra.");
                });
        };

        // Hàm xóa giới thiệu theo ID
        $scope.deleteById = function (id) {
            if (confirm("Bạn có chắc chắn muốn xóa giới thiệu này không?")) {
                var url = baseUrl + "Delete_SimSo?id=" + id;
                $http({
                    method: 'delete',
                    headers: { "Authorization": 'Bearer ' + token },
                    url: url
                })
                    .then(function (response) {
                        $scope.openSuccessAlert(response.data.message);
                        $scope.search();
                    })
                    .catch(function (error) {
                        console.log("Lỗi: " + error);
                    });
            }
        };

        $scope.checkInput = function (event) {
            var charCode = event.keyCode;
            if (charCode < 48 || charCode > 57) {
                event.preventDefault();
            }
        };

        $scope.checkLength = function () {
            $scope.isValid = $scope.SoThueBao && $scope.SoThueBao.length === 10;
        };
        $scope.showMessage = false;
    } else {
        $window.location.href = '/Login';
    }

}]);

