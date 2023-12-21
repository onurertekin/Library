/**
 * Bootstrap Table English translation
 * Author: Zhixin Wen<wenzhixin2010@gmail.com>
 */

$.fn.bootstrapTable.locales['en-US'] = {
    formatLoadingMessage: function formatLoadingMessage() {
        return 'Loading, please wait';
    },
    formatRecordsPerPage: function formatRecordsPerPage(pageNumber) {
        return "".concat(pageNumber, " rows per page");
    },
    formatShowingRows: function formatShowingRows(pageFrom, pageTo, totalRows, totalNotFiltered) {
        if (totalNotFiltered !== undefined && totalNotFiltered > 0 && totalNotFiltered > totalRows) {
            return "Showing ".concat(pageFrom, " to ").concat(pageTo, " of ").concat(totalRows, " rows (filtered from ").concat(totalNotFiltered, " total rows)");
        }

        return "Showing ".concat(pageFrom, " to ").concat(pageTo, " of ").concat(totalRows, " rows");
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
        return 'Search';
    },
    formatNoMatches: function formatNoMatches() {
        return 'No matching records found';
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
        return 'Refresh';
    },
    formatToggle: function formatToggle() {
        return 'Toggle';
    },
    formatToggleOn: function formatToggleOn() {
        return 'Show card view';
    },
    formatToggleOff: function formatToggleOff() {
        return 'Hide card view';
    },
    formatColumns: function formatColumns() {
        return 'Columns';
    },
    formatColumnsToggleAll: function formatColumnsToggleAll() {
        return 'Toggle all';
    },
    formatFullscreen: function formatFullscreen() {
        return 'Fullscreen';
    },
    formatAllRows: function formatAllRows() {
        return 'All';
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

$.extend($.fn.bootstrapTable.defaults, $.fn.bootstrapTable.locales['en-US']);
