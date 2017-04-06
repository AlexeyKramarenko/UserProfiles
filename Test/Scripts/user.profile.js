
var UserProfile = (function () {

    function refreshProfiles() {
        var ageSelect = $('#AgeSelect option:selected').text();
        var city = $('#CitySelect option:selected').text();

        var sortByAgeAsc = 0;
        if (!ageSelect || ageSelect === 'Спочатку молодші')
            sortByAgeAsc = 1;

        if (!city)
            city = "all";

        $.ajax({
            url: '/user/GetSortedUserProfileList/' + sortByAgeAsc + "/" + city,
            type: 'GET',
            dataType: 'json',
            success: function (data) {

                var content = "";

                $.map(data.profilesVM, function (item, i) {

                    content += "<tr>" +
                                    "<td>" + item.Name + "</td>" +
                                    "<td>" + item.City + "</td>" +
                                    "<td>" + item.Age + "</td>" +
                               "</tr>";
                });
                $("table tbody").html(content);
            },
            error: function (a, b, c) {
                console.log("error:" + a.statusText);
            }
        });
    }
    return {
        refreshProfiles: refreshProfiles
    }
})();