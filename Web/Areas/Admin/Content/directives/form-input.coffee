app.directive 'formInput', [
     ->
        template:"""
        <div class="form-group form-group-sm">
            <label ng-bind="ngLabel?ngLabel:label"></label>
            <sup ng-if="isRequired">*</sup>
            <span class="pull-right" ng-bind="ngDes?ngDes:des"></span>
            <input name="{{ngName?ngName:name}}" type="text" class="form-control"/>
        </div>
        """
        replace: true
        transclude: true
        restrict: 'E'
        scope: 
            label: '@'
            name: '@'
            required: '@'
            pattern: '@'
            des: '@'
            
            ngLabel: '='
            ngName: '='
            ngRequired: '='
            ngPattern: '='
            ngDes: '='
            
        link: (scope, ele, attrs) ->
            scope.isRequired = scope.ngRequired or scope.required
            ele.attr('data-required', true) if scope.isRequired
            
            if scope.ngPattern or scope.pattern
                regPattern = if scope.ngPattern then scope.ngPattern else scope.pattern
                ele.attr('data-pattern', regPattern)
                
            input = ele.find('input')
            input.attr('placeholder', attrs.placeholder) if attrs.placeholder
]