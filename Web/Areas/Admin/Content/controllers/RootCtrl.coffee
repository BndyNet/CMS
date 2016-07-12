app.controller('RootCtrl', [
    '$scope', '$http'
    ($scope, $http) ->
        $scope.settings = settings
        $scope.nav = (menu, parents) ->
            $scope.currentMenus = []
            $scope.currentMenus.push item for item in arguments
        $scope.nav($scope.settings.menus[0])
])