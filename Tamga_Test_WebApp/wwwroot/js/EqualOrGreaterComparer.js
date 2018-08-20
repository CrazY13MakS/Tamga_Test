$.validator.addMethod("equalorgreater",
    function (value, element, parameters) {
        console.log("method");
        console.log(this);
        var target = $(parameters);
        if (this.settings.onfocusout && target.not(".validate-equalTo-blur").length) {
            target.addClass("validate-equalTo-blur").on("blur.validate-equalTo", function () {
                $(element).valid();
            });
        }
        var otherValue = target.val();
        return !(isNaN(value) || isNaN(otherValue)) && (parseFloat(value) >= parseFloat(otherValue));
    });

$.validator.unobtrusive.adapters.add("equalorgreater", ['other'], function (options) {
    console.log("adapt");
    var prefix = getModelPrefix(options.element.name),
        other = options.params.other,
        fullOtherName = appendModelPrefix(other, prefix),
        element = $(options.form).find(":input").filter("[name='" + escapeAttributeValue(fullOtherName) + "']")[0];

    setValidationValues(options, "equalorgreater", element);
});
function appendModelPrefix(value, prefix) {
    if (value.indexOf('*.') === 0) {
        value = value.replace('*.', prefix);
    }
    return value;
}
function getModelPrefix(fieldName) {
    return fieldName.substr(0, fieldName.lastIndexOf(".") + 1);
}
function setValidationValues(options, ruleName, value) {
    options.rules[ruleName] = value;
    if (options.message) {
        options.messages[ruleName] = options.message;
    }
}
function escapeAttributeValue(value) {
    // As mentioned on http://api.jquery.com/category/selectors/
    return value.replace(/([!"#$%&'()*+,./:;<=>?@\[\\\]^`{|}~])/g, "\\$1");
}