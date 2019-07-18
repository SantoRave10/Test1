/// <reference path="../../scripts/angular.min.js" />


angular.module("umbraco")
    .controller("UmbracoScheduler.Logout",
    function($scope, $http) {
        $http.get('/umbraco/backoffice/Scheduler/UmbracoScheduler/GetLoggedInUsers')
            .then(function(response) {
                $scope.Name = response.data.Name;
                $scope.IsAdmin = response.data.IsAdmin;
                $scope.Role = response.data.Role;

                alert("Name: " + response.data.Name);
                alert("IsAdmin: " + response.data.IsAdmin);
                alert("IsAdmin: " + response.data.Role);

            }).catch(function(response) {
                console.error('Error occurred:', response.status, response.data);
            }).finally(function() {
                console.log("Task Finished.");
            });
});

