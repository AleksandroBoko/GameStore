function getAllGenres(genresResponse) {
    $.ajax({
        url: '/api/genre/getgenres',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            genresResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    })
}

function getGamesByGenreId(GenreGamesResponse, genreId) {
    $.ajax({
        url: '/api/genre/genregames/' + genreId,
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

