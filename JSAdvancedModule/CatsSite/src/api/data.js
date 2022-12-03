import {del, get, post, put} from './api.js';
//TO DO

const endpoints = {
    'pets': '/data/pets',
    'dashboard': '/data/pets?sortBy=_createdOn%20desc&distinct=name',
}

export async function createPet(data) {
    return post(endpoints.pets, data);
}

export async function getAllPets() {
    return get(endpoints.dashboard)
}

export async function getPetById(id) {
    return get(endpoints.pets + '/' + id)
}

export async function deleteById(id) {
    return del(endpoints.pets + '/' + id)
}

export async function editById(id, data) {
    return put(endpoints.pets + "/" + id, data);
}