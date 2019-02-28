angular.module("CrudDemoApp.controllers",[]).
controller("MainController", function($scope, PlayerService){
    $scope.message = "Main Controller";

    PlayerService.GetPlayersfromDB().then(function (x)
    {
        $scope.listPlayers = x.data.list;
    })

    $scope.DeletePlayer = function(id, $index)
    {
        $scope.listPlayers.splice($index, 1);
        PlayerService.DeletePlayer(id);
    }
}).
    controller("AddPlayerController", function ($scope, PlayerService) {
        $scope.message = "Add Player Details"; 

        PlayerService.GetClubsfromDB().then(function (x) {
            $scope.listClubs = x.data.list;
        })

        $scope.AddPlayer = function ()
        {
            PlayerService.AddPlayer($scope.playerParam);
        }
    }).
    controller("EditPlayerController", function ($scope, PlayerService, $routeParams) {
        $scope.message = "Update Player Details";

        var id = $routeParams.id;

        PlayerService.GetPlayerById(id).then(function (x)
        {
            $scope.playerParam = x.data.player;
        })

        PlayerService.GetClubsfromDB().then(function (x) {
            $scope.listClubs = x.data.list;
        })

        $scope.EditPlayer = function()
        {
            console.log($scope.playerParam);
            PlayerService.EditPlayer($scope.playerParam);
        }
    }).
factory("PlayerService", ["$http", function ($http) {
    
    var fac = {};

    fac.GetPlayersfromDB = function ()
    {
        return $http.get("/Player/GetPlayers");
    }

    fac.GetClubsfromDB = function () {
        return $http.get("/Club/GetClubs");
    }

    fac.GetPlayerById = function (id) {
        return $http.get("/Player/GetPlayerById", { params: {id : id}});
    }

    fac.AddPlayer = function (playerParam) {
        $http.post("/Player/AddPlayer", playerParam).success(function (response){
            alert(response.status);
        })
    }

    fac.EditPlayer = function (playerParam) {
        $http.post("/Player/EditPlayer", playerParam).success(function (response) {
            alert(response.status);
        })
    }

    fac.DeletePlayer = function (id) {
        $http.post("/Player/DeletePlayer", {id : id}).success(function (response) {
            alert(response.status);
        })
    }

    return fac;
}])