function getArticleGenerator(articles) {
    let contentDiv = document.getElementById('content');

    return function() {
        if(articles.length == 0)
        {
            return;
        }

        let text = articles.shift();

        contentDiv.innerHTML += `<article>${text}</article>`;
    }
}
