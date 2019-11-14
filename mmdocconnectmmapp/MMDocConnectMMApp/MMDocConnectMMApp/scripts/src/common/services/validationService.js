define(['angularAMD'], function (angularAMD) {
    angularAMD.service('validationService', function () {
        this.IBANvalidator = function validationService(iban) {
            var newIban = iban.toUpperCase(),
                modulo = function (divident, divisor) {
                    var cDivident = '';
                    var cRest = '';

                    for (var i in divident) {
                        var cChar = divident[i];
                        var cOperator = cRest + '' + cDivident + '' + cChar;
                        if (cOperator < parseInt(divisor)) {
                            cDivident += '' + cChar;
                        } else {
                            cRest = cOperator % divisor;
                            if (cRest == 0) {
                                cRest = '';
                            }
                            cDivident = '';
                        } validationService

                    }
                    cRest += '' + cDivident;
                    if (cRest == '') {
                        cRest = 0;
                    }
                    return cRest;
                };

            if (newIban.search(/^[A-Z]{2}/gi) < 0) {
                return false;
            }

            newIban = newIban.substring(4) + newIban.substring(0, 4);

            newIban = newIban.replace(/[A-Z]/g, function (match) {
                return match.charCodeAt(0) - 55;
            });

            return parseInt(modulo(newIban, 97), 10) === 1;
        };

        this.validateBIC = function validationService(BIC) {
            var regexpBIC = new RegExp("^([a-zA-Z]){4}([a-zA-Z]){2}([0-9a-zA-Z]){2}([0-9a-zA-Z]{3})?$");
            var res = regexpBIC.test(BIC);
            return res;
        };

        this.generatePassword = function validationService() {
            var length = 8,
                 charset = "abcdefghijklnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789",
                 retVal = "";
            for (var i = 0, n = charset.length; i < length; ++i) {
                retVal += charset.charAt(Math.random() * n);
            };
            return retVal;
        };

        this.ValidatePassword = function validationService(pass) {
    
            var passwordValidation = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[-\w!$%@^&*[()_#\]+|~=`{}\\:";'<>?,.\/]{8,128}$/.test(pass);

            return passwordValidation;
        };

        this.validateEmail = function validationService(email) {
            //var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            var re = /^[_A-Za-z0-9-\+]+(\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\.[A-Za-z0-9]+)*(\.[A-Za-z]{2,})$/
            return re.test(email);
        };

        this.LANRValidation = function validationService(Lanr) {
            var checkSumCounted = 0;
            var LanrValid = Lanr;

            var char1 = LanrValid.charAt(0) * 4;
            var char2 = LanrValid.charAt(1) * 9;
            var char3 = LanrValid.charAt(2) * 4;
            var char4 = LanrValid.charAt(3) * 9;
            var char5 = LanrValid.charAt(4) * 4;
            var char6 = LanrValid.charAt(5) * 9;
            var CheckSum = LanrValid.charAt(6) * 1;
            var sum = 0;

            var listCheck = [char1, char2, char3, char4, char5, char6];


            for (var i = 0; i < listCheck.length; i++) {
                sum = sum + listCheck[i];
            };
           
            var sumHelper = ((sum / 10).toFixed(1)).toString();
            var splited = sumHelper.split('.');
            var helpSum = splited[1];
            checkSumCounted = 10 - helpSum;
            if (checkSumCounted == 10) { checkSumCounted = 0 };
            if (checkSumCounted == CheckSum) {
                return true;
            }
            else {
                return false;
            };
        };

        this.isNotNullOrEmpty = function (value) {
            return value !== '' && value !== null;
        };
        
        this.isNotUndefinedOrNull = function (value) {
            return value !== null && value !== undefined && value !== '';
        };

        this.isValidDate = function(dateString) {
            if (!/^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/.test(dateString))
                return false;

            var parts = dateString.split(".");
            var month = parseInt(parts[1], 10);
            var day = parseInt(parts[0], 10);
            var year = parseInt(parts[2], 10);


            if (year < 1000 || year > 3000 || month == 0 || month > 12)
                return false;

            var monthLength = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];


            if (year % 400 == 0 || (year % 100 != 0 && year % 4 == 0))
                monthLength[1] = 29;

            return day > 0 && day <= monthLength[month - 1];
        };
    });
});