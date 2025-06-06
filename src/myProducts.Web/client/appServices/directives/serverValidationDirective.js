﻿(function () {
    "use strict";

    /**
     * @param $scope
     * @param $http
     * @constructor
     */
    function ServerValidateDirective() {
        return {
            require: "ngModel",
            link: function (scope, ele, attrs, c) {
                scope.$watch("modelState", function () {
                    if (scope.modelState == null) return;

                    var modelStateKey = attrs.serverValidate || attrs.ngModel;
                    modelStateKey = modelStateKey.replace("$index", scope.$index);

                    if (scope.modelState[modelStateKey]) {
                        c.$setValidity("server", false);
                        c.$error.server = scope.modelState[modelStateKey];
                    } else {
                        c.$setValidity("server", true);
                    }
                });
            }
        };
    };

    app.module.directive("serverValidate", ServerValidateDirective);
})();
