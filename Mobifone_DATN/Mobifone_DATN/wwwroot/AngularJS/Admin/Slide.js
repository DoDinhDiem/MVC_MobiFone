myApp.controller('SlideCtrl', ['$scope', '$http', '$window', function ($scope, $http, $window) {

    var token = localStorage.getItem('token');
    if (token) {

        // Khai báo base URL cho API
        var baseUrl = "/Admin/Slide/";

        // Hàm tìm kiếm slide
        $scope.TaoMoi = function () {
            $scope.btnText = "Lưu";
            var fileInput = document.getElementById('fileInput');
            var file = fileInput.files[0];
        }

        $scope.btnText = "Lưu";

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
            $scope.searchSlide($scope.currentPage, $scope.pageSize);
        };
        // Hàm searchSlide được định nghĩa ở đoạn mã của bạn
        $scope.searchSlide = function (page, pageSize) {
            var url = baseUrl + "Search_Slide?page=" + page + "&pageSize=" + pageSize;
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
        $scope.searchSlide($scope.currentPage, $scope.pageSize);

        // Hàm tạo mới slide
        $scope.CreateUpdate = function () {
            if ($scope.Id) {
                var Data = {
                    Id: $scope.Id,
                    Image: $scope.Image
                };
                var url = baseUrl + "Update_Slide";
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
                        $scope.TaoMoi();
                    })
                    .catch(function (error) {
                        $scope.openErrorAlert("Có lỗi xảy ra.");
                    });
            } else {
                var Data = {
                    Image: $scope.Image
                };
                var url = baseUrl + "Creat_Slide";
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



        // Hàm lấy thông tin slide theo ID
        $scope.getById = function (id) {
            var url = baseUrl + "GetById_Slide?id=" + id;
            $http({
                method: 'get',
                headers: { "Authorization": 'Bearer ' + token },
                url: url
            })
                .then(function (response) {
                    $scope.Id = response.data.id;
                    $scope.Image = response.data.image;
                    $scope.btnText = "Cập nhập";
                })
                .catch(function (error) {
                    $scope.openErrorAlert("Có lỗi xảy ra.");
                });
        };

        // Hàm xóa slide theo ID
        $scope.deleteById = function (id) {
            if (confirm("Bạn có chắc chắn muốn xóa slide này không?")) {
                var url = baseUrl + "Delete_Slide?id=" + id;
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
