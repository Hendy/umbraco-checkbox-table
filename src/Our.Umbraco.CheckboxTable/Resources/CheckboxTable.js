(function () {

    'use strict';

    angular
        .module("umbraco")
        .controller("CheckboxTableController", CheckboxTableController);

    CheckboxTableController.$inject = ['$scope'];

    function CheckboxTableController($scope) {

        $scope.setActiveRowColumn = function (rowIndex, columnIndex) {
            $scope.activeRow = rowIndex;
            $scope.activeColumn = columnIndex;
        }

        $scope.clearActiveRowColumn = function () {
            $scope.activeRow = -1;
            $scope.activeColumn = -1;
        }

        var columnCount = parseInt($scope.model.config.columns) + 1;
        var rowCount = parseInt($scope.model.config.rows) + 1;

        $scope.clearActiveRowColumn();

        $scope.model.value = buildTableData(rowCount, columnCount, $scope.model.value);
    }

    function buildTableData(rowCount, columnCount, modelValue) {
            
        var tableData = new Array(rowCount); // first index in array is y axis (html rendering tr)

        for (var rowCounter = 0; rowCounter < rowCount; rowCounter ++)
        {
            tableData[rowCounter] = new Array(columnCount); // second index is x axis (html rendering td)

            for (var columnCounter = 0; columnCounter < columnCount; columnCounter++)
            {
                if (angular.isArray(modelValue) && rowCounter < modelValue.length && columnCounter < modelValue[0].length) {                    
                    tableData[rowCounter][columnCounter] = modelValue[rowCounter][columnCounter]; // restore saved value
                } else if (rowCounter == 0 || columnCounter == 0)  {                    
                    tableData[rowCounter][columnCounter] = ""; // new header label or row label  
                } else {                    
                    tableData[rowCounter][columnCounter] = false; // new checkbox cell
                }
            }
        }

        return tableData;
    }
   

})();
