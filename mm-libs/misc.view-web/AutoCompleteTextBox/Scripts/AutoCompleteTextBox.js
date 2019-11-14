//initialize all AutoCompleteTextBoxes after DOM is fully loaded

$(document).ready(function () {
    initAutoCompleteTextBox();
});
function initAutoCompleteTextBox() {
    var $AutoCompleteTextBoxs = $("span[AutoCompleteTextBox]"); //get all AutoCompleteTextBoxes. AutoCompleteTextBox is defined with span element that has AutoCompleteTextBox attribute

    //init each AutoCompleteTextBox with empty filter
    $AutoCompleteTextBoxs.each(function (i, obj) { AutoCompleteTextBox_InitListData($(obj), ""); });

    //Set TextBox attribute and add keydown and keyup event handler for AutoCompleteTextBox textbox
    $AutoCompleteTextBoxs.find(":text")
        .data("currentitem", -1) //current selected item is -1
        .attr("autocomplete", "off") //turn off auto complete
        .on("keydown", function (e) { //set keydown event handler
            AutoCompleteTextBox_KeySelectItem(e);
        })
        .on("keyup", function (e) { //set keyup event handler
            AutoCompleteTextBox_KeyFilterItem(e);
        });

    //add click event handler for document
    $(document).click(function (e) {
        var element = e.srcElement || e.target;
        AutoCompleteTextBox_HideList();
    });
}

//init AutoCompleteTextBox items
function AutoCompleteTextBox_InitListData($container, filterValue) {
    var $div = $container.find("div");
    var $txt=$div.parent().find(":text");
    var newList = new Array();
    var newListID = new Array();
    var index=-1;
    var oSelect = $container.find("select")[0];
    var len = oSelect.options.length;
    var x = $txt[0].offsetLeft;
    for (var i = 0; i < len; i++) {
        if (filterValue == undefined || filterValue == "") {
            index = newList.length;
            newList[index] = oSelect.options[i].text;
            newListID[index] = oSelect.options[i].value;
          
        }
        else {
            if (newList.length >= 9) {
                break;
            }
            var currVal = oSelect.options[i].text;
            var currID = oSelect.options[i].value;
           
            if (currVal.length >= filterValue.length) {
                if (currVal.toLowerCase().substring(0, filterValue.length) == filterValue.toLowerCase()) {
                    index = newList.length;
                    newList[index] = currVal;
                    newListID[index] = currID;
                    
                }
            }

        }

        $container.find("select")[0].options[0].removeAttribute("selected");
      }

    var sHtml = [];
    sHtml.push("<table border=\"0\" cellpadding=\"0\" cellspace=\"0\" width=\"100%\" border=\"1\" style=\"z-index:10; background-color:white;\">");
    for (var i = 0; i < newList.length; i++) {
        sHtml.push("<tr onMouseOver=\"this.bgColor='#7DA7D9'; this.style.color='#ffffff'; this.style.cursor='default'; \" onMouseOut=\"this.bgColor='#ffffff'; this.style.color='#000000';\">");
        sHtml.push("<td nowrap style=\"text-transform:capitalize;\" onClick=\"AutoCompleteTextBox_SelectItemWithMouse(this);\" id=\"" + newListID[i] + "\">");
        sHtml.push((newList[i] == "" ? "&nbsp;" : newList[i]));
        sHtml.push("</td>");
        sHtml.push("</tr>");
    }

    sHtml.push("</table>");

    $div.html(sHtml.join('')); //set the HTML contents of div to concatenated string from sHtml arrary
    $div.css("overflowX", "hidden"); //oTmp.style.overflowX = "hidden"
    $div.css("overflowY", "auto"); //oTmp.style.overflowY = "auto";
    $div.css("border", "1px solid silver"); //oTmp.style.border = "1px solid midnightblue";
    $div.css("position", "absolute"); //oTmp.style.position = "absolute";
    $div.css("visibility", "hidden"); //oTmp.style.visibility = "hidden";
    $div.css("left", $txt[0].offsetLeft);
    $div.css("top", $txt[0].offsetBottom);
    var count = $container.find("table td").size(); //get total AutoCompleteTextBox items
    var $text = $container.find(":text"); //get textbox element
    // $div.css("width", $text.outerWidth()); //make the dropdown list same width as textbox with 
    $div.css("min-width", $text.outerWidth());
    $div.css("display", "inline");
    $div.css("padding-right", "15px");
    if ( count == 0) {
        $div.css({ "height": "150" }); //limit the height of dropdown list when there is no item
    }
    else {
        $div.css({ "height": count *22 }); //set the height of dropdown box same as total of items' height. Each item's height is 19.5
    }

}

