export interface ShortBook {
    id: number;
    title: string;
    authors: string[];
    subjects: string[];
    image: string;
}

export interface FullBook {
    id: number;
    title: string;
    authors: string[];
    summaries: string[];
    subjects: string[];
    languages: string[];
    image: string;
    reviews: Review[];
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

//export enum Status {
//    WantToRead,
//    AlreadyRead,
//    InProgress
//}

export const Statuses = {
    0: 'WantToRead',
    1: 'AlreadyRead',
    2: 'InProgress'
} as const;

export type Status = keyof typeof Statuses;