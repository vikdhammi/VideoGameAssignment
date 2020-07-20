app.controller('GameController', function ($scope, gameService) {

    $scope.createVM = {}
    $scope.updateVM = {}
    $scope.showAlert = false;

    $scope.loadTableData = function () {
        gameService.serviceCall("GET", "", "").then(function (response) {
            if (response.data.length < 1) {
                $scope.showAlert = true;
                $scope.alertName = "Note!"
                $scope.alertMessage = "These Is No Record To Show."
            }
            $scope.videoGameData = response.data;
        });
    }

    $scope.addVideoGame = function (isValid) {
        if (isValid) {
            $scope.addVideoGameForm.$setPristine();
            gameService.serviceCall("POST", "", $scope.createVM).then(function (response) {
                $scope.showAlert = true;
                $scope.alertName = "Success!"
                $scope.alertMessage = "Video Game Is Created Successfully."
                $scope.createVM = {};
                $scope.loadTableData();
            });
        }
    }

    $scope.openUpdateVideoGameModal = function (Id) {
        gameService.serviceCall("GET", Id, "").then(function (response) {
            $scope.updateVM = response.data;
        });
    }

    $scope.updateVideoGame = function (Id) {

        gameService.serviceCall("PUT", Id, $scope.updateVM).then(function (response) {
            $scope.showAlert = true;
            $scope.alertName = "Success!"
            $scope.alertMessage = "Video Game Is Updated Successfully."
            $scope.loadTableData();
        });

    }

    $scope.openDeleteVideoGameModal = function (Id) {
        $scope.gameIdToDelete = Id;
    }

    $scope.deleteVideoGame = function (Id) {
        gameService.serviceCall("Delete", Id, "").then(function (response) {
            $scope.showAlert = true;
            $scope.alertName = "Success!"
            $scope.alertMessage = "Video Game Is Deleted Successfully."
            $scope.loadTableData();
        });
    }

    $scope.loadTableData();

})
app.service('gameService', ['$http', function ($http) {
    return {
        serviceCall: function (method, parameter, data) {
            return $http({
                method: method,
                url: 'http://localhost:50430/api/default/' + parameter,
                data: data
            });
        }
    };
}]);

