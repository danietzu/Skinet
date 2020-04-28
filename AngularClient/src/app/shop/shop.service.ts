import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IPagination } from '../shared/models/pagination';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'https://localhost:4000/api/';

  constructor(private http: HttpClient) {}

  getProducts() {
    return this.http.get<IPagination>(this.baseUrl + 'products');
  }
}
