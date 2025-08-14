import axios from 'axios';
import type { SearchResult, Book, Review } from './ApiModels';

const API_BASE_URL = 'http://localhost:7092/api/books/';
const GUTENDEX_API_BASE_URL = 'https://gutendex.com/books/';

export async function fetchBooks(url: string = GUTENDEX_API_BASE_URL): Promise<SearchResult[]> {
    const response = await axios.get<SearchResult[]>(url);
    return response.data;
}

export async function fetchBookById(id: number): Promise<Book> {
    const response = await axios.get<Book>(`${GUTENDEX_API_BASE_URL}${id}`);
    return response.data;
}

export async function fetchBooksByIds(ids: number[]): Promise<SearchResult[]> {
    const response = await axios.get<SearchResult[]>(`${GUTENDEX_API_BASE_URL}?ids=${ids.join(',')}`);
    return response.data;
}

export async function searchBooks(key: string, value: string): Promise<SearchResult[]> {
    const response = await axios.get<SearchResult[]>(`${GUTENDEX_API_BASE_URL}?${key}=${value}`);
    return response.data;
}

export async function searchBooksByQueryString(query: string): Promise<SearchResult[]> {
    const response = await axios.get<SearchResult[]>(`${GUTENDEX_API_BASE_URL}?${query}`);
    return response.data;
}

export async function getTextByBookId(id: number): Promise<string> {
    const response = await axios.get<string>(`${API_BASE_URL}${id}/text`);
    return response.data;
}

export async function fetchReviewsByBookId(bookId: number): Promise<Review[]> {
    const response = await axios.get<Review[]>(`${API_BASE_URL}${bookId}/reviews`);
    return response.data;
}

//export async function searchBooksByPattern(query: string): Promise<SearchResult[]> {
//    const response = await axios.get<SearchResult[]>(`${GUTENDEX_API_BASE_URL}?search=${query}`);
//    return response.data;
//}

//export async function searchBooksByAuthor(author: string): Promise<SearchResult[]> {
//    const response = await axios.get<SearchResult[]>(`${GUTENDEX_API_BASE_URL}?author=${author}`);
//    return response.data;
//}

//export async function searchBooksByTopic(topic: string): Promise<SearchResult[]> {
//    const response = await axios.get<SearchResult[]>(`${GUTENDEX_API_BASE_URL}?topic=${topic}`);
//    return response.data;
//}

//export async function searchBooksByLanguages(languages: string): Promise<SearchResult[]> {
//    const response = await axios.get<SearchResult[]>(`${GUTENDEX_API_BASE_URL}?languages=${languages}`);
//    return response.data;
//}

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