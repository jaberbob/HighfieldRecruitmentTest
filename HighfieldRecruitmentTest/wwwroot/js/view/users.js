$(function () {
    Users.createTable();
});

/**
 * Users related methods
 */
var Users = {

    /**
     * Get and create data table of users (Ajax)
     */
    createTable: function () {
        $("#users-list").DataTable({
            ajax: {
                url: "/api/Users",
                dataSrc: ""
            },
            columnDefs: [{
                defaultContent: "-",
                targets: "_all"
            }],
            columns: [
                {
                    title: "ID",
                    data: "id"
                },
                {
                    title: "First Name",
                    data: "firstName"
                },
                {
                    title: "Last Name",
                    data: "lastName"
                },
                {
                    title: "Email",
                    data: "email"
                },
                {
                    title: "DOB",
                    data: "dob", render: DataTable.render.datetime('DD/MM/YYYY')
                },
                {
                    title: "Favourite Colour",
                    data: "favouriteColour"
                }
            ]
        });
    }
}
