var manager = Sys.WebForms.PageRequestManager;

if (manager == null) {
    $(document).ready(setupValidations());
}
else {
    Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(setupValidations);
}



function setupValidations() {

    //validate pending
    validatePending();

    var $hidden = $("#CurrentValidationWrapper");
    if ($hidden == null) {
        throw "CurrentValidationWrapper hidden field is not initialized!";
        return;
    }

    //set focus
    var $focused = $("#CurrentFocusedElement");
    if ($focused == null) {
        throw "CurrentFocusedElement hidden field is not initialized!";
        return;
    }

    //using plain javascript because jquery has problems with focus
    var focusedElement = document.getElementById($focused.val());
    if (focusedElement != null) {
        if ($(focusedElement).parents(".validate").length > 0) {
            var $currentName = $($(focusedElement).parents(".validate")[0]).attr("name");
            var $currentID = $(focusedElement).attr("id");
            $hidden.val($currentName);
            $focused.val($currentID);
        }
        

        focusedElement.focus();
    }


    var $form = $('form');
    if ($form == null) {
        throw "There is no form element on the page";
        return;
    }

    $form.find("input:visible,select:visible,textarea:visible").each(function (index) {

        //for textboxes inside validation panels
        if ($(this).parents(".validate").length > 0) {
            var $currentName = $($(this).parents(".validate")[0]).attr("name");
            var $currentID = $(this).attr("id");
            $(this).focus(function () {
                var $toValidateID = $hidden.val();
                $hidden.val($currentName);
                $focused.val($currentID);
                //validate the last one
                if ($toValidateID != null && $toValidateID != "") {
                    __doPostBack($toValidateID, "RunValidation");
                }
            });
            $(this).keydown(function (event) {
                if (event.which == 9) {
                    var $nextID = $(nextOnTabIndex(this)).attr("id");
                    $focused.val($nextID);
                    __doPostBack($currentName, "RunValidation");
                }
            });
        }
        else {
            var $currentID = $(this).attr("id");
            $(this).focus(function () {
                var $toValidateID = $hidden.val();
                $hidden.val("");
                $focused.val($currentID);
                //validate the last one
                if ($toValidateID != null && $toValidateID != "") {
                    __doPostBack($toValidateID, "RunValidation");
                }
            });
        }


    });
}

/*
* Gets the element with tab index bigger than the passed element by 1
*/
function nextOnTabIndex(element) {
    var fields = $($('form')
                    .find('a[href], button, input, select, textarea')
                    .filter(':visible').filter(':enabled')
                    .toArray()
                    .sort(function (a, b) {
                        return ((a.tabIndex > 0) ? a.tabIndex : 1000) - ((b.tabIndex > 0) ? b.tabIndex : 1000);
                    }));


    return fields.eq((fields.index(element) + 1) % fields.length);
}

/*
* Gets the element with the smallest tab index
*/
function firstTabIndex(element) {
    var fields = $($('form')
                    .find('a[href], button, input, select, textarea')
                    .filter(':visible').filter(':enabled')
                    .toArray()
                    .sort(function (a, b) {
                        return ((a.tabIndex > 0) ? a.tabIndex : 1000) - ((b.tabIndex > 0) ? b.tabIndex : 1000);
                    }));


    return fields[0];
}

/*
* Makes a '|' separated concatenation of names of all validation wrappers inside of the form and adds it to the hidden
* field "PendingValidationWrappers" and initiates a postback to invoke the validation at the begining.
*/
function validateAllWrappers() {
    var $pendingList = $.makeArray([]);
    var $form = $("form");
    $form.find("input:visible,select:visible,textarea:visible").each(function (index) {
        if ($(this).parents(".validate").length > 0) {
            var $currentName = $($(this).parents(".validate")[0]).attr("name");
            $pendingList.push($currentName);
        }
    });

    var $pending = $("#PendingValidationWrappers");
    if ($pending != null) {
        $pending.val($pendingList.join('|'));
    }

    validatePending();
}

/*
* Runs validation on all validation wrappers in the peding list
*/
function validatePending() {
    var $pending = $("#PendingValidationWrappers");
    if ($pending == null) {
        throw "PendingValidationWrappers hidden field is not initialized!";
        return;
    }
    else if ($pending.val() != null && $pending.val() != "") {
        var $pendingElements = $.makeArray($pending.val().split('|'));
        if ($pendingElements.length > 0) {
            //get first and then remove it from array
            var $firstPending = $pendingElements[0];
            $pendingElements.splice(0, 1);
            $pending.val($pendingElements.join('|'));

            //run validation for first element
            __doPostBack($firstPending, "RunValidation");
        }
    }
}

function messagesOnPage() {
    return ($("div[class*='validate'][triggeredstate!='']").length);
}

function errorsOnPage() {
    return ($("div[class*='validate'][triggeredstate='jsError']").length);
}

function warningsOnPage() {
    return ($("div[class*='validate'][triggeredstate='jsWarning']").length);
}