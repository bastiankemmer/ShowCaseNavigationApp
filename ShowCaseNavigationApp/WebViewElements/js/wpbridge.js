var Media = {
        scanBarcode: function(){
            window.external.notify('ScanBarcode');
        }
};
var Device = {
    vibrate: function (miliseconds) {
        window.external.notify('Vibrate' + '/' + miliseconds);
    },
    GoBack: function () {
        window.external.notify('GoBack');
    }
};