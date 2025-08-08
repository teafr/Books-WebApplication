import axios from 'axios';
import type { User } from './ApiModels';

const API_BASE_URL = '/api/users';

//export async function getUsers(): Promise<User[]> {
//  const response = await axios.get<User[]>(API_BASE_URL);
//  return response.data;
//}

export async function getUserById(id: number): Promise<User> {
  const response = await axios.get<User>(`${API_BASE_URL}/${id}`);
  return response.data;
}

export async function createUser(user: Omit<User, 'id'>): Promise<User> {
  const response = await axios.post<User>(API_BASE_URL, user);
  return response.data;
}

export async function updateUser(id: number, user: Partial<Omit<User, 'id'>>): Promise<User> {
  const response = await axios.put<User>(`${API_BASE_URL}/${id}`, user);
  return response.data;
}

export async function deleteUser(id: number): Promise<void> {
  await axios.delete(`${API_BASE_URL}/${id}`);
}