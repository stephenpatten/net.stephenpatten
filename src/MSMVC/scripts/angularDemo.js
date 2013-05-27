TodoCtrl.$inject = ['$scope'];
function TodoCtrl($scope) {
    $scope.todos = [
      { text: 'learn angular', done: true },
      { text: 'build an angular app', done: false }];

    $scope.addTodo = function () {
        $scope.todos.push({ text: $scope.todoText, done: false });
        $scope.todoText = '';
    };

    $scope.remaining = function () {
        var count = 0;
        angular.forEach($scope.todos, function (todo) {
            count += todo.done ? 0 : 1;
        });
        return count;
    };

    $scope.archive = function () {
        var oldTodos = $scope.todos;
        $scope.todos = [];
        angular.forEach(oldTodos, function (todo) {
            if (!todo.done) $scope.todos.push(todo);
        });
    };
}

flickerCtrl.$inject = ['$scope', '$resource'];
function flickerCtrl($scope, $resource) {
    $scope.userId = 'googlebuzz';
    $scope.Activity = $resource(
     'https://www.googleapis.com/buzz/v1/activities/:userId/:visibility/:activityId/:comments',
     { alt: 'json', callback: 'JSON_CALLBACK' },
     {
         get: { method: 'JSONP', params: { visibility: '@self' } },
         replies: { method: 'JSONP', params: { visibility: '@self', comments: '@comments' } }
     });

    $scope.fetch = function() {
        $scope.activities = $scope.Activity.get({ userId: this.userId });
    };

    $scope.expandReplies = function(activity) {
        activity.replies = $scope.Activity.replies({ userId: this.userId, activityId: activity.id });
    };
};