import { editById, getPetById } from "../api/data.js";
import { html } from "../lib.js";
import { createSubmitHandler } from "../util.js";

const editTemp = (handler, pet) => html`
<section id="editPage">
    <form @submit=${handler} class="editForm">
        <img src="./images/editpage-dog.jpg">
        <div>
            <h2>Edit PetPal</h2>
            <div class="name">
                <label for="name">Name:</label>
                <input name="name" id="name" type="text" value="${pet.name}">
            </div>
            <div class="breed">
                <label for="breed">Breed:</label>
                <input name="breed" id="breed" type="text" value="${pet.breed}">
            </div>
            <div class="Age">
                <label for="age">Age:</label>
                <input name="age" id="age" type="text" value="${pet.age}">
            </div>
            <div class="weight">
                <label for="weight">Weight:</label>
                <input name="weight" id="weight" type="text" value="${pet.weight}">
            </div>
            <div class="image">
                <label for="image">Image:</label>
                <input name="image" id="image" type="text" value="${pet.image}">
            </div>
            <button class="btn" type="submit">Edit Pet</button>
        </div>
    </form>
</section>
`;

export async function showEditPet(ctx){
    const id = ctx.params.id;
    const pet = await getPetById(id);
    ctx.render(editTemp(createSubmitHandler(onEditPet), pet));

    async function onEditPet(data) {
        const {
            name,
            breed,
            age,
            weight,
            image
          } = data;
          
        console.log("EDITING");

        if(!name || !breed || !age || !weight || !image){
            return alert("fields empty");
        }
        
        await editById(id, data);
        ctx.page.redirect("/details/" + id);
    }
}