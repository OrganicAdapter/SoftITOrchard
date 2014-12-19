var taskEditor = angular.module('taskEditor', []);

taskEditor.controller('taskEditorController', function ($scope) {
    $scope.isSubtask;

    $scope.init = function (initValues) {
        $scope.isSubtask = initValues.parent == '' ? false : true;
    }
});