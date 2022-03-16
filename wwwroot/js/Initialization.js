function GetConfigValue(configKey) {
    return $.ajax({
        url: "https://localhost:44363/Home/" + configKey,
        method: "GET"
    }).then(function (val) {
        return val;
    }).fail(function (err) {
        alert("Error : " + err);
    });
}