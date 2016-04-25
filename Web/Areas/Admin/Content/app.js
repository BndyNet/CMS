(function() {
  $(function() {});

  this.app = angular.module('app', ['ngRoute']).run([
    '$rootScope', '$location', '$http', function($rootScope, $location, $http) {
      return $rootScope.$on("$locationChangeStart", function(event, next, current) {
        $rootScope.title = '';
        $rootScope.subtitle = '';
        return $('.sidebar-menu').find('a').each(function(idx, item) {
          var u;
          $(item).parent().removeClass('active');
          u = $(item).attr('href');
          if (next.substring(next.indexOf(u)) === u) {
            return $(item).parent().addClass('active');
          }
        });
      });
    }
  ]);

  app.factory('appHttpInterceptor', [
    '$q', '$location', function($q, $location) {
      return {
        'responseError': function(rejection) {
          if (rejection && rejection.status === 401) {
            $location.path('/login');
          }
          return $q.reject(rejection);
        }
      };
    }
  ]);

  app.config([
    '$routeProvider', '$locationProvider', '$httpProvider', function($routeProvider, $locationProvider, $httpProvider) {
      var item, key, routes, value, _i, _len;
      routes = [
        {
          '/login': {
            templateUrl: '/ng/templates/login.html',
            controller: 'LoginCtrl'
          }
        }
      ];
      for (_i = 0, _len = routes.length; _i < _len; _i++) {
        item = routes[_i];
        for (key in item) {
          value = item[key];
          $routeProvider.when(key, value);
        }
      }
      $routeProvider.otherwise({
        redirectTo: '/dashboard'
      });
      $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
      }).hashPrefix('!');
      return $httpProvider.interceptors.push('appHttpInterceptor');
    }
  ]);

  app.controller('RootCtrl', [
    '$scope', '$http', function($scope, $http) {
      $scope.settings = settings;
      $scope.nav = function(menu, parents) {
        var item, _i, _len, _results;
        $scope.currentMenus = [];
        _results = [];
        for (_i = 0, _len = arguments.length; _i < _len; _i++) {
          item = arguments[_i];
          _results.push($scope.currentMenus.push(item));
        }
        return _results;
      };
      return $scope.nav($scope.settings.menus[0]);
    }
  ]);

}).call(this);
