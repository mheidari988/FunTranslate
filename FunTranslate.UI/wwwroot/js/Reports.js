$(document).ready(function () {
    $("#reportsTable").DataTable({
        ajax: {
            url: 'https://localhost:7177/api/translations',
            dataSrc: ''
        },
        columns: [
            { data: 'text' },
            { data: 'translation' },
            { data: 'translated' }
        ]
    });
});