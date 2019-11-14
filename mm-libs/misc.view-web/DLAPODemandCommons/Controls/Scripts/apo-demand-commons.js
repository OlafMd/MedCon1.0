/*
+               Init for APOArticleSearch
-------------------------------------------------------------------------------------- */

function InitAPOArticleSearch() {

    //this is fix for chrome
    var ignoreEnterAfterAutocompleteSelect = false; 
    var uniqueAutocompleteResultValue = "";

    $(".js_autocomplete").autocomplete({

        source: function (request, response) {

            var autoCompleteHandlerUrl = $(this.element).closest("div").find('#hiddenAutoCompleteHandlerUrl').val();

            $.ajax({
                url: autoCompleteHandlerUrl + "?prefix=" + request.term,
                dataType: "json",
                type: "POST",
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.Name,
                            value: item.Value
                        }
                    }))
                },
                error: function (a, b, c) {
                    //error handler
                }
            });

        },
        response: function (event, ui) {
            if (ui.content.length == 1)
                uniqueAutocompleteResultValue = ui.content[0].value;
            else
                uniqueAutocompleteResultValue = "";
        },
        select: function (event, ui) {

            ignoreEnterAfterAutocompleteSelect = true;
            event.preventDefault();

            articleIsChoosenPostBack($(this), ui.item.value);

        },
        focus: function (event, ui) {
            return false;
        },
        minLength: 3,
        delay: 500
    });

    $(".js_autocomplete").keypress(function (e) {
        if (e.keyCode == 13 && !ignoreEnterAfterAutocompleteSelect) {

            //hide list
            $(this).autocomplete("destroy");

            if (uniqueAutocompleteResultValue != "") 
            {
                //unique result
                articleIsChoosenPostBack($(this),uniqueAutocompleteResultValue)
            } 
            else
            {
                //do postback
                e.preventDefault();
                var href = decodeURIComponent($(this).closest("div").find('.js_open_popup').attr('href'));
                eval(href);
            }
        }

        ignoreEnterAfterAutocompleteSelect = false;
    });

    $(".js_autocomplete").focus(function () {
        $(this).select();
    });
}

var articleIsChoosenPostBack = function (control, selectedValue) {
    var href = decodeURIComponent( $(control).closest("div").find('.js_choose_article').attr('href') );
    $(control).closest("div").find('#hiddenSelectedItemITL').val(selectedValue);

    eval(href);
}

/*
+               Init for APOChoosePopupSearch 
-------------------------------------------------------------------------------------- */

var InitAPOChoosePopupSearch = function () 
{
    $('.search-holder').find('i').on('click', function () {
        $(this).parent().next().toggle();
    });
}

/*
+               Init Backbone 
-------------------------------------------------------------------------------------- */

var initBackbone = function () {

    if (window.App === undefined) {

        _.templateSettings = {
            interpolate: /\{\{(.+?)\}\}/g,      // print value: {{ value_name }}
            evaluate: /\{%([\s\S]+?)%\}/g,      // excute code: {% code_to_execute %}
            escape: /\{%-([\s\S]+?)%\}/g
        };                                      // escape HTML: {%- <script> %} prints &lt;script&gt;

        window.App = {
            Views: {},
            Models: {},
            Collections: {}
        };

        window.template = function (id) {
            return _.template($('#' + id).html());
        };

        App.DLModel = Backbone.Model.extend({
            defaults: {}
        });

        App.DLView = Backbone.View.extend({

        });

        App.DLCollection = Backbone.Collection.extend({
        });

        App.DLCollView = Backbone.View.extend({
            initialize: function () {
                this.collection.on('add', this.addItem, this);
            },
            addItem: function (item) {
                var iv = this.itemView;
                iv.model = item;
                var cve = iv.render().el;
                this.$el.append(cve);
            }
        });
    }
};

/*
+              Init Backbone functionality for ArticleTabe
-------------------------------------------------------------------------------------- */

var selectionMode = 'Multiple';

var initChooseArticlePopUp = function () {

    initBackbone();

    App.Models.Article = App.DLModel.extend({
        defaults: {
            ProductITL: '',
            ProductName: '',
            ProductNumber: '',
            Producer: '',
            ActiveComponents: [],
            DosageFormName: '',
            Unit: '',
            ABDAPrice: 0.0,
            SalesPrice: 0.0
        }
    });
    App.Views.Article = App.DLView.extend({
        template: template('choosePopupArticlesTemplate'),
        render: function () {
            this.el = this.template(this.model.toJSON());
            return this;
        }
    });
    App.Collections.Articles = App.DLCollection.extend({
        model: App.Models.Article
    });
    App.Views.Articles = App.DLCollView.extend({
        itemView: new App.Views.Article()
    });
};

