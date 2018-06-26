(function () {

    'use strict';

    angular
        .module("umbraco")
        .controller("CheckboxTableController", CheckboxTableController);

    CheckboxTableController.$inject = ['$scope'];

    // this will become the main controller for both an editor connfig and the property editor
    function CheckboxTableController($scope) {

   
        // if this being used as the prevalue editor, create fake config
        if (angular.equals($scope.model.config, {})) {
            console.log('in config mode');

            $scope.model.config = {
                defaultCheckboxTable: {
                    columns: [],
                    rows: [],
                    cells: []
                },
                columnPermissions: 'addRemove',
                rowPermissions: 'addRemove'
            };
        }

        // v0.2.0 saved array data, whilst v0.3.0 saves an object - here we clear any legacy saved values to prevent errors
        if (angular.isArray($scope.model.value)) { $scope.model.value = null; }

        $scope.model.value = $scope.model.value || $scope.model.config.defaultCheckboxTable;

        // watch the columns collection and rows collection, and on change, update cells (so we can sort cols in future)
        $scope.$watch('model.value.columns', function (newColumns, oldColumns) {
        }, true); // NOTE: bug in Angular $watchCollection, doesn't return the old value correctly, so using deep $watch instead

        $scope.$watch('model.value.rows', function (newRows, oldRows) { 
        }, true); // NOTE: bug in Angular $watchCollection, doesn't return the old value correctly, so using deep $watch instead

        $scope.addColumn = function () {
            $scope.model.value.columns.push('');
        };

        $scope.removeColumn = function (columnIndex) {
            $scope.model.value.columns.splice(columnIndex, 1);
        };

        $scope.addRow = function () {
            $scope.model.value.rows.push('');
        };

        $scope.removeRow = function (rowIndex) {
            $scope.model.value.rows.splice(rowIndex, 1);
        };
    }

})();
