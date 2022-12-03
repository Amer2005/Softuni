//Import views

import { render, page } from './lib.js';
import { getUserData } from './util.js';
import { showCreateAlbum } from './views/createView.js';
import { showDashboard } from './views/dashboardView.js';
import { showDetails } from './views/detailsView.js';
import { showEdit } from './views/editView.js';
import { showHome } from './views/homeView.js';
import { showLogin } from './views/loginView.js';
import { updateNav } from './views/nav.js'
import { showRegister } from './views/registerView.js';

//get main element for rendering
const main = document.getElementsByTagName('main')[0];

page(decorateContext);

updateNav();

page('/', showHome)
page('/home', showHome)
page('/login', showLogin)
page('/register', showRegister)
page('/dashboard', showDashboard)
page('/create', showCreateAlbum)
page('/details/:id', showDetails)
page('/edit/:id', showEdit)

page.start();

function decorateContext(ctx, next) {
    ctx.render = renderMain;
    ctx.updateNav = updateNav;
    
    const user = getUserData();
    if(user) {
        ctx.user = user;
    }

    next();
}

function renderMain(content) {
    render(content, main);
}