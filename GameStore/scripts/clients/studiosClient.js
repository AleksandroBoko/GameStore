function getAllStudios(studiosResponse) {
    $.ajax({
        url: '/api/studio/getstudios',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            studiosResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    })
}

function getStudiosGames(studiosResponse) {
    $.ajax({
        url: '/api/studio/withgames',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            studiosResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    })
}

function getStudiosRatings(studiosResponse) {
    $.ajax({
        url: '/api/studio/withratings',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            studiosResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    })
}