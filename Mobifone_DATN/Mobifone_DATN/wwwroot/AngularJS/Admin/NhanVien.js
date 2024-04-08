myApp.controller('NhanVienCtrl', ['$scope', '$http', '$window', function ($scope, $http, $window) {

    var token = localStorage.getItem('token');
    if (token) {

        // Khai báo base URL cho API
        var baseUrl = "/Admin/NhanVien/";

        // Hàm tìm kiếm nhân viên
        $scope.TaoMoi = function () {
            $scope.btnText = "Lưu";
            $scope.Id = "";
            $scope.RoleId = "";
            $scope.UserName = "";
            $scope.Email = "";
            $scope.PassWord = "";
            $scope.HoTen = "";
            $scope.HoTen = "";
            $scope.GioiTinh = "";
            $scope.NgaySinh = "";
            $scope.DiaChi = "";
        }

        $scope.btnText = "Lưu";
        $scope.Id = "";
        $scope.RoleId = "";
        $scope.UserName = "";
        $scope.Email = "";
        $scope.PassWord = "";
        $scope.HoTen = "";
        $scope.HoTen = "";
        $scope.GioiTinh = "";
        $scope.NgaySinh = "";
        $scope.DiaChi = "";

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
            $scope.searchNhanVien($scope.searchTitle, $scope.currentPage, $scope.pageSize);
        };
        // Hàm searchNhanVien được định nghĩa ở đoạn mã của bạn
        $scope.searchNhanVien = function (title, page, pageSize) {
            var url = baseUrl + "Search_NhanVien?title=" + title + "&page=" + page + "&pageSize=" + pageSize;
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

        // Hàm tạo mới nhân viên
        $scope.CreateUpdate = function () {

            if ($scope.Id) {
                var Data = {
                    Id: $scope.Id,
                    RoleId: $scope.RoleId,
                    HoTen: $scope.HoTen,
                    GioiTinh: $scope.GioiTinh,
                    NgaySinh: $scope.NgaySinh,
                    DiaChi: $scope.DiaChi,
                };
                var url = baseUrl + "Update_NhanVien";
                $http({
                    method: 'put',
                    headers: { "Authorization": 'Bearer ' + token },
                    url: url,
                    data: Data
                })
                    .then(function (response) {
                        $scope.openSuccessAlert(response.data.message);
                        $scope.search();
                        $scope.TaoMoi();
                    })
                    .catch(function (error) {
                        $scope.openErrorAlert("Có lỗi xảy ra.");
                    });
            } else {
                var Data = {
                    RoleId: $scope.RoleId,
                    UserName: $scope.UserName,
                    Email: $scope.Email,
                    PassWord: $scope.PassWord,
                    HoTen: $scope.HoTen,
                    GioiTinh: $scope.GioiTinh,
                    NgaySinh: $scope.NgaySinh,
                    DiaChi: $scope.DiaChi,
                };
                console.log(Data)
                var url = baseUrl + "Creat_NhanVien";
                $http({
                    method: 'post',
                    headers: { "Authorization": 'Bearer ' + token },
                    url: url,
                    data: Data
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



        // Hàm lấy thông tin nhân viên theo ID
        $scope.getById = function (id) {
            var url = baseUrl + "GetById_NhanVien?id=" + id;
            $http({
                method: 'get',
                headers: { "Authorization": 'Bearer ' + token },
                url: url
            })
                .then(function (response) {
                    $scope.Id = response.data.id;
                    $scope.HoTen = response.data.hoTen;
                    $scope.GioiTinh = response.data.gioiTinh;
                    $scope.NgaySinh = response.data.ngaySinh;
                    $scope.DiaChi = response.data.diaChi;
                    $scope.RoleId = response.data.roleId;

                    $scope.btnText = "Cập nhập";
                })
                .catch(function (error) {
                    $scope.openErrorAlert("Có lỗi xảy ra.");
                });
        };

        // Hàm xóa nhân viên theo ID
        $scope.deleteById = function (id) {
            if (confirm("Bạn có chắc chắn muốn xóa nhân viên này không?")) {
                var url = baseUrl + "Delete_NhanVien?id=" + id;
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
                        $scope.openErrorAlert("Có lỗi xảy ra.");
                    });
            }
        };

        $scope.getAllRole = function () {
            var url = baseUrl + "GetAllRole";
            $http({
                method: 'get',
                headers: { "Authorization": 'Bearer ' + token },
                url: url
            })
                .then(function (response) {
                    $scope.listRole = response.data
                })
                .catch(function (error) {
                    $scope.openErrorAlert("Có lỗi xảy ra.");
                });
        }

        $scope.getAllRole()

    } else {
        $window.location.href = '/Login';
    }
}]);

myApp.directive('formatdate', function ($filter) {
    return {
        require: 'ngModel',
        link: function (scope, element, attrs, ngModelController) {
            ngModelController.$parsers.push(function (data) {
                // Chuyển đổi dữ liệu từ ngày tháng thành định dạng đúng
                return $filter('date')(data, "dd/MM/yyyy");
            });

            ngModelController.$formatters.push(function (data) {
                // Chuyển đổi dữ liệu từ định dạng đúng thành ngày tháng
                return $filter('date')(data, "yyyy-MM-dd");
            });
        }
    };
});

