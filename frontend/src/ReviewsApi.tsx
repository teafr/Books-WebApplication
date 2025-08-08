import axios from 'axios';
import type { Review } from './ApiModels';

const API_BASE_URL = 'http://localhost:7092/api/reviews/';

export async function fetchReviewById(reviewId: number): Promise<Review> {
    const response = await axios.get<Review>(`${API_BASE_URL}${reviewId}`);
    return response.data;
}

export async function addReview(review: Review): Promise<Review> {
  const response = await axios.post<Review>(API_BASE_URL, review);
  return response.data;
}

export async function deleteReview(reviewId: number): Promise<void> {
  await axios.delete(`${API_BASE_URL}/${reviewId}`);
}

export async function updateReview(reviewId: number, data: Partial<Omit<Review, 'id' | 'createdAt'>>): Promise<Review> {
  const response = await axios.put<Review>(`${API_BASE_URL}${reviewId}`, data);
  return response.data;
}