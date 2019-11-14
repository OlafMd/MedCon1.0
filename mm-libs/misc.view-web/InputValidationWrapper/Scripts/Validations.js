/*
** Checks if the passed value exists.
** value - value to check
*/
function mandatory(value) {
    return (value != null && value != "");
}

/*
** Checks if the passed value is an integer.
** value - value to check
*/
function integer(value) {
    return (value % 1 === 0);
}

/*
** Checks if the passed value is a decimal number with specified number of decimal points.
** value - value to check
** decimals - number of decimal points
*/
function decimals(value, decimals) {
    try {
        var number = parseFloat(value);
        var fixed = number.toFixed(decimals);
        if (value == fixed) return true;
        else return false;
    }
    catch (e) {
        return false;
    }
}
