import { getAlbumById, deleteById, getLikes, likesByUser, likeAlbum } from "../api/data.js";
import { html } from "../lib.js";

const detailsTemp = (album, user, onDelete, onLike) => html`
<section id="details">
<div id="details-wrapper">
    <p id="details-title">Album Details</p>
    <div id="img-wrapper">
    <img src="./images/BackinBlack.jpeg" alt="example1" />
    </div>
    <div id="info-wrapper">
    <p><strong>Band:</strong><span id="details-singer">${album.singer}</span></p>
    <p>
        <strong>Album name:</strong><span id="details-album">${album.album}</span>
    </p>
    <p><strong>Release date:</strong><span id="details-release">${album.release}</span></p>
    <p><strong>Label:</strong><span id="details-label">${album.label}</span></p>
    <p><strong>Sales:</strong><span id="details-sales">${album.sales}</span></p>
    </div>
    <div id="likes">Likes: <span id="likes-count">${album.likes}</span></div>

    <!--Edit and Delete are only for creator-->
    ${user ? album._ownerId == user._id ? html`
    <div id="action-buttons">
    <a href="/edit/${album._id}" id="edit-btn">Edit</a>
    <a @click=${onDelete} href="javascript:void(0)" id="delete-btn">Delete</a>
    </div>
    ` : 
    html`
        ${!album.liked ? html`
            <div id="action-buttons">
            <a @click=${onLike} href="javascript:void(0)" id="like-btn">Like</a>
            </div>
        `: html``}
    ` : 
    html``}
</div>
</section>
`;

export async function showDetails(ctx){
    const id = ctx.params.id;
    const album = await getAlbumById(id);
    if(ctx.user){
       // const isOwner = pet._ownerId === ctx.user._id;
        album.likes = await getLikes(id);
        album.liked = (await likesByUser(id, ctx.user._id)) != 0;

        ctx.render(detailsTemp(album, ctx.user, onDelete, onLike));
    }
    else {
        ctx.render(detailsTemp(album));
    }

    async function onLike() {
        likeAlbum(id);

        album.likes = await getLikes(id);
        album.liked = (await likesByUser(id, ctx.user._id)) != 0;

        ctx.render(detailsTemp(album, ctx.user, onDelete, onLike));
    }

    async function onDelete() {
        const conf = confirm("Are you sure?");

        if(!conf){
            return;
        }

        await deleteById(id)
        ctx.page.redirect('/dashboard');
    }
}