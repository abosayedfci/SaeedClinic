App.controller('VisitDetailsController', ["$http", "$scope", function ($http, $scope) {
    var  VisitId = document.getElementById("VisitId").value
    $http({
        method: 'GET',
        url: '/Visits/VisitDetails',
        data: VisitId
    }).then(function successCallback(response) {
        var USSS = response.data.USList
       
    }, function errorCallback(response) {
        alert("error");
    })

}]);