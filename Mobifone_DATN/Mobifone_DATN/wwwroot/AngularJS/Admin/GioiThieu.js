myApp.controller('GioiThieuCtrl', ['$scope', '$http', '$window', function ($scope, $http, $window) {

    var token = localStorage.getItem("token");

    if (token) {
        // Khai báo base URL cho API
        var baseUrl = "/Admin/GioiThieu/";

        // Hàm tìm kiếm giới thiệu
        $scope.TaoMoi = function () {
            $scope.btnText = "Lưu";
            $scope.Id = "";
            $scope.Title = "";
            $scope.NoiDung = "";
        }

        $scope.btnText = "Lưu";
        $scope.Id = "";
        $scope.Title = "";
        $scope.NoiDung = "";

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
            $scope.searchGioiThieu($scope.searchTitle, $scope.currentPage, $scope.pageSize);
        };
        // Hàm searchGioiThieu được định nghĩa ở đoạn mã của bạn
        $scope.searchGioiThieu = function (title, page, pageSize) {
            var url = baseUrl + "Search_GioiThieu?title=" + title + "&page=" + page + "&pageSize=" + pageSize;
            $http({
                method: 'GET',
                headers: { "Authorization": 'Bearer ' + token },
                url: url
            }).then(function (response) {

                    $scope.gioiThieuList = response.data.items.result;
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
               $scope.search()
            }
        };
       $scope.search()

        // Hàm tạo mới giới thiệu
        $scope.CreateUpdate = function () {
            console.log(gioiThieuData)
            if ($scope.Id) {
                var gioiThieuData = {
                    Id: $scope.Id,
                    Title: $scope.Title,
                    NoiDung: $scope.NoiDung
                };
                var url = baseUrl + "Update_GioiThieu";
                $http({
                    method: 'put',
                    headers: { "Authorization": 'Bearer ' + token },
                    url: url,
                    data: gioiThieuData
                }).then(function (response) {
                        $scope.openSuccessAlert(response.data.message);
                        $scope.search()
                        $scope.TaoMoi();
                    })
                    .catch(function (error) {
                        $scope.openErrorAlert("Có lỗi xảy ra.");
                    });
            } else {
                var gioiThieuData = {
                    Title: $scope.Title,
                    NoiDung: $scope.NoiDung
                };
                var url = baseUrl + "Creat_GioiThieu";
                $http({
                    method: 'post',
                    headers: { "Authorization": 'Bearer ' + token },
                    url: url,
                    data: gioiThieuData
                }).then(function (response) {
                    $scope.openSuccessAlert(response.data.message);
                        $scope.search()
                        $scope.TaoMoi();
                    })
                    .catch(function (error) {
                        $scope.openErrorAlert("Có lỗi xảy ra.");
                    });
            }
        };



        // Hàm lấy thông tin giới thiệu theo ID
        $scope.getGioiThieuById = function (id) {
            var url = baseUrl + "GetById_GioiThieu?id=" + id;
            $http({
                method: 'get',
                headers: { "Authorization": 'Bearer ' + token },
                url: url
            }).then(function (response) {
                    $scope.Id = response.data.id;
                    $scope.Title = response.data.title;
                    $scope.NoiDung = response.data.noiDung;
                    $scope.btnText = "Cập nhập";
                })
                .catch(function (error) {
                    $scope.openErrorAlert("Có lỗi xảy ra.");
                });
        };

        // Hàm xóa giới thiệu theo ID
        $scope.deleteGioiThieuById = function (id) {
            if (confirm("Bạn có chắc chắn muốn xóa giới thiệu này không?")) {
                var url = baseUrl + "Delete_GioiThieu?id=" + id;
                $http({
                    method: 'delete',
                    headers: { "Authorization": 'Bearer ' + token },
                    url: url
                })
                    .then(function (response) {
                        $scope.openSuccessAlert(response.data.message);
                        $scope.search()
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
myApp.directive('quillEditor', function ($timeout) {
    return {
        restrict: 'E',
        template: '<div></div>',
        require: 'ngModel',
        link: function (scope, element, attrs, ngModel) {
            $timeout(function () {
                var quill = new Quill(element[0], {
                    theme: 'snow'
                });

                quill.on('text-change', function (delta, oldDelta, source) {
                    if (source === 'user') {
                        scope.$apply(function () {
                            ngModel.$setViewValue(quill.root.innerHTML);
                        });
                    }
                });

                ngModel.$render = function () {
                    var htmlContent = ngModel.$viewValue || '';
                    quill.root.innerHTML = htmlContent;
                };
            });
        }
    };
});
