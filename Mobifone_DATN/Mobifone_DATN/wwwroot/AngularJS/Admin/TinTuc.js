myApp.controller('TinTucCtrl', ['$scope', '$http', '$window', function ($scope, $http, $window) {

    function decodeJWT(token) {
        const base64Url = token.split('.')[1];
        const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        const jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
            return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        }).join(''));

        return JSON.parse(jsonPayload);
    }
    var token = localStorage.getItem('token');
    if (token) {

        var decodedToken = decodeJWT(token);
        var UserId = decodedToken.UserId;

        // Khai báo base URL cho API
        var baseUrl = "/Admin/TinTuc/";

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

        // Hàm tìm kiếm giới thiệu
        $scope.TaoMoi = function () {
            $scope.btnText = "Lưu";
            $scope.id = "";
            $scope.TieuDe = "";
            $scope.NoiDung = "";
            $scope.Image = "";
            document.getElementById('fileInput').value = null;
        }
        $scope.btnText = "Lưu";
        $scope.id = "";
        $scope.TieuDe = "";
        $scope.NoiDung = "";
        $scope.Image = ""
        $scope.NguoiViet = UserId;

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
        $scope.searchItem = function (Title, page, pageSize) {
            var url = baseUrl + "Search_TinTuc?title=" + Title + "&page=" + page + "&pageSize=" + pageSize;
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

        // Hàm tạo mới giới thiệu
        $scope.CreateUpdate = function () {

            if ($scope.Id) {
                var Data = {
                    Id: $scope.Id,
                    TieuDe: $scope.TieuDe,
                    NoiDung: $scope.NoiDung,
                    NguoiViet: $scope.NguoiViet,
                    Image: $scope.Image
                };
                var url = baseUrl + "Update_TinTuc";
                $http({
                    method: 'put',
                    headers: { "Authorization": 'Bearer ' + token },
                    url: url,
                    data: Data
                })
                    .then(function (response) {
                        if ($scope.isCreateClicked) {
                            $scope.uploadFile()
                        }
                        $scope.openSuccessAlert(response.data.message);
                        $scope.search();

                    })
                    .catch(function (error) {
                        $scope.openErrorAlert("Có lỗi xảy ra.");
                    });
            }
            else {
                var Data = {
                    TieuDe: $scope.TieuDe,
                    NoiDung: $scope.NoiDung,
                    NguoiViet: $scope.NguoiViet,
                    Image: $scope.Image
                };
                var url = baseUrl + "Creat_TinTuc";
                $http({
                    method: 'post',
                    headers: { "Authorization": 'Bearer ' + token },
                    url: url,
                    data: Data
                })
                    .then(function (response) {
                        if ($scope.isCreateClicked) {
                            $scope.uploadFile()
                        }
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
            var url = baseUrl + "GetById_TinTuc?id=" + id;
            $http({
                method: 'get',
                headers: { "Authorization": 'Bearer ' + token },
                url: url
            })
                .then(function (response) {
                    $scope.Id = response.data.id;
                    $scope.TieuDe = response.data.tieuDe;
                    $scope.NoiDung = response.data.noiDung;
                    $scope.LinkGoogleForm = response.data.linkGoogleForm
                    $scope.Image = response.data.image
                    $scope.btnText = "Cập nhập";

                })
                .catch(function (error) {
                    $scope.openErrorAlert("Có lỗi xảy ra.");
                });
        };

        // Hàm xóa giới thiệu theo ID
        $scope.deleteById = function (id) {
            if (confirm("Bạn có chắc chắn muốn xóa giới thiệu này không?")) {
                var url = baseUrl + "Delete_TinTuc?id=" + id;
                $http({
                    method: 'delete',
                    headers: { "Authorization": 'Bearer ' + token },
                    url: url
                })
                    .then(function (response) {
                        $scope.openSuccessAlert(response.data.message);
                        $scope.searchItem($scope.searchTitle, $scope.currentPage, $scope.pageSize);
                    })
                    .catch(function (error) {
                        $scope.openErrorAlert("Có lỗi xảy ra.");
                    });
            }
        };


        $scope.isCreateClicked = false;
        document.getElementById('fileInput').addEventListener('change', function (event) {

            var file = event.target.files[0];
            var currentDate = new Date();
            var formattedDate = currentDate.getFullYear() + '-' + (currentDate.getMonth() + 1) + '-' + currentDate.getDate();
            var formattedTime = currentDate.getHours() + '-' + currentDate.getMinutes() + '-' + currentDate.getSeconds();
            var fileExtension = file.type.split('/')[1]; // Lấy phần mở rộng của file
            var newName = 'Image_' + formattedDate + '_' + formattedTime + '.' + fileExtension; // Tạo tên mới với phần mở rộng của file

            var renamedFile = new File([file], newName, { type: file.type });

            $scope.imageFile = renamedFile;
            $scope.Image = newName;
            $scope.isCreateClicked = true;


        });

        $scope.uploadFile = function () {
            var formData = new FormData();
            formData.append('file', $scope.imageFile); // Sử dụng $scope.imageFile đã được gán từ sự kiện change

            var url = baseUrl + "Upload_Image";

            $http.post(url, formData, {
                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }
            }).then(function (response) {
                $scope.isCreateClicked = false;
            }).catch(function (error) {
                console.log('Lỗi khi tải lên tệp tin: ', error);
            });
        }

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
