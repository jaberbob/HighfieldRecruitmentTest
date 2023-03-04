$(function () {
    $.get("/api/testResponse", function (data) {
        TopColours.createTable(data.topColours);
        Ages.createTable(data.ages, data.users);
    });
});

/**
 * Favourite colours related methods
 */
var TopColours = {

    /**
     * Create data table of favourite colours
     * @param {TopColoursDto} data - TopColoursDto
     */
    createTable: function (data) {
        $("#index-fav-colours").DataTable({
            data: data,
            columnDefs: [{
                defaultContent: "-",
                targets: "_all"
            }],
            columns: [
                {
                    title: "Colour",
                    data: "colour"
                },
                {
                    title: "Count",
                    data: "count"
                }
            ],
            ordering: false,
            searching: false,
            info: false
        });
    }
}

/**
 * Ages related methods
 */
var Ages = {

    /**
     * Create data table of ages plus twenty years
     * @param {AgePlusTwentyDto} data - AgePlusTwentyDto
     */
    createTable: function (data, users) {
        $("#index-ageplus20").DataTable({
            data: data,
            columnDefs: [{
                defaultContent: "-",
                targets: "_all"
            }],
            columns: [
                {
                    title: "User",
                    data: null,
                    render: function (data) {
                        return Ages.getUserName(users, data.userId)
                    }
                },
                {
                    title: "Age Plus Twenty",
                    data: "agePlusTwenty"
                }
            ],
            searching: false,
            info: false
        });
    },

    /**
     * Generate 'User' column value by looking up user Id
     * @param {UserEntity[]} users - UserEntity
     * @param {string} id - User ID
     */
    getUserName: function (users, id) {
        let user = users.find(o => o.id === id);
        return `${user.firstName} ${user.lastName} (${id})`;
    }
}