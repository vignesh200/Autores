var app = angular.module('myApp', []);
$(".txtchange").change(function () {
    $("button").removeAttr("disabled");
})
app.controller('customersCtrl', function ($scope, $http) {
    $scope.legalother = "";
    $scope.legal = "";
    $scope.county = "";
    $scope.attachments = "";
    $scope.names = ["LegalRejetion", "CountyRejection", "AttachmentRejection"]
    $scope.boxclears = [$scope.clear1, $scope.clear2, $scope.clear3];
    $scope.rejectList = [$scope.legal, $scope.county, $scope.attachments];
    $scope.txtchanges=function(value)
    {
        if (value != "") {
            $("#rejectsubmit").removeAttr("disabled");
        }
        else if(value=="") {
            $("#rejectsubmit").attr("disabled", "disabled");
        }
    }
    $scope.canSubmit = function () {
        //alert(($scope.rejectList + $scope.rejectList + $scope.rejectList) == "");
       // alert(($("input[name='LegalRejetion']").val() + $("input[name='CountyRejection']").val() + $("input[name='AttachmentRejection']").val()) == "");
      
        if (($scope.rejectList[0] + $scope.rejectList[1] + $scope.rejectList[2]) == "") {
            $("#rejectsubmit").attr("disabled", "disabled");
        } else {
            $("#rejectsubmit").removeAttr("disabled");
        }
    }
        $scope.allClear = function (no) {
        $scope.rejectList[no] = "";
        $scope.boxclears[no] = "";
        $scope.canSubmit();
    }

    $scope.setting = function (no, value) {
        if (value == "" || value == null || value == undefined) {
            return;

        }
        var str = $scope.rejectList[no];
        if (str.indexOf(value) >= 0) {
            $scope.rejectList[no] = str.replace(value + "^", "");
   
        }
        else {
            $scope.rejectList[no] = $scope.rejectList[no] + value + "^"
      
        }
     
        $scope.canSubmit();
    }

    $scope.isShow = function (a, b) {

        if (b) {
            if (a) {
                return true;
            }
        }
        else {
            return false;
        }
    }

    $http.get("/grid/rejectiondata")
    .success(function (response) {
        $scope.rejectHeads = response.metadata;
        $scope.rejectReasons = response.data;
        //alert($scope.rejectReasons[1]);
    });
});
