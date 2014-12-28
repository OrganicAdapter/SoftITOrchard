var taskEditor = angular.module('taskEditor', []);

taskEditor.controller('taskEditorController', function ($scope) {
    $scope.isSubtask;

    $scope.init = function (isSubtask) {
        $scope.isSubtask = isSubtask;
    }
});