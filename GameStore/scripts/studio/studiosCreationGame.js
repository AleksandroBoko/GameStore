﻿function getAllStudios(studiosResponse) {
    $.ajax({
        url: '/api/studio/studios',
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