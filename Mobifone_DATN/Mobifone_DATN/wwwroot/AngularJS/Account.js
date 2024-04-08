myApp.controller('MainController', function ($scope, $http, $window) {
    // Function to login admin
    $scope.loginAdmin = function () {
        var Data = {
            UserName: $scope.UserName,
            PassWord: $scope.PassWord
        }
        console.log(Data)
        $http.post('/LoginAdmin', Data)
            .then(function (response) {
                var token = response.data.accessToken;
                $window.localStorage.setItem('token',token);
                $window.location.href = '/Admin/DashBoard';
            })
            .catch(function (error) {
                console.log(error);
            });
    };
});