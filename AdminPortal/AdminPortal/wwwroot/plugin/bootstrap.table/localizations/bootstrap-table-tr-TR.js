/**
 * Bootstrap Table Turkish translation
 * Author: Emin Şen
 * Author: Sercan Cakir <srcnckr@gmail.com>
 */

$.fn.bootstrapTable.locales['tr-TR'] = {
    formatLoadingMessage: function formatLoadingMessage() {
        return 'Yükleniyor, lütfen bekleyin';
    },
    formatRecordsPerPage: function formatRecordsPerPage(pageNumber) {
        return "Sayfa ba\u015F\u0131na ".concat(pageNumber, " kay\u0131t.");
    },
    formatShowingRows: function formatShowingRows(pageFrom, pageTo, totalRows, totalNotFiltered) {
        if (totalNotFiltered !== undefined && totalNotFiltered > 0 && totalNotFiltered > totalRows) {
            return "".concat(totalRows, " kay\u0131ttan ").concat(pageFrom, "-").concat(pageTo, " aras\u0131 g\xF6steriliyor (filtered from ").concat(totalNotFiltered, " total rows).");
        }

        return "".concat(totalRows, " kay\u0131ttan ").concat(pageFrom, "-").concat(pageTo, " aras\u0131 g\xF6steriliyor.");
    },
    formatSRPaginationPreText: function formatSRPaginationPreText() {
        return 'previous page';
    },
    formatSRPaginationPageText: function formatSRPaginationPageText(page) {
        return "to page ".concat(page);
    },
    formatSRPaginationNextText: function formatSRPaginationNextText() {
        return 'next page';
    },
    formatDetailPagination: function formatDetailPagination(totalRows) {
        return "Showing ".concat(totalRows, " rows");
    },
    formatClearSearch: function formatClearSearch() {
        return 'Clear Search';
    },
    formatSearch: function formatSearch() {
        return 'Ara';
    },
    formatNoMatches: function formatNoMatches() {
        return 'Eşleşen kayıt bulunamadı.';
    },
    formatPaginationSwitch: function formatPaginationSwitch() {
        return 'Hide/Show pagination';
    },
    formatPaginationSwitchDown: function formatPaginationSwitchDown() {
        return 'Show pagination';
    },
    formatPaginationSwitchUp: function formatPaginationSwitchUp() {
        return 'Hide pagination';
    },
    formatRefresh: function formatRefresh() {
        return 'Yenile';
    },
    formatToggle: function formatToggle() {
        return 'Değiştir';
    },
    formatToggleOn: function formatToggleOn() {
        return 'Show card view';
    },
    formatToggleOff: function formatToggleOff() {
        return 'Hide card view';
    },
    formatColumns: function formatColumns() {
        return 'Sütunlar';
    },
    formatColumnsToggleAll: function formatColumnsToggleAll() {
        return 'Toggle all';
    },
    formatFullscreen: function formatFullscreen() {
        return 'Fullscreen';
    },
    formatAllRows: function formatAllRows() {
        return 'Tüm Satırlar';
    },
    formatAutoRefresh: function formatAutoRefresh() {
        return 'Auto Refresh';
    },
    formatExport: function formatExport() {
        return 'Export data';
    },
    formatJumpTo: function formatJumpTo() {
        return 'GO';
    },
    formatAdvancedSearch: function formatAdvancedSearch() {
        return 'Advanced search';
    },
    formatAdvancedCloseButton: function formatAdvancedCloseButton() {
        return 'Close';
    }
};

$.extend($.fn.bootstrapTable.defaults, $.fn.bootstrapTable.locales['tr-TR'])
