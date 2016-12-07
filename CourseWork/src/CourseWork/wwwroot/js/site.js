$(document).ready(function () {

    // Support posting to server when clicking to link
    $("a.cw-post-link").click(function () {

        // Wrap click on button in jQuery object.
        var $btn = $(this);

        // Get data-confirm-text attribute value.
        var confirmText = $btn.data("confirm-text");

        // Present user with a choice.
        if (confirm(confirmText)) {

            // Submit form inside link element.
            var $frmRemoveStudent = $(this).children("form");
            $frmRemoveStudent.submit();
        }
    });
});