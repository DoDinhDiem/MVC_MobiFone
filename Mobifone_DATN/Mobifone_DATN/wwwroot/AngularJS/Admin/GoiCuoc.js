myApp.controller('GoiCuocCtrl', ['$scope', '$http', '$window', function ($scope, $http, $window) {

    var token = localStorage.getItem('token');
    if (token) {

        // Khai báo base URL cho API
        var baseUrl = "/Admin/GoiCuoc/";

        // Hàm tìm kiếm gói cước
        $scope.TaoMoi = function () {
            $scope.btnText = "Lưu";
            $scope.Id = "";
            $scope.MaGoi = "";
            $scope.ThongTinChinh = "";
            $scope.Data = "";
            $scope.GiaGoiCuoc = "";
            $scope.ThongTinGoiCuocs = []
        }

        $scope.btnText = "Lưu";
        $scope.Id = "";
        $scope.MaGoi = "";
        $scope.ThongTinChinh = "";
        $scope.Data = "";
        $scope.GiaGoiCuoc = "";
        $scope.ThongTinGoiCuocs = []

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

        $scope.search = function () {
            $scope.currentPage = 1;
            $scope.searchGoiCuoc($scope.searchTitle, $scope.currentPage, $scope.pageSize);
        };
        // Hàm searchGoiCuoc được định nghĩa ở đoạn mã của bạn
        $scope.searchGoiCuoc = function (title, page, pageSize) {
            var url = baseUrl + "Search_GoiCuoc?title=" + title + "&page=" + page + "&pageSize=" + pageSize;
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

        // Hàm tạo mới gói cước
        $scope.CreateUpdate = function () {
            if ($scope.Id) {
                var Data = {
                    Id: $scope.Id,
                    MaGoi: $scope.MaGoi,
                    ThongTinChinh: $scope.ThongTinChinh,
                    Data: $scope.Data,
                    GiaGoiCuoc: $scope.GiaGoiCuoc,
                    ThongTinGoiCuocs: $scope.ThongTinGoiCuocs,
                };
                var url = baseUrl + "Update_GoiCuoc";
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
                    MaGoi: $scope.MaGoi,
                    ThongTinChinh: $scope.ThongTinChinh,
                    Data: $scope.Data,
                    GiaGoiCuoc: $scope.GiaGoiCuoc,
                    ThongTinGoiCuocs: $scope.ThongTinGoiCuocs,
                };
                var url = baseUrl + "Creat_GoiCuoc";
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
                        console.log("Lỗi: " + error);
                    });
            }
        };



        // Hàm lấy thông tin gói cước theo ID
        $scope.getById = function (id) {
            var url = baseUrl + "GetById_GoiCuoc?id=" + id;
            $http({
                method: 'get',
                headers: { "Authorization": 'Bearer ' + token },
                url: url
            })
                .then(function (response) {
                    $scope.Id = response.data.id;
                    $scope.MaGoi = response.data.maGoi;
                    $scope.ThongTinChinh = response.data.thongTinChinh;
                    $scope.Data = response.data.data;
                    $scope.GiaGoiCuoc = response.data.giaGoiCuoc;
                    $scope.ThongTinGoiCuocs = response.data.listThongTin;
                    $scope.btnText = "Cập nhập";
                })
                .catch(function (error) {
                    $scope.openErrorAlert("Có lỗi xảy ra.");
                });
        };

        // Hàm xóa gói cước theo ID
        $scope.deleteById = function (id) {
            if (confirm("Bạn có chắc chắn muốn xóa gói cước này không?")) {
                var url = baseUrl + "Delete_GoiCuoc?id=" + id;
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

        $scope.addNewThongSo = function () {
            $scope.ThongTinGoiCuocs.push({});
        };

        $scope.removeThongSo = function (index) {
            $scope.ThongTinGoiCuocs.splice(index, 1);
        };


    } else {
        $window.location.href = '/Login';
    }
}]);
