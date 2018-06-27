(function () {

    'use strict';

    angular
        .module("umbraco")
        .controller("CheckboxTableController", CheckboxTableController);

    CheckboxTableController.$inject = ['$scope'];

    // this will become the main controller for both an editor connfig and the property editor
    function CheckboxTableController($scope) {

        // if this being used as a prevalue editor then create a full fake config 
        if (angular.equals($scope.model.config, {})) { // is there a better way to check ?
            $scope.model.config = {
                defaultCheckboxTable: {
                    columns: [''],
                    rows: [''],
                    cells: [[false]]
                },
                columnPermissions: 'addRemove',
                rowPermissions: 'addRemove'
            };
        }

        // v0.2.0 saved array data, whilst v0.3.0 saves an object - here we clear any legacy saved values to prevent errors
        if (angular.isArray($scope.model.value)) { $scope.model.value = null; }

        // ensure model.value exists
        $scope.model.value = $scope.model.value || $scope.model.config.defaultCheckboxTable;

        $scope.addColumn = function () {
            $scope.model.value.columns.push('');
            updateCells();
        };

        $scope.removeColumn = function (columnIndex) {
            if ($scope.model.value.columns.length > 1) {
                $scope.model.value.columns.splice(columnIndex, 1);
                updateCells();
            }
        };

        $scope.addRow = function () {
            $scope.model.value.rows.push('');
            updateCells();
        };

        $scope.removeRow = function (rowIndex) {
            if ($scope.model.value.rows.length > 1) {
                $scope.model.value.rows.splice(rowIndex, 1);
                updateCells();
            }
        };

        // ensure the multi-dimension cells array matches the rows & columns
        function updateCells() {

            var rowCount = $scope.model.value.rows.length;
            var columnCount = $scope.model.value.columns.length;
            var cells = new Array(rowCount);

            for (var rowCounter = 0; rowCounter < rowCount; rowCounter ++)
            {
                var checkboxes = $scope.model.value.cells[rowCounter] || new Array();

                while (checkboxes.length > columnCount) { checkboxes.pop(); }
                while (checkboxes.length < columnCount) { checkboxes.push(false); }

                cells[rowCounter] = checkboxes;
            }

            $scope.model.value.cells = cells;
        }
    }

})();
