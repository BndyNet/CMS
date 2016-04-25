(function() {
  app.filter('filterSpecialSymbol', function() {
    return function(input) {
      return input.replace(/\W+/g, '-');
    };
  });

  app.filter('toAppTime', [
    '$filter', function($filter) {
      return function(input) {
        return $filter('date')(input, 'MM/dd/yyyy h:mm a');
      };
    }
  ]);

}).call(this);
