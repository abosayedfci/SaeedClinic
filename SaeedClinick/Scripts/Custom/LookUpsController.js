App.controller('LookUpsController', ["$http", "$scope", "treeViewService", function ($http, $scope, treeViewService) {
    $scope.Visit = {
        Labs: [],
        Treatments: [],
        Us: []
    };
    $scope.Visit.VisitNum = document.getElementById("VisitNum").value;
    $scope.Visit.PatientID = document.getElementById("PatientID").value
    $scope.Visit.Date = new Date();
   

    $http({
        method: 'GET',
        url: '/Labs/getLookupList'
    }).then(function successCallback(response) {
    $scope.Labs = response.data.LabsList;
    $scope.test = { "totalCount": $scope.Labs.length, "data": $scope.Labs, "success": true }.data;
    var USSS = response.data.USList
    $scope.USSS = { "totalCount": response.data.USList.length, "data": response.data.USList, "success": true }.data;
    var treatments = response.data.TreatmentList
    $scope.treatments = { "totalCount": response.data.TreatmentList.length, "data": response.data.TreatmentList, "success": true }.data;
}, function errorCallback(response) {
        alert("error");
    })

   
    $scope.pushToLeft = function (State) {
        if ($scope.NewLab != null && $scope.NewLab != "" && State==1)
        {

            $http({
                method: 'GET',
                url: '/Labs/newLab?NewlabTitle=' + $scope.NewLab
            }).then(function successCallback(response) {
                $scope.Labs = response.data.LabsList;

                if (response.data != null) {
                    var LabList = response.data.LabsList;
                    var itemToPush = {
                        LabTitle: $scope.NewLab,
                        Id: LabList[LabList.length - 1].Id
                    };
                    $scope.test = { "totalCount": response.data.LabsList.length, "data": response.data.LabsList, "success": true }.data;
                    // $scope.test.unshift(itemToPush);
                    treeViewService.applyChanges($scope.test, $scope.NewLab, itemToPush);
                }
            },
                function errorCallback(error) {
                    alert("error");
                }
                );
        }
        else if ($scope.NewTreatment != null && $scope.NewTreatment != "" && State == 2)
        {

            $http.post('/Labs/NewTreatment/' + $scope.NewTreatment).then(successCallback, errorCallback);

        function successCallback(response) {
            if (response.data != null) {
                var TreatmentList = response.data.TreatmentList;
                var itemToPush = {
                    TreatmentTitle: $scope.NewTreatment,
                    Id: TreatmentList[TreatmentList.length - 1].Id
                };
                $scope.treatments = { "totalCount": response.data.TreatmentList.length, "data": response.data.TreatmentList, "success": true }.data;
               // $scope.treatments.unshift(itemToPush);
                treeViewService.applyChanges($scope.treatments, $scope.NewTreatment, itemToPush);
            }
        }
        function errorCallback(error) {
            alert("error");
        }
        }
        else if ($scope.NewUS != null && $scope.NewUS != "" && State == 3)
        {
            $http.get('/Labs/NewUS?NewUSTitle=' + $scope.NewUS).then(successCallback, errorCallback);

            function successCallback(response) {
                if (response.data != null) {
                    var USList = response.data.USList;
                    var itemToPush = {
                        UsTitle: $scope.NewUS,
                        Id: USList[USList.length - 1].Id
                    };
                    $scope.USSS = { "totalCount": response.data.USList.length, "data": response.data.USList, "success": true }.data;
                    treeViewService.applyChanges($scope.USSS, $scope.NewUS, itemToPush);
                }
            }
            function errorCallback(error) {
                alert("error");
            }
        }
       
      
       
    };
    $scope.SubmitForm= function(Visit)
    {
        $http({
            method: 'post',
            url: '/Visits/CreateNew',
            data : $scope.Visit
        }).then(function (success) {
            alert("success")
        }, function (error) {
            alert("error")
        });
    }

  
  
}]);