myApp.controller('ThanhToanCtrl', function ($scope, $http, $window, $location) {

    $scope.Reset = function () {
        $scope.HoTen = "";
        $scope.SoDienThoai = "";
        $scope.DiaChi = "";
        $scope.GhiChu = "";
    }

    $scope.TrangThaiDonHang = "Chờ xác nhận";
    $scope.PhuongThucThanhToan = "Thanh toán khi nhận hàng"
    $scope.createHoaDon = function () {
        var hoaDonLocal = $window.localStorage.getItem('selectedSimSo');

        if (!hoaDonLocal) {
            console.error('Không tìm thấy dữ liệu hóa đơn trong local storage.');
            return;
        }

        try {
            var hoaDonData = JSON.parse(hoaDonLocal);

            var hoaDonXuat = {
                HoTen: $scope.HoTen,
                SoDienThoai: $scope.SoDienThoai,
                DiaChi: $scope.DiaChi,
                GhiChu: $scope.GhiChu,
                TrangThaiDonHang: $scope.TrangThaiDonHang,
                PhuongThucThanhToan: $scope.PhuongThucThanhToan,
                ChiTietHoaDons: [{
                    SimSoId: hoaDonData.id,
                    GiaBan: hoaDonData.giaBan
                }]
            };

            var url = "/Create_HoaDonXuat";

            // Gửi yêu cầu POST đến server để tạo hóa đơn xuất
            $http.post(url, hoaDonXuat)
                .then(function (response) {
                    alert('Đặt hàng thành công!');
                    $scope.Reset()
                    $window.localStorage.removeItem('selectedSimSo');
                    $window.location.href = '/'
                })
                .catch(function (error) {
                    alert('Đã xảy ra lỗi khi đặt hàng: ' + error.data.message);
                });
        } catch (error) {
            console.error('Đã xảy ra lỗi khi xử lý dữ liệu từ local storage.', error);
            alert('Đã xảy ra lỗi khi xử lý dữ liệu từ local storage.');
        }
    };

    $scope.init = function () {
        var selectedSimSo = $window.localStorage.getItem('selectedSimSo');
        console.log($scope.selectedSimSo)

        if (selectedSimSo) {
            $scope.selectedSimSo = JSON.parse(selectedSimSo);

        } else {
            console.error('Không tìm thấy đối tượng SIM số trong local storage.');
        }
    };

    $scope.checkInput = function (event) {
        var charCode = event.keyCode;
        if (charCode < 48 || charCode > 57) {
            event.preventDefault();
        }
    };

    $scope.checkLength = function () {
        $scope.isValid = $scope.SoDienThoai && $scope.SoDienThoai.length === 10;
    };

    $scope.init();
});
