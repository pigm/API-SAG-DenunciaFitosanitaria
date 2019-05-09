
// Takes a URL, param name, and data string
// Sends to the server.. The server can respond with binary data to download
jQuery.download = function(url, key, data){
    // Build a form
    var form = $('<form></form>').attr('action', url).attr('method', 'post');
    // Add the one key/value
    form.append($("<input></input>").attr('type', 'hidden').attr('name', key).attr('value', data));
    //send request
    form.appendTo('body').submit().remove();
}

jQuery.downloadM = function (url, key, data, key2, data2) {
    // Build a form
    var form = $('<form></form>').attr('action', url).attr('method', 'post');
    // Add the one key/value
    form.append($("<input></input>").attr('type', 'hidden').attr('name', key).attr('value', data));
    // Add the two key/value
    form.append($("<input></input>").attr('type', 'hidden').attr('name', key2).attr('value', data2));
    //send request
    form.appendTo('body').submit().remove();
}

jQuery.downloadArr = function (url, arrHidden) {
    // Build a form
    var form = $('<form></form>').attr('action', url).attr('method', 'post');
    for (i in arrHidden) {
        var hidden = arrHidden[i]
        form.append($("<input></input>").attr('type', 'hidden').attr('name', hidden.key).attr('value', hidden.data));
    }
    //send request
    form.appendTo('body').submit().remove();
}
