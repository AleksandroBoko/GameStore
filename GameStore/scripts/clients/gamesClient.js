function getAllGames(gamesResponse) {
    $.ajax({
        url: '/api/game',
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

function getGamesByGenreId(GenreGamesResponse, genreId) {
    $.ajax({
        url: '/api/game/' + genreId,
        type: 'GET',
        dataType: 'json',

        success: function (data) {
            GenreGamesResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    })
}