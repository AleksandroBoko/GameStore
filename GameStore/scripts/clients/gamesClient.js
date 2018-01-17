function getAllGames(gamesResponse) {
        $.ajax({
            url: '/api/main/games',
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                gamesResponse(data);
            },
            error: function (x, y, z) {
                alert(x + '\n' + y + '\n' + z);
            }
        })
    }