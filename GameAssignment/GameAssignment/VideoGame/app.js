var app = angular.module('videoGameApp', ['ngRoute']);
//// configure routes    
app.config(['$locationProvider', '$routeProvider', function ($locationProvider, $routeProvider) {
    debugger;
    $routeProvider.when('/', {
        templateUrl: 'VideoGame/Index.html',
        controller: 'GameController'  
    })
        .when('/EditData/:id', {  
    templateUrl: 'VideoGame/Views/EditDeletePage.html',  
    controller: 'GameController'  
        })
        .otherwise({  
            redirectTo: '/'  
});  
}]);