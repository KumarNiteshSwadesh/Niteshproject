$(function () {

    var specialKeys = new Array();
    specialKeys.push(8); //Backspace
    specialKeys.push(9); //Tab
    specialKeys.push(46); //Delete
    specialKeys.push(36); //Home
    specialKeys.push(35); //End
    specialKeys.push(37); //Left
    specialKeys.push(39); //Right

    //************* Trim extra white spaces **************
    $("input[type='text']").blur(function () {
        var hm_res = $(this).val();
        $(this).val(hm_res.trim());
    });

    $("input[type='number']").blur(function () {
        var hm_res = $(this).val();
        $(this).val(hm_res.trim());
    });

    $("input[type='email']").blur(function () {
        var hm_res = $(this).val();
        $(this).val(hm_res.trim());
    });

    //************* End Trim extra white spaces **************

    $(".required").blur(function () {
        if ($(this).val() == "") {
            $(this).css('border-color', 'red');
        }
        else {
            $(this).css('border-color', '');
        }
    });

    $(".number").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    });
    
    function forceNumber_decimal(element) {
        element
          .data("oldValue", '')
          .bind("paste", function (e) {
              var validNumber = /^[-]?\d+(\.\d{1,2})?$/;
              element.data('oldValue', element.val())
              setTimeout(function () {
                  if (!validNumber.test(element.val()))
                      element.val(element.data('oldValue'));
              }, 0);
          });
        element
          .keypress(function (event) {
              var text = $(this).val();
              if ((event.which != 46 || text.indexOf('.') != -1) && //if the keypress is not a . or there is already a decimal point
                ((event.which < 48 || event.which > 57) && //and you try to enter something that isn't a number
                  (event.which != 45 || (element[0].selectionStart != 0 || text.indexOf('-') != -1)) && //and the keypress is not a -, or the cursor is not at the beginning, or there is already a -
                  (event.which != 0 && event.which != 8))) { //and the keypress is not a backspace or arrow key (in FF)
                  event.preventDefault(); //cancel the keypress
              }

              if ((text.indexOf('.') != -1) && (text.substring(text.indexOf('.')).length > 2) && //if there is a decimal point, and there are more than two digits after the decimal point
                ((element[0].selectionStart - element[0].selectionEnd) == 0) && //and no part of the input is selected
                (element[0].selectionStart >= element.val().length - 2) && //and the cursor is to the right of the decimal point
                (event.which != 45 || (element[0].selectionStart != 0 || text.indexOf('-') != -1)) && //and the keypress is not a -, or the cursor is not at the beginning, or there is already a -
                (event.which != 0 && event.which != 8)) { //and the keypress is not a backspace or arrow key (in FF)
                  event.preventDefault(); //cancel the keypress
              }
          });
    }

    forceNumber_decimal($(".decimal"));

    $('.characters_only').keypress(function (evt) {
        var keyCode = (evt.which) ? evt.which : evt.keyCode
        if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32)
            return false;
    });

    $('.block_special_char').keypress(function (e) {
        // here -(45) and _(95) allowed 
        var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
        var ret = ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (keyCode == 45) || (keyCode == 95) || (specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode));
        return ret;
    });

    $(".email_required").blur(function () {
        if ($(this).val() == "") {
            $(this).css('border-color', 'red');
        }
        else {
            var emailReg = new RegExp(/^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i);
            var valid = emailReg.test($(this).val());
            if (!valid) {
                $(this).css('border-color', 'red');
            } else {
                $(this).css('border-color', '');
            }
        }
    });


    //************* form submit check ************

    $("form").submit(function (event) {
        // events: required, number, decimal, email_required
        var chk_required = true;
        var chk_email_required = true;
        var chk_email_format = true;
        $(this).find('.required').each(function () {
            if ($('#' + this.id).val() == "") {
                $('#' + this.id).css('border-color', 'red');
                chk_required = false;
            }
        });

        $(this).find('.email_required').each(function () {
            if ($('#' + this.id).val() == "") {
                $('#' + this.id).css('border-color', 'red');
                chk_email_required = false;
            }
        });

        $(this).find('.email_required').each(function () {
            if ($('#' + this.id).val() != "") {
                var emailReg = new RegExp(/^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i);
                var valid = emailReg.test('#' + this.id);
                if (!valid) {
                    $('#' + this.id).css('border-color', 'red');
                    chk_email_format = false;
                } else {
                    $('#' + this.id).css('border-color', '');
                }
                
            }
        });

        if (chk_required == false || chk_email_required == false || chk_email_format == false)
        {
            event.preventDefault();
        }
        
    });

});