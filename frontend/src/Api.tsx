import axios from 'axios';
import type { ShortBook, FullBook } from './ApiModels';

const API_BASE_URL = 'http://localhost:7092/api/books/';

export async function fetchBooks(): Promise<ShortBook[]> {
    const response = await axios.get<ShortBook[]>(API_BASE_URL);
    return response.data;
}

export async function fetchBookById(id: number): Promise<FullBook> {
    const response = await axios.get<FullBook>(`${API_BASE_URL}${id}`);
    return response.data;
}

//export async function createBook(book: Omit<ShortBook, 'id'>): Promise<ShortBook> {
//    const response = await axios.post<ShortBook>(API_BASE_URL, book);
//    return response.data;
//}

//export async function updateBook(id: number, book: Partial<ShortBook>): Promise<ShortBook> {
//    const response = await axios.put<ShortBook>(`${API_BASE_URL}${id}`, book);
//    return response.data;
//}

//export async function deleteBook(id: number): Promise<void> {
//    await axios.delete(`${API_BASE_URL}${id}`);
//}