

!function($) {
    "use strict";

    var CodeEditor = function() {};

    CodeEditor.prototype.getSelectedRange = function(editor) {
        return { from: editor.getCursor(true), to: editor.getCursor(false) };
    },
    CodeEditor.prototype.autoFormatSelection = function(editor) {
        var range = this.getSelectedRange(editor);
        editor.autoFormatRange(range.from, range.to);
    },
    CodeEditor.prototype.commentSelection = function(isComment, editor) {
        var range = this.getSelectedRange(editor);
        editor.commentRange(isComment, range.from, range.to);
    },
    CodeEditor.prototype.init = function() {
        var $this = this;

        CodeMirror.fromTextArea(document.getElementById("code"), {
            mode: {name: "xml", alignCDATA: true},
            lineNumbers: true
        });

        CodeMirror.fromTextArea(document.getElementById("code2"), {
            mode: {name: "javascript"},
            lineNumbers: true,
            theme: 'ambiance'
        });


        var editor = CodeMirror.fromTextArea(document.getElementById("code3"), {
            mode: {name: "javascript"},
            lineNumbers: true,
        });
        CodeMirror.commands["selectAll"](editor);


        $('.autoformat').click(function(){
            $this.autoFormatSelection(editor);
        });
        
        $('.comment').click(function(){
            $this.commentSelection(true, editor);
        });
        
        $('.uncomment').click(function(){
            $this.commentSelection(false, editor);
        });
    },

    $.CodeEditor = new CodeEditor, $.CodeEditor.Constructor = CodeEditor
}(window.jQuery),


function($) {
    "use strict";
    $.CodeEditor.init()
}(window.jQuery);
