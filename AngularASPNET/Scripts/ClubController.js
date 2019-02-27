angular.module("ClubController", []).
controller("ClubMainController", function ($scope, ClubService) {
    $scope.message = "Main Controller";

    ClubService.GetClubsfromDB().then(function (x) {
        $scope.listClubs = x.data.list;
    })

    $scope.DeleteClub = function (id, $index) {
        $scope.listClubs.splice($index, 1);
        ClubService.DeleteClub(id);
    }
}).
    controller("AddClubController", function ($scope, ClubService) {
        $scope.message = "Add Club Details";

        $scope.AddClub = function () {
            ClubService.AddClub($scope.club);
        }
    }).
    controller("EditClubController", function ($scope, ClubService, $routeParams) {
        $scope.message = "Update Club Details";

        var id = $routeParams.id;

        ClubService.GetClubById(id).then(function (x) {
            $scope.club = x.data.club;
        })

        $scope.UpdateClub = function () {
            ClubService.UpdateClub($scope.club);
        }
    }).
factory("ClubService", ["$http", function ($http) {

    var fac = {};

    fac.GetClubsfromDB = function () {
        return $http.get("/Club/GetClubs");
    }

    fac.GetClubById = function (id) {
        return $http.get("/Club/GetClubById", { params: { id: id } });
    }

    fac.AddClub = function (club) {
        $http.post("/Club/AddClub", club).success(function (response) {
            alert(response.status);
        })
    }

    fac.UpdateClub = function (club) {
        $http.post("/Club/UpdateClub", club).success(function (response) {
            alert(response.status);
        })
    }

    fac.DeleteClub = function (id) {
        $http.post("/Club/DeleteClub", { id: id }).success(function (response) {
            alert(response.status);
        })
    }

    return fac;
}])