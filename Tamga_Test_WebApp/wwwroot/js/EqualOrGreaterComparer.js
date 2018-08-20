$.validator.addMethod("equalorgreater",
    function (value, element, parameters) {
        console.log("method");
        var otherValue = $(parameters.element).val();
        console.log(value);
        console.log(element);
        console.log(parameters);
        return isNaN(value) && isNaN(otherValue) || (parseFloat(value) >= parseFloat(otherValue));
    });

$.validator.unobtrusive.adapters.add("equalorgreater", ['other'], function (options) {
    console.log("adapt");
    var prefix = options.element.name.substr(0, options.element.name.lastIndexOf('.') + 1),
        other = options.params.other,
        fullOtherName = appendModelPrefix(other, prefix),
        element = $(options.form).find(':input[name=' + fullOtherName + ']')[0];
    console.log(this);
    options.rules['equalorgreater'] = { element: element };
    if (options.message) {
        options.messages['equalorgreater'] = options.message;
    }
});
function appendModelPrefix(value, prefix) {
    if (value.indexOf('*.') === 0) {
        value = value.replace('*.', prefix);
    }
    return value;
}