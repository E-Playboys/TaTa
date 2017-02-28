// TAG HELPER HANDLERS

function handleInlineRemoveButtonTagHelper(self, containerElement, markElement) {
    var $container = $(self).parents(containerElement);
    $container.find(markElement).val('True');
    $container.hide();
}

function handleInlineAddButtonTagHelper(containerElement, propertyName, htmlContent) {
    var $container = $(containerElement);
    var nextIndex = $container.children().length;

    // Update index for name attribute, ex: "name=Properties[1]"
    var pattern = new RegExp(propertyName + "\\[(\\d+)\\]", "gi");
    var contentHtml = htmlContent.replace(pattern, propertyName + "[" + nextIndex + "]");
    
    // Update index for id attribute, ex: "name=Properties_1"
    pattern = new RegExp(propertyName + "_(\\d+)", "gi");
    contentHtml = contentHtml.replace(pattern, propertyName + "_" + nextIndex);
    
    // Update id for any unique element such as "switch"
    pattern = new RegExp("unique_(\\d+)", "gi");
    contentHtml = contentHtml.replace(pattern, "unique_" + (new Date()).getTime());

    $container.append(contentHtml);
}

// ==================