/*
+               Functions for APOChoosePopupSearch
-------------------------------------------------------------------------------------- */

function SetEnd(s) {
    //set cursor at the end
    var strLength = s.value.length;
    s.setSelectionRange(strLength, strLength);
}

function EnterEventAdvancedSearch(s, e, args) {
    if (e.keyCode == '13')
    {
        __doPostBack(s.name, args);
        e.stopPropagation();
        return false;
    }
}

/*
+               Functions for ChooseArticleGrid
-------------------------------------------------------------------------------------- */

var itemCollection = undefined;
var collectionView = undefined;
var pageIndex = 1;
var sortBy = 'ProductName';

var loadArticles = function (newSortBy) {
    if (pageIndex >= 1) {

        var sortingCriteriaLastItem = "";
        if (sortBy != "") {
            var tableHeader = $('#tblChooseArticle').closest('.floatThead-wrapper').find('.floatThead-table');
            var column = $(tableHeader).find('tr #' + sortBy).index() + 1;
            sortingCriteriaLastItem = $('#tblChooseArticle tr td:nth-child(' + column + ')').last().text().trim();

            //unit cell contains 12 ml
            if (sortBy == 'Unit') {
                var sortingArr = sortingCriteriaLastItem.split(' ');
                sortingCriteriaLastItem = sortingArr[sortingArr.length - 1];
            }
        }

        var hiddenArticlesWebServiceUrl = $("#tblChooseArticle").closest("div.popup ").find('#hiddenArticlesWebServiceUrl').val();

        $.ajax({
            type: "POST",
            url: hiddenArticlesWebServiceUrl,
            data: '{ pageIndex: ' + pageIndex + ', sortBy: "' + newSortBy + '", sortingCriteriaLastItem: "' + sortingCriteriaLastItem + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                itemCollection.add(JSON.parse(response.d).ABDAArticles);
                $('#tblChooseArticle').children('tbody').append(collectionView.render().$el.children());

                initChooseArticleGridEvents();
            }
        });
        pageIndex++;
    }
};

var initChooseArticleGridEvents = function () {
    selectionMode = $("#divChooseArticlePopUp #hiddenSelectionMode").val();

    if (selectionMode == 'Single') {
        $('#pnlChooseArticleControl table tr th:nth-child(1)').css('visibility', 'hidden'); ;
        $('#pnlChooseArticleControl table tr td:nth-child(1)').css("visibility", "hidden"); ;
    }

    $("#tblChooseArticle input:checkbox").click(function (event) {
        event.stopPropagation();
    });

    $("#tblChooseArticle tr").unbind();

    $("#tblChooseArticle tr").click(function () {
        if (selectionMode == 'Single') {
            var $checkboxes = $("#tblChooseArticle tr input[type=checkbox]");

            $checkboxes.prop('checked', false);
            $(this).closest("tr").find("input[type=checkbox]").prop('checked', true);

            //update clasees
            $("#tblChooseArticle tr").removeClass("selected-row");
            $(this).addClass("selected-row");
        } else {

            var $cb = $(this).find("input[type=checkbox]");

            if ($cb.is(":checked")) {
                $cb.prop('checked', false);
            } else {
                $cb.prop('checked', true);
            }
        }
    });
};

var resetArticlesTable = function (newSortBy) {

    if (typeof newSortBy === 'undefined') {
        newSortBy = '';
    };

    itemCollection = new App.Collections.Articles([]);
    collectionView = new App.Views.Articles({ collection: itemCollection });
    pageIndex = 1;
    $('#tblChooseArticle').children('tbody').empty();
    loadArticles(newSortBy);
}

var sortChange = function (sender, newSortBy) {
    sortBy = newSortBy;
    resetArticlesTable(newSortBy);
    updateSortByCss(sender);
};

var updateSortByCss = function (sender) {
    var senderClasses = $(sender).closest("table").find("th#" + sortBy).attr('class');

    $(sender).closest("table").find("th").removeClass('sorted_dsc');
    $(sender).closest("table").find("th").removeClass('sorted_asc');

    $(sender).closest("table").find("th").addClass('sort_asc_dsc');

    if (senderClasses.indexOf('sorted_asc') != -1)
        $(sender).closest("table").find("th#" + sortBy).addClass('sorted_dsc');
    else
        $(sender).closest("table").find("th#" + sortBy).addClass('sorted_asc');

}

