/// <reference path="../../scripts/angular.min.js" />

angular.module("umbraco")
    .controller("My.MarkdownEditorController",
        //inject umbracos assetsService
        function ($scope, assetsService) {

            //tell the assetsService to load the markdown.editor libs from the markdown editors
            //plugin folder
            assetsService
                .load([
                    "~/App_Plugins/MarkDownEditor/lib/Markdown.Converter.js",
                    "~/App_Plugins/MarkDownEditor/lib/Markdown.Sanitizer.js",
                    "~/App_Plugins/MarkDownEditor/lib/Markdown.Editor.js"
                ])
                .then(function () {
                    //this function will execute when all dependencies have loaded
                    alert("editor dependencies loaded");
                    console.log('stuff has loaded!');
                });

            //load the separate css for the editor to avoid it blocking our js loading
            assetsService.loadCss("~/App_Plugins/MarkDownEditor/lib/Markdown.Editor.css");
        });