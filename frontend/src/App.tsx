import { useState, useEffect } from 'react';
import { fetchBooks } from './api/BooksApi';
import './App.css';
import type { SearchResult } from './api/ApiModels';
import BookList from './Components/BookList/BookList';

function App() {
    const [searchResult, setSearchResult] = useState<SearchResult | null>(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        async function loadBook() {
            const result = await fetchBooks();
            setSearchResult(result);
            setLoading(false);
        }
        loadBook();
    }, []);

    if (loading) {
        return <div>Loading...</div>;
    }

    return (
        <>
            {searchResult && (
                <BookList books={searchResult.results} />
            )}
        </>
    );
}

export default App;