//hide AutoCompleteTextBox dropdown list
function AutoCompleteTextBox_HideList() {
    $("span[AutoCompleteTextBox]").find("div").css("visibility", "hidden");
}

//is AutoCompleteTextBox dropdown list hidden
function AutoCompleteTextBox_IsListHidden($container) {
    return $container.find("div").css("visibility") == "hidden";
}

//keydown
function AutoCompleteTextBox_KeySelectItem(e) {
    var txt = e.srcElement || e.target;
    var currentitem = $(txt).data("currentitem");
    var val = $.trim($(txt).val()); //get value in textbox
    var $container = $(txt).closest("span[AutoCompleteTextBox]"); //get AutoCompleteTextBox container that is defined with span element and AutoCompleteTextBox attribute

    var key = e.keyCode || e.which; //get key code
    switch (key) {
        case 9: //tab
            if (!AutoCompleteTextBox_IsListHidden($container)) {
                AutoCompleteTextBox_HideList();
                return false;
            }
            break;
        case 38: //up
            if (val == "" || AutoCompleteTextBox_IsListHidden($container)) {
                return;
            }
            --currentitem;
            $(txt).data("currentitem", currentitem);
            AutoCompleteTextBox_ChangeItemWithKey(txt);
            break;
        case 40: //down
            if (val == "" || AutoCompleteTextBox_IsListHidden($container)) {
                //$container.find("table").find("td").attr("tabindex", 1).focus();
                return;
            }
            currentitem++;
            $(txt).data("currentitem", currentitem)
            AutoCompleteTextBox_ChangeItemWithKey(txt);
            break;
        case 13: //enter			
            if (!AutoCompleteTextBox_IsListHidden($container)) {
                AutoCompleteTextBox_HideList();
                return false;
            }
            break;
        case 27: //esc
            AutoCompleteTextBox_HideList();
            return false;
            break;
        default:
            break;


    }
  
}

//keyup
function AutoCompleteTextBox_KeyFilterItem(e) {
    var txt = e.srcElement || e.target;

    //do nothing if up, down, enter, esc key pressed
    if (e.keyCode == 38 || e.keyCode == 40 || e.keyCode == 13 || e.keyCode == 27) {
        return;
    }

    $(txt).data("currentitem", -1);
    var val = $(txt).val();
    if (val == "") {
        AutoCompleteTextBox_HideList();
        return;
    }

    var $container = $(txt).closest("span[AutoCompleteTextBox]");
    AutoCompleteTextBox_InitListData($container, val);

    var $div = $container.find("div");
    $div.css({ "zIndex": "1", "visibility": "visible" });

    //hide dropdown list if there is no item
    if ($div.find("td").size() == 0) {
        AutoCompleteTextBox_HideList();
    }

    var table = $(txt).closest("span[AutoCompleteTextBox]").find("table")[0];

}
//make selection
function SelectItemFromList(txt,id) {
    var $txt = $(txt);
    var $container = $txt.closest("span[AutoCompleteTextBox]");
    var options = $container.find("select")[0].options;

    for (var i = 0; i < options.length; i++) {
        if (options[i].value == id) {
            $container.find("select")[0].options[i].selected = true
            break;
        }
       

    }
}
//change item
function AutoCompleteTextBox_ChangeItemWithKey(txt) {
    var $txt = $(txt);
    var currentitem = $txt.data("currentitem");
    var table = $txt.closest("span[AutoCompleteTextBox]").find("table")[0];
    for (i = 0; i < table.rows.length; i++) {
        table.rows[i].bgColor = "#ffffff";
        table.rows[i].style.color = "#000000";
    }
    
    if (currentitem < 0) {
        currentitem = table.rows.length - 1;
    }
    if (currentitem == table.rows.length) {
        currentitem = 0;
    }
    $txt.data("currentitem", currentitem);

    if (table.rows[currentitem] == null) {
        AutoCompleteTextBox_HideList();
        return;
    }
    table.rows[currentitem].bgColor = "#7DA7D9"; //darkblue color
   $txt.val($(table.rows[currentitem].cells[0]).text());
    var id = $(table.rows[currentitem].cells[0]).attr('id');
    SelectItemFromList(txt, id);
   
   
}

//select item
function AutoCompleteTextBox_SelectItemWithMouse(td) {
    var id = td.id;
    var $div = $(td).closest("div");
    var $txt = $div.parent().find(":text");
    var $container = $txt.closest("span[AutoCompleteTextBox]");
    var selectedValue = $(td).text();
    if ($.trim(selectedValue) == "") {
        selectedValue = "";
    }
    $txt.val(td.textContent);
    $txt[0].value = selectedValue;
  SelectItemFromList($txt,id);
}