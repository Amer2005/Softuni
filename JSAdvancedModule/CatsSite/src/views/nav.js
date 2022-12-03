import { logout } from "../api/user.js";
import { html, render, page } from "../lib.js";
import { getUserData } from "../util.js";

const nav = document.querySelector('nav'); // TO DO

const navTemplate = (hasUser) => html`
<section class="logo">
    <img src="./images/logo.png" alt="logo">
</section>
<ul>
    <!--Users and Guest-->
    <li><a href="/">Home</a></li>
    <li><a href="/dashboard">Dashboard</a></li>
    <!--Only Guest-->
    ${!hasUser ? 
        html`
        <li><a href="/login">Login</a></li>
        <li><a href="/register">Register</a></li>
        ` : 
        html`
        <li><a href="/create">Create Postcard</a></li>
        <li><a @click=${onLogout} href="javascript:void(0)">Logout</a></li>
        `
        }
</ul>
`;

export function updateNav() {
    const user = getUserData();

    render(navTemplate(!!user), nav);
}

function onLogout() {
    logout();
    updateNav();
    page.redirect('/');
}