var GLOBAL = GLOBAL || {};

GLOBAL.Search = GLOBAL.Search ||
{
    Search: function () {
        window.location.href = '/Search/' + $("#searchfield").val();
    },
    Init: function () {
        $("#searchbutton").on("click", function () {
            GLOBAL.Search.Search();
        });
    }
}


GLOBAL.Modals = GLOBAL.Modals ||
{
    ModalList: [{ ModalSelector: "#ticketDetailsModal", ModalActionMethod: "/Ticket/TicketModal" }],
    Init: function () {
        GLOBAL.Modals.ModalList.forEach(GLOBAL.Modals.ModalSetup);
    },
    ModalSetup: function (modal, index, array) {
        $(modal.ModalSelector).on('show.bs.modal', function (event) {

            var button = $(event.relatedTarget); // Button that triggered the modal
            var id = button.data('id');
            var modalWindow = $(this);
            var ajaxReplace = modalWindow.find('.modal-dialog');

            ajaxReplace.text(''); // Clear any older data

            $.ajax({
                url: modal.ModalActionMethod,
                type: 'GET',
                data: { id:id },
                success: function (partialView) {
                    ajaxReplace.html(partialView);
                },
                error: function() {
                    console.log('modal ajax error');
                }
            });
        });
    }
}
