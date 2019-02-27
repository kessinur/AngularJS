var clubapp = angular.module("CRUDClubApp", ["ClubController", "ngRoute"]);

clubapp.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.
    when("/", {
        templateUrl: "/Partials/Club/ClubList.html",
        controller: "ClubMainController"
    }).
    when("/AddClub", {
        templateUrl: "/Partials/Club/AddClub.html",
        controller: "AddClubController"
    }).
    when("/EditClub/:id", {
        templateUrl: "/Partials/Club/EditClub.html",
        controller: "EditClubController"
    }).
    otherwise({ redirectTo: "/" });
}])
