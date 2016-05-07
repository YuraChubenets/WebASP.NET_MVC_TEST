app.controller("mvcCRUDController", ["$scope", "crudAJService", function ($scope, crudAJService) {

    $scope.divPeople = false;
    getAllPeoples();

    function getAllPeoples() {
        
        var getData = crudAJService.getPeoples();
        
         getData.then(function (people) {
             $scope.peoples = people.data;

        }, function () {
            alert("Error in getting");
        });
    }

    $scope.CheckNickName = function () {

  
        var checkPeople = crudAJService.getPeople($scope.peopleNickName);

        checkPeople.then(function (msg) {
      
            $scope.Color = (msg.data.Id > 0) ? 'lightcoral' : 'lightgreen';
           
            $scope.divPeople = true;

        }, function () {
            alert("Error in getting");
        });
    };

    $scope.AddPeople = function () {
        var People = {
            Name: $scope.peopleName,
            NickName: $scope.peopleNickName
        }
     
        var getData = crudAJService.AddPeople(People);

        getData.then(function (msg) {          
            getAllPeoples();            
            $scope.allowClass(msg.data);
            $scope.divPeople = false;
        }, function () {             
            alert("Error in getting");
        });

    };
    
    $scope.AddPeopleDiv = function () {
        ClearFields();
        $scope.divPeople = true;
    };

   
    $scope.allowClass = function (someValue) {
        $scope.result = someValue;
        debugger;
        $scope.IsValid = (someValue === "Invalid People") ? true : false;
        debugger;
    };
   
   

    function ClearFields() {
        $scope.result = "";
        $scope.Color = "";
        $scope.peopleName = "";
        $scope.peopleNickName = "";

        $scope.Cancel = function () {
            $scope.divPeople = false;

        }
    }
}]);
