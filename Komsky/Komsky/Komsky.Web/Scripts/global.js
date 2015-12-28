var GLOBAL = GLOBAL || {};

GLOBAL.Search = GLOBAL.Search ||
{
    Search: function() {
        window.location.href = '/Search/' + $("#searchfield").val();
    },
    Init: function() {
        $("#searchbutton").on("click", function() {
            GLOBAL.Search.Search();
        });
    }
}