var saveSelectedIDs = function (confirmButton) {
    var selected = [];
    $(confirmButton).closest("div.popup").find('tbody').find('tr input[type=checkbox]:checked').each(function () {
        selected.push(this.value);
    });
    $(confirmButton).closest("div.popup").find('#hiddenSelectedArticlesInChoosePopupTable').val(JSON.stringify(selected));
};

var timer;

var registerOnScroll = function () {

    $("#divChooseArticlePopUp").on("scroll", function (e) {

        if (timer) {
            window.clearTimeout(timer);
        }

        timer = window.setTimeout(function () {
            var $o = $(e.currentTarget);
            if ($o[0].scrollHeight - $o.scrollTop() <= ($o.outerHeight() + 75)) {
                loadArticles('');
            }
        }, 50);
    });
};


/*
+               Functions for APOStorageSelectPopup
-------------------------------------------------------------------------------------- */
var saveSelectedStorageIDs = function (confirmButton) {
    var selected = [];
    $('.tree .storage-item-checkbox-selectable:checked')
        .parent()
        .next()
        .each(function () {
            selected.push(this.id);
        }
    );
    if (selected.length > 0) {
        saveIntoSelectedStorageIDsHiddenField(confirmButton, selected);
    }
};

var saveSelectedStorageID = function (linkButton, id) {
    saveIntoSelectedStorageIDsHiddenField(linkButton, [id]);
    selectAndExpand(linkButton);
};

var saveIntoSelectedStorageIDsHiddenField = function (button, selectedItems) {
    $(button).closest('.popup').find('.wrapperSelectedItemIDsHiddenFields > input[type=hidden]')
        .each(function () {
            $(this).val(JSON.stringify(selectedItems));
        }
    );
};

var saveIntoOpenedItemsIDsHiddenField = function (button, openedItems) {
    $(button).closest('#storage-tree-control').parent().find('.hidden_OpenedItemsIDs_Wrap > input[type=hidden]')
        .each(function () {
            $(this).val(openedItems);
        }
    );
};

var selectAndExpand = function (linkButton) {
    removeCheckedExceptSelected(linkButton);
    removeUnderlineExpectSelected(linkButton);
    expandSubTree(linkButton);
};

var removeCheckedExceptSelected = function (linkButton) {
    $('.tree input[type=checkbox]').each(function () {
        $(this).prop('checked', false);
        $(this).closest('span').removeClass('checked');
    });
    $(linkButton).prev().each(function () {
        $(this).addClass('checked');
    }).find('input[type=checkbox]').each(function () {
        $(this).prop('checked', true);
    });
};

var removeUnderlineExpectSelected = function (linkButton) {
    $('.tree li').each(function () {
        $(this).removeClass('selected');
    });
    $(linkButton).closest('li').each(function () {
        $(this).addClass('selected');
    });
};

var expandSubTree = function (element) {
    if (element.nodeName === 'A') {
        $(element).prev('i').toggleClass('icons-treeli_active');
        $(element).next('ul').toggle();
    }
    else if (element.nodeName === 'I') {
        $(element).toggleClass('icons-treeli_active');
        $(element).next('a').next('ul').toggle();
    }
    removeUnderlineExpectSelected(element);
    saveExpanededItemsIds(element);
};

var saveExpanededItemsIds = function (linkButton) {
    var openedItemsIds = [];
    $(linkButton).closest('#storage-tree-control').find('.icons-treeli_active + a')
        .each(function () {
            openedItemsIds.push(this.id);
        }
    );
    if (openedItemsIds.length > 0) {
        var openedItemsIdsAsString = openedItemsIds.join('&');
        saveIntoOpenedItemsIDsHiddenField(linkButton, openedItemsIdsAsString);
    }
};

var selectChildStorages = function (storageItemCheckBox) {
    var isChecked = $(storageItemCheckBox).prop('checked');
    var childCheckboxes = $(storageItemCheckBox)
        .closest('li')
        .find('input[type=checkbox]')
        .each(function () {
            $(this).prop('checked', isChecked);
            if (isChecked) {
                $(this).closest('span').addClass('checked');
            }
            else {
                $(this).closest('span').removeClass('checked');
            }
    });
};

var markSelectedItems = function (tree) {
    var selectedItemsHiddenField = $(tree).find('.wrapperSelectedItemIDsHiddenFields input[type=hidden]').val();
    if (selectedItemsHiddenField) {
        var selectedIDs = $.parseJSON(selectedItemsHiddenField);
        if (selectedIDs.length == 1) {
            $(tree).find('#' + selectedIDs[0]).parent().addClass("selected");
        }
    }
};
