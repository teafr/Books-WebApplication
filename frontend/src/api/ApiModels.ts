export interface User {
    id: number;
    name: string;
    email: string;
    username: string;
    statusCounts: Record<string, number>;
}

export interface SearchResult {
    count: number;
    results: Book[];
    next: string | null;
    previous: string | null;
}

export interface Book {
    id: number;
    title: string;
    authors: Author[];
    summaries: string[];
    subjects: string[];
    languages: string[];
    reviews: Review[];
    formats: Formats;
}

export interface Author {
    name: string;
}

export interface Formats {
    "text/plain; charset=us-ascii": string | null;
    "image/jpeg": string | null;
}

export interface Review {
    id: number;
    text: string;
    rating: number;
    reviewDate: string;
    reviewerId: number;
}

export interface SavedBook {
    bookId: number;
    status: Status;
}

export const Statuses = {
    0: 'WantToRead',
    1: 'AlreadyRead',
    2: 'InProgress'
} as const;

export type Status = keyof typeof Statuses;