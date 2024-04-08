myApp.controller('DashBoardCtrl', ['$scope', '$http', '$window', function ($scope, $http, $window) {

    var token = localStorage.getItem('token');
    if (token) {
        // Khai báo base URL cho API
        var baseUrl = "/Admin/DashBoard/";

      
        $scope.CountDonHang = function () {
            var url = baseUrl + "CountDonHang";
            $http({
                method: 'get',
                headers: { "Authorization": 'Bearer ' + token },
                url: url
            })
                .then(function (response) {
                    $scope.CountDonHang = response.data;
                })
                .catch(function (error) {
                    console.log("Lỗi: " + error);
                });
        };
        $scope.CountDonHang()
        $scope.CountDoanhThu = function () {
            var url = baseUrl + "CountDoanhThu";
            $http({
                method: 'get',
                headers: { "Authorization": 'Bearer ' + token },
                url: url
            })
                .then(function (response) {
                    $scope.CountDoanhThu = response.data;
                })
                .catch(function (error) {
                    console.log("Lỗi: " + error);
                });
        };
        $scope.CountDoanhThu()

        $scope.CountTinTuc = function () {
            var url = baseUrl + "CountTinTuc";
            $http({
                method: 'get',
                headers: { "Authorization": 'Bearer ' + token },
                url: url
            })
                .then(function (response) {
                    $scope.CountTinTuc = response.data;
                })
                .catch(function (error) {
                    console.log("Lỗi: " + error);
                });
        };
        $scope.CountTinTuc()

        $scope.CountNhanVien = function () {
            var url = baseUrl + "CountNhanVien";
            $http({
                method: 'get',
                headers: { "Authorization": 'Bearer ' + token },
                url: url
            })
                .then(function (response) {
                    $scope.CountNhanVien = response.data;
                })
                .catch(function (error) {
                    console.log("Lỗi: " + error);
                });
        };
        $scope.CountNhanVien()
        


        $scope.year = new Date().getFullYear(); // Lấy năm hiện tại
        $scope.chartLabels = [];
        $scope.chartData = [];

        $scope.getThongKeTheoThang = function () {
            var url = baseUrl + 'ThongKeTheoThang/' + $scope.year
            $http({
                method: 'get',
                headers: { "Authorization": 'Bearer ' + token },
                url: url
            }).then(function (response) {
                    if (response.data && response.data.thongKeThang) {
                        $scope.thongKeThang = response.data.thongKeThang;
                        $scope.tongTienNam = response.data.tongTienNam;
                        console.log($scope.thongKeThang)

                        // Xử lý dữ liệu để đổ vào biểu đồ
                        $scope.chartLabels = [];
                        $scope.chartData = [];
                        angular.forEach($scope.thongKeThang, function (item) {
                            $scope.chartLabels.push('Tháng ' + item.thang);
                          
                            $scope.chartData.push(item.tongTien);
                        });
                        console.log($scope.chartLabels)

                        // Vẽ biểu đồ
                        $scope.drawChart();
                    } else {
                        console.error('Dữ liệu trả về từ yêu cầu API không hợp lệ:', response.data);
                    }
                })
                .catch(function (error) {
                    console.error('Lỗi khi gửi yêu cầu API:', error);
                });
        };

        $scope.drawChart = function () {
            // Kiểm tra xem có biểu đồ nào đang được sử dụng trên canvas không
            if ($scope.myChart) {
                // Nếu có, hủy biểu đồ hiện tại
                $scope.myChart.destroy();
            }

            var ctx = document.getElementById('myChart').getContext('2d');
            $scope.myChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: $scope.chartLabels,
                    datasets: [{
                        label: 'Tổng tiền theo tháng của năm ' + $scope.year,
                        data: $scope.chartData,
                        backgroundColor: 'rgba(75, 192, 192, 0.2)',
                        borderColor: 'rgba(75, 192, 192, 1)',
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true,
                                stepSize: 100,
                            }
                        }]
                    }
                }
            });
        };



        // Gọi hàm thống kê khi trang được tải lần đầu
        $scope.getThongKeTheoThang();

  

    } else {
        $window.location.href = '/Login';
    }

}]);
