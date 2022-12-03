import {del, get, post, put} from './api.js';
//TO DO

const endpoints = {
    'dashboard': '/data/albums?sortBy=_createdOn%20desc',
    'albums': '/data/albums',
    'likes': '/data/likes'
}

export async function createAlbum(data) {
    return post(endpoints.albums, data)
}

export async function getAllAlbums() {
    return get(endpoints.dashboard)
}

export async function getAlbumById(id) {
    return get(endpoints.albums + "/" + id)
}

export async function editAlbumById(id, data) {
    return put(endpoints.albums + "/" + id, data)
}

export async function deleteById(id) {
    return del(endpoints.albums + "/" + id)
}

export async function likeAlbum(albumId){
    return post(endpoints.likes, {albumId})
}

export async function getLikes(albumId){
    return get(endpoints.likes + `?where=albumId%3D%22${albumId}%22&distinct=_ownerId&count`)
}

export async function likesByUser(albumId, userId){
    return get(endpoints.likes + `?where=albumId%3D%22${albumId}%22%20and%20_ownerId%3D%22${userId}%22&count`)
}