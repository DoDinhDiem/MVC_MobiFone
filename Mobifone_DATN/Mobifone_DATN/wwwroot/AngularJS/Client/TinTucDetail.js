myApp.controller('TinTucDetailCtrl', function ($scope, $http, $location, $window, $sce) {

    var url = $location.absUrl();

    var id = getIdFromUrl(url);

    $http.get(`/TinTucById/${id}`)
        .then(function (response) {
            console.log(response)
            $scope.tinTuc = response.data;
        })
        .catch(function (error) {
            console.error('Error fetching TinTucById:', error);
        });

    function getIdFromUrl(url) {
        var parts = url.split('/');
        return parts[parts.length - 1];
    }

    $scope.trustAsHtml = function (html) {
        return $sce.trustAsHtml(html);
    };
})