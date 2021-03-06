﻿function getAllStudios(studiosResponse) {
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
        url: '/api/studio/with-games',
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
        url: '/api/studio/with-ratings',
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