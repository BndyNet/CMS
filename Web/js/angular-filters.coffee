app.filter 'filterSpecialSymbol', ->
    (input) ->
        input.replace /\W+/g, '-'
app.filter 'toAppTime', ['$filter',
    ($filter) ->
        (input) ->
            return $filter('date')(input, 'MM/dd/yyyy h:mm a')
    ]