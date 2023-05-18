


!function($) {
    "use strict";

    var Nestable = function() {};

    Nestable.prototype.updateOutput = function (e) {
        var list = e.length ? e : $(e.target),
            output = list.data('output');
        if (window.JSON) {
            output.val(window.JSON.stringify(list.nestable('serialize'))); 
        } else {
            output.val('JSON browser support required for this demo.');
        }
    },
 
    Nestable.prototype.init = function() {

        $('#nestable_list_1').nestable({
            group: 1
        }).on('change', this.updateOutput);

        $('#nestable_list_2').nestable({
            group: 1
        }).on('change', this.updateOutput);

        this.updateOutput($('#nestable_list_1').data('output', $('#nestable_list_1_output')));
        this.updateOutput($('#nestable_list_2').data('output', $('#nestable_list_2_output')));

        $('#nestable_list_menu').on('click', function (e) {
            var target = $(e.target),
                action = target.data('action');
            if (action === 'expand-all') {
                $('.dd').nestable('expandAll');
            }
            if (action === 'collapse-all') {
                $('.dd').nestable('collapseAll');
            }
        });

        $('#nestable_list_3').nestable();
    },
    $.Nestable = new Nestable, $.Nestable.Constructor = Nestable
}(window.jQuery),


function($) {
    "use strict";
    $.Nestable.init()
}(window.jQuery);
