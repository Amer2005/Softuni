import { getPetById, deleteById } from "../api/data.js";
import { html } from "../lib.js";

const detailsTemp = (pet, user, onDelete) => html`
<section id="detailsPage">
    <div class="details">
        <div class="animalPic">
            <img src="${pet.image}">
        </div>
        <div>
            <div class="animalInfo">
                <h1>Name: ${pet.name}</h1>
                <h3>Breed: ${pet.breed}</h3>
                <h4>Age: ${pet.age}</h4>
                <h4>Weight: ${pet.weight}</h4>
                <h4 class="donation">Donation: 0$</h4>
            </div>
            <!-- if there is no registered user, do not display div-->
            ${!!user ? pet._ownerId === user._id ? 
                html`
                    <div class="actionBtn">
                    <!-- Only for registered user and creator of the pets-->
                    <a href="/edit/${pet._id}" class="edit">Edit</a>
                    <a @click=${onDelete} href="javascript:void(0)" class="remove">Delete</a>
                    <!--(Bonus Part) Only for no creator and user-->
                </div>
                ` 
                : 
                html`
                    <div class="actionBtn">
                    <a href="#" class="donate">Donate</a>
                    </div>
                `:
                html`
                `
                }
        </div>
    </div>
</section>
`;

export async function showDetails(ctx){
    const id = ctx.params.id;
    const pet = await getPetById(id);

    if(ctx.user){
       // const isOwner = pet._ownerId === ctx.user._id;
        ctx.render(detailsTemp(pet, ctx.user, onDelete));
    }
    else {
        ctx.render(detailsTemp(pet));
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