function getAllProducers(producersResponse) {
    $.ajax({
        url: '/api/producer/getproducers',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            producersResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    })
}

