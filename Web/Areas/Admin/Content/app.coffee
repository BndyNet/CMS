$(->
)

@app = angular.module('app', ['ngRoute'])
.run(['$rootScope', '$location', '$http', ($rootScope, $location, $http) ->
    $rootScope.$on("$locationChangeStart", (event, next, current) ->
        $rootScope.title = ''
        $rootScope.subtitle  = ''
        $('.sidebar-menu').find('a').each((idx, item)->
            $(item).parent().removeClass('active')
            u = $(item).attr('href')
            if(next.substring(next.indexOf(u)) == u)
                $(item).parent().addClass('active')
            )
    )
])

app.factory('appHttpInterceptor', [
    '$q', '$location'
    ($q, $location) ->
        'responseError': (rejection) ->
            if rejection and rejection.status is 401
                $location.path('/login') 
            $q.reject(rejection)
])

app.config(['$routeProvider', '$locationProvider', '$httpProvider', 
    ($routeProvider, $locationProvider, $httpProvider) ->
        routes = [
            '/login':
                templateUrl: '/ng/templates/login.html'
                controller: 'LoginCtrl'
        ]
        for item in routes
            for key, value of item
                $routeProvider.when key, value

        $routeProvider.otherwise( redirectTo: '/dashboard')
        
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        }).hashPrefix('!')

        $httpProvider.interceptors.push('appHttpInterceptor');
])
