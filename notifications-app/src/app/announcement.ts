import { Category } from "./category";

export interface Announcement {
    id?: string;
    title: string;
    author: string;
    message: string;
    description: string;
    categoryId: string;
    category: string;
    imageUrl: string;
}
