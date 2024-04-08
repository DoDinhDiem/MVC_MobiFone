myApp.controller('RoleCtrl', ['$scope', '$http', '$window', function ($scope, $http, $window) {

    var token = localStorage.getItem('token');
    if (token) {
        // Khai báo base URL cho API
        var baseUrl = "/Admin/Role/";

        // Hàm tìm kiếm quyền
        $scope.TaoMoi = function () {
            $scope.btnText = "Lưu";
            $scope.Id = "";
            $scope.TenRole = "";
        }

        $scope.btnText = "Lưu";
        $scope.Id = "";
        $scope.TenRole = "";

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
            $scope.searchRole($scope.searchTitle, $scope.currentPage, $scope.pageSize);
        };
        // Hàm searchRole được định nghĩa ở đoạn mã của bạn
        $scope.searchRole = function (title, page, pageSize) {
            var url = baseUrl + "Search_Role?title=" + title + "&page=" + page + "&pageSize=" + pageSize;
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
            console.log(Data)
            if ($scope.Id) {
                var Data = {
                    Id: $scope.Id,
                    TenRole: $scope.TenRole
                };
                var url = baseUrl + "Update_Role";
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
                    TenRole: $scope.TenRole
                };
                var url = baseUrl + "Creat_Role";
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



        // Hàm lấy thông tin quyền theo ID
        $scope.getById = function (id) {
            var url = baseUrl + "GetById_Role?id=" + id;
            $http({
                method: 'get',
                headers: { "Authorization": 'Bearer ' + token },
                url: url
            })
                .then(function (response) {
                    $scope.Id = response.data.id;
                    $scope.TenRole = response.data.tenRole;
                    $scope.btnText = "Cập nhập";
                })
                .catch(function (error) {
                    $scope.openErrorAlert("Có lỗi xảy ra.");
                });
        };

        // Hàm xóa quyền theo ID
        $scope.deleteById = function (id) {
            if (confirm("Bạn có chắc chắn muốn xóa quyền này không?")) {
                var url = baseUrl + "Delete_Role?id=" + id;
                $http({
                    method: 'delete',
                    headers: { "Authorization": 'Bearer ' + token },
                    url: url
                })
                    .then(function (response) {
                        $scope.openSuccessAlert(response.data.message);
                        $scope.searchRole($scope.searchTitle, $scope.currentPage, $scope.pageSize);
                    })
                    .catch(function (error) {
                        $scope.openErrorAlert("Có lỗi xảy ra.");
                    });
            }
        };
    } else {
        $window.location.href = '/Login';
    }

}]);
