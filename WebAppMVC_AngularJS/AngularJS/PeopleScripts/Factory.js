app.service("crudAJService", function ($http) {

    //get people
    this.getPeoples = function () {
        return $http.get("People/getAllPeoples")
    };


    //get people by nickName
    this.getPeople = function (nickName) {
        var response = $http({
            method: "post",
            url: "People/getPeopleByNickName",
            params: {
                nickName
            }
        });
        return response;
    }

    //add people
    this.AddPeople = function (people) {
        var response = $http({
            method: "post",
            url: "People/AddPeople",
            data: JSON.stringify(people),
            dataType: "json"
        });
        return response;
    }
});

