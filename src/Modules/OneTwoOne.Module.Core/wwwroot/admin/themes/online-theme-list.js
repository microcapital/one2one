/*global angular*/
(function () {
    angular
        .module('oneTwoOneAdmin.core')
        .controller('OnlineThemeListCtrl', ['themeService', 'translateService', OnlineThemeListCtrl]);

    function OnlineThemeListCtrl(themeService, translateService) {
        var vm = this;
        vm.themes = [];
        vm.translate = translateService;

        vm.getThemes = function getThemes() {
            themeService.getOnlineThemes().then(function (result) {
                vm.themes = result.data;
            });
        };

        vm.getThemes();
    }
})();
