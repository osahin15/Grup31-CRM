import { Product } from '../product/product';


export class Order {
    id: number;
    userId: number;
    customerName: string;
    description: string;
    product: string;
    adet: number;
    date: Date | null;
}