/// <reference path="../../../../scripts/angular.min.js" />
/// <reference path="../../umbracoscheduler.logout.controller.js" />

app.controller('UmbracoScheduler.Logout', ['$scope', '$rootScope',
function ($scope) {
    $scope.childmethod = function () {
        //$rootScope.$emit("getname", {});
        alert("Hello");
    }
    }
]);


