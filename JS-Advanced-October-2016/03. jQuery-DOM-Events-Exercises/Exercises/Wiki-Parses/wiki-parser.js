"use strict";

function wikiParser(selector) {
    let inputText = $(selector).text();
    let result = renderToHTML(inputText);
    $(selector).html(result);

    function renderToHTML(text) {
        let italicRegex = /''(.*?)''/g;
        let boldRegex = /'''(.*?)'''/g;
        let headingOneRegex = /=(.*?)=/g;
        let headingTwoRegex = /==(.*?)==/g;
        let headingThreeRegex = /===(.*?)===/g;
        let simpleLinkRegex = /\[\[([\w\s]+)*?\]\]/g;
        let advancedLinkRegex = /\[\[([\w\s]+)\|(.*?)\]\]/g;

        text = text.replace(boldRegex, (whole, text) => `<b>${text}</b>`);
        text = text.replace(italicRegex, (whole, text) => `<i>${text}</i>`);
        text = text.replace(headingThreeRegex, (whole, text) => `<h3>${text}</h3>`);
        text = text.replace(headingTwoRegex, (whole, text) => `<h2>${text}</h2>`);
        text = text.replace(headingOneRegex, (whole, text) => `<h1>${text}</h1>`);
        text = text.replace(simpleLinkRegex, (whole, link) => `<a href="/wiki/${link}">${link}</a>`);
        text = text.replace(advancedLinkRegex, (whole, link, text) => `<a href="/wiki/${link}">${text}</a>`);

        return text;
    }
}