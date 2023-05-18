
!function($) {
    "use strict";

    var PeityChart = function() {};

    PeityChart.prototype.createPie = function ($element, $colors) {
        $($element).peity("pie", {
            fill: $colors
        });
        return $element;
    },
    PeityChart.prototype.createLine = function ($element, $strokeColor, $fillColor, $width) {
        $($element).peity("line", {
            fill: $strokeColor,
            stroke: $fillColor,
            width: $width
        });
        return $($element);
    },

    PeityChart.prototype.createBar = function ($element, $colors, $width) {
        $($element).peity("bar", {
            fill: $colors,
            width: $width
        });
        return $element;
    },

    PeityChart.prototype.createDonut = function ($element, $colors) {
        $($element).peity("donut", {
            fill: $colors
        });
        return $element;
    },

    PeityChart.prototype.init = function() {
        this.createPie("span.pie", ['#317eeb', '#d7d7d7', '#ffffff']);

        this.createLine(".line", '#317eeb', '#169c81');        

        this.createBar('.bar', ["#317eeb", "#d7d7d7"]);

        this.createBar('.bar_dashboard', ["#317eeb", "#d7d7d7"], 100);

        this.createDonut('.donut', ["#317eeb", "#d7d7d7"]);

        this.createDonut('.data-attributes span');

        var updatingChart = this.createLine(".updating-chart",'#317eeb','#169c81', 64);

        setInterval(function() {
            var random = Math.round(Math.random() * 10)
            var values = updatingChart.text().split(",")
            values.shift()
            values.push(random)

            updatingChart
                .text(values.join(","))
                .change()
        }, 1000);
    },
    //init
    $.PeityChart = new PeityChart, $.PeityChart.Constructor = PeityChart
}(window.jQuery),

//initializing 
function($) {
    "use strict";
    $.PeityChart.init()
}(window.jQuery);
