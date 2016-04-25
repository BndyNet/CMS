(function() {
  app.directive('vNoData', function() {
    return {
      restrict: 'E',
      replace: true,
      scope: {
        content: '@'
      },
      template: "<div class=\"nodata-box text-warning\">\n    <div class=\"icon fa fa-warning\"></div>\n    <div class=\"msg\" ng-bind=\"content\"></div>\n</div>",
      compile: function(ele, attr) {
        if (attr.ngModel) {
          console.error('The ngModel is not required on vNoData');
        }
        if (ele.contents().context.innerHTML) {
          return ele.html(ele.contents().context.innerHTML);
        }
      }
    };
  });

  app.directive('vLoading', function() {
    return {
      scope: {
        loading: '=ngLoading',
        empty: '=ngNoData',
        emptyMsg: '@msgNoData'
      },
      restrict: 'E',
      replace: true,
      template: "<div class=\"box\" ng-class=\"{'box-info':loading, 'box-warning':!loading&&(empty==null||empty.length==0)}\" ng-show=\"loading||empty==null||empty.length==0\">\n    <div class=\"loading-box text-info\" ng-if=\"loading\" title=\"Loading...\"><i class=\"fa fa-spinner fa-spin\"></i></div>\n    <v-no-data content=\"{{emptyMsg}}\" ng-if=\"!loading && (empty == null || empty.length == 0)\"></v-no-data>\n</div>"
    };
  });

  app.directive('vPagination', function() {
    var templateHtml;
    templateHtml = "<div class=\"ng-pagination\" ng-show=\"Model.Data.length > 0\"> <div class=\"buttons\" ng-show=\"Model.PageCount > 1\"> <ul class=\"pagination pagination-sm\" ng-show=\"Model.PageCount > 1\"> <li ng-click=\"Paging(Model.CurrentPage - 1 <= 1 ? 1 : Model.CurrentPage - 1);\" ng-class=\"{\'disabled\' : Model.CurrentPage == 1}\"><a aria-label=\"Previous\"> <span aria-hidden=\"true\">&laquo;</span></a></li> <li ng-click=\"Paging(page);\" data-page=\"{{page}}\" ng-class=\"{\'active\': Model.CurrentPage == page, \'disabled\': page < 0}\" ng-repeat=\"page in Model.DisplayPageNumbers\"><a ng-show=\"page > 0\">{{page > 0 ? page : \"...\"}}</a><span ng-show=\"page < 0\">...</span></li> <li ng-click=\"Paging(Model.CurrentPage + 1 >= Model.PageCount ? Model.PageCount : Model.CurrentPage + 1);\"  ng-class=\"{\'disabled\' : Model.CurrentPage >= Model.PageCount}\"> <a aria-label=\"Next\"> <span aria-hidden=\"true\">&raquo;</span></a></li></ul> </div> <div class=\"summary\"> <span ng-show=\"!Model.PageCount || Model.PageCount == 1\">Total: {{Model.RecordCount}}</span> <span ng-show=\"Model.PageCount > 1\">View <span ng-bind=\"(Model.CurrentPage - 1) * Model.PageSize + 1\"></span> - <span ng-bind=\"Model.RecordCountOfCurrentPage\"></span> of <span ng-bind=\"Model.RecordCount\"></span></span> </div> <div class=\"clearfix\"></div> </div>";
    return {
      scope: {
        Model: '=ngModel',
        Paging: '=ngPage'
      },
      restrict: 'E',
      replace: true,
      template: templateHtml
    };
  });

}).call(this);
