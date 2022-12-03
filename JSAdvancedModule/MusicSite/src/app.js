//Import views

import { page, render } from "./lib.js";
import { getUserData } from "./util.js";
import { showLogin } from "./views/loginView.js";
import { showRegister } from "./views/registerView.js";
import { updateNav } from "./views/nav.js";
import { showHome } from "./views/homeView.js";

//get main element for rendering
const main = document.getElementById('main-content');

page(decorateContext);

page("/", showHome);
page("/home", showHome);
page("/login",  showLogin);
page("/register", showRegister);
page("/catalog", ()=> console.log("catalogView"));
page("/create", ()=> console.log("createView"));
page("/details/:id", ()=> console.log("detailsView"));
page("/edit/:id", ()=> console.log("editView"));
page("/search", ()=> console.log("searchView"));

updateNav();
page.start();

function decorateContext(ctx, next) {
    ctx.render = function (content) {
        console.log("inside context");
        render(content, main);
    };
    ctx.updateNav = updateNav;
    
    const user = getUserData();
    if(user) {
        ctx.user = user;
    }

    next();
}