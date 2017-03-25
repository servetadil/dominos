
function initAutoFileUpload() {
    'use strict';

    $('.fu-my-auto-upload').fileupload({
        autoUpload: true,
        url: '/Medium/UploadFile',
        dataType: 'json',
        progress: function (e, data) {
            //var progress = parseInt(data.loaded / data.total * 100, 10);
            $.blockUI({ message: '<h2><img src="/_assets/img/busy.gif" /> Uploading...</h2>' });
        },
        add: function (e, data) {
            var jqXHR = data.submit()
                .success(function (data, textStatus, jqXHR) {
                    $(document).ajaxStop($.unblockUI);

                    if (data.isUploaded) {
                        var mediumId = data.mediumId;
                        var inputId = this.fileInput.data("input");
                        var input = $("input[name^='" + inputId + "']");
                        input.val(mediumId);
                        $("#img" + inputId).hide();
                        input.parent().append("<img id='img" + inputId + "' src='/Medium/View/" + mediumId + "' width='100' height='100' />");
                    }
                    else {
                        alert(data.message);
                    }
                })
                .error(function (data, textStatus, errorThrown) {
                    $(document).ajaxStop($.unblockUI);

                    if (typeof (data) != 'undefined' || typeof (textStatus) != 'undefined' || typeof (errorThrown) != 'undefined') {
                        alert(textStatus + errorThrown + data);
                    }
                });
        },
        fail: function (event, data) {
            $(document).ajaxStop($.unblockUI);

            if (data.files[0].error) {
                alert(data.files[0].error);
            }
        }
    });

    $('.fu-my-auto-upload').each(function (i, x) {
        if ($(x).data("mediumid") != 0) {
            var mediumId = $(x).data("mediumid");
            var inputId = $(x).data("input");
            if ($(x).data("contenttype") == "image") {
                $(x).parent().append("<img id='img" + inputId + "' src='/Medium/View/" + mediumId + "' width='100' height='100' />");
            }
        }
    });

    $(".time-element").change(function () {
        var elemId = $(this).attr("id").slice(0, -1)
        var hour = $("#" + elemId + "H").find("option:selected").val();
        var min = $("#" + elemId + "M").find("option:selected").val();
        var str = hour + ":" + min;
        $("#" + elemId.capitalizeFirstLetter()).val(str);
    });
}

function slugify(text) {
    var trMap = {
        'çÇ': 'c',
        'ğĞ': 'g',
        'şŞ': 's',
        'üÜ': 'u',
        'ıİ': 'i',
        'öÖ': 'o'
    };
    for (var key in trMap) {
        text = text.replace(new RegExp('[' + key + ']', 'g'), trMap[key]);
    }
    return text.replace(/[^-a-zA-Z0-9\s]+/ig, '') // remove non-alphanumeric chars
                .replace(/\s/gi, "-") // convert spaces to dashes
                .replace(/[-]+/gi, "-") // trim repeated dashes
                .toLowerCase();
}

function initLoading() {
    $(document)
      .ajaxStart(function () {
          $.blockUI({ message: '<h2><img src="/_assets/img/busy.gif" /> Uploading...</h2>' });
      })
      .ajaxStop(function () {
          $.unblockUI();
      });
}

String.prototype.replaceAll = function (search, replacement) {
    var target = this;
    return target.replace(new RegExp(search, 'g'), replacement);
};


function getFormattedDate(date) {
    var day = date.getDate();
    var month = date.getMonth() + 1;
    var year = date.getFullYear().toString().slice(2);
    return day + '-' + month + '-' + year;
}

String.prototype.capitalizeFirstLetter = function () {
    return this.charAt(0).toUpperCase() + this.slice(1);
}


