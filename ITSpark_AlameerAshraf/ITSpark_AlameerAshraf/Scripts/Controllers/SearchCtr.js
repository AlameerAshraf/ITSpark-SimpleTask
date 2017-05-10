angular.module('myApp', []).controller('searchctr', function ($scope, $http) {
    $scope.singleSelect = null; 
    $http.get("http://localhost:58207/Students/StudentsJson")
       .then(function (response) {
            console.log("as");
            $scope.StudentsJson = response.data;
            angular.forEach($scope.StudentsJson, function (value, index) {
                var date = new Date(value.DateOfBirth.match(/\d+/)[0] * 1);
                var new_alignment = date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear();
                value.DateOfBirth = new_alignment;
            });
           
        });
    $scope.filterParam = function (key, value) {
        param = {};
        param[key] = value;
        return param;
    };
   console.log($scope.singleSelect);
});